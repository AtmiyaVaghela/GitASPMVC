using INDMS.WebUI.Infrastructure;
using INDMS.WebUI.Infrastructure.Filters;
using INDMS.WebUI.Models;
using INDMS.WebUI.ViewModels;
using System;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INDMS.WebUI.Controllers
{
    public class LibraryController : Controller
    {
        private INDMSEntities db = new INDMSEntities();

        // GET: Library

        #region PolicyLetter

        [AuthUser]
        public ActionResult PolicyLetter()
        {
            PolicyLetterViewModel pl = new PolicyLetterViewModel
            {
                PolicyLetters = db.PolicyLetters.OrderByDescending(x => x.id)
            };

            PopulateIssuingAuthorityDropDownList();
            return View(pl);
        }

        [HttpPost]
        [AuthUser]
        public ActionResult PolicyLetter(PolicyLetterViewModel pl, HttpPostedFileBase inputFile)
        {
            if (!string.IsNullOrEmpty(pl.PLetter.Year))
            {
                if (pl.PLetter.IssuingAuthority.Equals("OTHERS"))
                {
                    pl.PLetter.IssuingAuthority = pl.OIssuingAutherity;
                    string strKeyName = "IssuingAuthority";
                    string strKeyValue = pl.OIssuingAutherity.ToUpper();
                    AddParam(strKeyName, strKeyValue);
                }
                if (inputFile != null && inputFile.ContentLength > 0)
                {
                    if (inputFile.ContentType == "application/pdf")
                    {
                        if (!string.IsNullOrEmpty(pl.PLetter.PLNo))
                        {
                            if (!string.IsNullOrEmpty(pl.PLetter.Subject))
                            {
                                try
                                {
                                    Guid FileName = Guid.NewGuid();
                                    pl.PLetter.FilePath = "/Uploads/PolicyLetter/" + FileName + ".pdf";
                                    string tPath = Path.Combine(Server.MapPath("~/Uploads/PolicyLetter/"), FileName + ".pdf");
                                    inputFile.SaveAs(tPath);

                                    db.PolicyLetters.Add(pl.PLetter);
                                    db.SaveChanges();

                                    TempData["RowId"] = pl.PLetter.id;
                                    TempData["MSG"] = "Save Successfully";

                                    return RedirectToAction("PolicyLetter");
                                }
                                catch (Exception ex)
                                {
                                    TempData["Error"] = ex.Message;
                                }
                            }
                            else
                            {
                                TempData["Error"] = "Please Enter Subject";
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Please Enter Policy Letter No.";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Only PDF Files.";
                    }
                }
                else
                {
                    TempData["Error"] = "Please Select file";
                }
            }
            else
            {
                TempData["Error"] = "Please Enter Valid Year";
            }

            PolicyLetterViewModel plv = new PolicyLetterViewModel
            {
                OIssuingAutherity = pl.OIssuingAutherity,
                PLetter = pl.PLetter,
                PolicyLetters = db.PolicyLetters.OrderByDescending(x => x.id)
            };
            PopulateIssuingAuthorityDropDownList();
            return View(plv);
        }

        private static void AddParam(string strKeyName, string strKeyValue)
        {
            AddNewParameter obj = new AddNewParameter();
            string keyName = strKeyName;
            string keyValue = strKeyValue;
            obj.Add(keyName, keyValue);
        }

        #endregion PolicyLetter

        #region Standards

        public ActionResult Standards()
        {
            StandardViewModel pl = new StandardViewModel
            {
                Standards = db.Standards.OrderByDescending(x => x.Id)
            };

            PopulateSubjectTypeDropDownList();
            return View(pl);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Standards(StandardViewModel svm, HttpPostedFileBase inputFile)
        {
            if (!string.IsNullOrEmpty(svm.Standard.StandardNo))
            {
                if (!string.IsNullOrEmpty(svm.Standard.Year))
                {
                    if (!string.IsNullOrEmpty(svm.Standard.Revision))
                    {
                        if (!string.IsNullOrEmpty(svm.Standard.SubjectParam) && !string.IsNullOrEmpty(svm.Standard.Subject))
                        {
                            try
                            {
                                if (svm.Standard.Subject.Equals("OTHERS"))
                                {
                                    svm.Standard.Subject = svm.OSubject.Trim().ToUpper();
                                    string subjectParam = svm.Standard.SubjectParam;
                                    string strSubject = svm.OSubject.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strSubject))
                                    {
                                        string keyName = subjectParam.Equals("EQUIPMENT") ? "StdEquipment" : (subjectParam.Equals("SPARES FOR") ? "StdSpareFor" : string.Empty);
                                        if (keyName != string.Empty)
                                        {
                                            string keyValue = strSubject;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else
                                    {
                                        TempData["Error"] = "Please Enter Subject.";
                                    }
                                }
                            }
                            catch (Exception)
                            {
                                TempData["Error"] = "Subject is not added to the Parameter Master.";
                            }
                            if (!string.IsNullOrEmpty(svm.Standard.Type))
                            {
                                if (svm.Standard.Type.Equals("OTHERS"))
                                {
                                    svm.Standard.Type = svm.OType.Trim().ToUpper();
                                    string strType = svm.OType.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strType))
                                    {
                                        string keyName = "StdType";
                                        if (keyName != string.Empty)
                                        {
                                            string keyValue = svm.Standard.Type;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else
                                    {
                                        TempData["Error"] = "Please Enter Type.";
                                    }
                                }
                                if (inputFile != null && inputFile.ContentLength > 0)
                                {
                                    if (inputFile.ContentType == "application/pdf")
                                    {
                                        Guid FileName = Guid.NewGuid();
                                        svm.Standard.FilePath = "/Uploads/Standards/" + FileName + ".pdf";
                                        string tPath = Path.Combine(Server.MapPath("~/Uploads/Standards/"), FileName + ".pdf");
                                        inputFile.SaveAs(tPath);

                                        db.Standards.Add(svm.Standard);
                                        db.SaveChanges();

                                        TempData["RowId"] = svm.Standard.Id;
                                        TempData["MSG"] = "Save Successfully";

                                        return RedirectToAction("Standards");
                                    }
                                    else
                                    {
                                        TempData["Error"] = "Please Select PDF file only";
                                    }
                                }
                                else
                                {
                                    TempData["Error"] = "Please Select file";
                                }
                            }
                            else
                            {
                                TempData["Error"] = "Please Select Type.";
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Please Select Subject.";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Please Enter Revision.";
                    }
                }
                else
                {
                    TempData["Error"] = "Please Enter Year";
                }
            }
            else
            {
                TempData["Error"] = "Please Enter Standard No.";
            }
            StandardViewModel vm = new StandardViewModel
            {
                OType = svm.OType,
                OSubject = svm.OSubject,
                Standard = svm.Standard,
                Standards = db.Standards.OrderByDescending(x => x.Id)
            };
            PopulateSubjectTypeDropDownList();
            return View(vm);
        }

        private void PopulateSubjectTypeDropDownList()
        {
            var varSubjectType = from d in db.ParameterMasters
                                 where d.KeyName == "StdSubject"
                                 orderby d.KeyValue
                                 select d.KeyValue;

            ViewBag.SubjectType = varSubjectType;
            ViewBag.Subject = null;
        }

        #endregion Standards

        #region StandingOrders

        public ActionResult StandingOrder()
        {
            StandingOrderViewModel so = new StandingOrderViewModel();
            so.StandingOrders = db.StandingOrders.OrderByDescending(x => x.id);
            return View(so);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult StandingOrder(StandingOrderViewModel so, HttpPostedFileBase inputFile)
        {
            if (!string.IsNullOrEmpty(so.StandingOrder.IssuingAuthority))
            {
                if (!string.IsNullOrEmpty(so.StandingOrder.Subject))
                {
                    if (!string.IsNullOrEmpty(so.StandingOrder.Year))
                    {
                        if (!string.IsNullOrEmpty(so.StandingOrder.Revision))
                        {
                            if (inputFile != null && inputFile.ContentLength > 0)
                            {
                                if (inputFile.ContentType == "application/pdf")
                                {
                                    if (so.StandingOrder.IssuingAuthority.Equals("OTHERS"))
                                    {
                                        string strType = so.OIssuingAutherity.Trim().ToUpper();
                                        if (!string.IsNullOrEmpty(strType))
                                        {
                                            string keyName = "IssuingAuthority";
                                            if (keyName != string.Empty)
                                            {
                                                so.StandingOrder.IssuingAuthority = so.OIssuingAutherity.Trim().ToUpper();
                                                string keyValue = so.StandingOrder.IssuingAuthority;
                                                AddParam(keyName, keyValue);
                                            }
                                        }
                                        else
                                        {
                                            TempData["Error"] = "Please Enter Issuing Authority.";
                                        }
                                    }

                                    if (so.StandingOrder.Subject.Equals("OTHERS"))
                                    {
                                        string strSubject = so.OSubject.Trim().ToUpper();
                                        if (!string.IsNullOrEmpty(strSubject))
                                        {
                                            string keyName = "SoSubject";
                                            if (keyName != string.Empty)
                                            {
                                                so.StandingOrder.Subject = so.OSubject.Trim().ToUpper();
                                                string keyValue = so.StandingOrder.Subject;
                                                AddParam(keyName, keyValue);
                                            }
                                        }
                                        else
                                        {
                                            TempData["Error"] = "Please Enter Subject.";
                                        }
                                    }

                                    Guid FileName = Guid.NewGuid();
                                    so.StandingOrder.FilePath = "/Uploads/StandingOrders/" + FileName + ".pdf";
                                    string tPath = Path.Combine(Server.MapPath("~/Uploads/StandingOrders/"), FileName + ".pdf");
                                    inputFile.SaveAs(tPath);

                                    db.StandingOrders.Add(so.StandingOrder);
                                    db.SaveChanges();

                                    TempData["RowId"] = so.StandingOrder.id;
                                    TempData["MSG"] = "Save Successfully";

                                    return RedirectToAction("StandingOrder");
                                }
                                else
                                {
                                    TempData["Error"] = "Please Select PDF file only";
                                }
                            }
                            else
                            {
                                TempData["Error"] = "Please Select file";
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Please Enter Revision.";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Please Enter Year.";
                    }
                }
                else
                {
                    TempData["Error"] = "Please Select Subject";
                }
            }
            else
            {
                TempData["Error"] = "Please select Issuing Authority.";
            }

            so.StandingOrders = db.StandingOrders.OrderByDescending(x => x.id);

            return View(so);
        }

        #endregion StandingOrders

        #region Guidelines

        public ActionResult GuideLines()
        {
            GuideLineViewModel gvm = new GuideLineViewModel();
            gvm.GuideLines = db.GuideLines.OrderByDescending(x => x.ID);
            return View(gvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GuideLines(GuideLineViewModel gvm, HttpPostedFileBase inputFile)
        {
            if (!string.IsNullOrEmpty(gvm.GuideLine.IssuingAuthority))
            {
                if (!string.IsNullOrEmpty(gvm.GuideLine.Subject))
                {
                    if (!string.IsNullOrEmpty(gvm.GuideLine.Year))
                    {
                        if (inputFile != null && inputFile.ContentLength > 0)
                        {
                            if (inputFile.ContentType == "application/pdf")
                            {
                                if (gvm.GuideLine.IssuingAuthority.Equals("OTHERS"))
                                {
                                    string strIssuingAuthority = gvm.OIssuingAutherity.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strIssuingAuthority))
                                    {
                                        string keyName = "IssuingAuthority";
                                        if (keyName != string.Empty)
                                        {
                                            gvm.GuideLine.IssuingAuthority = gvm.OIssuingAutherity.Trim().ToUpper();
                                            string keyValue = gvm.GuideLine.IssuingAuthority;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else
                                    {
                                        TempData["Error"] = "Please Enter Issuing Authority.";
                                    }
                                }

                                Guid FileName = Guid.NewGuid();
                                gvm.GuideLine.FilePath = "/Uploads/GuideLines/" + FileName + ".pdf";
                                string tPath = Path.Combine(Server.MapPath("~/Uploads/GuideLines/"), FileName + ".pdf");
                                inputFile.SaveAs(tPath);

                                db.GuideLines.Add(gvm.GuideLine);
                                db.SaveChanges();

                                TempData["RowId"] = gvm.GuideLine.ID;
                                TempData["MSG"] = "Save Successfully";

                                return RedirectToAction("GuideLines");
                            }
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Please Enter Year";
                    }
                }
                else
                {
                    TempData["Error"] = "Please Enter Subject.";
                }
            }
            else
            {
                TempData["Error"] = "Please select IssuingAuthority.";
            }
            gvm.GuideLines = db.GuideLines.OrderByDescending(x => x.ID);
            return View(gvm);
        }

        #endregion Guidelines

        #region GeneralBooks
        public ActionResult GeneralBooks() 
        { 
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public ActionResult GeneralBooks()
        {
            return View();
        }

        #endregion
        private void PopulateIssuingAuthorityDropDownList()
        {
            var issuingAuthorityQuery = from d in db.ParameterMasters
                                        where d.KeyName == "IssuingAuthority"
                                        orderby d.KeyValue
                                        select d.KeyValue;

            ViewBag.IssuingAuthority = issuingAuthorityQuery;
            //ViewBag.IssuingAuthority = new SelectList(issuingAuthorityQuery, "KeyValue", "KeyValue", string.Empty);
        }

        [HttpPost]
        public ActionResult GetJsonObjOfParam(string data)
        {
            var KeyValueList = from d in db.ParameterMasters
                               where d.KeyName == data
                               orderby d.KeyName
                               select d.KeyValue;

            return Json(KeyValueList, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
};
using INDMS.WebUI.Infrastructure;
using INDMS.WebUI.Infrastructure.Filters;
using INDMS.WebUI.Models;
using INDMS.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INDMS.WebUI.Controllers
{
    [AuthUser]
    public class LibraryController : Controller
    {
        private INDMSEntities db = new INDMSEntities();

        // GET: Library

        #region PolicyLetter

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
        public ActionResult PolicyLetter(PolicyLetterViewModel pl, HttpPostedFileBase inputFile)
        {
            if (!string.IsNullOrEmpty(pl.PLetter.Year))
            {
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
                                    if (pl.PLetter.IssuingAuthority.Equals("OTHERS"))
                                    {
                                        pl.PLetter.IssuingAuthority = pl.OIssuingAutherity;
                                        string strKeyName = "IssuingAuthority";
                                        string strKeyValue = pl.OIssuingAutherity.ToUpper();
                                        AddParam(strKeyName, strKeyValue);
                                    }

                                    Guid FileName = Guid.NewGuid();
                                    pl.PLetter.FilePath = "/Uploads/PolicyLetter/" + FileName + ".pdf";
                                    string tPath = Path.Combine(Server.MapPath("~/Uploads/PolicyLetter/"), FileName + ".pdf");
                                    inputFile.SaveAs(tPath);

                                    pl.PLetter.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                    pl.PLetter.CreatedDate = null;
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

                                        svm.Standard.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                        svm.Standard.CreatedDate = null;

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

                                    so.StandingOrder.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                    so.StandingOrder.CreatedDate = null;

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

                                gvm.GuideLine.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                gvm.GuideLine.CreatedDate = null;

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
            GeneralBookViewModel gbvm = new GeneralBookViewModel();
            gbvm.GeneralBooks = db.GeneralBooks.OrderByDescending(x => x.ID);
            return View(gbvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GeneralBooks(GeneralBookViewModel gbvm, HttpPostedFileBase inputFile)
        {
            if (!string.IsNullOrEmpty(gbvm.GeneralBook.Title))
            {
                if (!string.IsNullOrEmpty(gbvm.GeneralBook.Subject))
                {
                    if (!string.IsNullOrEmpty(gbvm.GeneralBook.Year))
                    {
                        if (inputFile != null && inputFile.ContentLength > 0)
                        {
                            if (inputFile.ContentType == "application/pdf")
                            {
                                Guid FileName = Guid.NewGuid();
                                gbvm.GeneralBook.FilePath = "/Uploads/GeneralBooks/" + FileName + ".pdf";
                                string tPath = Path.Combine(Server.MapPath("~/Uploads/GeneralBooks/"), FileName + ".pdf");
                                inputFile.SaveAs(tPath);

                                gbvm.GeneralBook.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                gbvm.GeneralBook.CreatedDate = null;

                                db.GeneralBooks.Add(gbvm.GeneralBook);
                                db.SaveChanges();

                                TempData["RowId"] = gbvm.GeneralBook.ID;
                                TempData["MSG"] = "Save Successfully";

                                return RedirectToAction("GeneralBooks");
                            }
                            else
                            {
                                TempData["Error"] = "Please Select PDF Files Only.";
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Please Select File";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Please Enter Year";
                    }
                }
                else
                {
                    TempData["Error"] = "Please Enter Title";
                }
            }
            else
            {
                TempData["Error"] = "Please Enter Title";
            }

            gbvm.GeneralBooks = db.GeneralBooks.OrderByDescending(x => x.ID);
            return View();
        }

        #endregion GeneralBooks

        #region Drawing

        public ActionResult Drawings()
        {
            DrawingViewModel m = new DrawingViewModel();
            m.Drawings = db.Drawings.OrderByDescending(x => x.Id);
            foreach (Drawing item in m.Drawings)
            {
                item.ApprovalBy = db.Users.SingleOrDefault(x => x.UserId == new Guid(item.ApprovalBy)).Name;
                //from d in db.Users
                //              where d.UserId.ToString() == item.ApprovalBy
                //              select d.Name;
            }
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Drawings(DrawingViewModel m, HttpPostedFileBase inputFile)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (!string.IsNullOrEmpty(m.Drawing.DrawingNo))
                    {
                        if (!string.IsNullOrEmpty(m.Drawing.Subject))
                        {
                            if (!string.IsNullOrEmpty(m.Drawing.ApprovalBy))
                            {
                                if (inputFile != null && inputFile.ContentLength > 0)
                                {
                                    if (inputFile.ContentType == "application/pdf")
                                    {
                                        Guid FileName = Guid.NewGuid();
                                        m.Drawing.FilePath = "/Uploads/Drawings/" + FileName + ".pdf";
                                        string tPath = Path.Combine(Server.MapPath("~/Uploads/Drawings/"), FileName + ".pdf");
                                        inputFile.SaveAs(tPath);

                                        m.Drawing.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                        m.Drawing.CreatedDate = null;

                                        db.Drawings.Add(m.Drawing);
                                        db.SaveChanges();

                                        TempData["RowId"] = m.Drawing.Id;
                                        TempData["MSG"] = "Save Successfully";

                                        return RedirectToAction("Drawings");
                                    }
                                    else
                                    {
                                        TempData["Error"] = "Please Select PDF Files Only.";
                                    }
                                }
                                else
                                {
                                    TempData["Error"] = "Please Select File";
                                }
                            }
                            else
                            {
                                TempData["Error"] = "Please Select Approval By.";
                            }
                        }
                        else
                        {
                            TempData["Error"] = "Please Enter Subject";
                        }
                    }
                    else
                    {
                        TempData["Error"] = "Please Enter Drawing No.";
                    }
                }
                catch (Exception ex)
                {
                    TempData["Error"] = ex.Message;
                }
            }

            m.Drawings = db.Drawings.OrderByDescending(x => x.Id);
            foreach (Drawing item in m.Drawings)
            {
                item.ApprovalBy = db.Users.SingleOrDefault(x => x.UserId == new Guid(item.ApprovalBy)).Name;
                //from d in db.Users
                //              where d.UserId.ToString() == item.ApprovalBy
                //              select d.Name;
            }
            return View(m);
        }

        #endregion Drawing

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

        [HttpPost]
        public ActionResult GetJsonObjOfUsers()
        {
            IEnumerable<User> Users = from d in db.Users
                                      where d.Active != "N"
                                      select d;
            return Json(Users, JsonRequestBehavior.AllowGet);
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
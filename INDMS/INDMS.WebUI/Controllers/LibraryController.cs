﻿using INDMS.WebUI.Infrastructure;
using INDMS.WebUI.Infrastructure.Filters;
using INDMS.WebUI.Models;
using INDMS.WebUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace INDMS.WebUI.Controllers {
    public class LibraryController : Controller {
        private INDMSEntities db = new INDMSEntities();

        // GET: Library

        #region PolicyLetter

        [AuthUser]
        public ActionResult PolicyLetter() {
            PolicyLetterViewModel pl = new PolicyLetterViewModel {
                PolicyLetters = db.PolicyLetters.OrderByDescending(x => x.id)
            };

            return View(pl);
        }

        [AuthUser]
        public ActionResult PolicyLetterNew() {
            return View();
        }

        [AuthUser]
        public ActionResult PolicyLetterEdit(int? id) {
            PolicyLetterViewModel pl = new PolicyLetterViewModel();

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                pl.PLetter = db.PolicyLetters.Find(id);
                if (pl.PLetter == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {
                    pl.file = pl.PLetter.FilePath;
                }
            }
            return View(pl);
        }

        [HttpPost]
        [AuthUser]
        public ActionResult PolicyLetterEdit(PolicyLetterViewModel pl, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(pl.PLetter.Year)) {
                if (!string.IsNullOrEmpty(pl.PLetter.PLNo)) {
                    if (!string.IsNullOrEmpty(pl.PLetter.Subject)) {
                        try {
                            if (pl.PLetter.IssuingAuthority.Equals("OTHERS")) {
                                pl.PLetter.IssuingAuthority = pl.OIssuingAutherity;
                                string strKeyName = "IssuingAuthority";
                                string strKeyValue = pl.OIssuingAutherity.ToUpper();
                                AddParam(strKeyName, strKeyValue);
                            }

                            if (inputFile != null && inputFile.ContentLength > 0) {
                                if (inputFile.ContentType == "application/pdf") {
                                    Guid FileName = Guid.NewGuid();
                                    pl.PLetter.FilePath = "/Uploads/PolicyLetter/" + FileName + ".pdf";
                                    string tPath = Path.Combine(Server.MapPath("~/Uploads/PolicyLetter/"), FileName + ".pdf");
                                    inputFile.SaveAs(tPath);
                                }
                                else {
                                    TempData["Error"] = "Only PDF Files.";
                                }
                            }
                            else {
                                pl.PLetter.FilePath = pl.file;
                            }

                            pl.PLetter.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                            pl.PLetter.CreatedDate = null;

                            try {
                                db.Entry(pl.PLetter).State = EntityState.Modified;
                                db.SaveChanges();
                                ModelState.Clear();

                                TempData["RowId"] = pl.PLetter.id;
                                TempData["MSG"] = "Save Successfully";

                                return RedirectToAction("PolicyLetter");
                            }
                            catch (RetryLimitExceededException /* dex */) {
                                TempData["Error"] = "Unable to save changes. Try again, and if the problem persists, see your system administrator.";
                            }
                            catch (Exception ex) {
                                TempData["Error"] = ex.Message;
                            }
                        }
                        catch (Exception ex) {
                            TempData["Error"] = ex.Message;
                        }
                    }
                    else {
                        TempData["Error"] = "Please Enter Subject";
                    }
                }
                else {
                    TempData["Error"] = "Please Enter Policy Letter No.";
                }
            }
            else {
                TempData["Error"] = "Please Enter Valid Year";
            }

            PolicyLetterViewModel plv = new PolicyLetterViewModel {
                OIssuingAutherity = pl.OIssuingAutherity,
                PLetter = pl.PLetter,
                PolicyLetters = db.PolicyLetters.OrderByDescending(x => x.id),
                file = pl.file
            };
            return View(plv);
        }

        [HttpPost]
        [AuthUser]
        public ActionResult PolicyLetter(PolicyLetterViewModel pl, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(pl.PLetter.Year)) {
                if (inputFile != null && inputFile.ContentLength > 0) {
                    if (inputFile.ContentType == "application/pdf") {
                        if (!string.IsNullOrEmpty(pl.PLetter.PLNo)) {
                            if (!string.IsNullOrEmpty(pl.PLetter.Subject)) {
                                try {
                                    if (pl.PLetter.IssuingAuthority.Equals("OTHERS")) {
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
                                catch (Exception ex) {
                                    TempData["Error"] = ex.Message;
                                }
                            }
                            else {
                                TempData["Error"] = "Please Enter Subject";
                            }
                        }
                        else {
                            TempData["Error"] = "Please Enter Policy Letter No.";
                        }
                    }
                    else {
                        TempData["Error"] = "Only PDF Files.";
                    }
                }
                else {
                    TempData["Error"] = "Please Select file";
                }
            }
            else {
                TempData["Error"] = "Please Enter Valid Year";
            }

            PolicyLetterViewModel plv = new PolicyLetterViewModel {
                OIssuingAutherity = pl.OIssuingAutherity,
                PLetter = pl.PLetter,
                PolicyLetters = db.PolicyLetters.OrderByDescending(x => x.id)
            };
            return View(plv);
        }

        private static void AddParam(string strKeyName, string strKeyValue) {
            AddNewParameter obj = new AddNewParameter();
            string keyName = strKeyName;
            string keyValue = strKeyValue;
            obj.Add(keyName, keyValue);
        }

        #endregion PolicyLetter

        #region Standards

        [AuthUser]
        public ActionResult Standards() {
            StandardViewModel pl = new StandardViewModel {
                Standards = db.Standards.OrderByDescending(x => x.Id)
            };

            return View(pl);
        }

        [AuthUser]
        public ActionResult StandardNew() {
            return View();
        }

        [AuthUser]
        public ActionResult StandardEdit(int? id) {
            StandardViewModel m = new StandardViewModel();

            if (id == null) {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            else {
                m.Standard = db.Standards.Find(id);
                if (m.Standard == null) {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                else {
                    m.file = m.Standard.FilePath;
                }
            }
            return View(m);
        }

        [HttpPost]
        [AuthUser]
        public ActionResult StandardEdit(StandardViewModel m, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(m.Standard.StandardNo)) {
                if (!string.IsNullOrEmpty(m.Standard.Year)) {
                    if (!string.IsNullOrEmpty(m.Standard.Revision)) {
                        if (!string.IsNullOrEmpty(m.Standard.SubjectParam) && !string.IsNullOrEmpty(m.Standard.Subject)) {
                            try {
                                if (m.Standard.Subject.Equals("OTHERS")) {
                                    m.Standard.Subject = m.OSubject.Trim().ToUpper();
                                    string subjectParam = m.Standard.SubjectParam;
                                    string strSubject = m.OSubject.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strSubject)) {
                                        string keyName = subjectParam.Equals("EQUIPMENT") ? "StdEquipment" : (subjectParam.Equals("SPARES FOR") ? "StdSpareFor" : string.Empty);
                                        if (keyName != string.Empty) {
                                            string keyValue = strSubject;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else {
                                        TempData["Error"] = "Please Enter Subject.";
                                    }
                                }
                            }
                            catch (Exception) {
                                TempData["Error"] = "Subject is not added to the Parameter Master.";
                            }

                            if (!string.IsNullOrEmpty(m.Standard.Type)) {
                                if (m.Standard.Type.Equals("OTHERS")) {
                                    m.Standard.Type = m.OType.Trim().ToUpper();
                                    string strType = m.OType.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strType)) {
                                        string keyName = "StdType";
                                        if (keyName != string.Empty) {
                                            string keyValue = m.Standard.Type;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else {
                                        TempData["Error"] = "Please Enter Type.";
                                    }
                                }

                                if (inputFile != null && inputFile.ContentLength > 0) {
                                    if (inputFile.ContentType == "application/pdf") {
                                        Guid FileName = Guid.NewGuid();
                                        m.Standard.FilePath = "/Uploads/Standards/" + FileName + ".pdf";
                                        string tPath = Path.Combine(Server.MapPath("~/Uploads/Standards/"), FileName + ".pdf");
                                        inputFile.SaveAs(tPath);
                                    }
                                    else {
                                        TempData["Error"] = "Only PDF Files.";
                                    }
                                }
                                else if (!m.file.Equals("")) {
                                    m.Standard.FilePath = m.file;
                                }
                                else {
                                    TempData["Error"] = "Please Select file";
                                }

                                m.Standard.CreatedBy = Request.Cookies["INDMS"]["UserID"];
                                m.Standard.CreatedDate = null;

                                try {
                                    db.Entry(m.Standard).State = EntityState.Modified;
                                    db.SaveChanges();
                                    ModelState.Clear();

                                    TempData["RowId"] = m.Standard.Id;
                                    TempData["MSG"] = "Save Successfully";

                                    return RedirectToAction("Standards");
                                }
                                catch (RetryLimitExceededException /* dex */) {
                                    TempData["Error"] = "Unable to save changes. Try again, and if the problem persists, see your system administrator.";
                                }
                                catch (Exception ex) {
                                    TempData["Error"] = ex.Message;
                                }
                            }
                            else {
                                TempData["Error"] = "Please Select Type.";
                            }
                        }
                        else {
                            TempData["Error"] = "Please Select Subject.";
                        }
                    }
                    else {
                        TempData["Error"] = "Please Enter Revision.";
                    }
                }
                else {
                    TempData["Error"] = "Please Enter Year";
                }
            }
            else {
                TempData["Error"] = "Please Enter Standard No.";
            }

            StandardViewModel mv = new StandardViewModel {
                Standard = m.Standard,
                OSubject = m.OSubject,
                OType = m.OType,
                file = m.file
            };

            return View(mv);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthUser]
        public ActionResult Standards(StandardViewModel svm, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(svm.Standard.StandardNo)) {
                if (!string.IsNullOrEmpty(svm.Standard.Year)) {
                    if (!string.IsNullOrEmpty(svm.Standard.Revision)) {
                        if (!string.IsNullOrEmpty(svm.Standard.SubjectParam) && !string.IsNullOrEmpty(svm.Standard.Subject)) {
                            try {
                                if (svm.Standard.Subject.Equals("OTHERS")) {
                                    svm.Standard.Subject = svm.OSubject.Trim().ToUpper();
                                    string subjectParam = svm.Standard.SubjectParam;
                                    string strSubject = svm.OSubject.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strSubject)) {
                                        string keyName = subjectParam.Equals("EQUIPMENT") ? "StdEquipment" : (subjectParam.Equals("SPARES FOR") ? "StdSpareFor" : string.Empty);
                                        if (keyName != string.Empty) {
                                            string keyValue = strSubject;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else {
                                        TempData["Error"] = "Please Enter Subject.";
                                    }
                                }
                            }
                            catch (Exception) {
                                TempData["Error"] = "Subject is not added to the Parameter Master.";
                            }
                            if (!string.IsNullOrEmpty(svm.Standard.Type)) {
                                if (svm.Standard.Type.Equals("OTHERS")) {
                                    svm.Standard.Type = svm.OType.Trim().ToUpper();
                                    string strType = svm.OType.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strType)) {
                                        string keyName = "StdType";
                                        if (keyName != string.Empty) {
                                            string keyValue = svm.Standard.Type;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else {
                                        TempData["Error"] = "Please Enter Type.";
                                    }
                                }
                                if (inputFile != null && inputFile.ContentLength > 0) {
                                    if (inputFile.ContentType == "application/pdf") {
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
                                    else {
                                        TempData["Error"] = "Please Select PDF file only";
                                    }
                                }
                                else {
                                    TempData["Error"] = "Please Select file";
                                }
                            }
                            else {
                                TempData["Error"] = "Please Select Type.";
                            }
                        }
                        else {
                            TempData["Error"] = "Please Select Subject.";
                        }
                    }
                    else {
                        TempData["Error"] = "Please Enter Revision.";
                    }
                }
                else {
                    TempData["Error"] = "Please Enter Year";
                }
            }
            else {
                TempData["Error"] = "Please Enter Standard No.";
            }
            StandardViewModel vm = new StandardViewModel {
                OType = svm.OType,
                OSubject = svm.OSubject,
                Standard = svm.Standard,
                Standards = db.Standards.OrderByDescending(x => x.Id)
            };
            return View(vm);
        }

        #endregion Standards

        #region StandingOrders

        [AuthUser]
        public ActionResult StandingOrder() {
            StandingOrderViewModel so = new StandingOrderViewModel();
            so.StandingOrders = db.StandingOrders.OrderByDescending(x => x.id);
            return View(so);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthUser]
        public ActionResult StandingOrder(StandingOrderViewModel so, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(so.StandingOrder.IssuingAuthority)) {
                if (!string.IsNullOrEmpty(so.StandingOrder.Subject)) {
                    if (!string.IsNullOrEmpty(so.StandingOrder.Year)) {
                        if (!string.IsNullOrEmpty(so.StandingOrder.Revision)) {
                            if (inputFile != null && inputFile.ContentLength > 0) {
                                if (inputFile.ContentType == "application/pdf") {
                                    if (so.StandingOrder.IssuingAuthority.Equals("OTHERS")) {
                                        string strType = so.OIssuingAutherity.Trim().ToUpper();
                                        if (!string.IsNullOrEmpty(strType)) {
                                            string keyName = "IssuingAuthority";
                                            if (keyName != string.Empty) {
                                                so.StandingOrder.IssuingAuthority = so.OIssuingAutherity.Trim().ToUpper();
                                                string keyValue = so.StandingOrder.IssuingAuthority;
                                                AddParam(keyName, keyValue);
                                            }
                                        }
                                        else {
                                            TempData["Error"] = "Please Enter Issuing Authority.";
                                        }
                                    }

                                    if (so.StandingOrder.Subject.Equals("OTHERS")) {
                                        string strSubject = so.OSubject.Trim().ToUpper();
                                        if (!string.IsNullOrEmpty(strSubject)) {
                                            string keyName = "SoSubject";
                                            if (keyName != string.Empty) {
                                                so.StandingOrder.Subject = so.OSubject.Trim().ToUpper();
                                                string keyValue = so.StandingOrder.Subject;
                                                AddParam(keyName, keyValue);
                                            }
                                        }
                                        else {
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
                                else {
                                    TempData["Error"] = "Please Select PDF file only";
                                }
                            }
                            else {
                                TempData["Error"] = "Please Select file";
                            }
                        }
                        else {
                            TempData["Error"] = "Please Enter Revision.";
                        }
                    }
                    else {
                        TempData["Error"] = "Please Enter Year.";
                    }
                }
                else {
                    TempData["Error"] = "Please Select Subject";
                }
            }
            else {
                TempData["Error"] = "Please select Issuing Authority.";
            }

            so.StandingOrders = db.StandingOrders.OrderByDescending(x => x.id);

            return View(so);
        }

        #endregion StandingOrders

        #region Guidelines

        [AuthUser]
        public ActionResult GuideLines() {
            GuideLineViewModel gvm = new GuideLineViewModel();
            gvm.GuideLines = db.GuideLines.OrderByDescending(x => x.ID);
            return View(gvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthUser]
        public ActionResult GuideLines(GuideLineViewModel gvm, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(gvm.GuideLine.IssuingAuthority)) {
                if (!string.IsNullOrEmpty(gvm.GuideLine.Subject)) {
                    if (!string.IsNullOrEmpty(gvm.GuideLine.Year)) {
                        if (inputFile != null && inputFile.ContentLength > 0) {
                            if (inputFile.ContentType == "application/pdf") {
                                if (gvm.GuideLine.IssuingAuthority.Equals("OTHERS")) {
                                    string strIssuingAuthority = gvm.OIssuingAutherity.Trim().ToUpper();
                                    if (!string.IsNullOrEmpty(strIssuingAuthority)) {
                                        string keyName = "IssuingAuthority";
                                        if (keyName != string.Empty) {
                                            gvm.GuideLine.IssuingAuthority = gvm.OIssuingAutherity.Trim().ToUpper();
                                            string keyValue = gvm.GuideLine.IssuingAuthority;
                                            AddParam(keyName, keyValue);
                                        }
                                    }
                                    else {
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
                    else {
                        TempData["Error"] = "Please Enter Year";
                    }
                }
                else {
                    TempData["Error"] = "Please Enter Subject.";
                }
            }
            else {
                TempData["Error"] = "Please select IssuingAuthority.";
            }
            gvm.GuideLines = db.GuideLines.OrderByDescending(x => x.ID);
            return View(gvm);
        }

        #endregion Guidelines

        #region GeneralBooks

        [AuthUser]
        public ActionResult GeneralBooks() {
            GeneralBookViewModel gbvm = new GeneralBookViewModel();
            gbvm.GeneralBooks = db.GeneralBooks.OrderByDescending(x => x.ID);
            return View(gbvm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthUser]
        public ActionResult GeneralBooks(GeneralBookViewModel gbvm, HttpPostedFileBase inputFile) {
            if (!string.IsNullOrEmpty(gbvm.GeneralBook.Title)) {
                if (!string.IsNullOrEmpty(gbvm.GeneralBook.Subject)) {
                    if (!string.IsNullOrEmpty(gbvm.GeneralBook.Year)) {
                        if (inputFile != null && inputFile.ContentLength > 0) {
                            if (inputFile.ContentType == "application/pdf") {
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
                            else {
                                TempData["Error"] = "Please Select PDF Files Only.";
                            }
                        }
                        else {
                            TempData["Error"] = "Please Select File";
                        }
                    }
                    else {
                        TempData["Error"] = "Please Enter Year";
                    }
                }
                else {
                    TempData["Error"] = "Please Enter Title";
                }
            }
            else {
                TempData["Error"] = "Please Enter Title";
            }

            gbvm.GeneralBooks = db.GeneralBooks.OrderByDescending(x => x.ID);
            return View();
        }

        #endregion GeneralBooks

        #region Drawing

        [AuthUser]
        public ActionResult Drawings() {
            DrawingViewModel m = new DrawingViewModel();
            m.Drawings = db.Drawings.OrderByDescending(x => x.Id);
            foreach (Drawing item in m.Drawings) {
                item.ApprovalBy = db.Users.SingleOrDefault(x => x.UserId == new Guid(item.ApprovalBy)).Name;
                //from d in db.Users
                //              where d.UserId.ToString() == item.ApprovalBy
                //              select d.Name;
            }
            return View(m);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AuthUser]
        public ActionResult Drawings(DrawingViewModel m, HttpPostedFileBase inputFile) {
            if (ModelState.IsValid) {
                try {
                    if (!string.IsNullOrEmpty(m.Drawing.DrawingNo)) {
                        if (!string.IsNullOrEmpty(m.Drawing.Subject)) {
                            if (!string.IsNullOrEmpty(m.Drawing.ApprovalBy)) {
                                if (inputFile != null && inputFile.ContentLength > 0) {
                                    if (inputFile.ContentType == "application/pdf") {
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
                                    else {
                                        TempData["Error"] = "Please Select PDF Files Only.";
                                    }
                                }
                                else {
                                    TempData["Error"] = "Please Select File";
                                }
                            }
                            else {
                                TempData["Error"] = "Please Select Approval By.";
                            }
                        }
                        else {
                            TempData["Error"] = "Please Enter Subject";
                        }
                    }
                    else {
                        TempData["Error"] = "Please Enter Drawing No.";
                    }
                }
                catch (Exception ex) {
                    TempData["Error"] = ex.Message;
                }
            }

            m.Drawings = db.Drawings.OrderByDescending(x => x.Id);
            foreach (Drawing item in m.Drawings) {
                item.ApprovalBy = db.Users.SingleOrDefault(x => x.UserId == new Guid(item.ApprovalBy)).Name;
                //from d in db.Users
                //              where d.UserId.ToString() == item.ApprovalBy
                //              select d.Name;
            }
            return View(m);
        }

        #endregion Drawing

        private void PopulateIssuingAuthorityDropDownList() {
            var issuingAuthorityQuery = from d in db.ParameterMasters
                                        where d.KeyName == "IssuingAuthority"
                                        orderby d.KeyValue
                                        select d.KeyValue;

            ViewBag.IssuingAuthority = issuingAuthorityQuery;
            //ViewBag.IssuingAuthority = new SelectList(issuingAuthorityQuery, "KeyValue", "KeyValue", string.Empty);
        }

        [HttpPost]
        public ActionResult GetJsonObjOfParam(string data) {
            IEnumerable<string> KeyValueList = from d in db.ParameterMasters
                                               where d.KeyName == data
                                               orderby d.KeyName
                                               select d.KeyValue;

            return Json(KeyValueList, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult GetJsonObjOfUsers() {
            IEnumerable<User> Users = from d in db.Users
                                      where d.Active != "N"
                                      select d;
            return Json(Users, JsonRequestBehavior.AllowGet);
        }

        protected override void Dispose(bool disposing) {
            if (disposing) {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
};
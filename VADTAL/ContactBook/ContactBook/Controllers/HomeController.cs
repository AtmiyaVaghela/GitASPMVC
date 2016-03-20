using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ContactBook.Models;
using ContactBook.ViewModel;

namespace ContactBook.Controllers
{
    public class HomeController : Controller
    {
        private ContactBookContext db = new ContactBookContext();

        // GET: Home
        public ActionResult Index()
        {
            return View(db.UserMasters.ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            UserMasterViewModel u = new UserMasterViewModel();
            return View(u);
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(string command, UserMasterViewModel userMasterViewModel)
        {
            if (command.Equals("Add"))
            {
                UserMaster userMaster = userMasterViewModel.UserMaster;
              
                userMasterViewModel.UserMaster = new UserMaster();
                List<UserMaster> listUserMaster = new List<UserMaster>();
                if (userMasterViewModel.UserMasters != null)
                {
                   listUserMaster = userMasterViewModel.UserMasters.ToList();
                }
               
                listUserMaster.Add(userMaster);

                userMasterViewModel.UserMasters = listUserMaster;


            }
            else if (command.Equals("Create"))
            {
                UserMaster userMaster = new UserMaster();
                if (ModelState.IsValid)
                {
                    db.UserMasters.Add(userMaster);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(userMaster);
            }
            return View(userMasterViewModel);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // POST: Home/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,MiddleName,LastName,ContactNo,Address,City,NativeAddress,Email,Reference,BirthOfDate,ExDate,IsActive,Education,Occupation,Designation,CompanyName,WorkAddress,UID")] UserMaster userMaster)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userMaster).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userMaster);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserMaster userMaster = db.UserMasters.Find(id);
            if (userMaster == null)
            {
                return HttpNotFound();
            }
            return View(userMaster);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserMaster userMaster = db.UserMasters.Find(id);
            db.UserMasters.Remove(userMaster);
            db.SaveChanges();
            return RedirectToAction("Index");
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
}

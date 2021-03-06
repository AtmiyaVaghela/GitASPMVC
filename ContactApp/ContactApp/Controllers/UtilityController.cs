﻿using ContactApp.Concrete.Filters;
using ContactApp.Helpers.Encoding;
using ContactApp.Models;
using System;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace ContactApp.Controllers
{
    public class UtilityController : Controller
    {
        private ConttactAppDBContext db = new ConttactAppDBContext();

        // GET: Utility
        [CAuthorize("ADMIN")]
        public ActionResult CreateUser()
        {
            return View();
        }

        [HttpPost]
        [CAuthorize("ADMIN")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateUser(User user)
        {
            if (ModelState.IsValid)
            {
                var u = db.Users
                     .Where(x => x.UserName.Equals(user.UserName))
                     .FirstOrDefault();

                if (u == null)
                {
                    user.Password = Encoding.ASCII.EncodeBase64(user.Password);
                    user.Name = user.Name.ToUpper();
                    user.Role = user.Role.ToUpper();
                    user.CreatedBy = Convert.ToInt32(Encoding.ASCII.DecodeBase64(Request.Cookies["ContactApp"]["UserId"]));
                    user.CreatedDate = DateTime.Now;

                    db.Users.Add(user);
                    db.SaveChanges();
                    TempData["MSG"] = "Save Suceessfully.";
                    return RedirectToAction("CreateUser");
                }
                else
                {
                    TempData["ERROR"] = "User Name already used.";
                    return View();
                }
            }
            else
            {
                return View();
            }
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
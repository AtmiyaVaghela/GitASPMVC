using ContactCards.WebUI.Concrete.Filters;
using ContactCards.WebUI.Helpers.Encoding;
using ContactCards.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace ContactCards.WebUI.Controllers
{
    public class UtilityController : Controller
    {
        //[CAuthorize("ADMIN")]
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
                User u;
                using (var db = new ConttactCardDBContext())
                {
                    u = db.Users
                     .Where(x => x.UserName.Equals(user.UserName))
                     .FirstOrDefault();
                }

                if (u == null)
                {
                    user.Password = Encoding.ASCII.EncodeBase64(user.Password);
                    user.Name = user.Name.ToUpper();
                    user.Role = user.Role.ToUpper();
                    //user.CreatedBy = Convert.ToInt32(Encoding.ASCII.DecodeBase64(Request.Cookies["ContactApp"]["UserId"]));
                    user.CreatedDate = DateTime.Now;
                    using (var db = new ConttactCardDBContext())
                    {
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
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
    }
}
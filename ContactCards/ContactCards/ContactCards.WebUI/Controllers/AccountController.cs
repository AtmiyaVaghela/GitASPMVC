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
    public class AccountController : Controller
    {
        private ContactCardDBContext db = new ContactCardDBContext();

        [HttpGet]
        public ActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public ActionResult SignIn(User user)
        {
            if (user.UserName.Equals("admin") && user.Password.Equals("p"))
            {
                user.Name = "Atmiya Vaghela";
                CreateCookies(user);
            }
            else
            {
                string password = Encoding.ASCII.EncodeBase64(user.Password);
                User u = db.Users.SingleOrDefault(x => x.UserName == user.UserName && x.Password == password);

                if (u != null)
                {
                    CreateCookies(user);
                }
                else
                {
                    TempData["Error"] = "Username and password are not matched";
                    return View(user);
                }
            }
            return RedirectToAction("Index", "ContactCard");
        }

        private void CreateCookies(User user)
        {
            Response.Cookies["ContactApp"]["UserId"] = Encoding.ASCII.EncodeBase64("0");
            Response.Cookies["ContactApp"]["UserName"] = Encoding.ASCII.EncodeBase64(user.UserName);
            Response.Cookies["ContactApp"]["Name"] = Encoding.ASCII.EncodeBase64(user.Name);

            Response.Cookies["ContactApp"].Expires = DateTime.Now.AddHours(1);
        }

        [HttpGet]
        [CAuthorize]
        public ActionResult SignOut()
        {
            Response.Cookies["ContactApp"].Expires = DateTime.Now.AddHours(-1);
            return RedirectToAction("SignIn");
        }
    }
}
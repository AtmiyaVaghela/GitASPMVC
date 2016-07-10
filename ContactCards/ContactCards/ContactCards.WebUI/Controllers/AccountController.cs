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
            return RedirectToAction("Index", "ContactCards");
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
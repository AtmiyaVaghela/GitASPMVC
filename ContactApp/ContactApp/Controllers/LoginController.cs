using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using ContactApp.Helpers.Encoding;
using ContactApp.Concrete.Filters;

namespace ContactApp.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
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
            return RedirectToAction("Index", "Home");
        }

        private void CreateCookies(User user)
        {
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
using ContactCards.WebUI.Concrete.Filters;
using ContactCards.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ContactCards.WebUI.Controllers
{
    public class ContactCardController : Controller
    {
        //[CAuthorize("A", "U")]
        public async Task<ActionResult> Index()
        {
            using (var db = new ConttactAppDBContext())
            {
                return View(await db.ContactCards.ToListAsync());
            }
        }
    }
}
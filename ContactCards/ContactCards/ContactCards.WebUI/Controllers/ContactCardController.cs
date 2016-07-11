using ContactCards.WebUI.Concrete.Filters;
using ContactCards.WebUI.Models;
using ContactCards.WebUI.ViewModel;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContactCards.WebUI.Controllers
{
    public class ContactCardController : Controller
    {
        private ContactCardDBContext db = new ContactCardDBContext();

        [CAuthorize("A", "U")]
        public ActionResult Index(int? id)
        {
            ContactCardViewModel CC = new ContactCardViewModel();
            CC.CC = db.ContactCards.ToList();

            return View(CC);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactCard contactCard = db.ContactCards.Find(id);
            if (contactCard == null)
            {
                return HttpNotFound();
            }
            return View("Details", contactCard);
        }

        // GET: ContactCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactCardViewModel contactCardViewModel)
        {
            ContactCard contactCard = contactCardViewModel.C;
            if (ModelState.IsValid)
            {
                db.ContactCards.Add(contactCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactCard);
        }

        // GET: ContactCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactCard contactCard = db.ContactCards.Find(id);
            if (contactCard == null)
            {
                return HttpNotFound();
            }
            return View(contactCard);
        }

        // POST: ContactCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Address,Town,City,Pincode,Photo,MobileNo,HomeNo,EmailId,BirthDate,NirvanTithi,BloodGroup,Education,InterestedIn,GurukulSanstha,SwaminarayanSampradaay,RWSanints,PoliticalConnections,KnownSaints,ReligiousPlaces,DevoteeCategory,SevaSahyog,RId,Relation,CreatedBy,CreatedDate")] ContactCard contactCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactCard).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Redirect("~/ContactCard/Details/" + contactCard.Id + "");
            }
            return View(contactCard);
        }

        // GET: ContactCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactCard contactCard = db.ContactCards.Find(id);
            if (contactCard == null)
            {
                return HttpNotFound();
            }
            return View(contactCard);
        }

        // POST: ContactCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactCard contactCard = db.ContactCards.Find(id);
            db.ContactCards.Remove(contactCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult GetRelation()
        {
            var Relation = (from d in db.ContactCards
                            orderby d.Relation
                            select d.Relation.ToUpper()).Distinct().ToList();

            return Json(Relation, JsonRequestBehavior.AllowGet);
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
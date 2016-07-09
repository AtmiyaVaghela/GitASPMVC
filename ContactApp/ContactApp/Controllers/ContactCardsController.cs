using ContactApp.Concrete.Filters;
using ContactApp.Models;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ContactApp.Controllers
{
    public class ContactCardsController : Controller
    {
        private ConttactAppDBContext db = new ConttactAppDBContext();

        // GET: ContactCards
        [CAuthorize("A", "U")]
        public async Task<ActionResult> Index()
        {
            return View(await db.ContactCards.ToListAsync());
        }

        // GET: ContactCards/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactCard contactCard = await db.ContactCards.FindAsync(id);
            if (contactCard == null)
            {
                return HttpNotFound();
            }
            return View(contactCard);
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
        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,MiddleName,LastName,Address,Town,City,Pincode,Photo,MobileNo,HomeNo,EmailId,BirthDate,NirvanTithi,BloodGroup,Education,InterestedIn,GurukulSanstha,SwaminarayanSampradaay,RWSanints,PoliticalConnections,KnownSaints,ReligiousPlaces,DevoteeCategory,SevaSahyog,RId,Relation,CreatedBy,CreatedDate")] ContactCard contactCard)
        {
            if (ModelState.IsValid)
            {
                db.ContactCards.Add(contactCard);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(contactCard);
        }

        // GET: ContactCards/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactCard contactCard = await db.ContactCards.FindAsync(id);
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
        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,Address,Town,City,Pincode,Photo,MobileNo,HomeNo,EmailId,BirthDate,NirvanTithi,BloodGroup,Education,InterestedIn,GurukulSanstha,SwaminarayanSampradaay,RWSanints,PoliticalConnections,KnownSaints,ReligiousPlaces,DevoteeCategory,SevaSahyog,RId,Relation,CreatedBy,CreatedDate")] ContactCard contactCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactCard).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(contactCard);
        }

        // GET: ContactCards/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactCard contactCard = await db.ContactCards.FindAsync(id);
            if (contactCard == null)
            {
                return HttpNotFound();
            }
            return View(contactCard);
        }

        // POST: ContactCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            ContactCard contactCard = await db.ContactCards.FindAsync(id);
            db.ContactCards.Remove(contactCard);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<ActionResult> GetRelation()
        {
            var Relation = await (from d in db.ContactCards
                                  orderby d.Relation
                                  select d.Relation).ToListAsync();

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
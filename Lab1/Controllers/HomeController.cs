using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lab1.Infrastucture;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserContext db = new UserContext();

        // GET: Home
        public ActionResult Index()
        {
            var clients = db.Clients.Include(c => c.Disability).Include(c => c.FamilyStatus).Include(c => c.Nationality).Include(c => c.Town);
            return View(clients.OrderBy(c => c.LastName).ToList());
        }

        // GET: Home/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            ViewBag.DisabilityId = new SelectList(db.Disabilities, "DisabilityId", "Name");
            ViewBag.FamilyStatusId = new SelectList(db.FamilyStatuses, "FamilyStatusId", "Name");
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "Name");
            ViewBag.TownId = new SelectList(db.Towns, "TownId", "Name");
            return View();
        }

        // POST: Home/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,LastName,FirstName,MidName,Birthday,PassportNumber,PassportIssuedBy,PassportIssueDate,PassrortIdNumber,BirthPlace,Address,HomePhone,MobilePhone,Mail,WorkPlace,WorkPosition,RegistrationAddress,Pensioner,MounthIncome,FamilyStatusId,NationalityId,DisabilityId,TownId")] Client client)
        {
            if (ModelState.IsValid)
            {
                if (
                    db.Set<Client>()
                        .Any(
                            c =>
                                c.PassportNumber.Equals(client.PassportNumber) ||
                                c.PassrortIdNumber.Equals(client.PassrortIdNumber)))
                {
                    ModelState.AddModelError("", "Such client exists!");
                }
                else
                {
                    db.Clients.Add(client);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                
            }

            ViewBag.DisabilityId = new SelectList(db.Disabilities, "DisabilityId", "Name", client.DisabilityId);
            ViewBag.FamilyStatusId = new SelectList(db.FamilyStatuses, "FamilyStatusId", "Name", client.FamilyStatusId);
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "Name", client.NationalityId);
            ViewBag.TownId = new SelectList(db.Towns, "TownId", "Name", client.TownId);
            return View(client);
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            ViewBag.DisabilityId = new SelectList(db.Disabilities, "DisabilityId", "Name", client.DisabilityId);
            ViewBag.FamilyStatusId = new SelectList(db.FamilyStatuses, "FamilyStatusId", "Name", client.FamilyStatusId);
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "Name", client.NationalityId);
            ViewBag.TownId = new SelectList(db.Towns, "TownId", "Name", client.TownId);
            return View(client);
        }

        // POST: Home/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,LastName,FirstName,MidName,Birthday,PassportNumber,PassportIssuedBy,PassportIssueDate,PassrortIdNumber,BirthPlace,Address,HomePhone,MobilePhone,Mail,WorkPlace,WorkPosition,RegistrationAddress,Pensioner,MounthIncome,FamilyStatusId,NationalityId,DisabilityId,TownId")] Client client)
        {
            if (ModelState.IsValid)
            {
                bool isPassportDataExist = db.Set<Client>().Where(c =>
                        c.PassportNumber.Equals(client.PassportNumber) ||
                        c.PassrortIdNumber.Equals(client.PassrortIdNumber))
                    
                    .Any(c => c.Id != client.Id);

                if (isPassportDataExist)
                {
                    ModelState.AddModelError("", "Such client exists!");
                }
                else
                {
                    db.Entry(client).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            ViewBag.DisabilityId = new SelectList(db.Disabilities, "DisabilityId", "Name", client.DisabilityId);
            ViewBag.FamilyStatusId = new SelectList(db.FamilyStatuses, "FamilyStatusId", "Name", client.FamilyStatusId);
            ViewBag.NationalityId = new SelectList(db.Nationalities, "NationalityId", "Name", client.NationalityId);
            ViewBag.TownId = new SelectList(db.Towns, "TownId", "Name", client.TownId);
            return View(client);
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Home/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Client client = db.Clients.Find(id);
            db.Clients.Remove(client);
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

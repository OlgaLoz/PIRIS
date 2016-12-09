using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Lab1.Infrastucture;
using Lab1.Models;

namespace Lab1.Controllers
{
    public class DepositController : Controller
    {
        private readonly UserContext db = new UserContext();

        // GET: Deposit
        public ActionResult Index()
        {
            var clientDepositCredits = db.ClientDepositCredits.Include(c => c.Client).Include(c => c.DepositCredit).Include(c => c.MainAccount).Include(c => c.PersentAccount);
            return View(clientDepositCredits.ToList());
        }

        // GET: Deposit/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientDepositCredit clientDepositCredit = db.ClientDepositCredits.Find(id);
            if (clientDepositCredit == null)
            {
                return HttpNotFound();
            }
            return View(clientDepositCredit);
        }

        // GET: Deposit/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FirstName");
            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name");
            ViewBag.MainAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber");
            ViewBag.PersentAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber");
            return View();
        }

        // POST: Deposit/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientDepositCreditId,Name,Sum,StartDate,ClientId,DepositCreditId,MainAccountId,PersentAccountId")] ClientDepositCredit clientDepositCredit)
        {
            if (ModelState.IsValid)
            {
                db.ClientDepositCredits.Add(clientDepositCredit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "Id", "FirstName", clientDepositCredit.ClientId);
            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name", clientDepositCredit.DepositCreditId);
            ViewBag.MainAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber", clientDepositCredit.MainAccountId);
            ViewBag.PersentAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber", clientDepositCredit.PersentAccountId);
            return View(clientDepositCredit);
        }

        // GET: Deposit/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientDepositCredit clientDepositCredit = db.ClientDepositCredits.Find(id);
            if (clientDepositCredit == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "LastName", clientDepositCredit.ClientId);
            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name", clientDepositCredit.DepositCreditId);
            ViewBag.MainAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber", clientDepositCredit.MainAccountId);
            ViewBag.PersentAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber", clientDepositCredit.PersentAccountId);
            return View(clientDepositCredit);
        }

        // POST: Deposit/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientDepositCreditId,Name,Sum,StartDate,ClientId,DepositCreditId,MainAccountId,PersentAccountId")] ClientDepositCredit clientDepositCredit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientDepositCredit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "Id", "LastName", clientDepositCredit.ClientId);
            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name", clientDepositCredit.DepositCreditId);
            ViewBag.MainAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber", clientDepositCredit.MainAccountId);
            ViewBag.PersentAccountId = new SelectList(db.Accounts, "AccountId", "AccountNumber", clientDepositCredit.PersentAccountId);
            return View(clientDepositCredit);
        }

        // GET: Deposit/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientDepositCredit clientDepositCredit = db.ClientDepositCredits.Find(id);
            if (clientDepositCredit == null)
            {
                return HttpNotFound();
            }
            return View(clientDepositCredit);
        }

        // POST: Deposit/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientDepositCredit clientDepositCredit = db.ClientDepositCredits.Find(id);
            db.ClientDepositCredits.Remove(clientDepositCredit);
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

using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Lab1.Infrastucture;
using Lab1.Models;
using Lab1.Services;

namespace Lab1.Controllers
{
    public class DepositController : Controller
    {
        private readonly UserContext db = new UserContext();
        private readonly BankService bankService = new BankService();

        public ActionResult CloseBankDay()
        {
            bankService.CloseBankDay();
            return View(db.AccountOperations.ToList());
        }

        [HttpGet]
        public ActionResult CreateCredit(int id)
        {
            var deposit = new ClientDepositCredit { ClientId = id };
            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name");
            return View(deposit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCredit([Bind(Include = "ClientDepositCreditId,Number,Sum,StartDate,ClientId,DepositCreditId,MainAccountId,PersentAccountId")] ClientDepositCredit clientDepositCredit)
        {

            if (ModelState.IsValid)
            {
                var credit =
                    db.DepositCredits.FirstOrDefault(x => x.DepositCreditId == clientDepositCredit.DepositCreditId);
                var mainAccount = new Account
                {
                    AccountNumber = "9999" + Guid.NewGuid().ToString().Substring(0, 9),
                    AccountCodeId = 2,
                    Sum = clientDepositCredit.Sum,
                    CurrencyId = credit.CurrencyId,
                    AccountActivity = AccountActivity.Active,
                    AccountTypeId = 2,
                    ClientId = clientDepositCredit.ClientId
                };

                var persentAccount = new Account
                {
                    AccountNumber = "9999" + Guid.NewGuid().ToString().Substring(0, 9),
                    AccountCodeId = 2,
                    CurrencyId = credit.CurrencyId,
                    AccountActivity = AccountActivity.Active,
                    AccountTypeId = 3,
                    ClientId = clientDepositCredit.ClientId
                };

                clientDepositCredit.MainAccount = mainAccount;
                clientDepositCredit.PersentAccount = persentAccount;
                clientDepositCredit.DaysLeft = credit.DaysCount;
                clientDepositCredit.StartDate = DateTime.Now;


                var bdf = db.Accounts.FirstOrDefault();
                var exchangeRate = db.ExchangeRates.FirstOrDefault(x => x.StartCurrencyId == clientDepositCredit.DepositCredit.CurrencyId
                  && x.FinishCurrencyId == bdf.CurrencyId);

               
                bdf.Sum -= clientDepositCredit.Sum * exchangeRate.Rate;

                bdf.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Debit",
                    Sum = clientDepositCredit.Sum,
                    OperationDate = DateTime.Now,
                });

                mainAccount.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Debit",
                    Sum = clientDepositCredit.Sum,
                    OperationDate = DateTime.Now,
                });


                db.Entry(bdf).State = EntityState.Modified;
                db.SaveChanges();

                db.ClientDepositCredits.Add(clientDepositCredit);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name", clientDepositCredit.DepositCreditId);
            return View(clientDepositCredit);
        }

        [HttpGet]
        public ActionResult CreateDeposit(int id)
        {
            var deposit = new ClientDepositCredit {ClientId = id};
            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name");
            return View(deposit);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateDeposit([Bind(Include = "ClientDepositCreditId,Number,Sum,StartDate,ClientId,DepositCreditId,MainAccountId,PersentAccountId")] ClientDepositCredit clientDepositCredit)
        {

            if (ModelState.IsValid)
            {
                var deposit =
                    db.DepositCredits.FirstOrDefault(x => x.DepositCreditId == clientDepositCredit.DepositCreditId);
                var mainAccount = new Account
                {
                    AccountNumber = "9999" + Guid.NewGuid().ToString().Substring(0, 9),
                    AccountCodeId = 1,
                    Sum = clientDepositCredit.Sum,
                    CurrencyId = deposit.CurrencyId,
                    AccountActivity = AccountActivity.Passive,
                    AccountTypeId = 2,
                    ClientId = clientDepositCredit.ClientId
                };

                var persentAccount = new Account
                {
                    AccountNumber = "9999" + Guid.NewGuid().ToString().Substring(0, 9),
                    AccountCodeId = 1,
                    CurrencyId = deposit.CurrencyId,
                    AccountActivity = AccountActivity.Passive,
                    AccountTypeId = 3,
                    ClientId = clientDepositCredit.ClientId
                };

                clientDepositCredit.MainAccount = mainAccount;
                clientDepositCredit.PersentAccount = persentAccount;
                clientDepositCredit.DaysLeft = deposit.DaysCount;
                clientDepositCredit.StartDate = DateTime.Now;

                var bdf = db.Accounts.FirstOrDefault();
                var exchangeRate = db.ExchangeRates.FirstOrDefault(x => x.StartCurrencyId == clientDepositCredit.DepositCredit.CurrencyId
                  && x.FinishCurrencyId == bdf.CurrencyId);


                bdf.Sum += clientDepositCredit.Sum * exchangeRate.Rate;

                bdf.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Credit",
                    Sum = clientDepositCredit.Sum,
                    OperationDate = DateTime.Now,
                });

                mainAccount.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Debit",
                    Sum = clientDepositCredit.Sum,
                    OperationDate = DateTime.Now,
                });


                db.Entry(bdf).State = EntityState.Modified;
                db.SaveChanges();

                db.ClientDepositCredits.Add(clientDepositCredit);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }

            ViewBag.DepositCreditId = new SelectList(db.DepositCredits, "DepositCreditId", "Name", clientDepositCredit.DepositCreditId);
            return View(clientDepositCredit);
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab1.Infrastucture;
using Lab1.Models;

namespace Lab1.Services
{
    public class BankService
    {
        private readonly UserContext db = new UserContext();

        public void CloseBankDay()
        {
            var clients = db.Set<Client>().ToList();
            clients.ForEach(CloseBankDayForClient);
            db.SaveChanges();
        }

        private void CloseBankDayForClient(Client client)
        {
            var clientDepositCredits = client.ClientDepositCredits.ToList();
            clientDepositCredits.ForEach(CountClientDepositCredit);
        }

        private void CountClientDepositCredit(ClientDepositCredit clientDepositCredit)
        {
            var cash = db.Set<Account>().FirstOrDefault(x => x.AccountType.Name == "Cash");
            var bdfa = db.Set<Account>().FirstOrDefault(x => x.AccountType.Name == "BDFA");

            var currentAccount = clientDepositCredit.MainAccount;
            //var percentAccount = clientDepositCredit.PersentAccount;



        }
    }
}
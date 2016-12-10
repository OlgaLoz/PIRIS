using System;
using System.Linq;
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
            var bankDevelopmentFund = db.Set<Account>().FirstOrDefault(x => x.AccountType.Name == "Bank Development Fund");

            switch (clientDepositCredit.DepositCredit.DepositCreditType)
            {
                case DepositCreditType.CallableDeposit:
                    CountCallableDeposit(clientDepositCredit, bankDevelopmentFund);
                    break;
                case DepositCreditType.UncallableDeposit:
                    CountUncallableDeposit(clientDepositCredit, bankDevelopmentFund);
                    break;
                case DepositCreditType.AnnuityPaymentCredit:
                    CountAnnuityPaymentCredit(clientDepositCredit, bankDevelopmentFund);
                    break;
                case DepositCreditType.DifferentialPaymentCredit:
                    CountDifferentialPaymentCredit(clientDepositCredit, bankDevelopmentFund);
                    break;
            }
        }

        private void CountCallableDeposit(ClientDepositCredit clientDepositCredit, Account fund)
        {
            if (clientDepositCredit.DaysLeft == 0)
            {
                return;
            }

            clientDepositCredit.DaysLeft -= 1;

            var mainAccount = clientDepositCredit.MainAccount;
            var persentAccount = clientDepositCredit.PersentAccount;
            
            var sumAdded = (mainAccount.Sum + persentAccount.Sum)*(clientDepositCredit.DepositCredit.PerSent/(100*365));

            var daysPast = clientDepositCredit.DepositCredit.DaysCount - clientDepositCredit.DaysLeft;

            if (daysPast % 30 == 0)
            {
                var persentSum = persentAccount.Sum;
                mainAccount.Sum += persentSum;
                persentAccount.Sum = 0;

                persentAccount.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Debit",
                    Sum = persentSum,
                    OperationDate = DateTime.Now,
                });

                mainAccount.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Credit",
                    Sum = persentSum,
                    OperationDate = DateTime.Now,
                });
            }

            var exchangeRate =
                db.ExchangeRates.FirstOrDefault(x => x.StartCurrencyId == clientDepositCredit.DepositCredit.CurrencyId
                && x.FinishCurrencyId == fund.CurrencyId);

            if (fund.Sum < exchangeRate.Rate * sumAdded)
            {
                throw new NotSupportedException("Closing of bank day was failed.");
            }

            fund.Sum -= exchangeRate.Rate * sumAdded;
            persentAccount.Sum += sumAdded;

            fund.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Debit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });

            persentAccount.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Credit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });
        }

        private void CountUncallableDeposit(ClientDepositCredit clientDepositCredit, Account fund)
        {
            if (clientDepositCredit.DaysLeft == 0)
            {
                return;
            }

            clientDepositCredit.DaysLeft -= 1;

            var mainAccount = clientDepositCredit.MainAccount;
            var persentAccount = clientDepositCredit.PersentAccount;

            var sumAdded = clientDepositCredit.Sum*(clientDepositCredit.DepositCredit.PerSent/(100*365));

            var exchangeRate =
                db.ExchangeRates.FirstOrDefault(x => x.StartCurrencyId == clientDepositCredit.DepositCredit.CurrencyId
                && x.FinishCurrencyId == fund.CurrencyId);

            if (fund.Sum < exchangeRate.Rate * sumAdded)
            {
                throw new NotSupportedException("Closing of bank day was failed.");
            }

            fund.Sum -= exchangeRate.Rate * sumAdded;
            persentAccount.Sum += sumAdded;

            fund.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Debit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });

            persentAccount.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Credit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });

            if (clientDepositCredit.DaysLeft == 0)
            {
                var persentSum = persentAccount.Sum;
                mainAccount.Sum += persentSum;
                persentAccount.Sum = 0;

                persentAccount.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Debit",
                    Sum = persentSum,
                    OperationDate = DateTime.Now,
                });

                mainAccount.AccountOperations.Add(new AccountOperation
                {
                    OperationType = "Credit",
                    Sum = persentSum,
                    OperationDate = DateTime.Now,
                });
            }
        }

        private void CountAnnuityPaymentCredit(ClientDepositCredit clientDepositCredit, Account fund)
        {
            if (clientDepositCredit.DaysLeft == 0)
            {
                return;
            }

            clientDepositCredit.DaysLeft -= 1;

            var mainAccount = clientDepositCredit.MainAccount;
            var persentAccount = clientDepositCredit.PersentAccount;

            var sumAdded = clientDepositCredit.Sum * (clientDepositCredit.DepositCredit.PerSent / (100 * 365));
            
            var exchangeRate =
                db.ExchangeRates.FirstOrDefault(x => x.StartCurrencyId == clientDepositCredit.DepositCredit.CurrencyId
                && x.FinishCurrencyId == fund.CurrencyId);

            persentAccount.Sum += sumAdded;
            fund.Sum += exchangeRate.Rate * sumAdded;

            persentAccount.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Credit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });

            fund.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Credit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });
        }

        private void CountDifferentialPaymentCredit(ClientDepositCredit clientDepositCredit, Account fund)
        {
            if (clientDepositCredit.DaysLeft == 0)
            {
                return;
            }

            clientDepositCredit.DaysLeft -= 1;

            var mainAccount = clientDepositCredit.MainAccount;
            var persentAccount = clientDepositCredit.PersentAccount;

            var sumAdded = (mainAccount.Sum + persentAccount.Sum)*(clientDepositCredit.DepositCredit.PerSent/(100*365));

            var exchangeRate =
                db.ExchangeRates.FirstOrDefault(x => x.StartCurrencyId == clientDepositCredit.DepositCredit.CurrencyId
                && x.FinishCurrencyId == fund.CurrencyId);

            persentAccount.Sum += sumAdded;
            fund.Sum += exchangeRate.Rate * sumAdded;

            persentAccount.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Credit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });

            fund.AccountOperations.Add(new AccountOperation
            {
                OperationType = "Credit",
                Sum = sumAdded,
                OperationDate = DateTime.Now,
            });
        }
    }
}
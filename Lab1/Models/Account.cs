using System.Collections.Generic;

namespace Lab1.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public int AccountCodeId { get; set; }

        public virtual AccountCode AccountCode { get; set; }

        public decimal Sum { get; set; }
        
        public int CurrencyId { get; set; }

        public virtual Currency Currency { get; set; }

        public AccountActivity AccountActivity { get; set; }

        public int AccountTypeId { get; set; }

        public virtual AccountType AccountType { get; set; }

        public int? ClientId { get; set; }

        public virtual Client Client { get; set; }
        
        public virtual List<ClientCard> ClientCards { get; set; } = new List<ClientCard>();

        public virtual List<AccountOperation> AccountOperations { get; set; } = new List<AccountOperation>();
    }
}
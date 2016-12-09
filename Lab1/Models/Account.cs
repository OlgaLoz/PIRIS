using System.Collections.Generic;

namespace Lab1.Models
{
    public class Account
    {
        public int AccountId { get; set; }

        public string AccountNumber { get; set; }

        public int AccountCodeId { get; set; }

        public AccountCode AccountCode { get; set; }

        public decimal Sum { get; set; }
        
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }

        public AccountActivity AccountActivity { get; set; }

        public int AccountTypeId { get; set; }

        public AccountType AccountType { get; set; }

        public int? ClientId { get; set; }

        public Client Client { get; set; }
        
        public List<ClientCard> ClientCards { get; set; } = new List<ClientCard>();
    }
}
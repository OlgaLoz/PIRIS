using System;

namespace Lab1.Models
{
    public class AccountOperation
    {
        public int AccountOperationId { get; set; }

        public string OperationType { get; set; }

        public decimal Sum { get; set; }

        public DateTime OperationDate { get; set; }

        public int AccountId { get; set; }

        public virtual Account Account { get; set; }
    }
}
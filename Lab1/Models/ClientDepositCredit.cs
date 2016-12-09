using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class ClientDepositCredit
    {
        public int ClientDepositCreditId { get; set; }

        [RegularExpression(@"^[a-zA-Z0-9]+$", ErrorMessage = "Incorrect number")]
        [Display(Name = "Number")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Field is required")]
        public decimal Sum { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Date)]
        [Display(Name = "Start date")]
        public DateTime StartDate { get; set; }

        public int DaysLeft { get; set; }

        public int StartSum { get; set; }

        [Display(Name = "Client")]
        public int ClientId { get; set; }

        public Client Client { get; set; }

        public int DepositCreditId { get; set; }

        public DepositCredit DepositCredit { get; set; }

        [ForeignKey("MainAccount")]
        public int MainAccountId { get; set; }

        public Account MainAccount { get; set; }

        [ForeignKey("PersentAccount")]
        public int PersentAccountId { get; set; }

        public Account PersentAccount { get; set; }
    }
}
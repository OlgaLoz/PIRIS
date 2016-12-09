using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
    public class DepositCredit
    {
        public int DepositCreditId { get; set; }

        public string Name { get; set; }

        public decimal PerSent { get; set; }

        [Display(Name = "Min sum")]
        public decimal MinSum { get; set; }

        [Display(Name = "Max sum")]
        public decimal MaxSum { get; set; }

        [Display(Name = "Duration (days)")]
        public int DaysCount { get; set; }

        [Display(Name = "Type")]
        public DepositCreditType DepositCreditType { get; set; }

        [Display(Name = "Currency")]
        public int CurrencyId { get; set; }

        public Currency Currency { get; set; }
    }
}
 
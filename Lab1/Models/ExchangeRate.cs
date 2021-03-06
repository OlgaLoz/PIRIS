﻿using System.ComponentModel.DataAnnotations.Schema;

namespace Lab1.Models
{
    public class ExchangeRate
    {
        public int ExchangeRateId { get; set; }

        public decimal Rate { get; set; }

        [ForeignKey("StartCurrency")]
        public int StartCurrencyId { get; set; }

        public virtual Currency StartCurrency { get; set; }

        [ForeignKey("FinishCurrency")]
        public int FinishCurrencyId { get; set; }

        public virtual Currency FinishCurrency { get; set; }
    }
}
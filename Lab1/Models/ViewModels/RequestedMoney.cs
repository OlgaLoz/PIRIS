using System;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models.ViewModels
{
    public class RequestedMoney
    {
        [Required(ErrorMessage = "Enter balance!")]
        [Range(0, Int32.MaxValue, ErrorMessage = "Incorrect value!")]
        public int Money { get; set; }
    }
}
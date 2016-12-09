using System.ComponentModel.DataAnnotations;

namespace Lab1.Models.ViewModels
{
    public class Card
    {
        [Required(ErrorMessage = "Enter card number!")]
        public string CardNumber { get; set; }

        [Required(ErrorMessage = "Enter pin code!")]
        [DataType(DataType.Password)]
        public int PinCode { get; set; }

        public int AttemptionsCount { get; set; } = 3;
    }
}
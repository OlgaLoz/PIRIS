using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Lab1.Models
{
	public class Client
    {
        [ScaffoldColumn(false)]
		public int Id { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Incorrect last name")]
        [Display(Name = "* Last name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Incorrect first name")]
        [Display(Name = "* First name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Incorrect mid name")]
        [Display(Name = "* Mid name")]
        public string MidName { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [DataType(DataType.Date)]
        [Display(Name = "* Birthday")]
        public DateTime Birthday { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Passport number")]
        public string PassportNumber { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Passport issued by")]
        public string PassportIssuedBy { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Passport issued date")]
        [DataType(DataType.Date)]
        public DateTime PassportIssueDate { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Passport identification number")]
        public string PassrortIdNumber { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Birth place")]
        public string BirthPlace { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Address")]
        public string Address { get; set; }

        [Display(Name = "Home phone")]
        public string HomePhone { get; set; }

        [Display(Name = "Mobile phone")]
        public string MobilePhone { get; set; }

        public string Mail { get; set; }

        [Display(Name = "Work place")]
        public string WorkPlace { get; set; }

        [Display(Name = "Work position")]
        public string WorkPosition { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Registration address")]
        public string RegistrationAddress { get; set; }

        [Required(ErrorMessage = "* Field is required")]
        public bool Pensioner { get; set; }

        [Display(Name = "Mounth income")]
        public decimal? MounthIncome { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Family status")]
        public int FamilyStatusId { get; set; }

        public virtual FamilyStatus FamilyStatus { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Nationality")]
        public int NationalityId { get; set; }

        public virtual Nationality Nationality { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Disability")]
        public int DisabilityId { get; set; }

        public virtual Disability Disability { get; set; }

        [Required(ErrorMessage = "Field is required")]
        [Display(Name = "* Town")]
        public int TownId { get; set; }

        public virtual Town Town { get; set; }

        public virtual List<Account> Accounts { get; set; } = new List<Account>();

        public virtual List<ClientDepositCredit> ClientDepositCredits { get; set; } = new List<ClientDepositCredit>();
    }
}
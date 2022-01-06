using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCenter.Models
{
    public class Patient
    {
        public int Id { get; set; }
        [Display(Name = "CNP")]
        [Required(ErrorMessage = "Field Required")]
        public string CNP { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Field Required")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Field Required")]
        public string LastName { get; set; }
        [Display(Name = "Gender")]
        [Required(ErrorMessage = "Field Required")]
        public Gender Gender { get; set; }
        [Display(Name = "Phone")]
        [Required(ErrorMessage = "Field Required")]
        public string Phone { get; set; }
        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email Required")]
        [EmailAddress(ErrorMessage = "Email Required")]
        public string Email { get; set; }
        [Display(Name = "BirthDate")]
        [Required(ErrorMessage = "Field Required")]
        public DateTime BirthDate { get; set; }
        [Display(Name = "City")]
        [Required(ErrorMessage = "Field Required")]
        public City City { get; set; }
        [Display(Name = "Street")]
        [Required(ErrorMessage = "Field Required")]
        public string Street { get; set; }
        [Display(Name = "StreetNumber")]
        [Required(ErrorMessage = "Field Required")]
        public string StreetNumber { get; set; }
        [Display(Name = "AssignedDoctor")]
        [Required(ErrorMessage = "Field Required")]
        public MedicalStaff AssignedDoctor { get; set; }
    }
}

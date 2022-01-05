using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCenter.Models
{
    public class MedicalStaff
    {
        public int Id { get; set; }
        [Display(Name = "FirstName")]
        [Required(ErrorMessage = "Field Required")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [Required(ErrorMessage = "Field Required")]
        public string LastName { get; set; }
        [Display(Name = "StartTime")]
        [Required(ErrorMessage = "TimeSpan Field Required")]
        public TimeSpan StartTime { get; set; }
        [Display(Name = "EndTime")]
        [Required(ErrorMessage = "TimeSpan Field Required")]
        public TimeSpan EndTime { get; set; }
        [Display(Name = "Specialisation")]
        public Specialisation Specialisation { get; set; }
        [Display(Name = "ConsultationRoom")]
        public Room ConsultationRoom { get; set; }
        [NotMapped]
        public int ConsultationRoomId { set; get; }
       
    }
}

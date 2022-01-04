using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MedicalCenter.Models
{
    public class Room
    {
        public int Id { get; set; }
        [Display(Name = "Floor")]
        [Required(ErrorMessage = "Field Required")]
        public int Floor { get; set; }
        [Display(Name = "RoomNumber")]
        [Required(ErrorMessage = "Field Required")]
        public int RoomNumber { get; set; }
        [Display(Name = "Description")]
        public string Description { get; set; }
        [Display(Name = "IsAvailable")]
        public bool IsAvailable { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalCenter.Data;
using MedicalCenter.Models;
using Microsoft.AspNetCore.Http;

namespace MedicalCenter.Pages.MedicalStaff
{
    public class CreateModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;

        public CreateModel(MedicalCenter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var specialisations = from Specialisation s in Enum.GetValues(typeof(Specialisation))
                        select new { ID = (int)s, Name = s.ToString() };
            ViewData["Specialisation"] = new SelectList(specialisations, "ID", "Name");

            var rooms = from MedicalCenter.Models.Room r in _context.Room.Where(r => r.IsAvailable).ToList()
                        select new { ID = (int)r.Id, Name = string.Format("{0}.{1}",r.Floor,r.RoomNumber) };
            ViewData["Room"] = new SelectList(rooms, "ID", "Name");

            return Page();
        }

        [BindProperty]
        public MedicalCenter.Models.MedicalStaff MedicalStaff { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                var roles = from Specialisation s in Enum.GetValues(typeof(Specialisation))
                            select new { ID = (int)s, Name = s.ToString() };
                ViewData["Specialisation"] = new SelectList(roles, "ID", "Name");

                var rooms = from MedicalCenter.Models.Room r in _context.Room.Where(r => r.IsAvailable).ToList()
                            select new { ID = (int)r.Id, Name = string.Format("{0}.{1}", r.Floor, r.RoomNumber) };
                ViewData["Room"] = new SelectList(rooms, "ID", "Name");

                return Page();
            }
            var room = _context.Room.FirstOrDefault(r => r.Id == MedicalStaff.ConsultationRoomId);
            MedicalStaff.ConsultationRoom = room;
            _context.MedicalStaff.Add(MedicalStaff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalCenter.Data;
using MedicalCenter.Models;

namespace MedicalCenter.Pages.MedicalStaff
{
    public class EditModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;

        public EditModel(MedicalCenter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalCenter.Models.MedicalStaff MedicalStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalStaff = await _context.MedicalStaff.Include(m=>m.ConsultationRoom).FirstOrDefaultAsync(m => m.Id == id);

            if (MedicalStaff == null)
            {
                return NotFound();
            }
            var roles = from Specialisation s in Enum.GetValues(typeof(Specialisation))
                        select new { ID = (int)s, Name = s.ToString() };
            ViewData["Specialisation"] = new SelectList(roles, "ID", "Name");

            var rooms = from MedicalCenter.Models.Room r in _context.Room.Where(r => r.IsAvailable).ToList()
                        select new { ID = (int)r.Id, Name = string.Format("{0}.{1}", r.Floor, r.RoomNumber) };
            ViewData["Room"] = new SelectList(rooms, "ID", "Name");
            MedicalStaff.ConsultationRoomId = MedicalStaff.ConsultationRoom.Id;

            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
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
                MedicalStaff.ConsultationRoomId = MedicalStaff.ConsultationRoom.Id;

                return Page();
            }
            var room = _context.Room.FirstOrDefault(r => r.Id == MedicalStaff.ConsultationRoomId);
            MedicalStaff.ConsultationRoom = room;
            _context.Attach(MedicalStaff).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MedicalStaffExists(MedicalStaff.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool MedicalStaffExists(int id)
        {
            return _context.MedicalStaff.Any(e => e.Id == id);
        }
    }
}

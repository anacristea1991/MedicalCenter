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
using MedicalCenter.Services;

namespace MedicalCenter.Pages.Room
{
    public class EditModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;
        private readonly CommonLocalizationService _localizer;

        public EditModel(MedicalCenter.Data.ApplicationDbContext context, CommonLocalizationService localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        [BindProperty]
        public MedicalCenter.Models.Room Room { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room.FirstOrDefaultAsync(m => m.Id == id);

            if (Room == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var existingRoom = _context.Room.FirstOrDefault(r => r.Id!=Room.Id &&r.Floor == Room.Floor && r.RoomNumber == Room.RoomNumber);
            if (existingRoom != null)
            {
                ModelState.AddModelError(string.Empty, _localizer.Get("RoomExists"));
                return Page();
            }

            _context.Attach(Room).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(Room.Id))
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

        private bool RoomExists(int id)
        {
            return _context.Room.Any(e => e.Id == id);
        }
    }
}

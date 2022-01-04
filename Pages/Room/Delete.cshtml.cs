using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalCenter.Data;
using MedicalCenter.Models;
using MedicalCenter.Services;

namespace MedicalCenter.Pages.Room
{
    public class DeleteModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;
        private readonly CommonLocalizationService _localizer;

        public DeleteModel(MedicalCenter.Data.ApplicationDbContext context, CommonLocalizationService localizer)
        {
            _context = context;
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Room = await _context.Room.FindAsync(id);

            if (Room != null)
            {
                if (_context.MedicalStaff.Where(m => m.ConsultationRoom == Room).Any())
                {
                    ViewData["ErrorDeleteRoom"] = _localizer.Get("ErrorDeleteRoom");
                    return Page();
                }
                else
                {
                    _context.Room.Remove(Room);
                    await _context.SaveChangesAsync();
                }
            }

            return RedirectToPage("./Index");
        }
    }
}

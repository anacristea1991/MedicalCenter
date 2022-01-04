using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalCenter.Data;
using MedicalCenter.Models;
using MedicalCenter.Services;

namespace MedicalCenter.Pages.Room
{
    public class CreateModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;
        private readonly CommonLocalizationService _localizer;

        public CreateModel(MedicalCenter.Data.ApplicationDbContext context, CommonLocalizationService localizer)
        {
            _context = context;
            _localizer = localizer;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public MedicalCenter.Models.Room Room { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            var existingRoom = _context.Room.FirstOrDefault(r => r.Floor == Room.Floor && r.RoomNumber == Room.RoomNumber);
            if (existingRoom != null)
            {
                ModelState.AddModelError(string.Empty, _localizer.Get("RoomExists"));
                return Page();
            }

            _context.Room.Add(Room);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

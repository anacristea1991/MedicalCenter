using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalCenter.Data;
using MedicalCenter.Models;

namespace MedicalCenter.Pages.Pacient
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
            //var counties = from MedicalCenter.Models.County r in _context.MedicalStaff.ToList()
            //            select new { ID = (int)r.Id, Name = string.Format("{0}.{1}", r.Floor, r.RoomNumber) };
            //ViewData["County"] = new SelectList(counties, "ID", "Name");
            return Page();
        }

        [BindProperty]
        public Patient Patient { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Patient.Add(Patient);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

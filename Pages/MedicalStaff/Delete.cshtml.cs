using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalCenter.Data;
using MedicalCenter.Models;

namespace MedicalCenter.Pages.MedicalStaff
{
    public class DeleteModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;

        public DeleteModel(MedicalCenter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public MedicalCenter.Models.MedicalStaff MedicalStaff { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalStaff = await _context.MedicalStaff.FirstOrDefaultAsync(m => m.Id == id);

            if (MedicalStaff == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MedicalStaff = await _context.MedicalStaff.FindAsync(id);

            if (MedicalStaff != null)
            {
                _context.MedicalStaff.Remove(MedicalStaff);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

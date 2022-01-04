using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MedicalCenter.Data;
using MedicalCenter.Models;

namespace MedicalCenter.Pages.Room
{
    public class DetailsModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;

        public DetailsModel(MedicalCenter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
    }
}

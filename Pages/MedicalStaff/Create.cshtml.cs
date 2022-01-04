﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using MedicalCenter.Data;
using MedicalCenter.Models;

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
            return Page();
        }

        [BindProperty]
        public MedicalCenter.Models.MedicalStaff MedicalStaff { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.MedicalStaff.Add(MedicalStaff);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

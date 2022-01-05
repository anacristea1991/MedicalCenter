﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly MedicalCenter.Data.ApplicationDbContext _context;

        public IndexModel(MedicalCenter.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<MedicalCenter.Models.Room> Room { get;set; }

        public async Task OnGetAsync()
        {
            Room = await _context.Room.ToListAsync();
        }
    }
}
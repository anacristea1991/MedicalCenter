﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using MedicalCenter.Models;

namespace MedicalCenter.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<MedicalCenter.Models.Room> Room { get; set; }
        public DbSet<MedicalCenter.Models.MedicalStaff> MedicalStaff { get; set; }
    }
}

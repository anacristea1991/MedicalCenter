using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicalStaff>().Ignore(t => t.ConsultationRoomId);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<MedicalCenter.Models.Room> Room { get; set; }
        public DbSet<MedicalCenter.Models.MedicalStaff> MedicalStaff { get; set; }
    }
}

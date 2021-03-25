using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone_Project.Models;
using Microsoft.AspNetCore.Identity;

namespace Capstone_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Models.MonthlyFinance> Finance { get; set; }
        public DbSet<Capstone_Project.Models.NewGoal> NewGoal { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<IdentityRole>()
                .HasData(
                new IdentityRole
                {
                    Name = "New User",
                    NormalizedName = "NewUser"

                }
            );
               
                
        }
        public DbSet<Capstone_Project.Models.UserModel> UserModel { get; set; }
                
                   
        
    }
    
}

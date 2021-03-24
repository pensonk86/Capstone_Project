using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Capstone_Project.Models;

namespace Capstone_Project.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Models.MonthlyFinance> Finance { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Capstone_Project.Models.GoalModel> GoalModel { get; set; }
    }
}

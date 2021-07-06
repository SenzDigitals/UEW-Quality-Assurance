using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UEW_Quality_Assurance.Models;

namespace UEW_Quality_Assurance.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly DbContextOptions _options;

        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            _options = options;
        }

        //Registering models as datasets


        public DbSet<AppraisalPeriod> AppraisalPeriods { set; get; }
        public DbSet<Threshold> Thresholds { set; get; }
        public DbSet<Campus> Campuses { set; get; }
        public DbSet<Course> Courses { set; get; }
        public DbSet<Department> Departments { set; get; }
        public DbSet<Enrollment> Enrollments { set; get; }
        public DbSet<Faculty> Faculties { set; get; }
        public DbSet<Lecturer> Lecturers { set; get; }
        public DbSet<Prog> Progs { set; get; }
        public DbSet<Student> Students { set; get; }
        public DbSet<UEW_Quality_Assurance.Models.Email> Email { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //renaming tables
            builder.Entity<AppraisalPeriod>().ToTable("AppraisalPeriod");
            builder.Entity<Threshold>().ToTable("Threshold");
            builder.Entity<Campus>().ToTable("Campus");
            builder.Entity<Course>().ToTable("Course");
            builder.Entity<Department>().ToTable("Department");
            builder.Entity<Enrollment>().ToTable("Enrollment");
            builder.Entity<Faculty>().ToTable("Faculty");
            builder.Entity<Lecturer>().ToTable("Lecturer");
            builder.Entity<Prog>().ToTable("Program");
            builder.Entity<Student>().ToTable("Student");

            builder.Entity<IdentityUser>();

            //Renaming identity table groups
            //builder.HasDefaultSchema("Identity");
            builder.Entity<IdentityUser>().ToTable(name:"User");
            builder.Entity<IdentityRole>().ToTable(name: "Role");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaim");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("RoleClaim");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens");

        }
    }
}

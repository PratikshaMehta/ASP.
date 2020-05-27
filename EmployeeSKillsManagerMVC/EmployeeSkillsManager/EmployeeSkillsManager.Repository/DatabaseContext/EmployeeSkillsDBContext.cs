using EmployeeSkillsManager.DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace EmployeeSkillsManager.Repository.DatabaseContext
{
    public class EmployeeSkillsDBContext : DbContext


    {

        public EmployeeSkillsDBContext() : base("EmployeeSkillsDBContext1")

        {
            Configuration.ProxyCreationEnabled = false;

            Database.SetInitializer<EmployeeSkillsDBContext>(null);

            //Database.SetInitializer<EmployeeSkillsDBContext>(new EmployeeDCIn());
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Department>().ToTable("Department");
            modelBuilder.Entity<Skill>().ToTable("Skill");
            modelBuilder.Entity<Category>().ToTable("SkillsCategory");
            modelBuilder.Entity<Employee>().ToTable("Employee");


            modelBuilder.Entity<Department>().HasKey(d => d.DepartmentID);
            modelBuilder.Entity<Skill>().HasKey(c => c.SkillID);
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryID);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeID);

            modelBuilder.Entity<Department>().Property(d => d.DepartmentID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Skill>().Property(d => d.SkillID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Category>().Property(d => d.CategoryID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            modelBuilder.Entity<Employee>().Property(d => d.EmployeeID).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Skill>().Property(d => d.Description)
                .HasColumnOrder(3)
                .HasColumnType("varchar")
                .HasMaxLength(250)
                .IsOptional();

            //One to many relationship 

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Skills)
                .WithRequired(a => a.Category)
                .HasForeignKey(c => c.SkillCategoryID);
            //many to many relationship

            modelBuilder.Entity<EmployeeSkills>()
    .HasKey(c => new { c.EmployeeID, c.SkillID });

            modelBuilder.Entity<Employee>()
                .HasMany(c => c.EmployeeSkills)
                .WithRequired()
                .HasForeignKey(c => c.EmployeeID);

            modelBuilder.Entity<Skill>()
                .HasMany(c => c.EmployeeSkills)
                .WithRequired()
                .HasForeignKey(c => c.SkillID);





            //    modelBuilder.Entity<Employee>()
            //.HasRequired(e => e.Department)
            //.WithMany(d => d.Employees)
            //.HasForeignKey(a => a.);


            ////many to many relationship 
            //modelBuilder.Entity<Employee>()
            //    .HasMany(c => c.Skills)
            //    .WithMany(e => e.Employees)
            //    .Map(m => m.ToTable("EmployeeSkills"));

            ////one to one relationship


            //modelBuilder.Entity<Employee>()
            //  .HasRequired(s => s.EmployeeAddress)
            //  .WithRequiredPrincipal(ad => ad.Employee);


            //    modelBuilder.Entity<Employee>()
            //.HasRequired(d => d.EmployeeDepartment)
            //.WithRequiredPrincipal(e => e.Employees);

            base.OnModelCreating(modelBuilder);
        }

        public System.Data.Entity.DbSet<EmployeeSkillsManager.DomainClasses.EmployeeSkills> EmployeeSkills { get; set; }
    }
}
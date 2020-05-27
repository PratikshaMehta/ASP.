using EmployeeSkillsManager.DomainClasses;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;
namespace EmployeeSKillsManagerMVC.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;


    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeSkillsManager.Repository.DatabaseContext.EmployeeSkillsDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeSkillsManager.Repository.DatabaseContext.EmployeeSkillsDBContext context)
        {


            //var Employees = new List<Employee>
            //{
            //    //new Employee { Name = "Kajal Gajjar",   Email = "Kajal.Gajjar@taxtechnologies.com", Gender = "Female", Contact = "989878899" , AcNo = "111", SSN = "222" , EmployeeDepartmentID = 3, TotalExp = 10 ,
            //    //    CreatedDate = DateTime.Parse("2019-07-19") },
            //    new Employee { Name = "Usha Patel",   Email = "Usha.Patel@taxtechnologies.com", Gender = "Female", Contact = "989878899" , AcNo = "111", SSN = "222" , EmployeeDepartmentID = 4, TotalExp = 10 ,
            //    CreatedDate = DateTime.Parse("2019-07-19") },
            //    new Employee { Name = "Bhargav Gandhi",   Email = "Bhargav.Gandhi@taxtechnologies.com", Gender = "Male", Contact = "989878899" , AcNo = "111", SSN = "222" , EmployeeDepartmentID = 4, TotalExp = 13 ,
            //CreatedDate = DateTime.Parse("2019-07-19") },
            //      new Employee { Name = "Kamal Zaveri",   Email = "Kamal.Zaveri@taxtechnologies.com", Gender = "Male", Contact = "989878899" , AcNo = "111", SSN = "222" , EmployeeDepartmentID = 9, TotalExp = 10 ,
            //        CreatedDate = DateTime.Parse("2019-07-19") }
            


            //};
            //Employees.ForEach(s => context.Employees.AddOrUpdate(p => p.Name, s));
            //context.SaveChanges();

            //var Category = new List<Category>
            //    {
            //        new Category {Name = "Chemistry",      Credits = 3, },
            //        new Course {CourseID = 4022, Title = "Microeconomics", Credits = 3, },
            //        new Course {CourseID = 4041, Title = "Macroeconomics", Credits = 3, },
            //        new Course {CourseID = 1045, Title = "Calculus",       Credits = 4, },
            //        new Course {CourseID = 3141, Title = "Trigonometry",   Credits = 4, },
            //        new Course {CourseID = 2021, Title = "Composition",    Credits = 3, },d
            //        new Course {CourseID = 2042, Title = "Literature",     Credits = 4, }
            //    };
            //    courses.ForEach(s => context.Courses.AddOrUpdate(p => p.Title, s));
            //    context.SaveChanges();

            //    var enrollments = new List<Enrollment>
            //    {
            //        new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID,
            //            Grade = Grade.A
            //        },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //            CourseID = courses.Single(c => c.Title == "Microeconomics" ).CourseID,
            //            Grade = Grade.C
            //         },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Alexander").ID,
            //            CourseID = courses.Single(c => c.Title == "Macroeconomics" ).CourseID,
            //            Grade = Grade.B
            //         },
            //         new Enrollment {
            //             StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //            CourseID = courses.Single(c => c.Title == "Calculus" ).CourseID,
            //            Grade = Grade.B
            //         },
            //         new Enrollment {
            //             StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //            CourseID = courses.Single(c => c.Title == "Trigonometry" ).CourseID,
            //            Grade = Grade.B
            //         },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Alonso").ID,
            //            CourseID = courses.Single(c => c.Title == "Composition" ).CourseID,
            //            Grade = Grade.B
            //         },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Anand").ID,
            //            CourseID = courses.Single(c => c.Title == "Chemistry" ).CourseID
            //         },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Anand").ID,
            //            CourseID = courses.Single(c => c.Title == "Microeconomics").CourseID,
            //            Grade = Grade.B
            //         },
            //        new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Barzdukas").ID,
            //            CourseID = courses.Single(c => c.Title == "Chemistry").CourseID,
            //            Grade = Grade.B
            //         },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Li").ID,
            //            CourseID = courses.Single(c => c.Title == "Composition").CourseID,
            //            Grade = Grade.B
            //         },
            //         new Enrollment {
            //            StudentID = students.Single(s => s.LastName == "Justice").ID,
            //            CourseID = courses.Single(c => c.Title == "Literature").CourseID,
            //            Grade = Grade.B
            //         }
            //    };

            //    foreach (Enrollment e in enrollments)
            //    {
            //        var enrollmentInDataBase = context.Enrollments.Where(
            //            s =>
            //                 s.Student.ID == e.StudentID &&
            //                 s.Course.CourseID == e.CourseID).SingleOrDefault();
            //        if (enrollmentInDataBase == null)
            //        {
            //            context.Enrollments.Add(e);
            //        }
            //    }
            //    context.SaveChanges();
            //}




            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.





        }
    }
}

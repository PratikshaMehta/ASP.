using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.TestProject
{
    [TestClass]
    public class TestLinq
    {
        public TestContext TestContext { get; set; }
        EmployeeSkillsDBContext _Context = new EmployeeSkillsDBContext();
        [TestMethod]
        public void EmployeeSortedList_QuerySyntax()
        {
           

 
            var query = from c in _Context.Employees
                        where c.Name.Contains("Pratiksha")
                        orderby c.Name, c.TotalExp descending
                        select new { Name = c.Name, Department = c.Department.Name };

            foreach (var e in query)
                Console.WriteLine("Department - {0}, Employee - {1}", e.Department, e.Name);

            // Assert
            //Assert.IsNotNull(items);
        }
        [TestMethod]
        public void TestMethod1()
        {
            //IEmployeeRepository EmployeeRepo = new EmployeeRepository(new EmployeeSkillsDBContext());

            //var items = EmployeeRepo.GetListofEmployees();
            //TestContext.WriteLine("test");

            //foreach (var item in items)
            //{
            //    TestContext.WriteLine(item.ToString());
            //}

            //// Assert
            //Assert.IsNotNull(items);
        }
    }
}

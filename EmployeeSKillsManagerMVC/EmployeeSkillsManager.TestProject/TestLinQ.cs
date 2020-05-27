using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;

namespace EmployeeSkillsManager.TestProject
{
    [TestClass]
    public class TestLinq
    {
        public TestContext TestContext { get; set; }
        [TestMethod]
        public void TestMethod1()
        {
            IEmployeeRepository EmployeeRepo = new EmployeeRepository(new EmployeeSkillsDBContext());

            var items = EmployeeRepo.GetListofEmployees();
            TestContext.WriteLine("test");

            foreach (var item in items)
            {
                TestContext.WriteLine(item.ToString());
            }

            // Assert
            Assert.IsNotNull(items);
        }
    }
}

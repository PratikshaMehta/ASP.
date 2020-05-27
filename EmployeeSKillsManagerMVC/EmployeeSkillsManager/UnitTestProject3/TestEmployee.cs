using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
namespace UnitTestProject3
{
    [TestClass]
    public class TestEmployee
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }



        [TestMethod]
        public void Test_GetListOfSkillsForEmployee()
        {
            IEmployeeRepository EmployeeRepo = new EmployeeRepository(new EmployeeCapacityDBContext());

             var items = EmployeeRepo.GetListOfSkillsForEmployee(4);
            TestContext.WriteLine("test");

        }
    }
}

using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
namespace UnitTestProject3
{
    [TestClass]
    public class UnitTest1
    {
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get { return testContextInstance; }
            set { testContextInstance = value; }
        }



        [TestMethod]
        public void TestMethod1()
        {
            ISkillRepository SkillRepo = new SkillRepository(new EmployeeCapacityDBContext());

       var items =     SkillRepo.GetListofSkills();
            TestContext.WriteLine("test");
            
        }
    }
}

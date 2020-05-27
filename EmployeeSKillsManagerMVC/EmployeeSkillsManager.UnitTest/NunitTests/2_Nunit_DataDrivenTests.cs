using NUnit.Framework;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using EmployeeSkillsManager.DomainClasses;
using System;

namespace EmployeeSkillsManager.UnitTest
{
    [TestFixture]
   public  class Nunit_DataDrivenTests
    {

        private EmployeeSkillsDBContext _context;
        private SkillRepository _skillRepository;
        private EmployeeSkillsRepository _EmployeeSkillsRepository;


        [OneTimeSetUp]
        public void Setup()
        {
            _context = new EmployeeSkillsDBContext();
            _skillRepository = new SkillRepository(_context);
            _EmployeeSkillsRepository = new EmployeeSkillsRepository(_context);
        
        }
        [Test]
        [TestCase("ASP.NET MVC", true)]
        [TestCase("Project Planning", true)]
        [TestCase("Testing for fail", false)]
        public void TestIfSkillExistsInSys(string SkillName, bool expected)
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists(SkillName);
            TestContext.WriteLine(SkillName + "Testing");
            Assert.That(bskillexist, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(typeof(NunitDataDriven_TestData), "TestCases")]
        public void TestIfSkillExistsInSys_Centeralized(string SkillName, bool expected)
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists(SkillName);
            TestContext.WriteLine(SkillName + "Testing");
            Assert.That(bskillexist, Is.EqualTo(expected));
        }
        [Test]
        [TestCaseSource(typeof(NunitTestWithCSVData), "GetTestCases", new object[] {"TestData.csv" })]
        public void TestIfSkillExistsInSys_CsvData(string SkillName, bool expected)
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists(SkillName);
            TestContext.WriteLine(SkillName + "Testing");
            Assert.That(bskillexist, Is.EqualTo(expected));
        }

  


        [Test]
        [TestCase("ASP.NET MVC", ExpectedResult= true)]
        [TestCase("Project Planning", ExpectedResult = true)]
        [TestCase("Testing for fail", ExpectedResult = false)]
        public bool TestIfSkillExistsInSys_simplifiedTestCase(string SkillName)
        {
            return _skillRepository.CheckIfSkillNameExists(SkillName);

           
        }


        [Test]
        [TestCaseSource(typeof(NunitDataDriven_TestData), "TestCases_simplified")]
        public bool TestIfSkillExistsInSys_simplifiedTestCase_Centralized(string SkillName)
        {
            return _skillRepository.CheckIfSkillNameExists(SkillName);


        }
        [Test]
        [Sequential]
        public void TestIfSkillExistsInSys_CombineData(

      [Values("ASP.NET MVC", "Project Planning", "Test") ]string SkillName,
      [Values(true,true, false)] bool Expected)
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists(SkillName);
            TestContext.WriteLine(SkillName + "Testing");
            Assert.That(bskillexist, Is.EqualTo(Expected));
        }

    }
}

using NUnit.Framework;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using EmployeeSkillsManager.DomainClasses;
using System;

namespace Tests
{
    [TestFixture]
    public class TestUsingNunit
    {


        private StringBuilder _logBuilder = new StringBuilder();
        private EmployeeSkillsDBContext _context;
        private SkillRepository _skillRepository;
        private EmployeeSkillsRepository _EmployeeSkillsRepository;
        private string _log;


        [OneTimeSetUp]
        public void Setup()
        {
            _context = new EmployeeSkillsDBContext();
            _skillRepository = new SkillRepository(_context);
            _EmployeeSkillsRepository = new EmployeeSkillsRepository(_context);
            SetupLogging();
        }

        private void SetupLogging()
        {
            _context.Database.Log = BuildLogString;
        }
        private void BuildLogString(string message)
        {
            _logBuilder.Append(message);
            _log = _logBuilder.ToString();
        }
        private void WriteLog()
        {
            TestContext.WriteLine(_log);
            //Debug.WriteLine(_log);
        }
        [Test]
        public void TestIsEqual()
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists("ASP.NET MVC");
            TestContext.WriteLine("This is test output text");
            Assert.That(bskillexist, Is.EqualTo(true));
        }
        [Test]
        public void TestIsNotEqual()
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists("ASP.NET MVC1");
            WriteLog();
            Assert.That(bskillexist, Is.Not.EqualTo(true));
        }

        [Test]
        public void TestIsEqualWithCustomMessage()
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists("ASP.NET MVC1");
            WriteLog();
            Assert.That(bskillexist, Is.Not.EqualTo(true), "Skill does not exist in system");
        }


        [Test]
        public void ReferenceEqualityExample()
        {
            var a = new SkillRepository(_context);
            var b = a;
            var c = new SkillRepository(_context);

            Assert.That(a, Is.SameAs(b));
            Assert.That(a, Is.Not.SameAs(c));

            var x = new List<string> { "a", "b" };
            var y = x;
            var z = new List<string> { "a", "b" };

            Assert.That(y, Is.SameAs(x));
            Assert.That(z, Is.Not.SameAs(x));
        }

        [Test]
        public void Double()
        {
            double a = 1.0 / 6.0;
            Assert.That(a, Is.EqualTo(0.16).Within(10).Percent);
        }


        [Test]
        public void AssertingOnCollection()
        {
            var Skills = _skillRepository.All();

            Assert.That(Skills, Has.Exactly(4).Items);
        }
        [Test]
        public void AssertingOnCollection_unique()
        {
            var Skills = _skillRepository.All();

            Assert.That(Skills, Is.Unique);
        }
        [Test]
        public void AssertingOnCollection_AdditionalCheck()
        {
            var Skills = _skillRepository.All();

            //Assert.That(Skills, Has.Exactly(1).Property("Name").EqualTo("ASP.NET MVC").And.Property("Description").EqualTo("ASP.NET MVC"));


            Assert.That(Skills, Has.Exactly(1).Matches<Skill>(
                    item => item.Name == "ASP.NET MVC" &&
                           item.Description == "ASP.NET MVC"
                ));



            // Assert.That(Skills, Has.Exactly(1).Property("Name").EqualTo("ASP.NET MVC"));
        }


        [Test]
        public void TestIsNull()
        {
            string name = null;

            Assert.That(name, Is.Null);
        }
        [Test]
        public void TestIsNotNull()
        {
            string name = "Pratiksha";

            Assert.That(name, Is.Not.Null);

        }
        [Test]
        public void TestIsEmpty()
        {
            string name = "";

            Assert.That(name, Is.Empty);
        }
        [Test]
        public void TestIsNotEmpty()
        {
            string name = "Pratiksha";

            Assert.That(name, Is.Not.Empty);

        }
        [Test]
        public void TestStringCharactercheck()
        {
            string name = "Pratiksha";

            Assert.That(name, Does.StartWith("Prati"));

        }

        [Test]
        public void TestStringCharactercheck1()
        {
            string name = "Pratiksha";

            Assert.That(name, Does.EndWith("ha"));

        }

        [Test]
        public void TestStringCharactercheck2()
        {
            string name = "Pratiksha";

            Assert.That(name, Does.Contain("Prati"));

        }

        [Test]
        public void TestStringCharactercheck3()
        {
            string name = "Pratiksha";

            Assert.That(name, Does.Not.Contain("SARSI"));

        }

        [Test]
        [Category("test")]
        public void TestStringCharactercheck4()
        {
            string name = "Pratiksha";

            Assert.That(name, Does.StartWith("P").And.EndWith("a"));

        }

        [Test]
        [Category("test")]
        [Ignore("Don't forget to uncomment it later -:)")]
        public void TestIsTrue()
        {
            bool bskillexist = _skillRepository.CheckIfSkillNameExists("ASP.NET MVC");

            Assert.That(bskillexist, Is.True);
        }

        [Test]
        [Category("In Range Test Category")]
        [Category("test")]
        public void TestIsInRange()
        {
            int i = 45;

            //Assert.That(i, Is.GreaterThan(42));
            //Assert.That(i, Is.GreaterThanOrEqualTo(45));
           // Assert.That(i, Is.LessThan(48));
           //Assert.That(i, Is.LessThanOrEqualTo(49));
            Assert.That(i, Is.InRange(40,45));
        }

        [Test]
        [Category("In Range Test Category")]
        [Category("test")]
        public void TestDateIsInRange()
        {
            DateTime d1 = new DateTime(2000, 2, 20);
            DateTime d2 = new DateTime(2000, 2, 25);

            Assert.That(d1, Is.EqualTo(d2).Within(6).Days);
        }
    }
}

using NUnit.Framework;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using EmployeeSkillsManager.DomainClasses;
using System;
using Moq;
using EmployeeSkillsManager.Repository.Interfaces;
using Moq.Protected;
namespace EmployeeSkillsManager.UnitTest.MoqTests

{
    [TestFixture]
    public class TestWithMoq
    {
        [Test]
        public void TestMethod_MethodCall()
        {
            var skill = new Skill()
            {
                Description = "Project Management",
                Name = "Project Management",
                DateSkillAdded = DateTime.Now,
                ObjectState = ObjectState.Added,
                SkillCategoryID = 6
            };


            var SkillRepo = new Mock<ISkillRepository>();
              SkillRepo.Setup(x => x.InsertOrUpdate(skill));
         
            var skillObject = SkillRepo.Object;
            skillObject.InsertOrUpdate(skill);

            SkillRepo.Verify(x => x.InsertOrUpdate(It.IsAny<Skill>()), Times.Exactly(1));
        }


        [Test]
        public void TestMethod_MethodReturns()
        {
           

            var SkillRepo = new Mock<ISkillRepository>();
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            SkillRepo.Setup(x => x.CheckIfSkillNameExists("ASP.NET MVC")).Returns(true);
            bool test = skillObject.CheckIfSkillNameExists("ASP.NET MVC");
            SkillRepo.Verify(x => x.CheckIfSkillNameExists(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void TestMethod_MethodOut()
        {
            bool isValid = false;

            var SkillRepo = new Mock<ISkillRepository>();
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            SkillRepo.Setup(x => x.CheckIfSkillNameExists_OutTest("ASP.NET MVC", out isValid));
           skillObject.CheckIfSkillNameExists_OutTest("ASP.NET MVC", out isValid);
            SkillRepo.Verify(x => x.CheckIfSkillNameExists_OutTest(It.IsAny<string>(), out isValid), Times.Exactly(1));
        }


        [Test]
        public void TestMethod_MethodRef()
        {
            bool isValid = false;

            var SkillRepo = new Mock<ISkillRepository>();
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            SkillRepo.Setup(x => x.CheckIfSkillNameExists_RefTest("ASP.NET MVC", ref isValid));
            skillObject.CheckIfSkillNameExists_RefTest("ASP.NET MVC", ref isValid);
            SkillRepo.Verify(x => x.CheckIfSkillNameExists_RefTest(It.IsAny<string>(), ref It.Ref<bool>.IsAny), Times.Exactly(1));
        }


        [Test]
        public void TestMethod_PropertyTest()
        {
  

            var SkillRepo = new Mock<ISkillRepository>();
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            skillObject.TestTimeZone = "Test time Zone";
      
            SkillRepo.VerifySet(x => x.TestTimeZone = It.IsAny<string>());
        }


        [Test]
        public void TestMethod_CheckIfMethodCalled()
        {


            var SkillRepo = new Mock<ISkillRepository>(MockBehavior.Strict);
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            SkillRepo.Setup(x => x.CheckIfSkillNameExists("ASP.NET MVC")).Returns(true);
            bool test = skillObject.CheckIfSkillNameExists("ASP.NET MVC");
            SkillRepo.Verify(x => x.CheckIfSkillNameExists(It.IsAny<string>()), Times.Exactly(1));
        }


        [Test]
        public void TestMethod_ExceptionTest()
        {
            bool IsValid;

            var SkillRepo = new Mock<ISkillRepository>(MockBehavior.Strict);
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            SkillRepo.Setup(x => x.CheckIfSkillNameExists_OutTest("ASP.NET MVC", out IsValid)).Throws(new InvalidOperationException("Test"));
         skillObject.CheckIfSkillNameExists_OutTest("ASP.NET MVC", out IsValid);
  ;
        }


        [Test]
        public void TestMethod_DateTimeProperty()
        {

            var SkillRepo = new Mock<ISkillRepository>();
            var skillObject = SkillRepo.Object;
            //      SkillRepo.Setup(x => x.InsertOrUpdate(skill));
            skillObject.TestTimeZone = "Test time Zone";
            skillObject.TestDateTime = DateTime.Now;

            Assert.That(skillObject.TestDateTime, Is.EqualTo(DateTime.Now).Within(10).Seconds );
        }


        [Test]
        public void TestMethod_ProtectedMember()
        {
            var dbcontext = new Mock<EmployeeSkillsDBContext>();
            var SkillRepo = new Mock<SkillRepository>(dbcontext.Object);
            
            var skillObject = SkillRepo.Object;
            SkillRepo.Protected().Setup<string>("ProtectedFunction", ItExpr.IsAny<string>()).Returns("Test").Verifiable();

    


            skillObject.TestProtected();

            SkillRepo.Verify();
        }

    }
}

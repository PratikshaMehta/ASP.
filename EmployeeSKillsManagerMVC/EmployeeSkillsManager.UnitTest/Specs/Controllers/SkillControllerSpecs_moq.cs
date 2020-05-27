using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecsFor;
using Should;
using System.Threading.Tasks;
using EmployeeSkillsManager.Controllers;
using SpecsFor.StructureMap;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.DomainClasses;
using NUnit.Framework;
using Moq;

namespace EmployeeSkillsManager.UnitTest.Specs.Controllers
{
    public class SkillControllerSpecs_moq

        
    {
        public class when_creating_skills : SpecsFor<SkillsController>
        {

            //[Test]
            //public void TestMethod_MethodCall()
            //{
            //    var skill = new Skill()
            //    {
            //        Description = "Project Management",
            //        Name = "Project Management",
            //        DateSkillAdded = DateTime.Now,
            //        ObjectState = ObjectState.Added,
            //        SkillCategoryID = 6
            //    };


            //    var SkillRepo = new Mock<ISkillRepository>();
            //    SkillRepo.Setup(x => x.InsertOrUpdate(skill));

            //    var skillObject = SkillRepo.Object;
            //    skillObject.InsertOrUpdate(skill);

            //    SkillRepo.Verify(x => x.InsertOrUpdate(It.IsAny<Skill>()), Times.Exactly(1));
            //}

            protected override void Given()
            {
                var skill = new Skill()
                {
                    Description = "Project Management",
                    Name = "Project Management",
                    DateSkillAdded = DateTime.Now,
                    ObjectState = ObjectState.Added,
                    SkillCategoryID = 6
                };
                GetMockFor<ISkillRepository>().Setup(x => x.InsertOrUpdate(skill));
                GetMockFor<ISkillRepository>().Setup(x => x.CheckIfSkillNameExists("ASP.NET MVC")).Returns(true);
            }
            private Skill skillObject;
            bool test;

            protected override void When()
            {
                var skill = new Skill()
                {
                    Description = "Project Management",
                    Name = "Project Management",
                    DateSkillAdded = DateTime.Now,
                    ObjectState = ObjectState.Added,
                    SkillCategoryID = 6
                };
                skillObject = SUT.CreateSkill(skill);

                 test = SUT.CheckIfSkillExists("ASP.NET MVC");
            }
            [Test]
            public  void Then_Verify_InsertSkillCalled_Atleastonce()
            {
                GetMockFor<ISkillRepository>().Verify(x => x.InsertOrUpdate(It.IsAny<Skill>()), Times.Exactly(1));
            }

            [Test]
            public void Then_Verify_resulttype()
            {
                skillObject.ShouldBeType<Skill>();
            }

            [Test]
            public void Then_Verify_CheckIfSkillNameExists_Called()
            {
                GetMockFor<ISkillRepository>().Verify(x => x.CheckIfSkillNameExists(It.IsAny<string>()), Times.Exactly(1));
            }

        }



        public class when_Checking_IfSkillExists : SpecsFor<SkillsController>
        {


            protected override void Given()
            {
                bool IsValid_Test1 = false;
                bool IsValid_Test2 = false;
                GetMockFor<ISkillRepository>().Setup(x => x.CheckIfSkillNameExists("ASP.NET MVC")).Returns(true);
                GetMockFor<ISkillRepository>().Setup(x => x.CheckIfSkillNameExists_OutTest("ASP.NET MVC", out IsValid_Test1));
                GetMockFor<ISkillRepository>().Setup(x => x.CheckIfSkillNameExists_RefTest("ASP.NET MVC", ref IsValid_Test2));

            }
            private bool test;
            private bool validate1=false;
            private bool validate = false;
            protected override void When()
            {

                test = SUT.CheckIfSkillExists("ASP.NET MVC");
                SUT.CheckIfSkillNameExists_OutTest("ASP.NET MVC", out validate);
                SUT.CheckIfSkillNameExists_RefTest("ASP.NET MVC", ref validate1);
            }
            [Test]
            public void Then_Verify_MethodCalled_Atleastonce()
            {
                GetMockFor<ISkillRepository>().Verify(x => x.CheckIfSkillNameExists(It.IsAny<string>()), Times.Exactly(1));
                GetMockFor<ISkillRepository>().Verify(x => x.CheckIfSkillNameExists_OutTest(It.IsAny<string>(), out validate), Times.Exactly(1));                
                GetMockFor<ISkillRepository>().Verify(x => x.CheckIfSkillNameExists_RefTest(It.IsAny<string>(), ref It.Ref<bool>.IsAny), Times.Exactly(1));
            }

            [Test]
            public void Then_verify_skillExists()
            {
                test.ShouldBeTrue();
            }



        }

    }
}

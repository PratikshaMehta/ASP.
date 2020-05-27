using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EmployeeSkillsManagerJson.Controllers;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using System.Web.Mvc;
using EmployeeSkillsManager.DomainClasses;
namespace EmployeeSkillsManager.UnitTest
{
    [TestClass]
    public class ControllersTest
    {

        [TestMethod]
        public void TestGetEmployeeSkills()
        {
            IEmployeeSkillsRepository _EmployeeSkillsRepository = new EmployeeSkillsRepository(new EmployeeSkillsDBContext());
            //arrange     
            EmployeeSkillsController controller = new EmployeeSkillsController(_EmployeeSkillsRepository);
            dynamic data = ((JsonResult)controller.GetEmployeeSkill(2, 2)).Data;       
            Assert.IsNotNull(data);    
        }

    }
}

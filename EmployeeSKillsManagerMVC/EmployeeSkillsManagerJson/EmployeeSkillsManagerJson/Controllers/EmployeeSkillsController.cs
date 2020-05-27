using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
namespace EmployeeSkillsManagerJson.Controllers
{
    public class EmployeeSkillsController : Controller
    {

        private IEmployeeSkillsRepository _EmployeeSkillsRepository;

        public EmployeeSkillsController(IEmployeeSkillsRepository repo)
        {
            this._EmployeeSkillsRepository = repo;
        }



        [HttpGet]
        public JsonResult GetEmployeeSkills()
        {

            var employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillsList();
            
            return Json(employeeSkills, JsonRequestBehavior.AllowGet);
        }


        [Route("EmployeeSkills/GetEmployeeSkill/{EmployeeID}/{SkillID}")]
        public ActionResult GetEmployeeSkill(int EmployeeID, int SkillID)
        {

            return Json(_EmployeeSkillsRepository.GetEmployeeSkill(EmployeeID, SkillID), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateEmployeeSkill(EmployeeSkills EmployeeSkill)
        {
        

            _EmployeeSkillsRepository.InsertEmployeeSkill(EmployeeSkill);
            _EmployeeSkillsRepository.Save();
            return Json("Inserted record successfully", JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateEmployeeSkill(EmployeeSkills EmployeeSkil)
        {
         
            _EmployeeSkillsRepository.UpdateEmployeeSkill(EmployeeSkil);
            _EmployeeSkillsRepository.Save();
            return Json("Updated record successfully", JsonRequestBehavior.AllowGet);

        }

        [HttpDelete]
        public JsonResult DeleteEmployeeSkill(int EmployeeID, int SkillID)
        {

         

            _EmployeeSkillsRepository.EmployeeSkillDelete(EmployeeID, SkillID);

            _EmployeeSkillsRepository.Save();
            return Json("Deleted record successfully", JsonRequestBehavior.AllowGet);
        }
    }
}

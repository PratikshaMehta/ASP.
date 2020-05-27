using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
using Newtonsoft.Json;

namespace EmployeeSkillsManagerJson.Controllers
{
    public class SkillsController : Controller
    {
        private ISkillRepository _SkillsRepository;

        public SkillsController(ISkillRepository repo)
        {
            this._SkillsRepository = repo;
        }


        //Get /Api/Skills
        public JsonResult GetSkills()
        {
            var data = _SkillsRepository.GetListOfSkills();
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);

            return Json(data, JsonRequestBehavior.AllowGet);
        }

        //Get /Api/Skills/1
        public JsonResult GetSkill(int id)
        {
            var data = _SkillsRepository.GetSkillByID(id);
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);
            return Json(data, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult CreateSkill(Skill skill)
        {
         
            skill.ObjectState = ObjectState.Added;
            _SkillsRepository.InsertOrUpdate(skill);
            _SkillsRepository.Save();
            return Json("Inserted record successfully", JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateCapacity(Skill skill)
        {
          
            skill.ObjectState = ObjectState.Modified;
            _SkillsRepository.InsertOrUpdate(skill);
            _SkillsRepository.Save();

            return Json("Updated record successfully", JsonRequestBehavior.AllowGet);
        }

        [HttpDelete]
        public JsonResult DeleteSkill(int id)
        {

           
            Skill skill = _SkillsRepository.GetSkillByID(id);
            skill.ObjectState = ObjectState.Deleted;
            _SkillsRepository.Delete(skill);
      

            _SkillsRepository.Save();
            return Json("Deleted record successfully", JsonRequestBehavior.AllowGet);
        }
    }
}
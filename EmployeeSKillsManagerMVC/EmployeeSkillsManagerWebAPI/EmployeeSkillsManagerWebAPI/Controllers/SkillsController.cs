using System.Collections.Generic;
using System.Net;
using System.Web.Http;

using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;


namespace EmployeeSkillsManager.Controllers
{
    public class SkillsController : ApiController
    {
        private ISkillRepository _SkillsRepository;

        public SkillsController(ISkillRepository repo)
        {
            this._SkillsRepository = repo;
        }


        //Get /Api/Skills
        public IEnumerable<Skill> GetSkills()
        {

            return _SkillsRepository.GetListOfSkills();
        }

        //Get /Api/Skills/1
        public Skill GetSkill(int id)
        {
            return _SkillsRepository.GetSkillByID(id);

        }

   
        public bool CheckIfSkillExists(string skillname)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            return _SkillsRepository.CheckIfSkillNameExists(skillname);
        }


        public void CheckIfSkillNameExists_OutTest(string SkillName, out bool validate)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
              _SkillsRepository.CheckIfSkillNameExists_OutTest(SkillName , out validate);
        }


        public void CheckIfSkillNameExists_RefTest(string SkillName, ref bool validate)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            _SkillsRepository.CheckIfSkillNameExists_RefTest(SkillName, ref validate);
        }
        [HttpPost]
        public Skill CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            skill.ObjectState = ObjectState.Added;
            _SkillsRepository.InsertOrUpdate(skill);
            _SkillsRepository.Save();
            return skill;
        }

        [HttpPut]
        public void UpdateCapacity(Skill skill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            skill.ObjectState = ObjectState.Modified;
            _SkillsRepository.InsertOrUpdate(skill);
            _SkillsRepository.Save();


        }

        [HttpDelete]
        public void DeleteSkill(int id)
        {

            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Skill skill = _SkillsRepository.GetSkillByID(id);
            skill.ObjectState = ObjectState.Deleted;
            _SkillsRepository.Delete(skill);
      

            _SkillsRepository.Save();
        }
    }
}
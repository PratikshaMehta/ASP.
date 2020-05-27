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
        private ISkillRepository _CapacityRepository;

        public SkillsController()
        {
            this._CapacityRepository = new SkillRepository(new EmployeeSkillsDBContext());
        }


        //Get /Api/Skills
        public IEnumerable<Skill> GetSkills()
        {

            return _CapacityRepository.Get_List_of_Skills();
        }

        //Get /Api/Skills/1
        public Skill GetSkill(int id)
        {
            return _CapacityRepository.GetSkillByID(id);

        }

        [HttpPost]
        public Skill CreateSkill(Skill skill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _CapacityRepository.AddSkill(skill);
            _CapacityRepository.Save();
            return skill;
        }

        [HttpPut]
        public void UpdateCapacity(Skill skill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _CapacityRepository.UpdateSkill(skill);
            _CapacityRepository.Save();


        }

        //[HttpDelete]
        //public void DeleteCapacity(int id)
        //{

        //    if (!ModelState.IsValid)
        //    {

        //        throw new HttpResponseException(HttpStatusCode.BadRequest);
        //    }

        //    _CapacityRepository.CapacityDelete(id);

        //    _CapacityRepository.Save();
        //}
    }
}
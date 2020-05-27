using System.Collections.Generic;
using System.Net;
using System.Web.Http;

using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
namespace EmployeeSkillsManagerWebAPI.Controllers
{
    public class EmployeeSkillsController : ApiController
    {

        private IEmployeeSkillsRepository _EmployeeSkillsRepository;

        public EmployeeSkillsController(IEmployeeSkillsRepository repo)
        {
            this._EmployeeSkillsRepository = repo;
        }


        //Get /Api/Skills

     


        [HttpGet]
        public IEnumerable<EmployeeSkillsViewModel> GetEmployeeSkills()
        {

            var employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillsList();
            return employeeSkills;
        }

        //Get /Api/Skills/1
        [Route("Api/EmployeeSkills/GetEmployeeSkill/{EmployeeID}/{SkillID}")]
        public EmployeeSkills GetEmployeeSkill(int EmployeeID, int SkillID)
        {
            return _EmployeeSkillsRepository.GetEmployeeSkillByID(EmployeeID, SkillID);

        }

        [HttpPost]
        public EmployeeSkills CreateEmployeeSkill(EmployeeSkills EmployeeSkill)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _EmployeeSkillsRepository.InsertEmployeeSkill(EmployeeSkill);
            _EmployeeSkillsRepository.Save();
            return EmployeeSkill;
        }

        [HttpPut]
        public void UpdateEmployeeSkill(EmployeeSkills EmployeeSkil)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _EmployeeSkillsRepository.UpdateEmployeeSkill(EmployeeSkil);
            _EmployeeSkillsRepository.Save();


        }

        [HttpDelete]
        public void DeleteCapacity(int EmployeeID, int SkillID)
        {

            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _EmployeeSkillsRepository.EmployeeSkillDelete(EmployeeID, SkillID);

            _EmployeeSkillsRepository.Save();
        }
    }
}

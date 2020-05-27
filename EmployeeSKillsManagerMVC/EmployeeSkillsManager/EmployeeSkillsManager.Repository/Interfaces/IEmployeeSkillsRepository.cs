using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.Repository.Interfaces
{ 
    public interface IEmployeeSkillsRepository : IDisposable
    {
        IQueryable<EmployeeSkills> GetListOfEmployeeSkills();
        void UpdateEmployeeSkill(EmployeeSkills EmployeeSkills);
            void InsertEmployeeSkill(EmployeeSkills EmployeeSkills);
        void Save();
        void EmployeeSkillDelete(int? EmployeeId, int? SkillID);
        EmployeeSkills GetEmployeeSkillByID(int? EmployeeID, int? SkillID);
        dynamic GetEmployeeSkill(int EmployeeID, int SkillID);
        IEnumerable<EmployeeSkillsViewModel> GetEmployeeSkillsList();
        
    }
}

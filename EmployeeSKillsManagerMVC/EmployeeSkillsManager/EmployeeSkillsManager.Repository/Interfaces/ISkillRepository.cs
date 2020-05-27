using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.Repository.Interfaces
{
    public interface ISkillRepository : IDisposable, IBaseInstanceRepository<Skill>
    {
        DateTime TestDateTime { get; set; }
        string TestTimeZone { get;  set; }
        List<Skill> GetListOfSkills();
    bool CheckIfSkillNameExists(string SkillName);
        void CheckIfSkillNameExists_OutTest(string SkillName, out bool validate);
        void CheckIfSkillNameExists_RefTest(string SkillName, ref bool validate);
        List<Skill> GetSkillCategoriesList();

        void PropertySetTest();
        Skill GetSkillByID(int id);


        string TestProtected();

    }
   
}

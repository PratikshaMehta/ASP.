using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.DomainClasses;


namespace EmployeeSkillsManager.Repository.Interfaces

{
    public interface IDepartmentRepository : IDisposable, IBaseInstanceRepository<Department>
    {
        List<Department> GetListOfDepartments();
        bool CheckDepartmentNameExists(string DepartmentName);
       
        Department GetDepartmentByID(int id);

    
    }
}

using EmployeeSkillsManager.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillsManager.Repository.Interfaces
{
    public interface IEmployeeRepository : IDisposable, IBaseInstanceRepository<Employee>
    {
        IQueryable<Employee> GetListofEmployees();
        bool CheckEmployeeNameExists(string EmployeeName);     
        Employee GetEmployeeByID(int id);

        Employee GetFirstEmployeeName_Query(int SkillID);
        Employee GetFirstEmployeeName_Method(int SkillID);
        List<Employee> GetListOfEmployeesWithDept(int SkillID);
        List<Department> GetListOfDepartments();
    }
}

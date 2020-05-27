using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.Repository.Interfaces
{
    public interface IBaseInstanceRepository<T> where T : class
    {
        IQueryable<T> GetAll();
      
        void InsertOrUpdate(T obj);    
        void Delete(T obj);
        void Save();
    }
}

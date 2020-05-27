using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.Repository.Interfaces
{
    public interface ICategoryRepository : IDisposable, IBaseInstanceRepository<Category>
    {
        List<Category> GetSkillCategoriesList();   

        Category GetCategoryByID(int id);
     

        //void DeleteSkillCategory(int CategoryID);
        //}
    }
}
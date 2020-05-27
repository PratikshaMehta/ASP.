using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.Repository.Repositories
{
    public class CategoryRepository : BaseInstanceRepository<Category>, ICategoryRepository
    {


        private EmployeeSkillsDBContext _context;

        private BaseInstanceRepository<Category> _repo;


        //private EmployeeSkillsDBContext _context;
        public CategoryRepository(EmployeeSkillsDBContext Context) : base(Context)
        {
            _context = Context;
            _repo = new BaseInstanceRepository<Category>(Context);

        }

        public Category GetCategoryByID(int id)
        {
            return _repo.FindByKey(id);
        }



        public List<Category> GetSkillCategoriesList()
        {
            try
            {
                return _repo.All().ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }



        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }





    }






}


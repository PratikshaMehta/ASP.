using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.DomainClasses;
using System.Data.Entity;
namespace EmployeeSkillsManager.Repository.Repositories
{
    public class DepartmentRepository : BaseInstanceRepository<Department>, IDepartmentRepository
    {


        private EmployeeSkillsDBContext _context;
        private BaseInstanceRepository<Department> _repo;


        //private EmployeeSkillsDBContext _context;
        public DepartmentRepository(EmployeeSkillsDBContext Context) : base(Context)
        {
            this._context = Context;
            _repo = new BaseInstanceRepository<Department>(Context);
        }


        public Department GetDepartmentByID(int id)
        {
            return _repo.FindByKey(id);
        }

        public bool CheckDepartmentNameExists(string DepartmentName)
        {
            try
            {

                var result = (from user in _repo.GetAll()
                              where user.Name == DepartmentName
                              select user).Count();

                if (result > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Department> GetListOfDepartments()
        {
            try
            {
                return _repo.GetAll().ToList();
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


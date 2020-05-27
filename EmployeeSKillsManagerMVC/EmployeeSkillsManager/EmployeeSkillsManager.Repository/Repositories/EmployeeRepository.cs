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
    public class EmployeeRepository : BaseInstanceRepository<Employee>, IEmployeeRepository
    {

        private EmployeeSkillsDBContext _context;
        private BaseInstanceRepository<Employee> _repo;
        public EmployeeRepository(EmployeeSkillsDBContext Context) : base(Context)
        {
            this._context = Context;
            _repo = new BaseInstanceRepository<Employee>(Context);
        }

        public Employee GetEmployeeByID(int id)
        {
            return _repo.FindByKey(id);
        }
        //LINQ Where clause 
        public bool CheckEmployeeNameExists(string EmployeeName)
        {
            try
            {

                var result = (from Employeename in _repo.GetAll()
                              where Employeename.Name == EmployeeName
                              orderby Employeename ascending
                              select Employeename).Count();

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


        //LINQ FirstOrDefault 
        public Employee GetFirstEmployeeName_Query(int SkillID)
        {

            var EmpNameQuery = (from e in _repo.GetAll()
                                select e).FirstOrDefault<Employee>();
            return EmpNameQuery;

        }

        public Employee GetFirstEmployeeName_Method(int SkillID)
        {

            var EmpNameQuery = _repo.GetAll()
                   .FirstOrDefault<Employee>();
            return EmpNameQuery;

        }

        //LINQ Eager loading
        public List<Employee> GetListOfEmployeesWithDept(int SkillID)

        {
            var query = _repo.GetAll().Include("Department").ToList();
            return query;

        }
        public List<Skill> GetListofSkills()
        {
            try
            {
                return _context.Skills.ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }
    

        public IQueryable<Employee> GetListofEmployees()
        {
            try
            {
                return _repo.GetAll().Include(d=>d.Department);
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
                return _context.Departments.ToList();
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

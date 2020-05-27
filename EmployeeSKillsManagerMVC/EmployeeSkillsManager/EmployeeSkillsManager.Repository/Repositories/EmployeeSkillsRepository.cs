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
    public class EmployeeSkillsRepository : IEmployeeSkillsRepository 
    {
        private EmployeeSkillsDBContext _context;



        //private EmployeeSkillsDBContext _context;
        public EmployeeSkillsRepository(EmployeeSkillsDBContext Context)
        {
            this._context = Context;
        }

        public IEnumerable<EmployeeSkillsViewModel> GetEmployeeSkillsList()
        {
            try
            {


                return from EmpSkill in _context.EmployeeSkills.Include(a => a.Skill.Category).Include(d => d.Employee.Department)
                       orderby EmpSkill.Employee.Department.Name, EmpSkill.Employee.Name
                       select new EmployeeSkillsViewModel
                       {
                           Department = EmpSkill.Employee.Department.Name,
                           EmployeeID = EmpSkill.EmployeeID,
                           Employee = EmpSkill.Employee.Name,
                           SkillCategory = EmpSkill.Skill.Category.Name,
                           SkillID = EmpSkill.SkillID,
                           Skill = EmpSkill.Skill.Name,
                           ProficiencyLevel = EmpSkill.SkillLevel,
                           ModifiedDate = EmpSkill.ModofiedDate

                       };



            }
            catch (Exception)
            {
                throw;
            }
        }
        public dynamic GetEmployeeSkill(int EmployeeID, int SkillID)
        {



            var query = from EmpSkill in _context.EmployeeSkills.Include(a => a.Skill.Category).Include(d => d.Employee.Department)
                        orderby EmpSkill.Employee.Department.Name, EmpSkill.Employee.Name
                        where EmpSkill.EmployeeID == EmployeeID && EmpSkill.SkillID == SkillID
                        select new
                        {
                            Department = EmpSkill.Employee.Department.Name,
                            EmployeeID = EmpSkill.EmployeeID,
                            Employee = EmpSkill.Employee.Name,
                            SkillCategory = EmpSkill.Skill.Category.Name,
                            SkillID = EmpSkill.SkillID,
                            Skill = EmpSkill.Skill.Name,
                            ProficiencyLevel = EmpSkill.SkillLevel,
                            ModifiedDate = EmpSkill.ModofiedDate

                        };

            return query.ToList();
        }
        public IQueryable<EmployeeSkills> GetListOfEmployeeSkills()
        {
            try
            {
                return _context.EmployeeSkills.Include(e => e.Skill).Include(a => a.Skill.Category);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void UpdateEmployeeSkill(EmployeeSkills EmployeeSkills)
        {
        

            if (EmployeeSkills != null)
            {
                _context.Entry(EmployeeSkills).State = EntityState.Modified;
                _context.SaveChanges();              
            }
          
        }
        public void InsertEmployeeSkill(EmployeeSkills EmployeeSkills)
        {
            try
            {
              
                if (EmployeeSkills != null)
                {
                    _context.EmployeeSkills.Add(EmployeeSkills);
                    _context.SaveChanges();
                 
                }
            

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EmployeeSkillDelete(int? EmployeeId, int? SkillID)
        {
            try
            {

                EmployeeSkills employeeSkills = _context.EmployeeSkills.SingleOrDefault(c => c.EmployeeID== EmployeeId && c.SkillID == SkillID);
                _context.EmployeeSkills.Remove(employeeSkills);

            }
            catch (Exception)
            {
                throw;
            }
        }
        public void Save()
        {
            _context.SaveChanges();
        }

    
        public EmployeeSkills GetEmployeeSkillByID(int? EmployeeID, int? SkillID)
        {


            var query = _context.EmployeeSkills.SingleOrDefault(c => c.EmployeeID == EmployeeID && c.SkillID == SkillID);

            return query;



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



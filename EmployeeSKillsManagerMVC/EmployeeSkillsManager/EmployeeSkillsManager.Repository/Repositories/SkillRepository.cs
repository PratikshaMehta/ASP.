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
    public class SkillRepository : BaseInstanceRepository<Skill>, ISkillRepository 
    {
        public virtual DateTime TestDateTime { get; set; }
        public virtual string TestTimeZone { get;  set; }
     
        private EmployeeSkillsDBContext _context;
        private BaseInstanceRepository<Skill> _repo;

        //private EmployeeSkillsDBContext _context;
        public SkillRepository(EmployeeSkillsDBContext Context) : base(Context)
        {
            this._context = Context;
            _repo = new BaseInstanceRepository<Skill>(Context);
        }

        public Skill GetSkillByID(int id)
        {
            return _repo.FindByKey(id);
        }
        public List<Skill> GetSkillCategoriesList()
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
        public virtual bool CheckIfSkillNameExists(string SkillName)
        {
            try
            {

                var result = (from Skillname in _repo.GetAll()
                              where Skillname.Name == SkillName
                             
                              select Skillname).Count();

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


        public virtual void PropertySetTest()
        {
            try
            {

             TestTimeZone = TimeZone.CurrentTimeZone.StandardName;
            }
            catch (Exception)
            {
                throw;
            }
        }
     

        public virtual string TestProtected()
        {
            try
            {
              return ProtectedFunction("SAPTest");
             
            }
            catch (Exception)
            {
                throw;
            }
        }
        protected virtual string ProtectedFunction(string value)
        {
            try
            {

                return value.Replace("SAP", string.Empty);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public virtual void CheckIfSkillNameExists_OutTest(string SkillName, out bool validate)
        {
            try
            {

                var result = (from Skillname in _repo.GetAll()
                              where Skillname.Name == SkillName

                              select Skillname).Count();

                if (result > 0)
                {
                    validate =  true;
                }
                else
                {
                    validate = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }

        public virtual void CheckIfSkillNameExists_RefTest(string SkillName, ref bool validate)
        {
            try
            {

                var result = (from Skillname in _repo.GetAll()
                              where Skillname.Name == SkillName

                              select Skillname).Count();

                if (result > 0)
                {
                    validate = true;
                }
                else
                {
                    validate = true;
                }

            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Skill> GetListOfSkills()
        {
            try
            {
                return _repo.GetAll().Include(a=>a.Category).ToList();
            }
            catch (Exception)
            {
                throw;
            }
        }


        //public List<CapacityCategory> GetListOfSkillsForCategory(int CategoryID)
        //{
        //    try
        //    {
        //        var query =
        //             from c in _context.Skills
        //             where c.CapacityCategoryID == CategoryID
        //             orderby c.Category ascending, c.Name ascending
        //             select new SkillCategory { CategoryName = c.Category.Name, SkillName = c.Name };
        //        return query.ToList();

        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
               
       

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




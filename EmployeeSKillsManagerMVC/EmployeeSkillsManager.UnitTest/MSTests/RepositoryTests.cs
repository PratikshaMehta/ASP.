using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillsManager.UnitTest
{



    [TestClass]
    public class RepositoryTest
    {
        private StringBuilder _logBuilder = new StringBuilder();
        private EmployeeSkillsDBContext _context;
        private SkillRepository _skillRepository;
        private EmployeeSkillsRepository _EmployeeSkillsRepository;
        private string _log;

    
        public RepositoryTest()
        {
            _context = new EmployeeSkillsDBContext();
            _skillRepository = new SkillRepository(_context);
            _EmployeeSkillsRepository= new EmployeeSkillsRepository(_context);
            SetupLogging();
        }


        [TestMethod]
        public void GetEmployeeSkills()
        {
            _EmployeeSkillsRepository.GetEmployeeSkillsList().ToList();
            WriteLog();
            Assert.IsFalse(_log.Contains("Select"));
        }


        [TestMethod]
        public void GetAllSkillsTest()
        {
            _skillRepository.All().Where(c => c.Name == "ASP.NET MVC").ToList();
            WriteLog();
            Assert.IsFalse(_log.Contains("ASP.NET MVC"));
        }

        public void FindByKey_SkillTest()
        {
            _skillRepository.GetSkillByID(2);
            WriteLog();
            Assert.IsFalse(_log.Contains("ASP.NET MVC"));
        }
        private void WriteLog()
        {
            Debug.WriteLine(_log);
        }
        private void SetupLogging()
        {
            _context.Database.Log = BuildLogString;
        }

        private void BuildLogString(string message)
        {
            _logBuilder.Append(message);
            _log = _logBuilder.ToString();
        }
    }
}

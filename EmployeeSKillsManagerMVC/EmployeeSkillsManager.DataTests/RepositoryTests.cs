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

        private SkillRepository _skillRepository;
        private string _log;

        public RepositoryTest()
        {
            _skillRepository = new SkillRepository(new EmployeeSkillsDBContext());
        }

        [TestMethod]
        public void GetAllSkillsTest()

        {

            _skillRepository.All().Where(c => c.Name == "ASP.NET MVC").ToList();
            WriteLog();
            Assert.IsFalse(_log.Contains("ASP.NET MVC"));
        }
         private void WriteLog()
        {
            Debug.WriteLine(_log);
        }
    }
}

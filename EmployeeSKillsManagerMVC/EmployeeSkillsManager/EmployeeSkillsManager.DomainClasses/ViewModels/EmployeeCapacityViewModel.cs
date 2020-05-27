using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeSkillsManager.DomainClasses;

namespace EmployeeSkillsManager.DomainClasses.ViewModels
{
    class EmployeeSkillsViewModel
    {
      
        public Employee Employee { get; set; }

        public IEnumerable<Skill> Skills { get; set; }
        public Department Department { get; set; }
    }
}

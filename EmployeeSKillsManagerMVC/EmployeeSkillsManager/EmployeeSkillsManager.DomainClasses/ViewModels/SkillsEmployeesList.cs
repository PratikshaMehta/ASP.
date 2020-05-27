using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace EmployeeSkillsManager.DomainClasses
{
    [NotMapped]
    public class SkillEmployeeList
    {
        
        public List<string> EmployeeName { get; set; }
    }
}

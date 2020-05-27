using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace EmployeeSkillsManager.DomainClasses
{
    [NotMapped]
    public class EmployeeSkillsViewModel
    {
        public string Department { get; set; }
        public int EmployeeID { get; set; }
        public string Employee { get; set; }
        public string SkillCategory { get; set; }

        public int SkillID { get; set; }
        public string Skill { get; set; }
        public int ProficiencyLevel { get; set; }
        public DateTime? ModifiedDate { get; set; }

    }
    
}
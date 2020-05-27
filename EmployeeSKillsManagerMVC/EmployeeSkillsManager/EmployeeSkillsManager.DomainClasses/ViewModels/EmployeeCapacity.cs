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
    public class EmployeeSkillsList
    {
       
        public List<string> SkillName { get; set; }
    }
}

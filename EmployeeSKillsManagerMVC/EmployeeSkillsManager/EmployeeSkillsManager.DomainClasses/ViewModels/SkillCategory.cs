using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeSkillsManager.DomainClasses
{

    [NotMapped]
    public class SkillCategory
    {     public string CategoryName { get; set; }
        public string SkillName { get; set; }
   
      

    }

}

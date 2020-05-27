﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EmployeeSkillsManager.DomainClasses
{
    [NotMapped]
  public  class EmployeeDepartment
    {
        public string EmployeeName { get; set; }
        public string DepartmentName { get; set; }
    }
}

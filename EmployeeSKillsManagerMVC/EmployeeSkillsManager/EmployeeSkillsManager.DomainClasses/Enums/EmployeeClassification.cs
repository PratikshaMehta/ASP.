using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EmployeeSkillsManager.DomainClasses
{
    public enum EmployeeClassification
    {
        Employee = 1,
        Contactor,
        Student,
        Other
    }
}
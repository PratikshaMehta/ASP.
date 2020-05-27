using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SpecsFor;
using Should;
using System.Threading.Tasks;
using EmployeeSkillsManager.Controllers;
using SpecsFor.StructureMap;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.DomainClasses;
using NUnit.Framework;
using Moq;

using StructureMap;
using EmployeeSkillsManager.Repository.Repositories;

namespace EmployeeSkillsManager.UnitTest.Specs.Controllers
{
    public class SkillControllerSpecs_concreteObj : SpecsFor<SkillsController>
    {
        private ISkillRepository _SkillsRepository;
        public class when_creating_skills : SpecsFor<SkillsController>
        {
        }

    }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeSkillsManager.UnitTest.Specs
{
   
        public interface INeedMediator : ISpecs
        {

        }

        public class MediatorProvider : Behavior<INeedMediator>
        {
            public override void SpecInit(INeedMediator instance)
            {
                instance.MockContainer.Configure(cfg => cfg.AddRegistry(new MediatorRegistry()));
            }
        }
   
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;
namespace EmployeeSkillsManager.UnitTest
{
    public class NunitDataDriven_TestData
    {
        public static IEnumerable TestCases
        {

            get
            {
                yield return new TestCaseData("ASP.NET MVC", true);
                yield return new TestCaseData("Project Planning", true);
                yield return new TestCaseData("Test", false);
            }
        }
        public static IEnumerable TestCases_simplified
        {

            get
            {
                yield return new TestCaseData("ASP.NET MVC").Returns(true);
                yield return new TestCaseData("Project Planning").Returns(true);
                yield return new TestCaseData("Test").Returns(false);
            }
        }
    }
}

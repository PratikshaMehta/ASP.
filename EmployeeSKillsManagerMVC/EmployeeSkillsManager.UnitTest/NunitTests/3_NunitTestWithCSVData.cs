using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections;
using System.IO;

namespace EmployeeSkillsManager.UnitTest
{
    public class NunitTestWithCSVData
    {
        public static IEnumerable GetTestCases(string csvFileName)
        {
            var csvLines = File.ReadAllLines(csvFileName);

            var testCases = new List<TestCaseData>();

            foreach (var line in csvLines)
            {
                string[] values = line.Replace(" ", "").Split(',');

                string skill = values[0].ToString();
                bool Expected = Convert.ToBoolean(values[1]);
            

                testCases.Add(new TestCaseData(skill, Expected));
            }

            return testCases;
        }
    }
}

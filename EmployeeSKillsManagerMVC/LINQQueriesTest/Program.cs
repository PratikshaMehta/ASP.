using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQQueriesTest
{
    class Program
    {
        static EmployeeSkillsDBContext _Context = new EmployeeSkillsDBContext();

        static void Main(string[] args)
        {
            Test1();
            Test2();
            TestGroupBy();
            TestInnerJoin();
            TestGroupJoin();
            TestCrossJoin();
            GetEmployeesListForSkill();
        }

        public static void Test1()
        {
            Console.WriteLine("*************Test 1**************");
            //Query syntax
            var query = from c in _Context.Employees
                        where c.Name.Contains("Pratiksha")
                        orderby c.Name, c.TotalExp descending
                        select new { Name = c.Name, Department = c.Department.Name };

            foreach (var e in query)
                Console.WriteLine("Department - {0}, Employee - {1}", e.Department, e.Name);

            //Method syntax
            query = _Context.Employees
                       .Where(c => c.Name.Contains("Pratiksha"))
                       .OrderBy(c => c.Name).ThenByDescending(c => c.TotalExp)
                       .Select(c => new { Name = c.Name, Department = c.Department.Name });

            foreach (var e in query)
                 Console.WriteLine("Department - {0}, Employee - {1}", e.Department, e.Name);
               
        }

        public static void Test2()
        {
            Console.WriteLine("*************Test 2**************");


            var Employees = _Context.Departments
                            .Where(c => c.DepartmentID == 1)
                             .SelectMany(c => c.Employees).ToList();

            foreach (var Emp in Employees)
            {
                
                Console.WriteLine(Emp.Name);

            }

            //many to many relation, SelectMany example, select employees with skill level 5
              
                var query = _Context.Employees
                            .SelectMany(c => c.EmployeeSkills
                                        .Where(i => (i.SkillLevel == 5) == true),
                                        (c, i) => c).Distinct();


                foreach (var Emp in Employees)
                {

                    Console.WriteLine("Employee with skill level 5: " + Emp.Name);

                }


            }

        public static void TestGroupBy()
        {
            Console.WriteLine("*************Test 3**************");
            //Group by

            var query = from c in _Context.Employees
                        group c by c.Department.Name
                        into g
                        select g;

            foreach (var group in query)
            {

                Console.WriteLine(group.Key);
                foreach (var emp in group)
                {
                    Console.WriteLine("\t" + emp.Name);
                }

                }
            

        var query1 = _Context.Employees.GroupBy(c => c.Department.Name);
                  

            foreach (var group in query1)
            {

                Console.WriteLine(group.Key);
                foreach (var emp in group)
                {
                    Console.WriteLine("\t" + emp.Name);
                }

}
            }

        public static void TestInnerJoin()
        {
            Console.WriteLine("*************Test Inner Join**************");

            var query =
                from emp in _Context.Employees
                join empskill in _Context.EmployeeSkills on emp.EmployeeID equals empskill.EmployeeID
                select new { EmployeeName = emp.Name, Skill = empskill.Skill.Name };


            foreach (var e in query)
                Console.WriteLine("Employee - {0}, Skill - {1}", e.EmployeeName, e.Skill);


            var query1 =  _Context.Employees.Join(_Context.EmployeeSkills, c => c.EmployeeID, a => a.EmployeeID, (Employees, EmployeeSkills) => new { EmployeeName = Employees.Name, Skill = EmployeeSkills.Skill.Name });
    
      


            foreach (var e in query1)
                Console.WriteLine("Employee - {0}, Skill - {1}", e.EmployeeName, e.Skill);


        }

        public static void TestGroupJoin()
        {
            Console.WriteLine("*************Test Group Join**************");

            //var query =
            //    from dept in _Context.Departments
            //    join emp in _Context.Employees on dept.EmployeeID equals emp.EmployeeID into g
            //    select new { Department = dept.Name, NumberOfEmployees = g.Count() };




            ////foreach (var e in query)
            ////    Console.WriteLine("Employee - {0}, Skill - {1}", e.EmployeeName, e.Skill);


            var query =
              _Context.Departments.GroupJoin(_Context.Employees, a => a.DepartmentID, d => d.EmployeeDepartmentID, (Departments, Employees) => new { Department = Departments.Name, NumberofEmployees = Employees.Count() });


            foreach (var e in query)
                Console.WriteLine("Department - {0}, Number of Employees - {1}", e.Department, e.NumberofEmployees);




        }

        public static void TestCrossJoin()
        {
            Console.WriteLine("*************Test Cross Join**************");

            var query =
                from dept in _Context.Departments
                from emp in _Context.Employees 
                select new { Department = dept.Name, EmployeeName = emp.Name };


            foreach (var e in query)
                Console.WriteLine("Department - {0}, Employee - {1}", e.Department, e.EmployeeName);

            query =
          _Context.Departments.SelectMany(a => _Context.Employees, (Departments, Employees) => new { Department = Departments.Name, EmployeeName = Employees.Name });
    


            foreach (var e in query)
                Console.WriteLine("Department - {0}, Employee - {1}", e.Department, e.EmployeeName);

        }

        public static void GetEmployeesListForSkill()
        {
            try
            {



                var query = from p in _Context.EmployeeSkills
                            where p.SkillID == 2
                            select new
                            {
                               Skill = p.Skill.Name,
                               Emloyee=  p.Employee
                            };


                foreach (var e in query)
                {
                    Console.WriteLine("Skill - {0}, Employee - {1}", e.Skill, e.Emloyee.Name);

                }



            }
            catch (Exception)
            {
                throw;
            }
        }

        public void GetEmployeesWithDepartment(int pageIndex, int pageSize = 10)
        {
           var query=  _Context.Employees
                .Include("Departments")
                .OrderBy(c => c.Name)
                .Skip((pageIndex - 1) * pageSize)
                .Take(pageSize)
                .ToList();


            foreach (var e in query)
                Console.WriteLine("Department - {0}, Employee - {1}", e.Department, e.Name);
        }


    }
}

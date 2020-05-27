using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;

using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;
using System.Web.Http;

namespace EmployeeSkillsManager.Controllers
{
    public class EmployeesController : ApiController
    {

        private IEmployeeRepository _EmployeeRepository;

        public EmployeesController()
        {
            this._EmployeeRepository = new EmployeeRepository(new EmployeeSkillsDBContext());
        }

        //Get /Api/Employees
        public IEnumerable<Employee> GetEmployees()
        {

            return _EmployeeRepository.GetListofEmployees();
        }

        //Get /Api/Employees/1
        public Employee GetEmployee(int id)
        {
            return _EmployeeRepository.GetEmployeeByID(id);

        }

        [HttpPost]
        public Employee CreateEmployee(Employee Employee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _EmployeeRepository.InsertEmployee(Employee);
            _EmployeeRepository.Save();
            return Employee;
        }

        [HttpPut]
        public void UpdateEmployee(Employee Employee)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _EmployeeRepository.UpdateEmployee(Employee);
            _EmployeeRepository.Save();


        }

        [HttpDelete]
        public void DeleteEmployee(int id)
        {

            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _EmployeeRepository.EmployeeDelete(id);

            _EmployeeRepository.Save();
        }

    }
}
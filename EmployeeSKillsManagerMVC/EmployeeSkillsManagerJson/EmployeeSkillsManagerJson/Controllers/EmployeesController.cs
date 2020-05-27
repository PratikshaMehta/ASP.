using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.Repositories;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSkillsManagerJson.Controllers
{
    public class EmployeesController : Controller
    {

        private IEmployeeRepository _EmployeeRepository;

        public EmployeesController(IEmployeeRepository repo)
        {
            this._EmployeeRepository = repo;
        }

        //Get /Api/Employees
        public JsonResult GetEmployees()
        {
            var data = _EmployeeRepository.GetListofEmployees();

            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        //Get /Api/Employees/1
        public JsonResult GetEmployee(int id)
        {
            var data = _EmployeeRepository.GetEmployeeByID(id);
            JsonSerializerSettings jss = new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore };
            var result = JsonConvert.SerializeObject(data, Formatting.Indented, jss);
            return Json(result, JsonRequestBehavior.AllowGet);

        }

        [HttpPost]
        public JsonResult CreateEmployee(Employee Employee)
        {
          
            Employee.ObjectState = ObjectState.Added;
            _EmployeeRepository.InsertOrUpdate(Employee);
            _EmployeeRepository.Save();
            return Json("Inserted record successfully", JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateEmployee(Employee Employee)
        {
         
            Employee.ObjectState = ObjectState.Modified;
            _EmployeeRepository.InsertOrUpdate(Employee);
            _EmployeeRepository.Save();
            return Json("Updated record successfully", JsonRequestBehavior.AllowGet);

        }

        [HttpDelete]
        public JsonResult DeleteEmployee(int id)
        {

            Employee employee = _EmployeeRepository.GetEmployeeByID(id);
            employee.ObjectState = ObjectState.Deleted;
            _EmployeeRepository.Delete(employee);

            _EmployeeRepository.Save();
            return Json("Deleted record successfully", JsonRequestBehavior.AllowGet);
        }

    }
}
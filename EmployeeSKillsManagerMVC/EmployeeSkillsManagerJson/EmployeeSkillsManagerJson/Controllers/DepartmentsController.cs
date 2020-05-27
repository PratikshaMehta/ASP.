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
using System.Web.Mvc;

namespace EmployeeSkillsManagerJson.Controllers
{

    public class DepartmentsController : Controller
    {
        private IDepartmentRepository _DepartmentRepository;

        public DepartmentsController(IDepartmentRepository repo)
        {
            _DepartmentRepository = repo;
        }

        //Get /Api/Departments
        public JsonResult GetDepartments()
        {

     
            return Json(_DepartmentRepository.GetListOfDepartments(), JsonRequestBehavior.AllowGet);
        }

        //Get /Api/Departments/1
        public JsonResult GetDepartment(int id)
        {
           
            return Json(_DepartmentRepository.GetDepartmentByID(id), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult CreateDepartment(Department Department)
        {
         
            Department.ObjectState = ObjectState.Added;
            _DepartmentRepository.InsertOrUpdate(Department);
            _DepartmentRepository.Save();
            return Json("Inserted record successfully", JsonRequestBehavior.AllowGet);
        }

        [HttpPut]
        public JsonResult UpdateDepartment(Department Department)
        {
       
            Department.ObjectState = ObjectState.Modified;
            _DepartmentRepository.InsertOrUpdate(Department);
            _DepartmentRepository.Save();
            return Json("Updated record successfully", JsonRequestBehavior.AllowGet);

        }

        [HttpDelete]
        public JsonResult DeleteDepartment(int id)
        {

          
            Department department = _DepartmentRepository.GetDepartmentByID(id);
            department.ObjectState = ObjectState.Deleted;
            _DepartmentRepository.Delete(department);

            _DepartmentRepository.Save();
            return Json("Deleted record successfully", JsonRequestBehavior.AllowGet);
        }
    }
}
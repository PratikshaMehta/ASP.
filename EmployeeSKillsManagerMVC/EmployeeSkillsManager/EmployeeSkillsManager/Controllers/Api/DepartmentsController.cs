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

    public class DepartmentsController : ApiController
    {
        private IDepartmentRepository _DepartmentRepository;

        public DepartmentsController()
        {
            this._DepartmentRepository = new DepartmentRepository(new EmployeeSkillsDBContext());
        }

        //Get /Api/Departments
        public IEnumerable<Department> GetDepartments()
        {

            return _DepartmentRepository.GetListOfDepartments();
        }

        //Get /Api/Departments/1
        public Department GetDepartment(int id)
        {
            return _DepartmentRepository.GetDepartmentByID(id);

        }

        [HttpPost]
        public Department CreateDepartment(Department Department)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _DepartmentRepository.InsertDepartment(Department);
            _DepartmentRepository.Save();
            return Department;
        }

        [HttpPut]
        public void UpdateDepartment(Department Department)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _DepartmentRepository.UpdateDepartment(Department);
            _DepartmentRepository.Save();


        }

        [HttpDelete]
        public void DeleteDepartment(int id)
        {

            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _DepartmentRepository.DepartmentDelete(id);

            _DepartmentRepository.Save();
        }
    }
}
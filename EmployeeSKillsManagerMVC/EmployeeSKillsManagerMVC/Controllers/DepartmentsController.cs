using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;

namespace EmployeeSKillsManagerMVC.Controllers
{
    public class DepartmentsController : Controller
    {
        private IDepartmentRepository _DepartmentRepository;

        public DepartmentsController(IDepartmentRepository repo)
        {
            _DepartmentRepository = repo;
        }

        // GET: Departments
        public ActionResult Index()
        {
            return View(_DepartmentRepository.GetListOfDepartments());
        }

        // GET: Departments/Details/5
        public ActionResult Details(int id)
        {
          
            Department department = _DepartmentRepository.GetDepartmentByID(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // GET: Departments/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Departments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DepartmentID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                department.ObjectState = ObjectState.Added;
                _DepartmentRepository.InsertOrUpdate(department);
                _DepartmentRepository.Save();
                return RedirectToAction("Index");
            }

            return View(department);
        }

        // GET: Departments/Edit/5
        public ActionResult Edit(int id)
        {
           
            Department department = _DepartmentRepository.GetDepartmentByID(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DepartmentID,Name")] Department department)
        {
            if (ModelState.IsValid)
            {
                department.ObjectState = ObjectState.Modified;
                _DepartmentRepository.InsertOrUpdate(department);
                _DepartmentRepository.Save();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Departments/Delete/5
        public ActionResult Delete(int id)
        {
          
            Department department = _DepartmentRepository.GetDepartmentByID(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Departments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Department department = _DepartmentRepository.GetDepartmentByID(id);
            department.ObjectState = ObjectState.Deleted;
            _DepartmentRepository.Delete(department);

            _DepartmentRepository.Save();
            return RedirectToAction("Index");
        }

    }
}

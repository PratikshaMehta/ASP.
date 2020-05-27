using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using PagedList;
using PagedList.Mvc;

using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Repositories;
using EmployeeSkillsManager.Repository.Interfaces;


namespace EmployeeSKillsManagerMVC.Controllers
{
    public class EmployeesController : Controller
    {
        private IEmployeeRepository _EmployeeRepository;

        public EmployeesController(IEmployeeRepository repo)
        {
            this._EmployeeRepository = repo;
        }

        // GET: Employees

        public ActionResult Index(string sortOrder, string CurrentSort, int? page, string searchString, string currentFilter)
        {

            int pageSize = 10;
            int pageIndex = 1;
            pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            ViewBag.CurrentSort = sortOrder;
            sortOrder = String.IsNullOrEmpty(sortOrder) ? "Name" : sortOrder;
            IPagedList<Employee> employees = null;
            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;
            if (!String.IsNullOrEmpty(searchString))
            {

                switch (sortOrder)
                {
                    case "Name":
                        if (sortOrder.Equals(CurrentSort))
                            employees = _EmployeeRepository.GetListofEmployees().Where(s => s.Name.Contains(searchString)).OrderByDescending
                                    (m => m.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        else
                            employees = _EmployeeRepository.GetListofEmployees().Where(s => s.Name.Contains(searchString)).OrderBy
                                    (m => m.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        break;

                    case "Department":
                        if (sortOrder.Equals(CurrentSort))
                            employees = _EmployeeRepository.GetListofEmployees().Where(s => s.Name.Contains(searchString)).OrderByDescending
                                    (m => m.Department.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        else
                            employees = _EmployeeRepository.GetListofEmployees().Where(s => s.Name.Contains(searchString)).OrderBy
                                    (m => m.Department.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        break;



                    case "Default":
                        employees = _EmployeeRepository.GetListofEmployees().Where(s => s.Name.Contains(searchString)).OrderBy
                            (m => m.Name).ToPagedList(pageIndex, pageSize);
                        break;
                }

            }
            else
            {
                switch (sortOrder)
                {
                    case "Name":
                        if (sortOrder.Equals(CurrentSort))
                            employees = _EmployeeRepository.GetListofEmployees().OrderByDescending
                                    (m => m.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        else
                            employees = _EmployeeRepository.GetListofEmployees().OrderBy
                                    (m => m.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        break;

                    case "Department":
                        if (sortOrder.Equals(CurrentSort))
                            employees = _EmployeeRepository.GetListofEmployees().OrderByDescending
                                    (m => m.Department.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        else
                            employees = _EmployeeRepository.GetListofEmployees().OrderBy
                                    (m => m.Department.Name).Include(d => d.Department).ToList().ToPagedList(pageIndex, pageSize);
                        break;



                    case "Default":
                        employees = _EmployeeRepository.GetListofEmployees().OrderBy
                            (m => m.Name).ToList().ToPagedList(pageIndex, pageSize);
                        break;
                }
            }


            return View(employees);
        }


        
        //public ActionResult Index()
        //{
        //    var employees = db.Employees.Include(e => e.Department);
        //    return View(employees.ToList());
        //}

        // GET: Employees/Details/5
        public ActionResult Details(int id)
        {
            
            Employee employee =_EmployeeRepository.GetEmployeeByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // GET: Employees/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeDepartmentID = new SelectList(_EmployeeRepository.GetListOfDepartments(), "DepartmentID", "Name");
            return View();
        }

        // POST: Employees/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]


        public ActionResult Create([Bind(Include = "Name,Email,Gender,Contact,Designation,TotalExp,AcNo,SSN,EmployeeDepartmentID,CreatedDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ObjectState = ObjectState.Added;
                _EmployeeRepository.InsertOrUpdate(employee);
                _EmployeeRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeDepartmentID = new SelectList(_EmployeeRepository.GetListOfDepartments(), "DepartmentID", "Name", employee.EmployeeDepartmentID);
            return View(employee);
        }

        // GET: Employees/Edit/5
        public ActionResult Edit(int id)
        {
          
            Employee employee =_EmployeeRepository.GetEmployeeByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeDepartmentID = new SelectList(_EmployeeRepository.GetListOfDepartments(), "DepartmentID", "Name", employee.EmployeeDepartmentID);
            return View(employee);
        }

        // POST: Employees/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Email,Gender,Contact,Designation,TotalExp,AcNo,SSN,EmployeeDepartmentID,CreatedDate")] Employee employee)
        {
            if (ModelState.IsValid)
            {
                employee.ObjectState = ObjectState.Added;
                _EmployeeRepository.InsertOrUpdate(employee);
                _EmployeeRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeDepartmentID = new SelectList(_EmployeeRepository.GetListOfDepartments(), "DepartmentID", "Name", employee.EmployeeDepartmentID);
            return View(employee);
        }

        // GET: Employees/Delete/5
        public ActionResult Delete(int id)
        {
         
            Employee employee =_EmployeeRepository.GetEmployeeByID(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        // POST: Employees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
        
            Employee employee =_EmployeeRepository.GetEmployeeByID(id);
            employee.ObjectState = ObjectState.Deleted;
            _EmployeeRepository.Delete(employee);

            _EmployeeRepository.Save();
            return RedirectToAction("Index");
        }

      
    }
}

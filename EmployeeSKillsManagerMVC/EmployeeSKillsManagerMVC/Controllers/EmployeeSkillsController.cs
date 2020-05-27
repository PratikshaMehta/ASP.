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
    public class EmployeeSkillsController : Controller
    {
        private IEmployeeSkillsRepository _EmployeeSkillsRepository;
        private IEmployeeRepository _EmployeeRepository;

        private ISkillRepository _SkillRepository;


        public EmployeeSkillsController(IEmployeeSkillsRepository repo, IEmployeeRepository repo1, ISkillRepository repo2)
        {
            this._EmployeeSkillsRepository = repo;
            this._EmployeeRepository = repo1;
            this._SkillRepository = repo2;
        }

        // GET: EmployeeSkills
        public ActionResult Index()
        {


            var employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillsList();
            return View(employeeSkills.ToList());
        }

      


        // GET: EmployeeSkills/Details/5
        public ActionResult Details(int? EmployeeID, int? SkillID)
        {
            if (EmployeeID == null || SkillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            EmployeeSkills employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillByID(EmployeeID, SkillID);
            if (employeeSkills == null)
            {
                return HttpNotFound();
            }
            return View(employeeSkills);
        }

        // GET: EmployeeSkills/Create
        public ActionResult Create()
        {
            ViewBag.EmployeeID = new SelectList(_EmployeeRepository.GetListofEmployees(), "EmployeeID", "Name");
            ViewBag.SkillID = new SelectList(_SkillRepository.GetListOfSkills(), "SkillID", "Description");
            return View();
        }

        // POST: EmployeeSkills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmployeeID,SkillID,SkillLevel,ModofiedDate")] EmployeeSkills employeeSkills)
        {
            if (ModelState.IsValid)
            {
                _EmployeeSkillsRepository.InsertEmployeeSkill(employeeSkills);
                _EmployeeSkillsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.EmployeeID = new SelectList(_EmployeeRepository.GetListofEmployees(), "EmployeeID", "Name", employeeSkills.EmployeeID);
            ViewBag.SkillID = new SelectList(_SkillRepository.GetListOfSkills(), "SkillID", "Description", employeeSkills.SkillID);
            return View(employeeSkills);
        }

      


        [Route("EmployeeSkills/Edit/{EmployeeID}/{SkillID}")]
        public ActionResult Edit(int? EmployeeID, int? SkillID)
        {

            if (EmployeeID == null || SkillID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkills employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillByID(EmployeeID, SkillID);
            if (employeeSkills == null)
            {
                return HttpNotFound();
            }
            ViewBag.EmployeeID = new SelectList(_EmployeeRepository.GetListofEmployees(), "EmployeeID", "Name", employeeSkills.EmployeeID);
            ViewBag.SkillID = new SelectList(_SkillRepository.GetListOfSkills(), "SkillID", "Description", employeeSkills.SkillID);
            return View(employeeSkills);
        }

        //POST: EmployeeSkills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmployeeID,SkillID,SkillLevel,ModofiedDate")] EmployeeSkills employeeSkills)
        {
            if (ModelState.IsValid)
            {
                _EmployeeSkillsRepository.UpdateEmployeeSkill(employeeSkills);
                _EmployeeSkillsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.EmployeeID = new SelectList(_EmployeeRepository.GetListofEmployees(), "EmployeeID", "Name", employeeSkills.EmployeeID);
            ViewBag.SkillID = new SelectList(_SkillRepository.GetListOfSkills(), "SkillID", "Description", employeeSkills.SkillID);
            return View(employeeSkills);
        }

        // GET: EmployeeSkills/Delete/5

        [Route("EmployeeSkills/Delete/{EmployeeID}/{SkillID}")]
        public ActionResult Delete(int? EmployeeID, int? SkillID)
        {
            if (EmployeeID == null || SkillID == null )
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeSkills employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillByID(EmployeeID, SkillID);
            if (employeeSkills == null)
            {
                return HttpNotFound();
            }
            return View(employeeSkills);
        }

        // POST: EmployeeSkills/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? EmployeeID, int? SkillID)
        {
            EmployeeSkills employeeSkills = _EmployeeSkillsRepository.GetEmployeeSkillByID(EmployeeID, SkillID);
            _EmployeeSkillsRepository.EmployeeSkillDelete(EmployeeID, SkillID);
            _EmployeeSkillsRepository.Save();
            return RedirectToAction("Index");
        }

     
    }
}

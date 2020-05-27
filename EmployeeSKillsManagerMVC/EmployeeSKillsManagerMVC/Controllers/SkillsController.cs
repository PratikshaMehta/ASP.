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
    public class SkillsController : Controller
    {
        private ISkillRepository _SkillsRepository;

        public SkillsController(ISkillRepository repo)
        {
            this._SkillsRepository = repo;
        }



        // GET: Skills
        public ActionResult Index()
        {
            var skills = _SkillsRepository.GetListOfSkills();
            return View(skills.ToList());
        }

        // GET: Skills/Details/5
        public ActionResult Details(int id)
        {
         
            Skill skill = _SkillsRepository.GetSkillByID(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            ViewBag.SkillCategoryID = new SelectList(_SkillsRepository.GetSkillCategoriesList(), "CategoryID", "Name");
            return View();
        }

        // POST: Skills/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SkillID,Description,Name,DateSkillAdded,SkillCategoryID")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                skill.ObjectState = ObjectState.Added;
                _SkillsRepository.InsertOrUpdate(skill);
                _SkillsRepository.Save();
                return RedirectToAction("Index");
            }

            ViewBag.SkillCategoryID = new SelectList(_SkillsRepository.GetSkillCategoriesList(), "CategoryID", "Name", skill.SkillCategoryID);
            return View(skill);
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
           
            Skill skill =_SkillsRepository.GetSkillByID(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            ViewBag.SkillCategoryID = new SelectList(_SkillsRepository.GetSkillCategoriesList(), "CategoryID", "Name", skill.SkillCategoryID);
            return View(skill);
        }

        // POST: Skills/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SkillID,Description,Name,DateSkillAdded,SkillCategoryID")] Skill skill)
        {
            if (ModelState.IsValid)
            {
                skill.ObjectState = ObjectState.Added;
                _SkillsRepository.InsertOrUpdate(skill);
                _SkillsRepository.Save();
                return RedirectToAction("Index");
            }
            ViewBag.SkillCategoryID = new SelectList(_SkillsRepository.GetSkillCategoriesList(), "CategoryID", "Name", skill.SkillCategoryID);
            return View(skill);
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int id)
        {
           
            Skill skill =_SkillsRepository.GetSkillByID(id);
            if (skill == null)
            {
                return HttpNotFound();
            }
            return View(skill);
        }

        // POST: Skills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Skill skill = _SkillsRepository.GetSkillByID(id);
            skill.ObjectState = ObjectState.Deleted;
            _SkillsRepository.Delete(skill);

            _SkillsRepository.Save();
            return RedirectToAction("Index");
        }


    }
}

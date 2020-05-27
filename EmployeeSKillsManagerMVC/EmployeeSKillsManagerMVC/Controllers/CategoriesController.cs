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
    public class CategoriesController : Controller
    {
        private ICategoryRepository _CategoryRepository;

        public CategoriesController(ICategoryRepository repo)
        {
            _CategoryRepository = repo;
        }


        // GET: Categories
        public ActionResult Index()
        {
            return View(_CategoryRepository.GetSkillCategoriesList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int id)
        {
            Category category = _CategoryRepository.GetCategoryByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.ObjectState = ObjectState.Added;
                _CategoryRepository.InsertOrUpdate(category);
                _CategoryRepository.Save();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int id)
        {
          
            Category category = _CategoryRepository.GetCategoryByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CategoryID,Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                category.ObjectState = ObjectState.Modified;
                _CategoryRepository.InsertOrUpdate(category);
                _CategoryRepository.Save();

                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int id)
        {
        
            Category category = _CategoryRepository.GetCategoryByID(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
          
            Category category = _CategoryRepository.GetCategoryByID(id);
            category.ObjectState = ObjectState.Deleted;

            _CategoryRepository.Delete(category);

            _CategoryRepository.Save();
            return RedirectToAction("Index");
        }

     
    }
}

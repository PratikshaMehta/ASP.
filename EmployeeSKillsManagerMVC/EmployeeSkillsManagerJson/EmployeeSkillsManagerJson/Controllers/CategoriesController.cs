using EmployeeSkillsManager.DomainClasses;
using EmployeeSkillsManager.Repository.DatabaseContext;
using EmployeeSkillsManager.Repository.Interfaces;
using EmployeeSkillsManager.Repository.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Web;
using System.Web.Mvc;

namespace EmployeeSkillsManagerJson.Controllers
{
    public class CategoriesController : Controller
    {
        private ICategoryRepository _CategoryRepository;

        public CategoriesController(ICategoryRepository repo)
        {
            _CategoryRepository = repo;
        }


        //Get /Categories
        public JsonResult GetCatrgories()
        {
                 
            return Json(_CategoryRepository.GetAll(), JsonRequestBehavior.AllowGet);

        }

        //Get /Categories/1
        public JsonResult GetCategory(int id)
        {
            return Json(_CategoryRepository.GetCategoryByID(id), JsonRequestBehavior.AllowGet);


        }

        [HttpPost]
        public JsonResult CreateCategory(Category Category)
        {


            Category.ObjectState = ObjectState.Added;
            _CategoryRepository.InsertOrUpdate(Category);
            _CategoryRepository.Save();
            return Json("Inserted record successfully", JsonRequestBehavior.AllowGet);


        }

        [HttpPut]
        public JsonResult UpdateCategory(Category Category)
        {
           

            Category.ObjectState = ObjectState.Modified;
            _CategoryRepository.InsertOrUpdate(Category);
            _CategoryRepository.Save();
            return Json("Updated record successfully", JsonRequestBehavior.AllowGet);

        }

        [HttpDelete]
        public JsonResult DeleteCategory(int id)
        {

        
            Category category = _CategoryRepository.GetCategoryByID(id);
            category.ObjectState = ObjectState.Deleted;

            _CategoryRepository.Delete(category);
            _CategoryRepository.Save();

            return Json("Deleted record successfully", JsonRequestBehavior.AllowGet);
        }
    }
}

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
    public class CategoriesController : ApiController
    {
        private ICategoryRepository _CategoryRepository;

        public CategoriesController(ICategoryRepository repo)
        {
            _CategoryRepository = repo;
        }


        //Get /Api/Categorys
        public IEnumerable<Category> GetCatrgories()
        {

            return _CategoryRepository.GetAll();
        }

        //Get /Api/Categorys/1
        public Category GetCategory(int id)
        {
            return _CategoryRepository.GetCategoryByID(id);

        }

        [HttpPost]
        public Category CreateCategory(Category Category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Category.ObjectState = ObjectState.Added;
            _CategoryRepository.InsertOrUpdate(Category);
            _CategoryRepository.Save();
            return Category;
        }

        [HttpPut]
        public void UpdateCategory(Category Category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            Category.ObjectState = ObjectState.Modified;
            _CategoryRepository.InsertOrUpdate(Category);
            _CategoryRepository.Save();


        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {

            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
            Category category = _CategoryRepository.GetCategoryByID(id);
            category.ObjectState = ObjectState.Deleted;

            _CategoryRepository.Delete(category);
            _CategoryRepository.Save();
        }
    }
}

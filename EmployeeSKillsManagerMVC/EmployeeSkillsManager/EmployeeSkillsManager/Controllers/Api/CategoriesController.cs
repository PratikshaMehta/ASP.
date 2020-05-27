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

        public CategoriesController()
        {
            this._CategoryRepository = new CategoryRepository(new EmployeeSkillsDBContext());
        }


        //Get /Api/Categorys
        public IEnumerable<Category> GetCatrgories()
        {

            return _CategoryRepository.GetListOfCategories();
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

            _CategoryRepository.InsertCategory(Category);
            _CategoryRepository.Save();
            return Category;
        }

        [HttpPut]
        public void UpdateCategory(Category Category)
        {
            if (!ModelState.IsValid)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            _CategoryRepository.UpdateCategory(Category);
            _CategoryRepository.Save();


        }

        [HttpDelete]
        public void DeleteCategory(int id)
        {

            if (!ModelState.IsValid)
            {

                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            _CategoryRepository.CategoryDelete(id);

            _CategoryRepository.Save();
        }
    }
}

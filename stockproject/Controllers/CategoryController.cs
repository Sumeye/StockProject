using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using stockproject.Repository;
using stockproject.Models;
using System.Data;

namespace stockproject.Controllers
{
    public class CategoryController : Controller
    {
        stockdbEntities db = new stockdbEntities();
        CategoryManager cm = new CategoryManager();
        // GET: Category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Category cat)
        {
            #region Ekleme

            try
            {
                if (ModelState.IsValid)
                {
                    cm.Insert(cat);
                    cm.Save();
                    return RedirectToAction("Create");
                }
            }
            catch (DataException)
            {
                ModelState.AddModelError(string.Empty, "Kayıt Eklenemedi");
            }
            return View(cat);
            #endregion
        }

        public ActionResult Edit(int id)
        {
            Category category = cm.SelectById(id);
            return View(category);
        }
        [HttpPost]
        public ActionResult Edit(Category category)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    cm.Update(category);
                    cm.Save();
                    return RedirectToAction("Create");

                }
            }
            catch (DataException)
            {

                ModelState.AddModelError(string.Empty, "Kayıt güncellenemedi");
            }
            return View(category);

        }

        public ActionResult Delete(bool? savechangesError = false,int id = 0)
        {
            if (savechangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Silme işlemi başarısız.";
            }
            Category category = cm.SelectById(id);
            return View(category);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                Category category = cm.SelectById(id);
                cm.Delete(id);
                cm.Save();
            }
            catch (DataException)
            {
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
              
            }
            return RedirectToAction("Create");

        }
    }
}
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
   
        public ActionResult List()
        {
   

            var data = cm.List();
            return View(data);

        }
        [HttpPost] 
        public JsonResult Search(string searching)
        {
            var term = searching.ToLower();
              var result  = db.Category.Where
                (x =>
                x.CategoryName.ToLower().Contains(term) ||
                x.Description.ToLower().Contains(term));
            var kayit = new JsonResult();
            kayit.Data = result;
            kayit.JsonRequestBehavior = JsonRequestBehavior.AllowGet;
            kayit.ContentEncoding = System.Text.UTF8Encoding.UTF8;
            kayit.ContentType = "application/json; charset=utf-8";

            return Json(result);
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
                    return RedirectToAction("List");
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
           
                if (ModelState.IsValid)
                {
                    cm.Update(category);                
                    return RedirectToAction("List");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Kayıt hatası");
                }
           
        
            return View(category);

        }
        
        public ActionResult Delete(int id, bool? savechangesError = false)
        {
            if (savechangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Silme işlemi başarısız.";
            }
            Category category = cm.SelectById(id);
            cm.Delete(id);
            return RedirectToAction("List",category);
        }
        
    }
}
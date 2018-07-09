using stockproject.IRepository;
using stockproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Linq.Expressions;
using System.Data.Entity;

namespace stockproject.Repository
{
    public class CategoryManager : IRepository<Category>
    {
        stockdbEntities db = new stockdbEntities();
        public void Delete(int itemId)
        {
            db.Category.Remove(db.Category.Find(itemId));
            db.SaveChanges();
        }
        public void Insert(Category obj)
        {
            db.Category.Add(obj);
             db.SaveChanges();
        }
        public List<Category> List()
        {
           return db.Category.ToList();

        }
        public void Save()
        {
              db.SaveChanges();
        }
        public Category SelectById(int itemId)
        {
            return db.Category.Find(itemId);
            
        }
        public void Update(Category item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
       
    }
}
using stockproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace stockproject.IRepository
{
   public interface IRepository<T>
    {
        List<T> List();
        //IQueryable<T> List(Expression<Func<T, bool>> where);
        void Insert(T obj);
        void Update(T obj);
        void Delete(int itemId);
        void Save();
        T SelectById(int itemId);
        //T Find(Expression<Func<T, bool>> where);
    }
}

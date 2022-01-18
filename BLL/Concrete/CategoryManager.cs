using BLL.Abstract;
using DAL.Abstract;
using Entities.Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDAL _ıcategorydal;

        public CategoryManager(ICategoryDAL ıcategorydal)
        {
            _ıcategorydal = ıcategorydal;
        }

        public void Add(Categories categories)
        {
            _ıcategorydal.Add(categories);
        }

        public void Delete(Categories categories)
        {
            _ıcategorydal.Delete(categories);
        }

        public Categories Get(int id)
        {
            return _ıcategorydal.Get(x => x.CategoryId == id);
        }

        public List<Categories> GetAll(Expression<Func<Categories, bool>> filter = null)
        {
            return _ıcategorydal.GetAll();
        }

        public Categories GetDetail(int id)
        {
             return _ıcategorydal.GetDetail(x => x.CategoryId == id);
        }

        public void Update(Categories categories)
        {
            _ıcategorydal.Update(categories);
        }
    }
}

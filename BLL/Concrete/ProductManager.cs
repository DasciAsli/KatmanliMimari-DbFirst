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
    public class ProductManager : IProductService
    {
        IProductDAL _ıproductdal;

        public ProductManager(IProductDAL ıproductdal)
        {
            _ıproductdal = ıproductdal;
        }

        public void Add(Products products)
        {
            _ıproductdal.Add(products);
        }

        public void Delete(Products products)
        {
            _ıproductdal.Delete(products);
        }

        public Products Get(int id)
        {
            return _ıproductdal.Get(x => x.ProductId == id);
        }

        public List<Products> GetAll(Expression<Func<Products, bool>> filter = null)
        {
            return _ıproductdal.GetAll();
        }

        public Products GetDetail(int id)
        {
            return _ıproductdal.GetDetail(x => x.ProductId == id);
        }

        public void Update(Products products)
        {
            _ıproductdal.Update(products);
        }
    }
}

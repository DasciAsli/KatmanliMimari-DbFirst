using Entities.Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface IProductService
    {
        void Add(Products products);
        List<Products> GetAll(Expression<Func<Products, bool>> filter = null);
        Products Get(int id);
        Products GetDetail(int id);
        void Update(Products products);
        void Delete(Products products);
    }
}

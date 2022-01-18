using Entities.Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Abstract
{
    public interface ICategoryService
    {
        void Add(Categories categories);
        List<Categories> GetAll(Expression<Func<Categories, bool>> filter = null);
        Categories Get(int id);
        Categories GetDetail(int id);
        void Update(Categories categories);
        void Delete(Categories categories);
    }
}

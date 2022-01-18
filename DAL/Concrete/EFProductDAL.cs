using Core.DataAccessLayer;
using DAL.Abstract;
using Entities.Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Concrete
{
    public class EFProductDAL:GenericRepositoryBase<Context,Products>,IProductDAL
    {
    }
}

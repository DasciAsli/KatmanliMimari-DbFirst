﻿using Core.DataAccessLayer;
using Entities.Model.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Abstract
{
    public interface IProductDAL:IRepositoryBase<Products>
    {
    }
}

using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfBrandDal :EfEntityRepositoryBase<Brand,CarContext>, IBrandDal
    {
       
    }
}

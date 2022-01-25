using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfColorDal:EfEntityRepositoryBase<Color,CarContext>,IColorDal
    {
    }
}

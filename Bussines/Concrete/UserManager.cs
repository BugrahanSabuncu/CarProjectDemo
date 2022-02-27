using Bussines.Abstract;
using Bussines.BussinesAspect.Autofac;
using Core.Aspect.Autofac.Caching;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Bussines.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        [SecuredOperation("admin,user.add")]
        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult();
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult();
        }
        [CacheAspect]
        public IDataResult<User> GetByEmail(string email)
        {
            var result = _userDal.Get(u => u.Email ==email);
            return new SuccessDataResult<User>(result);
        }
        [CacheAspect]
        //[SecuredOperation("admin")]
        public List<OperationClaim> GetClaims(User user)
        {           
            return _userDal.GetClaims(user);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult();
        }
    }
}

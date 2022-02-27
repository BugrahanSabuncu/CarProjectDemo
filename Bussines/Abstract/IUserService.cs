using Core.Entities.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IUserService
    {
        List<OperationClaim> GetClaims(User user);
        IDataResult<User> GetByEmail(string email);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);

    }
}

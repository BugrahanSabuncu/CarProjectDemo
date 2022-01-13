using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Abstract
{
    public interface IAuthService
    {
        IDataResult<User> Register(UserForRegisterDto registerDto,string password);
        IDataResult<User> Login(UserForLoginDto loginDto);
        IResult UserExist(string email);
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}

using Bussines.Abstract;
using Bussines.Constants.Messages;
using Core.Entities.Concrete;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class AuthManager : IAuthService
    {
        IUserService _userService;
        ITokenHelper _tokenHelper;

        public AuthManager(IUserService userService, ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }

        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var claims = _userService.GetClaims(user);
            var accessToken=_tokenHelper.CreateToken(user, claims.Data);
            return new SuccessDataResult<AccessToken>(accessToken, Messages.AccessTokenCreated);
        }

        public IDataResult<User> Login(UserForLoginDto loginDto)
        {
            var userToCheck = _userService.GetByEmail(loginDto.Email);
            if (!userToCheck.Success)
            {
                return new ErrorDataResult<User>(Messages.UserNotFound);
            }// buraya kadar geldiyse kullanıcıyı bulduk
            if (!HashingHelper.VerifyPasswordHash(loginDto.Password, userToCheck.Data.PasswordHash, userToCheck.Data.PasswordSalt))
            {
                return new ErrorDataResult<User>(Messages.PasswordError);
            }//bu kısımdada gönderilen parolayı tekrar hashleyerek karşılaştırıyoruz.
            return new SuccessDataResult<User>(Messages.SuccessfullLogin);
        }

        public IDataResult<User> Register(UserForRegisterDto registerDto, string password)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(password, out passwordHash, out passwordSalt);
            var user = new User()
            {
                FirstName = registerDto.FirstName,
                LastName = registerDto.LastName,
                Email = registerDto.Email,
                PasswordSalt = passwordSalt,
                PasswordHash = passwordHash,
                Status = true
            };
            _userService.Add(user);
            return new SuccessDataResult<User>(user,Messages.UserRegisted);
        }

        public IResult UserExist(string email)
        {
            var result = _userService.GetByEmail(email) != null;
            if (result)
            {
                return new ErrorResult(Messages.UserAlreadyExist);
            }
            return new SuccessResult();
        }
    }
}

using Autofac;
using Business.Concrete;
using Business.Abstact;
using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using DataAccessLayer.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework;
using Bussines.Abstract;
using Bussines.Concrete;
using Core.Utilities.Helpers.FileHelperManager;
using Core.Utilities.Security.JWT;

namespace Bussines.DependencyResolvers.Autofac
{
    public class AutoBussinesModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CarManager>().As<ICarService>().SingleInstance();
            builder.RegisterType<EfCarDal>().As<ICarDal>().SingleInstance();

            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<CarImageManager>().As<ICarImageService>().SingleInstance();

            builder.RegisterType<EfCarImageDal>().As<ICarImageDal>().SingleInstance();
            builder.RegisterType<FileHelperManager>().As<IFileHelper>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<EfUserDal>().As<IUserDal>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>().SingleInstance();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>().SingleInstance();
        }
    }
}

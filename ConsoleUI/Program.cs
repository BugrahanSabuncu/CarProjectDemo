using Business.Concrete;
using Core.Utilities.Security.Ecyption;
using DataAccessLayer.Concrete.EntityFramework;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Reflection;
using System.Text;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //CarTest();
            //Cartest2();
            //var securityKey = SecurityKeyHelper.CreateSecurityKey("Buğrahan");
            //var encoding = Encoding.UTF8.GetBytes("ab");
            //foreach (var encod in encoding)
            //{
            //    Console.WriteLine(encod);
            //}
            //var symetric = new SymmetricSecurityKey(encoding);
            //foreach (var encod in symetric.Key)
            //{
            //    Console.WriteLine(encod);
            //}
            ////Console.WriteLine();
            //Console.WriteLine("\nKeySize : " + symetric.KeySize +
            //    "\nProviderFactory : " + symetric.CryptoProviderFactory );

            //var signing = new SigningCredentials(symetric, SecurityAlgorithms.HmacSha512Signature);

            //var t = signing.GetType();

            //foreach (var item in t.GetRuntimeProperties())
            //{
            //    var value = item.GetValue(signing);
            //    Console.WriteLine(item.Name);
            //    Console.WriteLine(item.GetValue(signing));
            //}
            //Console.WriteLine("Signing" + signing);

            var hmac = new System.Security.Cryptography.HMACSHA512();
            var hash = hmac.ComputeHash(Encoding.UTF8.GetBytes("Buğrahan"));

            foreach (var item in hash)
            {
                Console.Write(item);
            }
            Console.WriteLine("SALT");
            foreach (var item in hmac.Key)
            {
                Console.Write(item);
            }

        }

        private static void Cartest2()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAllCarDto();
            if (result.Success == true)
            {
                foreach (var carDetails in result.Data)
                {
                    Console.WriteLine(carDetails.Description.Trim() + "  " + carDetails.ColorName.Trim());
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetAll();
            if (result.Success == true)
            {
                foreach (var car in carManager.GetAll().Data)
                {
                    Console.WriteLine(car.DailyPrice + " " + car.Description);
                }
                Console.WriteLine(result.Message);
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
        
    }
}

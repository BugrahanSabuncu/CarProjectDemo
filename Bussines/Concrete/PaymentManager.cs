using Bussines.Abstract;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bussines.Concrete
{
    public class PaymentManager : IPaymentService
    {
        public IResult payValidation(CreditCard creditCard)
        {
            return new SuccessResult("Doğrulama başarılı");
        }
    }
}

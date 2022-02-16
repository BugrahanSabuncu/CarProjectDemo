using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class CreditCard
    {
        public int Id { get; set; }
        public string CardNumber { get; set; }
        public string ExpireYear { get; set; }

        public string ExpireMonth { get; set; }

        public string Cvc { get; set; }

        public string CardHolderFullName { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swbc.Modules.AdValoremSwivel.Models
{
    public class PaymentInformation
    {
        public double amount { get; set; }
        public string applyFundsTo { get; set; }
        public string type { get; set; }
    }
}
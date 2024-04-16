using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Swbc.Modules.AdValoremSwivel.Models
{
    public class PaymentInit
    {
        public string Mode { get; set; }
        public string IntegrationID { get; set; }
        public string PaymentAccountId { get; set; }
        public string Element { get; set; }
        public string Experience { get; set; }
    }
}
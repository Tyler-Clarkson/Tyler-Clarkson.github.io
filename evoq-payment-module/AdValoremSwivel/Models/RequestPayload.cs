using System.Collections.Generic;

namespace Swbc.Modules.AdValoremSwivel.Models
{
    public class RequestPayload
    {
        public string experience { get; set; }
        public User user { get; set; }
        public List<PaymentInformation> paymentInformation { get; set; }
        public string PaymentAccountId { get; set; } // breaks naming convention bc SDK requires capital "P"

    }
}
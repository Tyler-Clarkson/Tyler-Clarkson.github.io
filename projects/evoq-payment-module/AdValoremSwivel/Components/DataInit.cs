using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Swbc.Modules.AdValoremSwivel.Components
{
    public class DataInit : IDataInit
    {
        // getting the domain for purposes of matching the pfx file name
        public string getDomain()
        {
            string domain = HttpContext.Current.Request.Url.Host;

            // need to strip www from production to match cert name
            if (domain.IndexOf("www", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                domain = "swbc.com";
            }

            return domain;
        }

        // getting the generic environment name based on domain name for purposed of dynamic pw retrieval for pfx file
        public string getEnvironment()
        {
            string domain = getDomain();

            if (domain.IndexOf("d", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "DEV";
            }
            if (domain.IndexOf("q", StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return "QA";
            }
            else
            {
                return "PROD";
            }
        }
    }
}
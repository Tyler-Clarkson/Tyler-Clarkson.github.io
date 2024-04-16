/*
' Copyright (c) 2023 swbc.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using DotNetNuke.Collections;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using Jose;
using Newtonsoft.Json;
using Swbc.Modules.AdValoremSwivel.Components;
using Swbc.Modules.AdValoremSwivel.Models;
using System;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using System.Web.Configuration;
using System.Web.Mvc;

namespace Swbc.Modules.AdValoremSwivel.Controllers
{
    [DnnHandleError]
    public class SwivelController : DnnController
    {
        /**
         * fields
         */
        // path to the cert as pfx file with public and private key
        private static string appPath;
        private static string filePath;
        private static string fullPath;

        // create x509cert object and set storage flags for accessing keys without a keystore
        private static X509Certificate2 cert;

        // get public and private key from cert
        private object privateKey;
        private object publicKey;

        /**
         * dependency injections
         */
        protected IDataInit DataInit { get; }

        /**
         * contructor override
         */
        public SwivelController(IDataInit dataInit)
        {
            DataInit = dataInit;

             // path to the cert as pfx file with public and private key
            appPath = AppDomain.CurrentDomain.BaseDirectory;
            filePath = "Portals\\0\\_After-020518\\Documents\\swivel\\" + DataInit.getDomain() + ".pfx";
            fullPath = Path.Combine(appPath, filePath);

            // create x509cert object and set storage flags for accessing keys without a keystore
            cert = new X509Certificate2(System.IO.File.ReadAllBytes(fullPath)
                               , WebConfigurationManager.AppSettings[DataInit.getEnvironment() + "Swivel"]
                               , X509KeyStorageFlags.MachineKeySet |
                                 X509KeyStorageFlags.PersistKeySet |
                                 X509KeyStorageFlags.Exportable);

            // get public and private key from cert
            privateKey = cert.GetRSAPrivateKey();
            publicKey = cert.GetRSAPublicKey();
        }


        /**
         * Ajax request for processing the form data as a jwt using Jose.jwt framework
         */
        [HttpPost]
         public String AjaxSwivelRequestProcessing(RequestPayload formData)
         {
            formData.PaymentAccountId = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Payment ID", "");
            formData.experience = "CC_ONLY";

            // construct payload from params
            string rawPayload = JsonConvert.SerializeObject(formData);

            // sign and encode payload into token
            string token = Jose.JWT.Encode(rawPayload, privateKey, JwsAlgorithm.RS256);
            return token;
        }

        /**
         * Ajax request for processing the response from the swivel sdk
         * NOT YET IMPLEMENTED. POSSIBLE PHASE 2
         */
        /*[HttpPost]
        public ActionResult AjaxSwivelResponseProcessing(SdkResponse rawToken)
        {
            string payload = rawToken.token.Split('.')[1];
            payload += "=="; // to fit criteria for base64 string
            byte[] data = Convert.FromBase64String(payload);
            string decodedString = System.Text.Encoding.UTF8.GetString(data);
            //string json = JsonConvert.SerializeObject(decodedString);
            return Json(decodedString);
        }*/

        /**
         * Ajax request for initializing payment object
         */
        [HttpPost]
        public ActionResult AjaxSwivelPaymentInit()
        {
            PaymentInit paymentData = new PaymentInit
            {
                Mode = "modal",
                IntegrationID = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Integration ID", ""),
                PaymentAccountId = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Payment ID", ""),
                Element = "swivel-iframe",
                Experience = "CC_ONLY"
            };
            return Json(paymentData);
        }

        /**
         * default index method
         */
        public ActionResult Index()
        {
            ViewBag.SwivelIntegrationURL = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Integration URL", "");
            return View();
        }
    }
}

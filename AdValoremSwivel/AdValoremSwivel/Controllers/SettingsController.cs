﻿/*
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
using DotNetNuke.Security;
using DotNetNuke.Web.Mvc.Framework.ActionFilters;
using DotNetNuke.Web.Mvc.Framework.Controllers;
using System.Web.Mvc;

namespace Swbc.Modules.AdValoremSwivel.Controllers
{
    [DnnModuleAuthorize(AccessLevel = SecurityAccessLevel.Edit)]
    [DnnHandleError]
    public class SettingsController : DnnController
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public ActionResult Settings()
        {
            var settings = new Models.Settings();
            settings.IntegrationId = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Integration ID", "");
            settings.PaymentId = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Payment ID", "");
            settings.IntegrationURL = ModuleContext.Configuration.ModuleSettings.GetValueOrDefault("Swivel Integration URL", "");

            return View(settings);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="supportsTokens"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(false)]
        [DotNetNuke.Web.Mvc.Framework.ActionFilters.ValidateAntiForgeryToken]
        public ActionResult Settings(Models.Settings settings)
        {
            ModuleContext.Configuration.ModuleSettings["Swivel Integration ID"] = settings.IntegrationId;
            ModuleContext.Configuration.ModuleSettings["Swivel Payment ID"] = settings.PaymentId;
            ModuleContext.Configuration.ModuleSettings["Swivel Integration URL"] = settings.IntegrationURL;

            return RedirectToDefaultRoute();
        }
    }
}
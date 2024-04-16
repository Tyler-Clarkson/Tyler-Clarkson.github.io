using DotNetNuke.Web.Mvc.Routing;

namespace Swbc.Modules.AdValoremSwivel

{

    public class RouteConfig : IMvcRouteMapper

    {

        public void RegisterRoutes(IMapRoute mapRouteManager)

        {

            mapRouteManager.MapRoute("AdValoremSwivel", "AdValoremSwivel", "{controller}/{action}", new[]

            {"Swbc.Modules.AdValoremSwivel.Controllers"});

        }

    }

}
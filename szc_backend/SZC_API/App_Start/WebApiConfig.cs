using System.Net.Http.Formatting;
using System.Web.Http;

namespace SZC_API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            /*var cors = new EnableCorsAttribute("http://localhost", "*", "*");
            cors.Origins.Add("http://localhost");
            config.EnableCors(cors);*/
            // Web API routes
            config.EnableCors();
            config.MapHttpAttributeRoutes();
            config.Formatters.Clear();
            config.Formatters.Add(new JsonMediaTypeFormatter());
            /*config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            config.Routes.MapHttpRoute(
                name: "AddApi",
                routeTemplate: "api/add/{klijent_id}/{group_id}/{stage_id}/{name}/{url}/{icon}/{hasTfsDeploy}/{TfsVersion}/{description}/{link_order}/{cssclass}/{active}/",
                defaults: new { klijent_id = RouteParameter.Optional, group_id = RouteParameter.Optional, stage_id = RouteParameter.Optional, name = RouteParameter.Optional, url = RouteParameter.Optional, icon = RouteParameter.Optional, hasTfsDeploy = RouteParameter.Optional, TfsVersion = RouteParameter.Optional, description = RouteParameter.Optional, link_order = RouteParameter.Optional, cssclass = RouteParameter.Optional, active = RouteParameter.Optional, }
            );
            config.Routes.MapHttpRoute(
                name: "UpdateApi",
                routeTemplate: "api/update/{klijent_stage_id}/{klijent_id}/{group_id}/{stage_id}/{name}/{url}/{icon}/{hasTfsDeploy}/{TfsVersion}/{description}/{link_order}/{cssclass}/{active}/",
                defaults: new { klijent_stage_id = RouteParameter.Optional, klijent_id = RouteParameter.Optional, group_id = RouteParameter.Optional, stage_id = RouteParameter.Optional, name = RouteParameter.Optional, url = RouteParameter.Optional, icon = RouteParameter.Optional, hasTfsDeploy = RouteParameter.Optional, TfsVersion = RouteParameter.Optional, description = RouteParameter.Optional, link_order = RouteParameter.Optional, cssclass = RouteParameter.Optional, active = RouteParameter.Optional, }
            );
            config.Routes.MapHttpRoute(
                name: "DeleteApi",
                routeTemplate: "api/delete/{klijent_stage_id}",
                defaults: new { klijent_stage_id = RouteParameter.Optional}
            );*/
        }
    }
}

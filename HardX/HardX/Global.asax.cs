using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HardX
{
    // Примечание: Инструкции по включению классического режима IIS6 или IIS7 
    // см. по ссылке http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Имя маршрута
                "{controller}/{action}/{id}", // URL-адрес с параметрами
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Параметры по умолчанию
            );

            routes.MapRoute(
            "issue",                                              // Route name
            "{controller}/issue/{repository_id}/{matmodel_id}",                           // URL with parameters
            new { controller = "Store", action = "issue", repository_id = "0", matmodel_id = "0" }  // Parameter defaults            
        );

            routes.MapRoute(
            "marriage",                                              // Route name
            "{controller}/marriage/{repository_id}/{matmodel_id}",                           // URL with parameters
            new { controller = "Store", action = "marriage", repository_id = "0", matmodel_id = "0" }  // Parameter defaults
        );


        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
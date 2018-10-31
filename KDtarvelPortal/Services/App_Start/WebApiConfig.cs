using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Services
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            // Enable CORS for the Angular App
            config.EnableCors(new EnableCorsAttribute("http://localhost:4300", "*", "*"));

            var appXmlType = config.Formatters.XmlFormatter.SupportedMediaTypes.FirstOrDefault(t => t.MediaType == "application/xml");
            config.Formatters.XmlFormatter.SupportedMediaTypes.Remove(appXmlType);
            //By default Web API return XML data  
            //We can remove this by clearing the SupportedMediaTypes option as follows  
            config.Formatters.XmlFormatter.SupportedMediaTypes.Clear();
            //Now set the serializer setting for JsonFormatter to Indented to get Json Formatted data  
            config.Formatters.JsonFormatter.SerializerSettings.Formatting =
                Newtonsoft.Json.Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver =
                        new CamelCasePropertyNamesContractResolver();

        }
    }
}

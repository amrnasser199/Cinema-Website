using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting = Formatting.Indented;
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            //var result = "{ \"id\": \"/apis/574c167dcd7c3216c8c633b3\", \"name\": \"Servicedesk and Operations\", \"description\": \"Servicedesk and Operations Internal API\", \"serviceUrl\": \"dev-endpoint.com\", \"path\": \"test\", \"protocols\": [ \"http\", \"https\" ], \"authenticationSettings\": { \"oAuth2\": null, \"openid\": null }, \"subscriptionKeyParameterNames\": { \"header\": \"Ocp-Apim-Subscription-Key\", \"query\": \"subscription-key\" } }";
            //var jsonResult = JsonConvert.DeserializeObject<dynamic>(result);
            //var value = (JToken)jsonResult;
            //var id = value["id"].ToString();
            //var id2 = jsonResult.id;

        }
    }
}

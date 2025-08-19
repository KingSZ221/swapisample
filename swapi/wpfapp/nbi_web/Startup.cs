using Microsoft.Owin;
using Owin;
using System.Web.Http;

[assembly: OwinStartup(typeof(wpfapp.nbi_web.Startup))]
namespace wpfapp.nbi_web
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // 启用跨域
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);

            // 配置WebAPI
            var config = new HttpConfiguration();

            // 启用属性路由
            config.MapHttpAttributeRoutes();

            // 默认路由
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            app.UseWebApi(config);
        }
    }
}

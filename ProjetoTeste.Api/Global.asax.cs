using ProjetoTeste.Application.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Routing;

namespace ProjetoTeste.Api
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AutoMapperConfigCore.RegisterMappings();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}

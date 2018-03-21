using CloudTraceability.Web.App_Start;
using DBI.SaaS.Setting;
using Rafy.Web;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace CloudTraceability.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfig.Init();
            AreaRegistration.RegisterAllAreas();
        }

        public override void Init()
        {
            base.Init();
            new WebAppStarter(this).Start(new CloudTraceabilityEnvironmentConfig());
        }
    }
}

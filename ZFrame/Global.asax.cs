using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace ZFrameWeb
{
    public class Global : System.Web.HttpApplication
    {


        //public void RegWCFServices()
        //{
        //    RouteTable.Routes.Add(new ServiceRoute("Func", new WebServiceHostFactory(), typeof(WCFServices)));
        //}


        protected void Application_Start(object sender, EventArgs e)
        {
           // RegWCFServices();
            Application["WCFHOME"] = System.Configuration.ConfigurationManager.AppSettings["WCFHOME"];
        }

        

    }
}
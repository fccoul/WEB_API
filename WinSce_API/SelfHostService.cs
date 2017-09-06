using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.SelfHost;

namespace WinSce_API
{
    //---creation dun simple client --->voir projet "WebApp_ConsumeAPIDicvover_forClt-->InfosWindowsSceAPI.html
    public partial class SelfHostService : ServiceBase
    {
        public SelfHostService()
        {
            InitializeComponent();
        }

        //When the service is hosted, this OnStart event will be fired and the hosting configuration will be registered.
        protected override void OnStart(string[] args)
        {
            var url = "http://localhost:5450";
            var config = new HttpSelfHostConfiguration(url); //definition de la configuration incluant le template routing
            
            config.Routes.MapHttpRoute("custom",
                                     "api/{controller}/{id}",
                                     new { id = RouteParameter.Optional});

            HttpSelfHostServer server = new HttpSelfHostServer(config); //creation de l'hebergeur de sce API avec affectaion de la config
            server.OpenAsync().Wait();

      
        }

        protected override void OnStop()
        {
        }
    }
}

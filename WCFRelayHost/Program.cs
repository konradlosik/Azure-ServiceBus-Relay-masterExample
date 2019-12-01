using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using WCFRelayLib;

namespace WCFRelayHost
{
    class Program
    {
        static void Main(string[] args)
        {
            //var xx=System.Configuration.ConfigurationSettings.AppSettings["SubjectAdressName"];
            string scheme, serviceNamespace, servicePath, policy, accessKey;
            AccessHelper.SetPolicy(out scheme, out serviceNamespace, out servicePath, out policy, out accessKey);

            Uri address = ServiceBusEnvironment.CreateServiceUri(scheme, serviceNamespace, servicePath);

            ServiceHost sh = new ServiceHost(typeof(Recharge), address);

            sh.AddServiceEndpoint(typeof(IRecharge), new NetTcpRelayBinding(), address)
                .Behaviors.Add(new TransportClientEndpointBehavior
                {
                    TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(policy, accessKey)
                });

            sh.Open();

            Console.WriteLine("Press ENTER to close");
            Console.ReadLine();

            sh.Close();
        }


    }
}

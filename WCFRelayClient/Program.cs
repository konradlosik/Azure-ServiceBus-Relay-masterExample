using Microsoft.ServiceBus;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace WCFRelayLib
{
    [ServiceContract(Namespace = Constants.SUBJECT01_PATH)]
        //"https://DoctorsMobileVisit.servicebus.windows.net/nettcpsubject02relay")]
    //[ServiceContract(Namespace = "https://DoctorsMobileVisit.servicebus.windows.net/nettcpsubject01relay")]
    //[ServiceContract(Namespace = "https://recharge.servicebus.windows.net/rechargerelay")]
    public interface IRecharge
    {
        [OperationContract]
        string DoRecharge(string message);
    }

    interface IRechargeChannel : IRecharge, IClientChannel { }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Mobile Recharge");
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Operators");
            Console.WriteLine("1. Vodafone");
            Console.WriteLine("2. Airtel");
            Console.WriteLine("3. JIO");
            Console.WriteLine("-------------------------------------------------------");

            Console.WriteLine("Operator:");
            string mobileOperator = Console.ReadLine();
            Console.WriteLine("Amount:");
            string amount = Console.ReadLine();
            Console.WriteLine("Mobile:");
            string mobile = Console.ReadLine();

            Console.WriteLine("-------------------------------------------------------");

            switch (mobileOperator)
            {
                case "1":
                    mobileOperator = "Vodafone";
                    break;
                case "2":
                    mobileOperator = "Airtel";
                    break;
                case "3":
                    mobileOperator = "JIO";
                    break;
                default:
                    break;
            }

            string message = mobileOperator + "*" + mobile + "*" + amount;

            string scheme, serviceNamespace, servicePath, policy, accessKey;
            AccessHelper.SetPolicy(out scheme, out serviceNamespace, out servicePath, out policy, out accessKey);

            ServiceBusEnvironment.SystemConnectivity.Mode = ConnectivityMode.AutoDetect;

            var cf = new ChannelFactory<IRechargeChannel>(new NetTcpRelayBinding(),new EndpointAddress(ServiceBusEnvironment.CreateServiceUri(scheme, serviceNamespace,servicePath)));

            cf.Endpoint.Behaviors.Add(new TransportClientEndpointBehavior { TokenProvider = TokenProvider.CreateSharedAccessSignatureTokenProvider(policy, accessKey) });

            using (var ch = cf.CreateChannel())
            {
                Console.WriteLine(ch.DoRecharge(message));
            }

            Console.ReadLine();
        }
    }
}

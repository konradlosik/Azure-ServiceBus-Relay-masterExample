using System;
namespace WCFRelayLib
{
    public class AccessHelper
    {
        public static void SetPolicy(out string scheme, out string serviceNamespace, out string servicePath, out string policy, out string accessKey)
        {
            //https://DoctorsMobileVisit.servicebus.windows.net/nettcpsubject01relay
            /*Klucz podstawowy	0d64/UUV8766etUmIg2/QmOT4Y3vEZi8r8h0DyaClXc=
            Podstawowe parametry połączenia	Endpoint=sb://doctorsmobilevisit.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=0d64/UUV8766etUmIg2/QmOT4Y3vEZi8r8h0DyaClXc=
            Namespace=doctorsmobilevisit
            Key=0d64/UUV8766etUmIg2/QmOT4Y3vEZi8r8h0DyaClXc=*/
            scheme = "sb";
            //string serviceNamespace = "recharge";
            serviceNamespace = Constants.NAMESPACE;// "doctorsmobilevisit";
            //string servicePath = "https://recharge.servicebus.windows.net/rechargerelay";
            //servicePath = "https://recharge.servicebus.windows.net/nettcpsubject01relay";
            servicePath = Constants.SUBJECT02_PATH;// "https://recharge.servicebus.windows.net/nettcpsubject02relay";
            policy = "RootManageSharedAccessKey";
            //string accessKey = "Kn1GO+dihGWMbMLEe6DfsuxJd6ptgvfQVG6EF6GivdY=";
            accessKey = Constants.ACCESSKEY;// "0d64/UUV8766etUmIg2/QmOT4Y3vEZi8r8h0DyaClXc=";
        }
    }
}

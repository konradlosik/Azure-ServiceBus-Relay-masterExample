using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WCFRelayLib
{
    //[ServiceContract(Namespace = "https://recharge.servicebus.windows.net/rechargerelay")]
    //[ServiceContract(Namespace = "https://DoctorsMobileVisit.servicebus.windows.net/nettcpsubject01relay")]
    [ServiceContract(Namespace = Constants.SUBJECT01_PATH)]
    public interface IRecharge
    {
        [OperationContract]
        string DoRecharge(string message);
    }

    interface IRechargeChannel : IRecharge, IClientChannel { }
}

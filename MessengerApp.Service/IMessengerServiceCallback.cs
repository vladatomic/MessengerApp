using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Service
{
    public interface IMessengerServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void SendMessageToAllClients(MessengerAppMessage message);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerApp.Service
{
    
    [ServiceContract(CallbackContract =typeof(IMessengerServiceCallback))]
    public interface IMessengerService
    {
        [OperationContract(IsOneWay = true)]
        void RegisterChatUser(MessengerAppUser user);

        [OperationContract(IsOneWay = true)]
        void PostMessage(MessengerAppMessage message);
    }
}

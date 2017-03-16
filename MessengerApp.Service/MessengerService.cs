using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace MessengerApp.Service
{
    [ServiceBehavior(InstanceContextMode =InstanceContextMode.Single)]
    public class MessengerService :IMessengerService
    {
       public Dictionary<string, IMessengerServiceCallback> collectionOfChannelsToClients = new Dictionary<string, IMessengerServiceCallback>();
        public static IMessengerServiceCallback callBack;
        public void PostMessage(MessengerAppMessage message)
        {
            foreach (var nickName in collectionOfChannelsToClients.Keys)
            {
                try
                {
                    if (message.User.NickName != nickName)
                    {
                        callBack = collectionOfChannelsToClients[nickName];
                        callBack.SendMessageToAllClients(message);
                    }
                   
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        public void RegisterChatUser(MessengerAppUser user)
        {
            var currentClientWhoCallServise = OperationContext.Current.GetCallbackChannel<IMessengerServiceCallback>();
            if (currentClientWhoCallServise != null)
                collectionOfChannelsToClients.Add(user.NickName, currentClientWhoCallServise);
            Console.WriteLine($"{user.NickName} joined to messenger!!!");
            foreach (var item in collectionOfChannelsToClients.Keys)
            {
                Console.WriteLine(item);
                Console.WriteLine("{0}",collectionOfChannelsToClients[item].ToString());
            }
        }
    }
}

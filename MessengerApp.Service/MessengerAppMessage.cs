using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace MessengerApp.Service
{
    [DataContract]
    public class MessengerAppMessage
    {
       
        [DataMember]
        public MessengerAppUser User { get; set; }
        [DataMember]
        public string Message { get; set; }
        [DataMember]
        public DateTime CreateAt { get; set; }
    }
}

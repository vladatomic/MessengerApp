using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessengerAppClientWpf
{
    public class ChatMessege
    {
        public string ChatMemberNickName { get; set; }
        public string CurrentUserMessage { get; set; }
        public string  ChatMemberMessage { get; set; }

        public override string ToString()
        {
            return ChatMemberNickName + " say: " + ChatMemberMessage;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MessengerApp.Service;

namespace MessengerHostServer
{
    class Program
    {
        static void Main(string[] args)
        {
            var host = new ServiceHost(typeof(MessengerService));
            host.Open();
            Console.WriteLine("Service started at {0}",DateTime.Now);
            Console.WriteLine("Type exit  to stop the service");
            string command=Console.ReadLine();
            while (!command.Equals("exit"))
            {
                command = Console.ReadLine();
            }
            Console.WriteLine("Service closed *** {0} ***", DateTime.Now);
            host.Close();
        }
    }
}

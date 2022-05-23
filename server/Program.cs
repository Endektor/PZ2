using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Worker;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpServerChannel channel = new TcpServerChannel(8086);
            ChannelServices.RegisterChannel(channel);
            RemotingConfiguration.RegisterWellKnownServiceType(typeof(DBWorker), "GetData", WellKnownObjectMode.SingleCall);

            Console.WriteLine("Сервер запущен");
            Console.ReadLine();
        }
    }
}

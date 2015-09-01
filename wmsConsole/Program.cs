using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace wmsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChanged;
            NetworkChange.NetworkAddressChanged += NetworkAddressChanged;
            Console.ReadKey();
        }
        private static void NetworkAddressChanged(object sender, EventArgs e)
        {
            Console.WriteLine("Current IP Addresses:");
            Debug.Write("Current IP Addresses:");
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation addr in ni.GetIPProperties().UnicastAddresses)
                {
                    Console.WriteLine("    - {0} (lease expires {1})", addr.Address, DateTime.Now + new TimeSpan(0, 0, (int)addr.DhcpLeaseLifetime));
                    Debug.Write(string.Format("    - {0} (lease expires {1})", addr.Address, DateTime.Now + new TimeSpan(0, 0, (int)addr.DhcpLeaseLifetime)));
                }
            }
        }

        private static void NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                Console.WriteLine("Network Available");
                Debug.Write("Network Available");
            }
            else
            {
                Debug.Write("Network Unavailable");
                Console.WriteLine("Network Unavailable");
            }
        }
    }
}

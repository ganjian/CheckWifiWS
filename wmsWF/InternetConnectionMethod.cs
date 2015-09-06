using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace wmsWF
{
    public class InterMethod
    {

        /// <summary>
        /// 检查TCP连接数
        /// </summary>
        /// <returns></returns>
        public static string CountTcpConnections()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            TcpConnectionInformation[] connections = properties.GetActiveTcpConnections();
            int establishedConnections = 0;
            StringBuilder sb = new StringBuilder();
            foreach (TcpConnectionInformation t in connections)
            {
                if (t.State == TcpState.Established)
                {
                    establishedConnections++;
                }

                sb.AppendLine(string.Format("Local endpoint: {0} ", t.LocalEndPoint.Address));
                sb.AppendLine(string.Format("Remote endpoint: {0} ", t.RemoteEndPoint.Address));


            }
            sb.AppendLine(string.Format("There are {0} established TCP connections.",
               establishedConnections));
            return sb.ToString();
        }



        /// <summary>
        /// Ping命令检测网络是否畅通
        /// </summary>
        /// <param name="urls">URL数据</param>
        /// <param name="errorCount">ping时连接失败个数</param>
        /// <returns></returns>
        public static string MyPing(string[] urls, out int errorCount)
        {

            StringBuilder sb = new StringBuilder();

            Ping ping = new Ping();
            errorCount = 0;
            try
            {
                PingReply pr;
                for (int i = 0; i < urls.Length; i++)
                {
                    pr = ping.Send(urls[i]);
                    if (pr.Status != IPStatus.Success)
                    {
                        sb.AppendLine("error Ping " + urls[i] + "    " + pr.Status.ToString());
                        errorCount++;
                    }
                    sb.AppendLine("Ping " + urls[i] + "    " + pr.Status.ToString());
                }
            }
            catch (Exception ex)
            {
                sb.AppendLine("error!! " + ex.Message);

                errorCount = urls.Length;
            }
            //if (errorCount > 0 && errorCount < 3)
            //  isconn = true;
            return sb.ToString();
        }

        /// <summary>
        /// 列出本地计算机上所有接口的摘要。
        /// </summary>
        public static string ShowInterfaceSummary()
        {
            StringBuilder sb = new StringBuilder();
            NetworkInterface[] interfaces = NetworkInterface.GetAllNetworkInterfaces();
            foreach (NetworkInterface adapter in interfaces)
            {
                sb.AppendLine(string.Format("Name: {0}", adapter.Name));
                sb.AppendLine(string.Format("id: {0}", adapter.Id));
                sb.AppendLine(string.Format("speed: {0}", adapter.Speed));
                sb.AppendLine(string.Format("GatewayAddresses: "));
                foreach (var item in adapter.GetIPProperties().UnicastAddresses)
                {
                    sb.AppendLine(item.Address.ToString());
                }
                sb.AppendLine(adapter.Description);
                sb.AppendLine(String.Empty.PadLeft(adapter.Description.Length, '='));
                sb.AppendLine(string.Format("  Interface type .......................... : {0}", adapter.NetworkInterfaceType));
                sb.AppendLine(string.Format("  Operational status ...................... : {0}",
                      adapter.OperationalStatus));
                string versions = "";

                // Create a display string for the supported IP versions.
                if (adapter.Supports(NetworkInterfaceComponent.IPv4))
                {
                    versions = "IPv4";
                }
                if (adapter.Supports(NetworkInterfaceComponent.IPv6))
                {
                    if (versions.Length > 0)
                    {
                        versions += " ";
                    }
                    versions += "IPv6";
                }
                sb.AppendLine(string.Format("  IP version .............................. : {0}", versions));
                sb.AppendLine();
            }
            sb.AppendLine();

            return sb.ToString();
        }



        private const int INTERNET_CONNECTION_MODEM = 1;
        private const int INTERNET_CONNECTION_LAN = 2;

        [System.Runtime.InteropServices.DllImport("winInet.dll")]
        private static extern bool InternetGetConnectedState(ref int dwFlag, int dwReserved);

        /// <summary>
        /// 判断本地的连接状态
        /// </summary>
        /// <returns></returns>
        private static bool LocalConnectionStatus()
        {
            System.Int32 dwFlag = new Int32();
            if (!InternetGetConnectedState(ref dwFlag, 0))
            {
                LogHelper.WriteLog("LocalConnectionStatus--未连网!");
                return false;
            }
            else
            {
                if ((dwFlag & INTERNET_CONNECTION_MODEM) != 0)
                {
                    LogHelper.WriteLog("LocalConnectionStatus--采用调制解调器上网。");
                    return true;
                }
                else if ((dwFlag & INTERNET_CONNECTION_LAN) != 0)
                {
                    LogHelper.WriteLog("LocalConnectionStatus--采用网卡上网。");
                    return true;
                }
            }
            return false;
        }


    }
}

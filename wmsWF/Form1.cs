using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace wmsWF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            //  NetworkChange 使应用程序可以在网络接口（也称为网卡或网络适配器）的 Internet 协议(IP) 地址更改时收到通知。

            //在网络的可用性更改时发生。
            NetworkChange.NetworkAvailabilityChanged += NetworkAvailabilityChanged;

            //在网络接口的 IP 地址更改时发生。
            NetworkChange.NetworkAddressChanged += NetworkAddressChanged;

            //log4net.Config.XmlConfigurator.Configure();//.DOMConfigurator.Configure();
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;//不显示在系统任务栏
                notifyIcon1.Visible = true;//托盘显示可见

            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = true;
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;
            }
        }



        private static void NetworkAddressChanged(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Current IP Addresses:");
            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation addr in ni.GetIPProperties().UnicastAddresses)
                {
                    long speed = ni.Speed;
                    sb.Append(string.Format((" {0} (lease expires {1})---"), addr.Address, DateTime.Now + new TimeSpan(0, 0, (int)addr.DhcpLeaseLifetime)));
                    //
                }
            }
            LogHelper.WriteLog("" + sb.ToString());


        }

        private static void NetworkAvailabilityChanged(object sender, NetworkAvailabilityEventArgs e)
        {
            if (e.IsAvailable)
            {
                LogHelper.WriteLog("Network Available");
            }
            else
            {
                LogHelper.WriteLog("Network Unavailable");
            }
        }





        /// <summary>
        /// 计算建立的 TCP 连接数。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnTCPCount_Click(object sender, EventArgs e)
        {
            string info = InterMethod.CountTcpConnections();
            txtInfo.Text += info;
        }

        /// <summary>
        /// Ping 外部IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnPing_Click(object sender, EventArgs e)
        {
            int count = 0;
            string[] strurl = new string[] { "10.0.0.1", "www.baidu.com", "10.83.29.212" };

            string info = (InterMethod.MyPing(strurl, out count));
            txtInfo.Text += info;
        }

        private void btnInterFaceSummary_Click(object sender, EventArgs e)
        {
            string info = InterMethod.ShowInterfaceSummary();
            txtInfo.Text += info;
        }
    }
}

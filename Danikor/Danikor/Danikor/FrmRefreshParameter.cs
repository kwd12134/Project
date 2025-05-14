using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sunny.UI;
using Communication;
using Data;
using System.Net.Sockets;

namespace Danikor
{
    public partial class FrmRefreshParameter : UIForm
    {
        public FrmRefreshParameter(TClient client)
        {
            InitializeComponent();
            Client = client;
           // client.DataReceived += Client_DataReceived;
        }

        private void Client_DataReceived(object sender)
        {
            Client.cts.Cancel();
            Client.Tcp_Client?.Close();
            Client.heartbeatTimer?.Dispose();
            this.Close();
            this.DialogResult = DialogResult.OK;
        }

        public TClient Client { get; set; }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            if (this.uiNumPadTextBox1.Text==null&& this.uiNumPadTextBox1.Text == "")
            {
                MessageBox.Show("请输入数值");
                return;
            }
            string countHexString = string.Empty;

            int Count = int.Parse(uiNumPadTextBox1.Text);
            
            if (Count < 10)
            {
                // 如果 Count 小于 10，则转换成一个字符的十六进制表示
                countHexString = Convert.ToInt32((char)('0' + Count)).ToString("X");
            }
            else if (Count < 17)
            {
                // 如果 Count 大于或等于 10，则转换成两个字符的十六进制表示
                countHexString = $"{(Count / 10 + '0'):X2} {(Count % 10 + '0'):X2}";
            }
            else
            {
                MessageBox.Show("输入的数值超出范围1-16");
                return;
            }
           // Client.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, "30 31 30 32",Hex: countHexString);
        }

        private void uiButton2_Click(object sender, EventArgs e)
        {
            Client.cts.Cancel();
            Client.Tcp_Client?.Close();
            Client.heartbeatTimer?.Dispose();
            this.Close();
        }

        private void FrmRefreshParameter_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Client.cts.Cancel();
            //Client.client?.Close();
            //Client.heartbeatTimer?.Dispose();
        }
    }
}

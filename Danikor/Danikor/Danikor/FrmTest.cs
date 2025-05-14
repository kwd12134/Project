using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Communication;
using Data;
using Sunny.UI;
namespace Danikor
{
    public partial class FrmTest : UIForm
    {
        public FrmTest()
        {
            InitializeComponent();
        }
        ITcpClient StopServer;
        private void but_Start_Click(object sender, EventArgs e)
        {
            StopServer = ServiceLocator.GetService<ITcpClient>();

            StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 31 03");

        }

        private void but_stop_Click(object sender, EventArgs e)
        {
            StopServer = ServiceLocator.GetService<ITcpClient>();

            StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 33 03");

        }

        private void but_Reset_Click(object sender, EventArgs e)
        {
            StopServer = ServiceLocator.GetService<ITcpClient>();

            StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 35 03");
        }

        private void but_Reverse_Click(object sender, EventArgs e)
        {
            StopServer = ServiceLocator.GetService<ITcpClient>();

            StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 32 03");
        }

        private void butCancelStop_Click(object sender, EventArgs e)
        {
            StopServer = ServiceLocator.GetService<ITcpClient>();

            StopServer.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.电机运行停止使能0301, "02 00 00 00 0a 57 30 33 30 31 30 30 31 3d 34 03");
        }
    }
}

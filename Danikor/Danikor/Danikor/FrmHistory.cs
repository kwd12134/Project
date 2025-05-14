using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Sunny.UI;
using thinger.DataConvertLib;
using Communication;
using Helper;
namespace Danikor
{
    public partial class FrmHistory : UIForm
    {
        public FrmHistory()
        {
            InitializeComponent();
            this.FormClosing += FrmHistory_FormClosing;
            dic.Add("时间", "时间");
            dic.Add("模式", "模式");
            dic.Add("扭矩", "扭矩");
            dic.Add("角度", "角度");
            dic.Add("时长", "时长");
            dic.Add("拧紧结果状态", "拧紧结果状态");
            dic.Add("错误码ID", "错误码ID");
            dic.Add("错误码信息", "错误码信息");
        }

        private Dictionary<string, string> dic = new Dictionary<string, string>();

        private void FrmHistory_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        public ITcpClient client;
        
        private void uiButton_Sender_Click_1(object sender, EventArgs e)
        {
            if (client==null)
            {
                client = ServiceLocator.GetService<ITcpClient>();
                client.DataReceived += Client_DataReceived;
            }

            client.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort,DeviceEnums.历史数据读取0401 ,"30 34 30 31", this.uiIntegerUpDown1.Value);

            this.ShowWaitForm("正在读取当中...");
        }

        private void Client_DataReceived()
        {            
            this.uiDataGridView1.DataSource = null;
            this.uiDataGridView1.DataSource = Variable.DeviceHistory;
            this.uiDataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.HideWaitForm();
        }

        private void uiDataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        private void uiButton_output_Click(object sender, EventArgs e)
        {
            saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.DefaultExt = ".xlsx";            
            
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string FileName = saveFileDialog1.FileName;
                if (Variable.DeviceHistory!=null)
                {
                    ExcelHelper.ListToExcel<DeviceHistoryData>(Variable.DeviceHistory, "历史数据", FileName, dic, true);
                }
                MessageBox.Show("保存成功");
            }
        }
    }
}

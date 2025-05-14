using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Helper;
using MCMQ;
using Sunny.UI;
namespace Danikor
{
    public partial class FrmCommunicateConfig : UIForm
    {
        public FrmCommunicateConfig(string Path, McmqServer mcmqServer)
        {
            InitializeComponent();
            SystemSettingPath = Path;
            this.mcmqServer = mcmqServer;
            Initial();
        }

        public McmqServer mcmqServer;

        public string SystemSettingPath;

        private void Initial()
        {
            string[] PortName = SerialPort.GetPortNames();
            if (PortName.Length > 0)
            {
                this.cmb_Port.Items.Clear();
                this.cmb_Port.Items.AddRange(PortName);
                this.cmb_Port.SelectedIndex = 0;

                this.cmb_Port.Text = SystemSetting.DeviceRTUPort;
                this.text_IP.Text = SystemSetting.DeviceIP;
                this.text_port.Text = SystemSetting.DeviceIpPort.ToString();

                this.uiTextBox_FTPIP.Text = SystemSetting.FtpIP;
                this.uiTextBox_FTPPort.Text = SystemSetting.FtpPort.ToString();
                this.uiTextBox_FTPUserNme.Text = SystemSetting.FtpUserName;
                this.uiTextBox_FTPRootPath.Text = SystemSetting.FtpRootPath;
                this.uiTextBox_FTP_UserPwd.Text = SystemSetting.FtpUserPwd;

                this.uiTextBox_MCMQPort.Text = SystemSetting.McmqPort.ToString();
                this.uiipTextBox_MCMQIP.Text = SystemSetting.McmqIP;
                this.uiTextBox_MCMQRQName.Text = SystemSetting.MCMQQueueName;
                this.uiTextBox_MCMQRQName.Text = SystemSetting.MCMQReplyQueueName;

                this.text_Area.Text = XMLData.Area;
                this.text_Station.Text = XMLData.Station;
                this.text_Line.Text = XMLData.Line;
                this.text_EQP_ID.Text = XMLData.EQP_ID;
                this.text_Model.Text = XMLData.Model_No;
                this.text_P_Area.Text = XMLData.P_Area;
                this.text_Sys_Para.Text = XMLData.Sys_Para;
                this.text_Function.Text = XMLData.Function;
                this.text_Operation.Text = XMLData.Operation;
                this.text_Measure_Type.Text = XMLData.Measure_Type;
                this.text_Next_Operation.Text = XMLData.Next_Operation;
                this.text_Port_ID.Text = XMLData.Port_ID;
                this.text_Mlp_ID.Text = XMLData.Mlp_ID;
                this.text_Jig_ID.Text = XMLData.Jig_ID;
                this.text_Chip_Info.Text = XMLData.Chip_Info;

                this.CheckBox_EnabledMCMQ.Checked = SystemSetting.EnabledMCMQ;

            }
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {
            try
            {
                SystemSetting.DeviceRTUPort = this.cmb_Port.Text;
                SystemSetting.DeviceIP = this.text_IP.Text;
                SystemSetting.DeviceIpPort = int.Parse(this.text_port.Text);
                SystemSetting.FtpIP = this.uiTextBox_FTPIP.Text;
                SystemSetting.FtpPort = int.Parse(this.uiTextBox_FTPPort.Text);
                SystemSetting.FtpUserName = this.uiTextBox_FTPUserNme.Text;
                SystemSetting.FtpRootPath = this.uiTextBox_FTPRootPath.Text;
                SystemSetting.FtpUserPwd = this.uiTextBox_FTP_UserPwd.Text;
                SystemSetting.McmqPort = int.Parse(this.uiTextBox_MCMQPort.Text);
                SystemSetting.McmqIP = this.uiipTextBox_MCMQIP.Text;
                SystemSetting.MCMQQueueName = this.uiTextBox_MCMQ_QName.Text;
                SystemSetting.MCMQReplyQueueName = this.uiTextBox_MCMQRQName.Text;
                SystemSetting.EnabledMCMQ = this.CheckBox_EnabledMCMQ.Checked;

                //开启MCMQ
                if (SystemSetting.EnabledMCMQ)
                {
                    mcmqServer.McmqConnet(SystemSetting.McmqIP, SystemSetting.McmqPort, SystemSetting.MCMQQueueName, SystemSetting.MCMQReplyQueueName);
                }
                else
                {
                    mcmqServer.McmqClose();
                }

                //XML

                XMLData.Area = this.text_Area.Text.Trim();
                XMLData.Station = this.text_Station.Text.Trim();
                XMLData.Line = this.text_Line.Text.Trim();
                XMLData.EQP_ID = this.text_EQP_ID.Text.Trim();
                XMLData.Model_No = this.text_Model.Text.Trim();
                XMLData.P_Area = this.text_P_Area.Text.Trim();
                XMLData.Sys_Para = this.text_Sys_Para.Text.Trim();
                XMLData.Function = this.text_Function.Text.Trim();
                XMLData.Operation = this.text_Operation.Text.Trim();
                XMLData.Measure_Type = this.text_Measure_Type.Text.Trim();
                XMLData.Next_Operation = this.text_Next_Operation.Text.Trim();
                XMLData.Port_ID = this.text_Port_ID.Text.Trim();
                XMLData.Mlp_ID = this.text_Mlp_ID.Text.Trim();
                XMLData.Jig_ID = this.text_Jig_ID.Text.Trim();
                XMLData.Chip_Info = this.text_Chip_Info.Text.Trim();
                XMLData.EQP_List = this.text_EQP_List.Text.Trim();
                XMLData.Defect_Code = this.text_EQP_List.Text.Trim();

                IniConfigHelper.WriteIniData("System", "DeviceIP", SystemSetting.DeviceIP, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "DeviceIpPort", SystemSetting.DeviceIpPort.ToString(), SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "DeviceRTUPort", SystemSetting.DeviceRTUPort, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "McmqIP", SystemSetting.McmqIP, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "McmqPort", SystemSetting.McmqPort.ToString(), SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "FtpIP", SystemSetting.FtpIP, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "FtpPort", SystemSetting.FtpPort.ToString(), SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "MCMQQueueName", SystemSetting.MCMQQueueName, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "MCMQReplyQueueName", SystemSetting.MCMQReplyQueueName, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "FtpRootPath", SystemSetting.FtpRootPath, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "FtpUserName", SystemSetting.FtpUserName, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "FtpUserPwd", SystemSetting.FtpUserPwd, SystemSettingPath);
                IniConfigHelper.WriteIniData("System", "UserPwd", Variable.UserPwd, SystemSettingPath);

                IniConfigHelper.WriteIniData("XML", "Area", XMLData.Area, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Station", XMLData.Station, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Line", XMLData.Line, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "EQP_ID", XMLData.EQP_ID, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Model_No", XMLData.Model_No, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "P_Area", XMLData.P_Area, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Sys_Para", XMLData.Sys_Para, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Function", XMLData.Function, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Operation", XMLData.Operation, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Measure_Type", XMLData.Measure_Type, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Next_Operation", XMLData.Next_Operation, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Port_ID", XMLData.Port_ID, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Mlp_ID", XMLData.Mlp_ID, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Jig_ID", XMLData.Jig_ID, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Chip_Info", XMLData.Chip_Info, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "EQP_List", XMLData.EQP_List, SystemSettingPath);
                IniConfigHelper.WriteIniData("XML", "Defect_Code", XMLData.Defect_Code, SystemSettingPath);

                IniConfigHelper.WriteIniData("System", "EnabledMCMQ", this.CheckBox_EnabledMCMQ.Checked ? "1" : "0", SystemSettingPath);

                Variable.ListAddLog(0, "保存通讯配置成功");

            }
            catch (Exception)
            {
                this.ShowErrorDialog("保存失败");
            }
        }

        private void uiButton3_Click(object sender, EventArgs e)
        {
            this.cmb_Port.Text = SystemSetting.DeviceRTUPort;
            this.text_IP.Text = SystemSetting.DeviceIP;
            this.text_port.Text = SystemSetting.DeviceIpPort.ToString();

            this.uiTextBox_FTPIP.Text = SystemSetting.FtpIP;
            this.uiTextBox_FTPPort.Text = SystemSetting.FtpPort.ToString();
            this.uiTextBox_FTPUserNme.Text = SystemSetting.FtpUserName;
            this.uiTextBox_FTPRootPath.Text = SystemSetting.FtpRootPath;
            this.uiTextBox_FTP_UserPwd.Text = SystemSetting.FtpUserPwd;

            this.uiTextBox_MCMQPort.Text = SystemSetting.McmqPort.ToString();
            this.uiipTextBox_MCMQIP.Text = SystemSetting.McmqIP;
            this.uiTextBox_MCMQRQName.Text = SystemSetting.MCMQQueueName;
            this.uiTextBox_MCMQRQName.Text = SystemSetting.MCMQReplyQueueName;
        }

    }
}

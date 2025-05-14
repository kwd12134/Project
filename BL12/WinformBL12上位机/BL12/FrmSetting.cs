using CurrentVariable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public partial class FrmSetting : Form
    {
        public FrmSetting()
        {
            InitializeComponent();
            IniConfigHelper.IniPath = SettingPath;
        }

        public string SettingPath = Application.StartupPath + "\\Setting.ini";

        private void FrmSetting_Load(object sender, EventArgs e)
        {
            if (System.IO.File.Exists(SettingPath))
            {
                this.text_XmlIP.Text = GlobalVariable.McmqSetting.McmqIp;
                this.text_XmlPort.Text = GlobalVariable.McmqSetting.McmqPort;
                this.text_Queue.Text = GlobalVariable.McmqSetting.McmqQueue;
                this.text_ReplyQueue.Text = GlobalVariable.McmqSetting.McmqReplyQueue;

                this.text_Part_No.Text = GlobalVariable.XmlData.Part_No;
                this.text_Port_ID.Text = GlobalVariable.XmlData.Port_ID;
                this.text_Operation.Text = GlobalVariable.XmlData.Operation;
                this.text_P_Area.Text = GlobalVariable.XmlData.P_Area;
                this.text_Line.Text = GlobalVariable.XmlData.Line;
                this.text_Eqp_ID.Text = GlobalVariable.XmlData.Eqp_ID;
                this.text_Jog_ID.Text = GlobalVariable.XmlData.Jog_ID;

                this.text_JinceIP.Text = GlobalVariable.Jince.JinceIP;
                this.text_JincePort.Text = GlobalVariable.Jince.JincePort;

                this.text_DayShhift.Text = GlobalVariable.CheckTime.DayShift;
                this.text_NightShift.Text = GlobalVariable.CheckTime.NightShift;
            }
            else
            {
                MessageBox.Show("配置文件不存在");
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                IniConfigHelper.WriteIniData("MCMQ", "IP", this.text_XmlIP.Text);
                IniConfigHelper.WriteIniData("MCMQ", "Port", this.text_XmlPort.Text);
                IniConfigHelper.WriteIniData("MCMQ", "Queue", this.text_Queue.Text);
                IniConfigHelper.WriteIniData("MCMQ", "ReplyQueue", this.text_ReplyQueue.Text);

                IniConfigHelper.WriteIniData("XML", "Part_No", this.text_Part_No.Text);
                IniConfigHelper.WriteIniData("XML", "Port_ID", this.text_Port_ID.Text);
                IniConfigHelper.WriteIniData("XML", "Operation", this.text_Operation.Text);
                IniConfigHelper.WriteIniData("XML", "P_Area", this.text_P_Area.Text);
                IniConfigHelper.WriteIniData("XML", "Line", this.text_Line.Text);
                IniConfigHelper.WriteIniData("XML", "Eqp_ID", this.text_Eqp_ID.Text);
                IniConfigHelper.WriteIniData("XML", "Jog_ID", this.text_Jog_ID.Text);
                IniConfigHelper.WriteIniData("Jince", "JinceIP", this.text_JinceIP.Text);
                IniConfigHelper.WriteIniData("Jince", "JincePort", this.text_JincePort.Text);

                IniConfigHelper.WriteIniData("CheckTime", "DayShift", GlobalVariable.CheckTime.DayShift);
                IniConfigHelper.WriteIniData("CheckTime", "NightShift", GlobalVariable.CheckTime.NightShift);

                GlobalVariable.McmqSetting.McmqReplyQueue = this.text_ReplyQueue.Text;
                GlobalVariable.McmqSetting.McmqQueue = this.text_Queue.Text;
                GlobalVariable.McmqSetting.McmqIp = this.text_XmlIP.Text;
                GlobalVariable.McmqSetting.McmqPort = this.text_XmlPort.Text;

                GlobalVariable.CheckTime.DayShift = this.text_DayShhift.Text;
                GlobalVariable.CheckTime.NightShift = this.text_NightShift.Text;

            }
            catch (Exception)
            {
                MessageBox.Show("保存失败");
                return;
            }
            MessageBox.Show("保存成功");
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.text_XmlIP.Text = GlobalVariable.McmqSetting.McmqIp;
            this.text_XmlPort.Text = GlobalVariable.McmqSetting.McmqPort;
            this.text_Queue.Text = GlobalVariable.McmqSetting.McmqQueue;
            this.text_ReplyQueue.Text = GlobalVariable.McmqSetting.McmqReplyQueue;

            this.text_Part_No.Text = GlobalVariable.XmlData.Part_No;
            this.text_Port_ID.Text = GlobalVariable.XmlData.Port_ID;
            this.text_Operation.Text = GlobalVariable.XmlData.Operation;
            this.text_P_Area.Text = GlobalVariable.XmlData.P_Area;
            this.text_Line.Text = GlobalVariable.XmlData.Line;
            this.text_Eqp_ID.Text = GlobalVariable.XmlData.Eqp_ID;
            this.text_Jog_ID.Text = GlobalVariable.XmlData.Jog_ID;

            this.text_JinceIP.Text = GlobalVariable.Jince.JinceIP;
            this.text_JincePort.Text = GlobalVariable.Jince.JincePort;
        }
    }
}

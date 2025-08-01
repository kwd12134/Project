using KWDHTMmodels;
using KWDMHTUserLib;
using MiniExcelLibs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using thinger.MTHHelper;

namespace KWD.MTHproject
{
    public partial class FrmParamSet : Form
    {
        public FrmParamSet(string DevicePath)
        {
            InitializeComponent();
            InitialParam();
            CommonBindEvent();
            //计时器循环设置时间读取    通过+=
            UpdateTimer.Interval = 500;
            UpdateTimer.Tick += UpdateTimer_Tick;

            this.DevicePaths = DevicePath;

            this.FormClosing += (sender, e) =>
            {
                UpdateTimer.Stop();
            };

            this.UpdateTimer.Start();

        }



        /// <summary>
        /// 通过时间间隔的触发事件来循环读取寄存器里面的变量
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            GetLimitParam();
            GetAlarmParam();
        }
        /// <summary>
        /// 读取并更新控件的限制变量
        /// </summary>
        private void GetLimitParam()
        {
            if (CommonMethod.Deviced.IsConnected)
            {
                //对查找所有panel里面的textset控件进行访问
                foreach (var item in MainPanel.Controls.OfType<TextSet>())
                {
                    if (item.BindAlarmVarName != null && item.BindAlarmVarName.ToString().Length > 0)
                    {
                        //对控件的数据进行读取更新
                        item.CurrentVariable = CommonMethod.Deviced[item.BindAlarmVarName].ToString();
                        
                    }
                    if (item.BindAlarmName != null && item.BindAlarmName.ToString().Length > 0)
                    {
                        //获取modbus寄存器的值写入到控件变量中
                        item.IsAlarm = CommonMethod.Deviced[item.BindAlarmName].ToString() == "True";
                    }
                }

            }
        }
        /// <summary>
        /// 读取报警数据
        /// </summary>
        private void GetAlarmParam()
        {
            if (CommonMethod.Deviced.IsConnected)
            {
                foreach (var item in MainPanel.Controls.OfType<CheckBoxEx>())
                {
                    if (item.Tag != null && item.Tag.ToString().Length > 0)
                    {
                        item.Checked = CommonMethod.Deviced[item.Tag.ToString()].ToString() == "1";
                    }
                }
            }
        }

        #region 属性与字段

        private string DevicePaths = string.Empty;

        private Timer UpdateTimer = new Timer();

        #endregion

        #region 通信配置和变量配置


        private void btn_groupConfig_Click(object sender, EventArgs e)
        {
            new FrmGroupConfig().Show();
        }

        private void btn_VariableConfig_Click(object sender, EventArgs e)
        {
            new FrmVariableConfig().Show();
        }
        #endregion

        #region 设置新变量写入配置文件


        /// <summary>
        ///  设置新变量写入配置文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_sureSetting_Click(object sender, EventArgs e)
        {
            bool result = IniConfigHelper.WriteIniData("设备参数", "IP地址", this.txt_IP.Text, DevicePaths);

            result &= IniConfigHelper.WriteIniData("设备参数", "端口号", this.txt_Port.Text, DevicePaths);

            if (result)
            {

                CommonMethod.Deviced.IPAddress = this.txt_IP.Text.Trim();
                CommonMethod.Deviced.Port = int.Parse(this.txt_Port.Text);

                FrmMsgBoxWithoutAck frmMsgBox = new FrmMsgBoxWithoutAck("通信配置写入成功,是否确定重连", "写入成功");

                frmMsgBox.ShowDialog();
                if (frmMsgBox.DialogResult == DialogResult.OK)
                {
                    CommonMethod.Deviced.IsConnected = false;
                }

            }
            else
            {
                new FrmMsgBoxWithAck("通信配置写入失败", "写入失败").Show();
            }
        }
        #endregion

        #region 初始化时加载对设置参数进行修改

        /// <summary>
        /// 初始化参数变量
        /// </summary>
        private void InitialParam()
        {

            this.txt_IP.Text = CommonMethod.Deviced.IPAddress;
            this.txt_Port.Text = (CommonMethod.Deviced.Port).ToString();

            GetLimitParam();
            GetAlarmParam();

        }
        /// <summary>
        /// 取消设置，回复原本设置的值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_cancelStting_Click(object sender, EventArgs e)
        {
            this.txt_IP.Text = CommonMethod.Deviced.IPAddress;
            this.txt_Port.Text = (CommonMethod.Deviced.Port).ToString();
        }
        #endregion
        /// <summary>
        /// 事件挂接方法
        /// </summary>
        public void CommonBindEvent()
        {
            foreach (var item in this.MainPanel.Controls.OfType<TextSet>())
            {
                if (item.BindAlarmName != null&&item.BindAlarmName.ToString().Length>0)
                {
                    item.ControlDoubleClick += Common_DoubleClick;
                }
            }
            foreach (var item in this.MainPanel.Controls.OfType<CheckBoxEx>())
            {
                if (item.Tag!=null&&item.Tag.ToString().Length>0)
                {
                    item.CheckedChanged += Common_CheckedChanged;
                }
            }
        }
        /// <summary>
        /// 通用修改报警上下限值
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_DoubleClick(object sender, EventArgs e)
        {
            if (sender is TextSet textset)
            {
                string BindVarName = textset.BindAlarmVarName;
                string currentValue = textset.CurrentVariable;
                string titleName = textset.TitleName;
                new FrmModify(titleName, currentValue, BindVarName).ShowDialog();
            }
        }
        /// <summary>
        /// 通用修改报警启用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Common_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBoxEx checkbox)
            {
                bool result = CommonMethod.CommonWirte(checkbox.Tag.ToString(), checkbox.Checked ? "1" : "0");

                if (result==false)
                {
                    checkbox.CheckedChanged -= Common_CheckedChanged;
                    checkbox.Checked = !checkbox.Checked;
                    checkbox.CheckedChanged += Common_CheckedChanged;
                }
            }
        }

    }
}

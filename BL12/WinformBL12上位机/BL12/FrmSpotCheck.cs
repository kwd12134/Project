using CurrentVariable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public partial class FrmSpotCheck : Form
    {
        public FrmSpotCheck(string Time,DateTime DayShift, DateTime NightShift)
        {
            InitializeComponent();
            this.lab_Time.Text = Time;
            dateTimeDayShift = DayShift;
            dateTimeNightShift = NightShift;
        }

        public DateTime dateTimeDayShift {  get; set; }

        public DateTime dateTimeNightShift { get; set; }

        public bool Status {  get; set; }   

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == IniConfigHelper.ReadIniData("System", "PassWord", "") && this.textBox2.Text == "Operator")
                {
                    JudgeCheckTimeEnable();
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("账号或者密码错误");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }

        public void JudgeCheckTimeEnable()
        {
            if (DateTime.Now >= dateTimeDayShift && DateTime.Now <= dateTimeNightShift)
            {
                IniConfigHelper.WriteIniData("CheckTime", "DayShiftSpotCheck", "1");
                IniConfigHelper.WriteIniData("CheckTime", "NightShiftSpotCheck", "0");
                IniConfigHelper.WriteIniData("CheckTime", "LoginTime", DateTime.Now.ToString("f"));
                GlobalVariable.CheckTime.DayShiftSpotCheck = true;
                GlobalVariable.CheckTime.NightShiftSpotCheck = false;
            }
            else
            {
                IniConfigHelper.WriteIniData("CheckTime", "NightShiftSpotCheck", "1");
                IniConfigHelper.WriteIniData("CheckTime", "DayShiftSpotCheck", "0");
                IniConfigHelper.WriteIniData("CheckTime", "LoginTime", DateTime.Now.ToString("f"));
                GlobalVariable.CheckTime.DayShiftSpotCheck = false;
                GlobalVariable.CheckTime.NightShiftSpotCheck = true;
            }
        }
    }
}

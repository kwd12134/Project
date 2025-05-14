using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CurrentVariable;
namespace BL12
{
    public partial class FrmChangePwd : Form
    {
        public FrmChangePwd()
        {
            InitializeComponent();
        }
        public string Path = Application.StartupPath + "\\Setting\\Setting.ini";
        private void Button_Click(object sender, EventArgs e)
        {
            if (this.TextBox_Original.Text == GlobalVariable.PassWord)
            {
                if (this.TextBox_Confirm.Text == this.TextBox_Modify.Text)
                {
                    GlobalVariable.PassWord = this.TextBox_Modify.Text;
                    IniConfigHelper.WriteIniData("System", "UserPwd", GlobalVariable.PassWord, Path);
                    MessageBox.Show("修改成功");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("两次密码不一致");
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("原密码错误");
                this.Close();
            }
        }
    }

}

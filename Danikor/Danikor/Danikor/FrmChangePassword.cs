using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Helper;
using Sunny.UI;
namespace Danikor
{
    public partial class FrmChangePassword : UIForm
    {
        public FrmChangePassword(string path)
        {
            InitializeComponent();
            this.Path = path;
        }

        public string Path { get; set; }

        private void uiButton_Click(object sender, EventArgs e)
        {
            if (this.uiTextBox_Original.Text == Variable.UserPwd)
            {
                if (this.uiTextBox_Confirm.Text == this.uiTextBox_Modify.Text)
                {
                    Variable.UserPwd = this.uiTextBox_Modify.Text;
                    IniConfigHelper.WriteIniData("System", "UserPwd", Variable.UserPwd, Path);
                    this.ShowSuccessTip("修改成功");
                    this.Close();
                }
                else
                {
                    this.ShowErrorTip("两次密码不一致");
                    this.Close();
                }
            }
            else
            {
                this.ShowErrorTip("原密码错误");
                this.Close();
            }
        }
    }
}

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
using Sunny.UI;
namespace Danikor
{
    public partial class FrmLogin : UIForm
    {
        public FrmLogin()
        {
            InitializeComponent();
        }


        private void but_affirm_Click(object sender, EventArgs e)
        {
            if (this.text_accont.Text == "Admin" && this.text_Password.Text == "")
            {
                this.ShowErrorTip("Admin密码为空请重新输入");
                return;
            }
            if (this.text_accont.Text == "Admin" )
            {
                if (this.text_Password.Text == Variable.UserPwd)
                {
                    this.ShowSuccessTip("管理员登录成功");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    this.ShowErrorTip("账号或者密码为错误!!! 请重新输入");
                }
            }
            if (this.text_accont.Text == "Operator")
            {
                this.ShowSuccessTip("操作员登录成功");
                this.DialogResult = DialogResult.Cancel;
            }
        }

        private void but_cLear_Click(object sender, EventArgs e)
        {
            this.text_Password.Text = "";
        }

        private void text_Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                but_affirm_Click(null, null);
            }
        }
    }
}

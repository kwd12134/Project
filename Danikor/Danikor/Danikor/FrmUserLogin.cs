using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Sunny.UI;
namespace Danikor
{
    public partial class FrmUserLogin : UIForm
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }

        private void uiButton1_Click(object sender, EventArgs e)
        {

            if (this.uiTextBox1.Text == "" || this.uiTextBox1.Text == null || this.uiTextBox1.Text.Length != 8 || this.uiTextBox1.Text.Substring(0, 1).ToLower() != "x")
            {

                this.ShowErrorTip("格式错误!!! 请重新输入");
                return;
            }
            foreach (var item in this.uiTextBox1.Text.Substring(1, 7))
            {
                var a = Encoding.ASCII.GetBytes(item.ToString());
                if (a[0] <= 48 || a[0] >= 57)
                {
                    this.ShowErrorTip("格式错误!!! 请重新输入");
                    return;
                }
            }

            Variable.UserID = this.uiTextBox1.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void uiTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                uiButton1_Click(null, null);
            }
        }
    }
}

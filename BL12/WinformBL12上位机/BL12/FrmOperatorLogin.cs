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
    public partial class FrmOperatorLogin : Form
    {
        public FrmOperatorLogin()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.textBox1.Text == "" || this.textBox1.Text == null || this.textBox1.Text.Length != 8 || this.textBox1.Text.Substring(0, 1).ToLower() != "x")
            {
                MessageBox.Show("格式错误!!! 请重新输入");
                return;
            }

            foreach (var item in this.textBox1.Text.Substring(1, 7))
            {
                var a = Encoding.ASCII.GetBytes(item.ToString());
                if (a[0] <= 48 || a[0] >= 57)
                {
                    MessageBox.Show("格式错误!!! 请重新输入");
                    return;
                }
            }

            GlobalVariable.OperatorID = this.textBox1.Text.Trim();
            this.DialogResult = DialogResult.OK;
        }

        private void uiTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Button1_Click(null, null);
            }
        }
    }
}

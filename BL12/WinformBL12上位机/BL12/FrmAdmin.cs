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
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if(textBox1.Text == GlobalVariable.PassWord)
                {
                    GlobalVariable.AddLog(0, "解锁成功");
                    this.DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("密码错误");
                    this.DialogResult = DialogResult.Cancel;
                }
            }
        }
    }
}

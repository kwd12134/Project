using SQLBLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }

        private void but_Login_Click(object sender, EventArgs e)
        {
            AdminManager.Admin = this.text_Account.Text.Trim();
            DataSet Result = SQLiteQuery.QueryUser();
            if (Result != null)
            {
                if (this.text_Account.Text != Result.Tables[0].Rows[0]["Admin"].ToString())
                {
                    MessageBox.Show("账号错误");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                if (this.text_Pwd.Text != Result.Tables[0].Rows[0]["Pwd"].ToString())
                {
                    MessageBox.Show("密码错误");
                    this.DialogResult = DialogResult.Cancel;
                    return;
                }
                AdminManager.Power = Result.Tables[0].Rows[0]["Power"].ToString(); 
                AdminManager.Admin = Result.Tables[0].Rows[0]["Admin"].ToString();
                AdminManager.Pwd = Result.Tables[0].Rows[0]["Pwd"].ToString();
                AdminManager.Id = Result.Tables[0].Rows[0]["Id"].ToString();
            }
            else
            {
                MessageBox.Show("账号不存在");
                this.DialogResult = DialogResult.Cancel;
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void text_Pwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                but_Login_Click(null, null); 
            }
        }
    }
}

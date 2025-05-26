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
    public partial class FrmModifyAccount : Form
    {
        public FrmModifyAccount()
        {
            InitializeComponent();
            this.text_Account.Text = AdminManager.Admin;
        }

        private void but_Modify_Click(object sender, EventArgs e)
        {

            bool result = false;
            try
            {
                DataSet dataSet = SQLiteQuery.QueryUser(this.text_Account.Text.Trim());
                if (dataSet != null)
                {
                    if (dataSet.Tables[0].Rows[0]["Pwd"].ToString() == this.text_Pwd.Text.Trim())
                    {
                        result = SQLiteQuery.UpDateUserPwd(this.text_ModifyPwd.Text.Trim(), dataSet.Tables[0].Rows[0]["Id"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("用户不存在");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("修改失败" +ex.Message);
            }
            if (!result)
            {
                MessageBox.Show("修改失败");
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using KWDHTMmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWD.MTHproject
{
    public partial class FrmModify : Form
    {
        public FrmModify(string VarName,string CurrentValue,string BindVarName)
        {
            InitializeComponent();
            this.lbl_VarName.Text = VarName;
            this.lbl_CurrentValue.Text = CurrentValue;
            bindVarName = BindVarName;

            this.txt_SetValue.Focus();
        }
        /// <summary>
        /// 变量标签
        /// </summary>
        private string bindVarName = string.Empty;

        private void btn_suer_Click(object sender, EventArgs e)
        {
            bool Result = CommonMethod.CommonWirte(bindVarName, this.txt_SetValue.Text.Trim());

            if (Result)
            {
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                new FrmMsgBoxWithAck("变量修改失败", "写入失败").Show();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region 无边框拖动

        private Point mPoint;

        private void Panel_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Panel_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);
            }
        }

        #endregion

        private void txt_SetValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode==Keys.Enter)
            {
                this.btn_suer_Click(null, null);
            }
        }

    }
}

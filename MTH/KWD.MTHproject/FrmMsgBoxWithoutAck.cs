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
    public partial class FrmMsgBoxWithoutAck : Form
    {
        public FrmMsgBoxWithoutAck(string title, string content)
        {
            InitializeComponent();
            //设置最顶层窗体
            this.TopMost = true;

            this.lbl_title.Text = content;
            this.lbl_content.Text = title;

        }

        private void btn_suer_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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

    }
   
}

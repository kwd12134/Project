using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Monitor : Form
    {
        public Monitor(bool Statu,int delay)
        {
            InitializeComponent();
            this.lab_OKNG.BringToFront();
            OKNG = Statu;
            if (!OKNG)
            {
                this.lab_OKNG.ForeColor = Color.Red;
                this.lab_OKNG.Text = "NG";
            }
            else
            {
                this.lab_OKNG.ForeColor = Color.Green;
                this.lab_OKNG.Text = "OK";
            }
            storeTimer.Interval = delay;
            storeTimer.AutoReset = true;
            storeTimer.Elapsed += StoreTimer_Elapsed;
            storeTimer.Start();
        }

        #region 减少闪烁
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parss = base.CreateParams;
                parss.ExStyle |= 0x02000000;
                return parss;
            }
        }
        #endregion

        private void StoreTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 使用Invoke确保线程安全地访问UI控件
            if (this.InvokeRequired)
            {
                this.Invoke(new MethodInvoker(Close));
            }
            else
            {
                this.Close();
            }
        }

        private System.Timers.Timer storeTimer = new System.Timers.Timer();
        private bool OKNG;

        public bool OK_NG
        {
            get { return OKNG; }
            set
            {
                OKNG = value;

            }
        }
    }
}

using KWD.MHTDAL;
using KWDHTMmodels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWD.MTHproject
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }
        private SysAdminService sysAdminService= new SysAdminService();

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if (this.text_loginName.Text.ToString().Length==0)
            {
                new FrmMsgBoxWithAck("登录用户名称不能为空", "登录失败").ShowDialog();
                this.text_loginName.Focus();
                return;
            }
            if (this.text_possword.Text.ToString().Length == 0)
            {
                new FrmMsgBoxWithAck("登录用户密码不能为空", "登录失败").ShowDialog();
                this.text_possword.Focus();
                return;
            }

            SysAdmin sysAdmin = new SysAdmin()
            {
                Loginpwd = this.text_possword.Text.Trim(),
                LoginName = this.text_loginName.Text.Trim(),
            };

            sysAdmin = sysAdminService.AdminLogin(sysAdmin);

            if (sysAdmin==null)
            {
                new FrmMsgBoxWithAck("登录账户名或者密码错误", "登录失败").ShowDialog();
                this.text_loginName.Focus();
                return;
            }
            else
            {
                this.DialogResult = DialogResult.OK;

                //存储当前用户信息
                CommonMethod.CureenAdmin = sysAdmin;

            }

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

        private void lbl_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void text_loginName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                btn_Login_Click(null, null);
            }
        }

        #region 启用软键盘

        private void StartKeyBoard()
        {
            //打开软键盘
            try
            {
                if (!System.IO.File.Exists(Environment.SystemDirectory + "\\osk.exe"))
                {
                    MessageBox.Show("软件盘可执行文件不存在！");
                    return;
                }

                softKey = System.Diagnostics.Process.Start(Environment.SystemDirectory + "\\osk.exe");
                // 上面的语句在打开软键盘后，系统还没用立刻把软键盘的窗口创建出来了。所以下面的代码用循环来查询窗口是否创建，只有创建了窗口
                // FindWindow才能找到窗口句柄，才可以移动窗口的位置和设置窗口的大小。这里是关键。
                IntPtr intptr = IntPtr.Zero;
                while (IntPtr.Zero == intptr)
                {
                    System.Threading.Thread.Sleep(100);
                    intptr = FindWindow(null, "屏幕键盘");
                }


                // 获取屏幕尺寸
                int iActulaWidth = Screen.PrimaryScreen.Bounds.Width;
                int iActulaHeight = Screen.PrimaryScreen.Bounds.Height;


                // 设置软键盘的显示位置，底部居中
                int posX = (iActulaWidth - 1000) / 2;
                int posY = (iActulaHeight - 300);


                //设定键盘显示位置
                MoveWindow(intptr, posX, posY, 1000, 300, true);


                //设置软键盘到前端显示
                SetForegroundWindow(intptr);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        // 申明要使用的dll和api
        [DllImport("User32.dll", EntryPoint = "FindWindow")]
        public extern static IntPtr FindWindow(string lpClassName, string lpWindowName);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "MoveWindow")]
        public static extern bool MoveWindow(System.IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);


        [DllImport("user32.dll")]
        static extern bool SetForegroundWindow(IntPtr hWnd);


        private System.Diagnostics.Process softKey;

        #endregion

        private void text_loginName_DoubleClick(object sender, EventArgs e)
        {
            StartKeyBoard();
        }

    }
}

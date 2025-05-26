using KYJDAL;
using SerialPortExample;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    internal static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //获取数据库位置
            SQLiteHelper.connString = "Data Source= " + Application.StartupPath + "\\DataBase\\RGBData.db;Pooling=true;FailIfMissing=false";
            //FrmAdmin frmAdmin = new FrmAdmin();
            //DialogResult result = frmAdmin.ShowDialog();
            //if (result == DialogResult.OK)
            //{
             Application.Run(new MainForm());
            //}
        }
    }
}

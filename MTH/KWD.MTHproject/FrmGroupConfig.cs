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
using MiniExcelLibs;
using thinger.MTHProject;
using System.Windows.Forms.VisualStyles;

namespace KWD.MTHproject
{
    public partial class FrmGroupConfig : Form
    {
        public FrmGroupConfig()
        {
            InitializeComponent();

            this.cmb_StoreArea.DataSource = new List<string>() { "输入线圈", "输出线圈", "输入寄存器", "输出寄存器" };

            //我们自己手动添加不需要自动添加
            this.dgv_Mian.AutoGenerateColumns = false;

            //读取
            TotalGroup = GrtAllGroup();
            //刷新
            RefreshGroup();
        }

        #region 字段属性

        /// <summary>
        /// 存储xlsx的文件路径
        /// </summary>
        private string GroupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        /// <summary>
        /// 文件中包含的所有Group组的所有文件
        /// </summary>
        private List<Group> TotalGroup = new List<Group>();

        /// <summary>
        /// 无边框拖动定位参数
        /// </summary>
        private Point Point;


        #endregion

        #region 查询路径里面的Xlsx文件转化为List<Group>


        /// <summary>
        /// 查询路径里面的Xlsx文件转化为List<Group>
        /// </summary>
        /// <returns></returns>
        private List<Group> GrtAllGroup()
        {
            //查询group属性路径中的文件返回    

            try
            {
                return MiniExcel.Query<Group>(GroupPath).ToList();

            }
            catch (Exception)
            {

                return new List<Group>();
            }
        }
        #endregion

        #region 对DataGridView 的内容进行刷新显示


        //对DataGridView 的内容进行刷新显示
        private void RefreshGroup()
        {
            this.dgv_Mian.DataSource = null;
            this.dgv_Mian.DataSource = TotalGroup;
        }
        #endregion

        #region 判断通信组名称是否存在

        /// <summary>
        /// 判断组名称是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool IsGroupName(string Name)
        {

            //使用lambda表达式对传入的string值和totalGroup里面的GroupName进行对比    如果有相等就返回false   否则trun

            return TotalGroup.FindAll(c => c.GroupName == Name).ToList().Count() > 0;
        }
        #endregion

        #region 删除通信组


        /// <summary>
        /// 删除通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string GroupName = this.txt_groupName.Text.Trim();

            if (!IsGroupName(GroupName))
            {
                new FrmMsgBoxWithAck("通信组删除失败: 没有该名称", "新建失败").Show();
                return;
            }

            TotalGroup.RemoveAll(c => c.GroupName == GroupName);

            try
            {
                //删除后重新写入
                MiniExcel.SaveAs(GroupPath, TotalGroup, overwriteFile: true);
                //刷新
                RefreshGroup();
            }
            catch (Exception)
            {

                new FrmMsgBoxWithAck("通信组删除失败", "新建失败").Show();
            }

        }
        #endregion

        #region 修改通信组

        private void btn_Modify_Click(object sender, EventArgs e)
        {

            string GroupNames = this.txt_groupName.Text.Trim();

            if (!IsGroupName(GroupNames))
            {
                new FrmMsgBoxWithAck("通信组修改失败: 没有该名称", "修改失败").Show();
                return;
            }
            Group Group = TotalGroup.Find(c => c.GroupName == GroupNames);

            Group.Start = (ushort)this.num_Start.Value;
            Group.Length = (ushort)this.num_Length.Value;
            Group.StoreArea = this.cmb_StoreArea.Text;
            Group.Remark = this.txt_Remark.Text;

            try
            {
                //删除后重新写入
                MiniExcel.SaveAs(GroupPath, TotalGroup, overwriteFile: true);
                //刷新
                RefreshGroup();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithAck("通信组修改失败" + ex.Message, "修改失败").Show();
            }

        }


        #endregion

        #region 新建通信组

        /// <summary>
        /// 新建通信组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {

            string GroupName = this.txt_groupName.Text.Trim();

            if (IsGroupName(GroupName))
            {
                new FrmMsgBoxWithAck("变量组新建失败: 已有相同组名称", "新建失败").Show();
                return;
            }

            if (GroupName == "")
            {
                new FrmMsgBoxWithAck("变量组新建失败: 变量组名称不能为空", "新建失败").Show();
                return;
            }


            try
            {
                //新建一个group组
                TotalGroup.Add(new Group()
                {
                    GroupName = GroupName.Trim(),
                    Start = (ushort)this.num_Start.Value,
                    Length = (ushort)this.num_Length.Value,
                    StoreArea = this.cmb_StoreArea.Text.Trim(),
                    Remark = this.txt_Remark.Text.Trim()
                }); 


                //将group组保存文件到groupPath路径中   overwriteFile（覆盖文件）写入到同一个xlsx中不同行  也表示着 list0  list1

                MiniExcel.SaveAs(GroupPath, TotalGroup, overwriteFile: true);

                new FrmMsgBoxWithAck("变量组新建成功", "新建成功").Show();

                RefreshGroup();
            }
            catch (Exception ex)
            {

                new FrmMsgBoxWithAck("变量组新建失败:" + ex.Message, "新建失败").Show();

            }


        }
        #endregion

        #region 无边框拖动


        private void panelEX_MouseDown(object sender, MouseEventArgs e)
        {
            Point = new Point(e.X, e.Y);
        }

        private void panelEX_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - Point.X, this.Location.Y + e.Y - Point.Y);
            }
        }

        #endregion

        #region DataGridView 行数选中编号设置

        /// <summary>
        /// 行数选中编号设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgv_Mian_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        #endregion

        #region 对通信组里面的null值添加---


        private void dgv_Mian_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                var Value = this.dgv_Mian.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                if (Value == null || Value.ToString().Length == 0)
                {
                    e.Value = "---";
                }
            }
        }
        #endregion

        #region 关闭窗体

        /// <summary>
        /// 关闭窗体
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion

        #region 点击DataGridView的数据行更新到写入栏中

        private void dgv_Mian_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                //点击当前行数获取当前对应的Group数组对象\

                UpDateGroup(TotalGroup[e.RowIndex]);

            }
        }

        private void UpDateGroup(Group group)
        {
            if (group != null)
            {
                this.txt_groupName.Text = group.GroupName;
                this.num_Start.Text = group.Start.ToString();
                this.num_Length.Text = group.Length.ToString();
                this.cmb_StoreArea.Text = group.StoreArea;
                this.txt_Remark.Text = group.Remark;
            }

        }
        #endregion

    }
}



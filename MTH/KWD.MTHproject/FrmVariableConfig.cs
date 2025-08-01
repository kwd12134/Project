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
using thinger.DataConvertLib;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace KWD.MTHproject
{
    public partial class FrmVariableConfig : Form
    {
        public FrmVariableConfig()
        {
            InitializeComponent();


            this.cmb_DataType.DataSource = Enum.GetNames(typeof(thinger.DataConvertLib.DataType));

            //我们自己手动添加不需要自动添加
            this.dgv_Mian.AutoGenerateColumns = false;

            //读取
            TotalGroup = GrtAllGroup();

            //读取

            TotalVariable = GrtAllVariable();

            if (TotalGroup.Count >= 0)
            {

                foreach (var item in TotalGroup)
                {
                    //设置combobox的
                    this.cmb_groupName.Items.Add(item.GroupName);
                }
                this.cmb_groupName.SelectedIndex = 0;
            }
            //刷新
            RefreshVariable();
        }

        #region 字段属性

        /// <summary>
        /// 存储xlsx的文件路径
        /// </summary>
        private string GroupPath = Application.StartupPath + "\\Config\\Group.xlsx";

        private string VariablePath = Application.StartupPath + "\\Config\\Variable.xlsx";

        /// <summary>
        /// 文件中包含的所有Group组的所有文件
        /// </summary>
        private List<Group> TotalGroup = new List<Group>();

        private List<Variable> TotalVariable = new List<Variable>();

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

        #region 查询路径里面的Xlsx文件转化为List<Variable>


        /// <summary>
        /// 查询路径里面的Xlsx文件转化为List<Variable>
        /// </summary>
        /// <returns></returns>
        private List<Variable> GrtAllVariable()
        {
            //查询group属性路径中的文件返回

            try
            {

                return MiniExcel.Query<Variable>(VariablePath).ToList();

            }
            catch (Exception)
            {
                return new List<Variable>();
            }
        }
        #endregion

        #region 对DataGridView 的内容进行刷新显示


        //对DataGridView 的内容进行刷新显示
        private void RefreshVariable()
        {

            var list = GetVariableByGroup(this.cmb_groupName.Text.Trim());

            if (list.Count>0)
            {

                this.dgv_Mian.DataSource = null;
                this.dgv_Mian.DataSource = TotalVariable;

            }
        }
        #endregion

        #region 根据通信组名称筛选

        private List<Variable> GetVariableByGroup(string groupname)
        {

            if (groupname.Length == 0)
            {
                return TotalVariable;
            }
            else
            {
                return TotalVariable.FindAll(c => c.GroupName == groupname).ToList();
            }

        }

        #endregion

        #region 判断变量组名称是否存在

        /// <summary>
        /// 判断组名称是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        private bool IsVarName(string Name)
        {

            //使用lambda表达式对传入的string值和totalGroup里面的GroupName进行对比    如果有相等就返回false   否则trun

            return TotalVariable.FindAll(c => c.VarName == Name).ToList().Count() > 0;
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
            string VariableName = this.txt_varName.Text.Trim();

            if (!IsVarName(VariableName))
            {
                new FrmMsgBoxWithAck("变量组删除失败: 没有该名称", "删除失败").Show();
                return;
            }

            TotalVariable.RemoveAll(c => c.VarName == VariableName);

            try
            {
                //删除后重新写入
                MiniExcel.SaveAs(VariablePath, TotalVariable, overwriteFile: true);
                //刷新
                RefreshVariable();
            }
            catch (Exception)
            {

                new FrmMsgBoxWithAck("变量组删除失败", "删除失败").Show();
            }

        }
        #endregion

        #region 修改通信组

        private void btn_Modify_Click(object sender, EventArgs e)
        {

            string VariableNames = this.txt_varName.Text.Trim();

            if (!IsVarName(VariableNames))
            {
                new FrmMsgBoxWithAck("变量组修改失败: 没有该名称", "修改失败").Show();
                return;
            }

            Variable Variables = TotalVariable.Find(c => c.VarName == VariableNames);

            Variables.Start = (ushort)this.num_Start.Value;
            Variables.OffsetOrLength = (ushort)this.num_Length.Value;
            Variables.Offset = (float)this.num_Offset.Value;
            Variables.DataType = this.cmb_DataType.Text;
            Variables.Scale = (float)this.num_Scale.Value;
            Variables.GroupName = this.cmb_groupName.Text.Trim();
            Variables.PosAlarm = this.chk_posAlarm.Checked;
            Variables.NegAlarm = this.chk_NegAlarm.Checked;
            Variables.Remark = this.txt_Remark.Text.Trim();

            try
            {
                //删除后重新写入
                MiniExcel.SaveAs(VariablePath, TotalVariable, overwriteFile: true);
                //刷新
                RefreshVariable();
            }
            catch (Exception ex)
            {
                new FrmMsgBoxWithAck("变量组修改失败" + ex.Message, "修改失败").Show();
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

            string VarName = this.txt_varName.Text.Trim();

            if (IsVarName(VarName))
            {
                new FrmMsgBoxWithAck("通信组新建失败: 已有相同组名称", "新建失败").Show();
                return;
            }

            if (VarName == "")
            {
                new FrmMsgBoxWithAck("通信组新建失败: 通信组名称不能为空", "新建失败").Show();
                return;
            }


            try
            {
                //新建一个group组
                TotalVariable.Add(new Variable()
                {
                    VarName = VarName.Trim(),
                    Start = (ushort)this.num_Start.Value,
                    OffsetOrLength = (ushort)this.num_Length.Value,
                    Offset = (float)this.num_Offset.Value,
                    DataType = this.cmb_DataType.Text,
                    Scale = (float)this.num_Scale.Value,
                    GroupName = this.cmb_groupName.Text.Trim(),
                    PosAlarm = this.chk_posAlarm.Checked,
                    NegAlarm = this.chk_NegAlarm.Checked,
                    Remark = this.txt_Remark.Text.Trim(),
                });


                //将group组保存文件到groupPath路径中   overwriteFile（覆盖文件）写入到同一个xlsx中不同行  也表示着 list0  list1

                MiniExcel.SaveAs(VariablePath, TotalVariable, overwriteFile: true);

                new FrmMsgBoxWithAck("通信组新建成功", "新建成功").Show();

                RefreshVariable();
            }
            catch (Exception ex)
            {

                new FrmMsgBoxWithAck("通信组新建失败:" + ex.Message, "新建失败").Show();

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

                if (e.ColumnIndex == 6 || e.ColumnIndex == 7)
                {
                    e.Value = Value.ToString() == "True" ? "启用" : "禁用";
                }
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

        private void btn_Close_Click(object sender, EventArgs e)
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

                UpDateVariable(TotalVariable[e.RowIndex]);

            }
        }

        private void UpDateVariable(Variable variable)
        {

            if (variable != null)
            {

                this.txt_varName.Text = variable.VarName;
                this.num_Start.Value = variable.Start;
                this.num_Length.Value = variable.OffsetOrLength;
                this.num_Offset.Value = variable.OffsetOrLength;
                this.cmb_DataType.Text = variable.DataType;
                this.num_Scale.Value = (decimal)variable.Scale;
                this.cmb_groupName.Text = variable.GroupName;
                this.chk_posAlarm.Checked = variable.PosAlarm;
                this.chk_NegAlarm.Checked = variable.NegAlarm;
                this.txt_Remark.Text = variable.Remark;

            }

        }

        #endregion

        private void dgv_Mian_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}



using MiniExcelLibs;
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
    public partial class FrmVariableConfig : Form
    {

        private string VariablePath = Application.StartupPath + "\\Config\\DeviceConfig.xlsx";

        public FrmVariableConfig()
        {
            InitializeComponent();
            Initalize();
            RefreshVariable();
        }

        private void RefreshVariable()
        {
            if (CommandMethod.DeviceConfig != null)
            {
                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = CommandMethod.DeviceConfig;
                this.dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            }
        }

        public void Initalize()
        {
            //    查询路径里的xlsx文件转换为list<Variable>类型
            try
            {
                CommandMethod.DeviceConfig = MiniExcel.Query<Variable>(VariablePath).ToList();
            }
            catch (Exception)
            {
                CommandMethod.DeviceConfig = new List<Variable>();
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string DeviceName = this.text_DeviceName.Text.Trim();

            if (DeviceName == null || DeviceName == "")
            {
                MessageBox.Show("设备名称为空!,无法新建");
                return;
            }
            if (IsDeviceName(DeviceName))
            {
                MessageBox.Show("设备名称已经存在!,无法新建");
                return;
            }
            try
            {
                CommandMethod.DeviceConfig.Add(new Variable()
                {
                    DeviceName = this.text_DeviceName.Text.Trim(),
                    RMIN = this.textBox1.Text.Trim(),
                    RMAX = this.textBox2.Text.Trim(),
                    GMIN = this.textBox3.Text.Trim(),
                    GMAX = this.textBox4.Text.Trim(),
                    BMIN = this.textBox5.Text.Trim(),
                    BMAX = this.textBox6.Text.Trim(),
                    IRMIN = this.textBox7.Text.Trim(),
                    IRMAX = this.textBox8.Text.Trim(),
                });

                MiniExcel.SaveAs(VariablePath, CommandMethod.DeviceConfig, overwriteFile: true);
                MessageBox.Show("创建成功");
                RefreshVariable();
            }
            catch (Exception)
            {
                MessageBox.Show("创建失败,请检查是否打开配置文件");
            }

        }

        /// <summary>
        /// 判断组名称是否存在
        /// </summary>
        /// <param name="Name"></param>
        /// <returns></returns>
        public bool IsDeviceName(string Name)
        {
            return CommandMethod.DeviceConfig.FindAll(c => c.DeviceName == Name).ToList().Count() > 0;
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            string Name = this.text_DeviceName.Text.Trim();
            if (!IsDeviceName(Name))
            {
                MessageBox.Show("删除失败没有改名称");
                return;
            }

            CommandMethod.DeviceConfig.RemoveAll(c => c.DeviceName == Name);

            try
            {
                MiniExcel.SaveAs(VariablePath, CommandMethod.DeviceConfig, overwriteFile: true);
                RefreshVariable();
            }
            catch (Exception)
            {
                MessageBox.Show("删除失败");
            }
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            string Name = this.text_DeviceName.Text.Trim();

            if (!IsDeviceName(Name))
            {
                MessageBox.Show("修改失败没有改名称");
                return;
            }

            var ModifyVariable = CommandMethod.DeviceConfig.Find(c => c.DeviceName == Name);

            ModifyVariable.DeviceName = this.text_DeviceName.Text.Trim();
            ModifyVariable.RMIN = this.textBox1.Text;
            ModifyVariable.RMAX = this.textBox2.Text;
            ModifyVariable.GMIN = this.textBox3.Text;
            ModifyVariable.GMAX = this.textBox4.Text;
            ModifyVariable.BMIN = this.textBox5.Text;
            ModifyVariable.BMAX = this.textBox6.Text;
            ModifyVariable.IRMIN = this.textBox7.Text;
            ModifyVariable.IRMAX = this.textBox8.Text;

            try
            {
                MiniExcel.SaveAs(VariablePath, CommandMethod.DeviceConfig, overwriteFile: true);
                RefreshVariable();
            }
            catch (Exception)
            {
                MessageBox.Show("修改失败");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                UpdataVariable(CommandMethod.DeviceConfig[e.RowIndex]);
            }
        }

        public void UpdataVariable(Variable variable)
        {
            this.text_DeviceName.Text = variable.DeviceName;
            this.textBox1.Text = variable.RMIN;
            this.textBox2.Text = variable.RMAX;
            this.textBox3.Text = variable.GMIN;
            this.textBox4.Text = variable.GMAX;
            this.textBox5.Text = variable.BMIN;
            this.textBox6.Text = variable.BMAX;
            this.textBox7.Text = variable.IRMIN;
            this.textBox8.Text = variable.IRMAX;
        }
    }
}

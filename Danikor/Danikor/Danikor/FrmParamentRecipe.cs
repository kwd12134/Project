using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Data;
using Helper;
using Sunny.UI;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Communication;
using System.Diagnostics;
using thinger.DataConvertLib;
namespace Danikor
{
    public partial class FrmParamentRecipe : UIForm
    {
        public FrmParamentRecipe()
        {
            InitializeComponent();
            RefreshRecipe();
            if (recipeInfos.Count>0)
            {
               SetRecipeInfo(recipeInfos[0]);
            }
        }

        public string RecipePath { get; set; } = Application.StartupPath + "\\Recipe";


        public List<DeviceRecipeInfo> recipeInfos = new List<DeviceRecipeInfo>();

        private void uiDataGridView1_RowPostPaint_1(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        #region 添加配方

        /// <summary>
        /// 添加配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Add_Click(object sender, EventArgs e)
        {
            //非空验证
            if (this.txt_RecipeName.Text.Trim().Length == 0)
            {
                this.ShowErrorDialog("添加配方", "配方名称为空，请检查");
                return;
            }

            var info = recipeInfos.Where(p => p.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();

            if (info != null)
            {
                this.ShowErrorDialog("添加配方", "配方名称已存在");
                return;
            }
            var deviceRecipeInfo = GetRecipeInfo();
            bool result = AddRecipe(deviceRecipeInfo);

            if (result)
            {
                RefreshRecipe();
                this.ShowSuccessDialog("添加配方", "配方添加成功");
            }
            else
            {
                this.ShowErrorDialog("添加配方", "配方添加失败");

            }

        }

        #endregion

        #region 获取配方对象

        private DeviceRecipeInfo GetRecipeInfo()
        {
            DeviceRecipeInfo recipeInfo = new DeviceRecipeInfo();

            recipeInfo.RecipeName = this.txt_RecipeName.Text.Trim();

            recipeInfo.RecipeParameters = new RecipeParameter()
            {
                Rotate_Speed = (int)this.num_Rotate_Speed.Value,
                RotitionDirection = this.cmb_RotitionDirection.Text,
                Nm = this.num_Nm.Value.ToString("0.0000"),
                NmThreshold = this.num_NmThreshold.Value.ToString("0.0000"),
                StartDelay = this.num_StartDelay.Value.ToString("0.0000"),
                SlopeThreshold = this.num_SlopeThreshold.Value.ToString("0.0000"),
                KeepTime = this.num_KeepTime.Value.ToString("0.0000"),
                NmUpperLimit = this.num_NmUpperLimit.Value.ToString("0.0000"),
                NmLowerLimit = this.num_NmLowerLimit.Value.ToString("0.0000"),
                AngleUpperLimit = this.num_AngleUpperLimit.Value.ToString(),
                AngleLowerLimit = this.num_AngleLowerLimit.Value.ToString(),
                ScrewDownNm = this.num_ScrewDownNm.Value.ToString("0.0000"),
                ScrewDownAngleUpper = this.num_ScrewDownAngleUpper.Value.ToString(),
                ScrewDownAngleLower = this.num_ScrewDownAngleLower.Value.ToString(),
                LengthKeepTime = this.num_LengthKeepTime.Value.ToString("0.0000"),
                Upper = this.cmb_Upper.Text,
                ScrewLosse = this.cmb_ScrewLosse.Text,
                Repair = this.cmb_Repair.Text,
                ScrewDownCount = (int)this.num_ScrewDownCount.Value,
            };
            return recipeInfo;
        }

        #endregion

        #region 添加配方
        private bool AddRecipe(DeviceRecipeInfo recipeInfo)
        {
            string path = RecipePath + "\\" + recipeInfo.RecipeName + ".ini";

            return IniConfigHelper.WriteIniData("配方", "配方数据", JsonHelper.EntityToJSON(recipeInfo), path);
        }
        #endregion

        #region 修改配方

        /// <summary>
        /// 修改配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Modify_Click(object sender, EventArgs e)
        {
            //非空验证
            if (this.txt_RecipeName.Text.Trim().Length == 0)
            {
                this.ShowErrorDialog("修改配方", "配方名称为空，请检查");
                return;
            }

            var info = recipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();

            if (info == null)
            {
                this.ShowErrorDialog("修改配方", "当前配方名称不存在，无法修改");
                return;
            }

            var recipeInfo = GetRecipeInfo();

            bool result = AddRecipe(recipeInfo);

            if (result)
            {
                RefreshRecipe();
                this.ShowSuccessDialog("修改配方", "配方修改成功");
            }
            else
            {
                this.ShowErrorDialog("修改配方", "配方修改失败");
            }
        }

        #endregion

        #region 删除配方   

        /// <summary>
        /// 删除配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            //非空验证
            if (this.txt_RecipeName.Text.Trim().Length == 0)
            {
                this.ShowErrorDialog("删除配方", "配方名称为空，请检查");
                return;
            }

            var info = recipeInfos.Where(c => c.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();

            if (info == null)
            {

                this.ShowErrorDialog("删除配方", "当前配方名称不存在，请检查");
                return;
            }

            if (this.ShowAskDialog("确认删除配方?"))
            {
                bool result = DeleteRecipe(this.txt_RecipeName.Text.Trim());

                if (result)
                {
                    RefreshRecipe();

                    this.ShowSuccessDialog("删除配方", "配方删除成功");
                }
                else
                {
                    this.ShowErrorDialog("删除配方", "配方删除失败");
                }

            }
        }

        #endregion

        #region 应用配方

        public ITcpClient PsetClient;

        public ITcpClient JobcClient;


        /// <summary>
        /// 应用配方
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Apply_Click(object sender, EventArgs e)
        {
            //   应用配方前先把修改的配方保存
            btn_Modify_Click(null, null);

            PsetClient = ServiceLocator.GetService<ITcpClient>();
            // 创建并启动 Stopwatch 实例
            Stopwatch stopwatch = Stopwatch.StartNew();

            Variable.deviceRecipeInfo = recipeInfos.Where(p => p.RecipeName == this.txt_RecipeName.Text.Trim()).FirstOrDefault();
            if (Variable.deviceRecipeInfo == null)
            {
                this.ShowErrorDialog("应用配方", "当前配方名称不存在，请检查");
                return;
            }
            this.ShowWaitForm("正在写入当中...");
            string AngleUpperLimit = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.AngleUpperLimit);
            string AngleLowerLimit = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.AngleLowerLimit);
            string Nm = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.Nm);
            string NmLowerLimit = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.NmLowerLimit);
            string NmUpperLimit = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.NmUpperLimit);
            string Rotate_Speed = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.Rotate_Speed);
            string SlopeThreshold = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.SlopeThreshold);
            string StartDelay = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.StartDelay);
            string KeepTime = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.KeepTime).Replace("2c", "");
            string NmThreshold = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.NmThreshold);
            string ScrewDownAngleLower = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.ScrewDownAngleLower);
            string ScrewDownAngleUpper = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.ScrewDownAngleUpper);
            string ScrewDownNm = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.ScrewDownNm);
            string LengthKeepTime = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.LengthKeepTime);

            string RotitionDirection = ConvertToStatus(Variable.deviceRecipeInfo.RecipeParameters.RotitionDirection);
            string Upper = ConvertToStatus(Variable.deviceRecipeInfo.RecipeParameters.Upper);
            string ScrewLosse = ConvertToStatus(Variable.deviceRecipeInfo.RecipeParameters.ScrewLosse);
            string Repair = ConvertToStatus(Variable.deviceRecipeInfo.RecipeParameters.Repair).Replace("2c", "");

            string ScrewDownCount = ConvertToHex(Variable.deviceRecipeInfo.RecipeParameters.ScrewDownCount);

            // pset参数写入
            byte[] PsetLength = ByteArrayLib.GetByteArrayFromHexString($"30 31 30 33 30 30 31 3D 39 2C 31 3B 30 30 32 3D 31 2c 38 2c 32 2c 31 2c 34 2c 31 2c 35 2c" +
                $" {AngleLowerLimit} 36 2c {AngleUpperLimit} 37 2c {LengthKeepTime} 31 34 2c {Upper} 31 35 2c {ScrewLosse} 31 37 2c {Repair} 3b 30 30 33 3d 31 2c 31 32 2c 32 2c {Rotate_Speed} 33 2c {RotitionDirection} " +
                $"34 2c {NmLowerLimit} 35 2c {NmUpperLimit} 37 2c {Nm} 38 2c {LengthKeepTime} 39 2c {AngleLowerLimit} 31 30 2c {AngleUpperLimit} 31 31 2c {ScrewDownNm} 31 32 2c {ScrewDownAngleLower} 31 33 2c {ScrewDownAngleUpper}" +
                $" 32 36 2c {KeepTime} 3b 03");

            PsetClient.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.写指定PSET参数0103, $" 02 00 00 00 {Convert.ToInt32((char)(PsetLength.Length)).ToString("X")} 52 30 31 30 33 30 30 31 3D 38 2C 31 3B 30 30 32 3D 31 2c 38 2c 32 2c 31 2c 34 2c 31 2c 35 2c" +
                $" {AngleLowerLimit} 36 2c {AngleUpperLimit} 37 2c {LengthKeepTime} 31 34 2c {Upper} 31 35 2c {ScrewLosse} 31 37 2c {Repair} 3b 30 30 33 3d 31 2c 31 32 2c 32 2c {Rotate_Speed} 33 2c {RotitionDirection} " +
                $"34 2c {NmLowerLimit} 35 2c {NmUpperLimit} 37 2c {Nm} 38 2c {LengthKeepTime} 39 2c {AngleLowerLimit} 31 30 2c {AngleUpperLimit} 31 31 2c {ScrewDownNm} 31 32 2c {ScrewDownAngleLower} 31 33 2c {ScrewDownAngleUpper}" +
                $" 32 36 2c {KeepTime} 3b 03");

            //   job参数写入
            JobcClient = ServiceLocator.GetService<ITcpClient>();
            JobcClient.DataReceived += Client_DataReceived;

            string context = AppendJob(Variable.deviceRecipeInfo.RecipeParameters.ScrewDownCount);
            byte[] JobLength = ByteArrayLib.GetByteArrayFromHexString($"30 31 30 37 30 30 31 3D 39 2c 31 3b 30 30 32 3D {ScrewDownCount} 32 2c 31 37 2c {Repair} 2c 31 36 2c 30 3b " + context);

            string Command = $"02 00 00 00 {Convert.ToInt32((char)(JobLength.Length)).ToString("X")} 57 30 31 30 37 30 30 31 3D 39 2c 31 3b 30 30 32 3D {ScrewDownCount} 32 2c 31 37 2c {Repair} 2c 31 36 2c 30 3b ";

            string Result = Encoding.ASCII.GetString(JobLength);
            JobcClient.TcpClienttConnect(SystemSetting.DeviceIP, SystemSetting.DeviceIpPort, DeviceEnums.写JOB参数0107, Command + context);

            // 停止 Stopwatch
            stopwatch.Stop();

            // 获取并显示运行时间
            TimeSpan ts = stopwatch.Elapsed;
            Console.WriteLine($"运行时间: {ts.TotalMilliseconds} 毫秒");
        }

        private string AppendJob(int Count)
        {
            string Command = null;
            for (int i = 3; i < Count+3; i++)
            {
                string countHexString = null;
                if (i < 10)
                {
                    // 如果 Count 小于 10，则转换成一个字符的十六进制表示
                     countHexString = Convert.ToInt32((char)('0' + i)).ToString("X");
                }
                else if (i < 100)
                {
                    // 如果 Count 大于或等于 10，则转换成两个字符的十六进制表示
                     countHexString = $"{(i / 10 + '0'):X2} {(i % 10 + '0'):X2}";
                }
                //job参数只需要引用对应的Pset序列化就行
                Command += $"30 30 {countHexString} 3D 31 2c 33 2c 31 2c 30 2c 32 2c 38 2c 33 2c 31 3b ";
            }
            return Command+"03";
        }

        private void Client_DataReceived()
        {
            Thread.Sleep(1000);
            this.HideWaitForm();
            Variable.ListAddLog(0,$"应用配方{this.txt_RecipeName.Text}成功;");
            this.DialogResult = DialogResult.OK;
            //this.ShowSuccessDialog("应用配方", "配方应用成功");
        }

        private string ConvertToHex<T>(T data)
        {
            string hex = null;
            foreach (var item in data.ToString())
            {
                hex += Convert.ToInt32((char)(item)).ToString("X") + " ";
            }
            return hex += "2c";
        }

        private string ConvertToStatus(string data)
        {
            switch (data)
            {
                case "正转CW":
                    return "30 2c";
                case "反转CCW":
                    return "31 2c";
                case "开启":
                    return "31 2c";
                case "关闭":
                    return "30 2c";
                default:
                    return null;

            }
        }

        #endregion

        #region 获取所有配方
        private List<DeviceRecipeInfo> GetAllRecipe()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(RecipePath);

            List<FileInfo> fileInfos = directoryInfo.GetFiles("*.ini").ToList();

            List<DeviceRecipeInfo> recipeInfos = new List<DeviceRecipeInfo>();

            foreach (var item in fileInfos)
            {
                recipeInfos.Add(GetRecipe(item.FullName));
            }
            return recipeInfos;
        }
        #endregion

        #region 更新配方列表
        private void RefreshRecipe()
        {
            recipeInfos = GetAllRecipe();

            if (recipeInfos.Count > 0)
            {
                this.dgv_Main.Rows.Clear();

                for (int i = 0; i < recipeInfos.Count; i++)
                {
                    this.dgv_Main.Rows.Add();
                    // this.dgv_Main.Rows[i].Cells[0].Value = (i + 1).ToString();
                    this.dgv_Main.Rows[i].Cells[0].Value = recipeInfos[i].RecipeName;

                    if (this.txt_RecipeName.Text == recipeInfos[i].RecipeName)
                    {
                        this.dgv_Main.Rows[i].Selected = true;
                    }
                    else
                    {
                        this.dgv_Main.Rows[i].Selected = false;
                    }
                }

                if (this.dgv_Main.SelectedRows.Count > 0)
                {
                    SetRecipeInfo(this.recipeInfos[this.dgv_Main.SelectedRows[0].Index]);
                }
            }
        }
        #endregion

        #region 显示当前配方
        private void SetRecipeInfo(DeviceRecipeInfo recipeInfo)
        {
            this.txt_RecipeName.Text = recipeInfo.RecipeName;

            if (recipeInfo.RecipeParameters.ScrewDownCount > 0)
            {

                this.num_Rotate_Speed.Value = recipeInfo.RecipeParameters.Rotate_Speed;
                this.cmb_RotitionDirection.Text = recipeInfo.RecipeParameters.RotitionDirection;
                this.num_Nm.Value = decimal.Parse(recipeInfo.RecipeParameters.Nm);
                this.num_NmThreshold.Value = decimal.Parse(recipeInfo.RecipeParameters.NmThreshold);
                this.num_StartDelay.Value = decimal.Parse(recipeInfo.RecipeParameters.StartDelay);
                this.num_SlopeThreshold.Value = decimal.Parse(recipeInfo.RecipeParameters.SlopeThreshold);
                this.num_KeepTime.Value = decimal.Parse(recipeInfo.RecipeParameters.KeepTime);
                this.num_NmUpperLimit.Value = decimal.Parse(recipeInfo.RecipeParameters.NmUpperLimit);
                this.num_NmLowerLimit.Value = decimal.Parse(recipeInfo.RecipeParameters.NmLowerLimit);
                this.num_AngleUpperLimit.Value = decimal.Parse(recipeInfo.RecipeParameters.AngleUpperLimit);
                this.num_AngleLowerLimit.Value = decimal.Parse(recipeInfo.RecipeParameters.AngleLowerLimit);
                this.num_ScrewDownNm.Value = decimal.Parse(recipeInfo.RecipeParameters.ScrewDownNm);
                this.num_ScrewDownAngleUpper.Value = decimal.Parse(recipeInfo.RecipeParameters.ScrewDownAngleUpper);
                this.num_ScrewDownAngleLower.Value = decimal.Parse(recipeInfo.RecipeParameters.ScrewDownAngleLower);
                this.num_LengthKeepTime.Value = decimal.Parse(recipeInfo.RecipeParameters.LengthKeepTime);
                this.cmb_Upper.Text = recipeInfo.RecipeParameters.Upper;
                this.cmb_ScrewLosse.Text = recipeInfo.RecipeParameters.ScrewLosse;
                this.cmb_Repair.Text = recipeInfo.RecipeParameters.Repair;
                this.num_ScrewDownCount.Value = recipeInfo.RecipeParameters.ScrewDownCount;
            }
        }

        #endregion

        #region DataGridView选中事件
        private void dgv_Main_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var recipeInfo = recipeInfos[e.RowIndex];

                SetRecipeInfo(recipeInfo);
            }
        }
        #endregion

        #region 文件变对象
        private DeviceRecipeInfo GetRecipe(string path)
        {
            return JsonHelper.JSONToEntity<DeviceRecipeInfo>(IniConfigHelper.ReadIniData("配方", "配方数据", "", path));
        }
        #endregion

        #region 删除配方
        private bool DeleteRecipe(string recipeName)
        {
            try
            {
                File.Delete(RecipePath + "\\" + recipeName + ".ini");
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}

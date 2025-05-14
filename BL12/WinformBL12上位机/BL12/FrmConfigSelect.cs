using CurrentVariable;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public partial class FrmConfigSelect : Form
    {
        public FrmConfigSelect()
        {
            InitializeComponent();
            Inital();
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        private void Inital()
        {
            RefreshRecipe();
            if (CollectionFileName.Count > 0)
            {
                this.text_CurrentRecipeName.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                string[] parameter = new string[]
                {
                     IniConfigHelper.ReadIniData("General", "CHNum", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "Channel", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "I", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "Imaxmin", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "Vmaxmin", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "SHorl", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "DV", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "NTC_Channel", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "NTC_MODEL", "", CurrentRecipeNamePath),
                     IniConfigHelper.ReadIniData("General", "NTCmaxmin", "", CurrentRecipeNamePath),
                };
                SetCollectionControlParam(parameter);
            }
        }

        public string RecipePath { get; set; } = Application.StartupPath + "\\Config\\";

        public List<string> CollectionFileName {  get; set; }

        public string CurrentRecipeNamePath { get; set; }

        public string CreateRecipePath { get; set; }


        private void but_Create_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.text_FileName.Text))
            {
                MessageBox.Show("配方参数名称不能为空!");
                return;
            }

            if (CollectionFileName.Contains(this.text_FileName.Text))
            {
                MessageBox.Show("已存在该名称配方参数!");
                return;
            }
            this.text_CurrentRecipeName.Text = this.text_FileName.Text;

            using (File.Create(CreateRecipePath)) { }

            GetControlValueToStore();

            RefreshRecipe();
        }

        private void but_Save_Click(object sender, EventArgs e)
        {
            if (!CollectionFileName.Contains(this.text_CurrentRecipeName.Text))
            {
                MessageBox.Show("请选择对应的配方名称");
                return;
            }
            if (!File.Exists(CurrentRecipeNamePath))
            {
                MessageBox.Show("没有该配方参数,请检查!");
                return;
            }

            IniConfigHelper.WriteIniData("General", "CHNum", this.text_ChannelNum.Text, CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "Channel", $"{this.text_Channel.Text}",CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "I", this.num_I.Value.ToString(), CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "Imaxmin", $"{this.num_Imin.Value.ToString()},{this.num_Imax.Value.ToString()}", CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "Vmaxmin", $"{this.num_Vmin.Value.ToString()},{this.num_Vmax.Value.ToString()}", CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "SHorl", this.text_SHorl.Text, CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "DV", this.num_DV.Value.ToString(), CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "NTC_Channel", $"{ this.text_NtcChannel.Text}", CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "NTC_MODEL", this.text_NtcModel.Text, CurrentRecipeNamePath);
            IniConfigHelper.WriteIniData("General", "NTCmaxmin", $"{this.num_Ntcmax.Value.ToString()},{this.num_Ntcmin.Value.ToString()}", CurrentRecipeNamePath);

            MessageBox.Show($"成功保存{this.text_CurrentRecipeName.Text}配方参数!");
        }

        private void but_Delete_Click(object sender, EventArgs e)
        {
            File.Delete(CurrentRecipeNamePath);
            MessageBox.Show($"成功删除{text_FileName.Text}配方");
            RefreshRecipe();
        }

        private void but_Application_Click(object sender, EventArgs e)
        {
            but_Save_Click(null, null);
            GlobalVariable.ConfigName = this.text_CurrentRecipeName.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                this.text_CurrentRecipeName.Text = CollectionFileName[e.RowIndex];
            }
            catch (Exception)
            {
                return;
            }

            string[] parameter = new string[]
            {
            IniConfigHelper.ReadIniData("General", "CHNum", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "Channel", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "I", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "Imaxmin", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "Vmaxmin", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "SHorl", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "DV", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "NTC_Channel", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "NTC_MODEL", "", CurrentRecipeNamePath),
            IniConfigHelper.ReadIniData("General", "NTCmaxmin", "", CurrentRecipeNamePath),
             };
            SetCollectionControlParam(parameter);
        }

        public void SetCollectionControlParam(string[] Parameter)
        {
            this.text_ChannelNum.Text = Parameter[0];
            this.text_Channel.Text = Parameter[1];
            this.num_I.Value = decimal.Parse(Parameter[2]);
            this.num_Imin.Value = decimal.Parse(Parameter[3].Split(',')[0]);
            this.num_Imax.Value = decimal.Parse(Parameter[3].Split(',')[1]);
            this.num_Vmin.Value = decimal.Parse(Parameter[4].Split(',')[0]);
            this.num_Vmax.Value = decimal.Parse(Parameter[4].Split(',')[1]);
            this.text_SHorl.Text = Parameter[5];
            this.num_DV.Value = decimal.Parse(Parameter[6]);
            this.text_NtcChannel.Text = Parameter[7];
            this.text_NtcModel.Text = Parameter[8];
            this.num_Ntcmax.Value = decimal.Parse(Parameter[9].Split(',')[0]);
            this.num_Ntcmin.Value = decimal.Parse(Parameter[9].Split(',')[1]);
        }

        public void GetControlValueToStore()
        {
            IniConfigHelper.WriteIniData("General", "CHNum", this.text_ChannelNum.Text, CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "Channel", this.text_Channel.Text, CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "I", this.num_I.Value.ToString(), CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "Imaxmin", this.num_Imin.Value.ToString() + "," + this.num_Imax.Value.ToString(), CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "Vmaxmin", this.num_Vmin.Value.ToString() + "," + this.num_Vmax.Value.ToString(), CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "SHorl", this.text_SHorl.Text, CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "DV", this.num_DV.Value.ToString(), CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "NTC_Channel", this.text_NtcChannel.Text, CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "NTC_MODEL", this.text_NtcModel.Text, CreateRecipePath);
            IniConfigHelper.WriteIniData("General", "NTCmaxmin", this.num_Ntcmax.Value.ToString() + "," + this.num_Ntcmin.Value, CreateRecipePath);
        }

        public void RefreshRecipe()
        {
            DirectoryInfo directoryInfo = new DirectoryInfo(RecipePath);

            List<FileInfo> fileInfos = directoryInfo.GetFiles("*.ini").ToList();

            CollectionFileName = new List<string>();

            foreach (var item in fileInfos)
            {
                CollectionFileName.Add(item.Name.Replace(".ini", ""));
            }

            dataGridView1.Rows.Clear();

            for (int i = 0; i < CollectionFileName.Count; i++)
            {
                dataGridView1.Rows.Add();
                dataGridView1.Rows[i].Cells[0].Value = CollectionFileName[i];
            }
        }

        private void text_FileName_TextChanged(object sender, EventArgs e)
        {
            var select = (TextBox)sender;
            if (select.Tag.ToString() == "1")
            {
                CurrentRecipeNamePath = RecipePath + text_CurrentRecipeName.Text + ".ini";
            }
            else
            {
                CreateRecipePath = RecipePath + text_FileName.Text + ".ini";
            }
        }

    }
}

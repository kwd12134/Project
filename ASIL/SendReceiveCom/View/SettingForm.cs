using Newtonsoft.Json.Linq;
using SendReceiveCom.com;
using SendReceiveCom.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace SendReceiveCom
{
    public partial class SettingForm : Form
    {
        public SettingForm()
        {
            this.InitializeComponent();
            settingForm = this;
            RefreshRecipe();
            if (CollectionFileName.Count > 0)
            {
                this.text_CurrentRecipeName.Text = dataGridView1.Rows[0].Cells[0].Value.ToString();
                bool PositionPanelState = Convert.ToBoolean(IniConfigHelper.ReadIniData("RecipeParam", "PositionPanelState", "", CurrentRecipeNamePath));
                string parameter = IniConfigHelper.ReadIniData("RecipeParam", "Parameter", "", CurrentRecipeNamePath);
                string PositionPanel = IniConfigHelper.ReadIniData("RecipeParam", "PositionPanel", "", CurrentRecipeNamePath);
                SetCollectionControlParam(parameter, PositionPanelState, PositionPanel);
            }
        }

        public SettingForm settingForm { get; set; }
        public string RecipePath = Application.StartupPath + "\\Recipe\\";

        private void SettingForm_Load(object sender, EventArgs e)
        {
            this.tc.Display();
            string HostName = Dns.GetHostName();
            this.Data.Text = this.tc.pis2Ip;
            this.textBox1.Text = this.tc.pis2Port.ToString();
            this.textBox2.Text = this.tc.jinceIp;
            this.textBox3.Text = this.tc.jincePort.ToString();
            this.textBox4.Text = this.tc.SendQueue;
            this.textBox5.Text = this.tc.ReplyQueue;
            //this.textBox12.Text = this.tc.SendQueue_ictest;
            //this.ASILcheckBox1.Checked = this.tc.ASIL1_check;
            //this.ASIL_Min_textBox1.Text = this.tc.ASIL1_Min.ToString();
            //this.ASIL_Max_textBox1.Text = this.tc.ASIL1_Max.ToString();
            //this.ASILcheckBox2.Checked = this.tc.ASIL2_check;
            //this.ASIL_Min_textBox2.Text = this.tc.ASIL2_Min.ToString();
            //this.ASIL_Max_textBox2.Text = this.tc.ASIL2_Max.ToString();
            //this.ASILcheckBox3.Checked = this.tc.ASIL3_check;
            //this.ASIL_Min_textBox3.Text = this.tc.ASIL3_Min.ToString();
            //this.ASIL_Max_textBox3.Text = this.tc.ASIL3_Max.ToString();
            //this.ASILcheckBox4.Checked = this.tc.ASIL4_check;
            //this.ASIL_Min_textBox4.Text = this.tc.ASIL4_Min.ToString();
            //this.ASIL_Max_textBox4.Text = this.tc.ASIL4_Max.ToString();
            //this.ASILcheckBox5.Checked = this.tc.ASIL5_check;
            //this.ASIL_Min_textBox5.Text = this.tc.ASIL5_Min.ToString();
            //this.ASIL_Max_textBox5.Text = this.tc.ASIL5_Max.ToString();
            //this.ASILcheckBox6.Checked = this.tc.ASIL6_check;
            //this.ASIL_Min_textBox6.Text = this.tc.ASIL6_Min.ToString();
            //this.ASIL_Max_textBox6.Text = this.tc.ASIL6_Max.ToString();
            //this.ASILcheckBox7.Checked = this.tc.ASIL7_check;
            //this.ASIL_Min_textBox7.Text = this.tc.ASIL7_Min.ToString();
            //this.ASIL_Max_textBox7.Text = this.tc.ASIL7_Max.ToString();
            //this.ASILcheckBox8.Checked = this.tc.ASIL8_check;
            //this.ASIL_Min_textBox8.Text = this.tc.ASIL8_Min.ToString();
            //this.ASIL_Max_textBox8.Text = this.tc.ASIL8_Max.ToString();
            //this.frequencycheckBox1.Checked = this.tc.frequency1_check;
            //this.FreqMinTextBox1.Text = this.tc.frequency1_Min.ToString();
            //this.FreqMaxTextBox1.Text = this.tc.frequency1_Max.ToString();
            //this.frequencycheckBox2.Checked = this.tc.frequency2_check;
            //this.FreqMinTextBox2.Text = this.tc.frequency2_Min.ToString();
            //this.FreqMaxTextBox2.Text = this.tc.frequency2_Max.ToString();
            this.User_ID_Box.Text = this.tc.User_ID;
            this.Station_ID_Box.Text = this.tc.Station_ID;
            this.Operator_Box.Text = this.tc.Operator;
            this.EQP_ID_Box.Text = this.tc.EQP_ID;
            this.PIS2_checkBox.Checked = this.tc.PIS2_check;
            this.TYPE1.Text = this.tc.type1;
            //this.TYPE2.Text = this.tc.type2;
            this.textBox6.Text = this.tc.max_lumi;
            this.textBox7.Text = this.tc.unifomity;
            this.textBox8.Text = this.tc.part_no;
            this.textBox9.Text = this.tc.model_no;
            this.textBox10.Text = this.tc.fw_version;
            this.textBox11.Text = this.tc.unique_id;

            this.textBox15.Text = this.tc.CCDTYPE1;
            this.textBox16.Text = this.tc.CCDTYPE2;
            this.textBox17.Text = this.tc.CCDTYPE3;
            this.textBox18.Text = this.tc.CCDTYPE4;
            this.textBox19.Text = this.tc.CCDTYPE5;
            this.textBox20.Text = this.tc.CCDTYPE6;
            this.textBox21.Text = this.tc.CCDTYPE7;
            this.textBox22.Text = this.tc.CCDTYPE8;
            this.textBox23.Text = this.tc.CCDTYPE9;
            this.textBox24.Text = this.tc.CCDTYPE10;

            this.text_ModelName.Text = this.tc.ModelName;
            this.text_SampleSN.Text = this.tc.SampleSN;

            this.textBox13.Text = this.tc.DayShift;
            this.textBox14.Text = this.tc.NightShift;

            //this.textBox25.Text = this.tc.PanelPosition;
        }

        #region 应用配方
        private void button1_Click(object sender, EventArgs e)
        {
            but_Modify_Click(null, null);

            try
            {
                foreach (object obj in this.tc.xnlist)
                {
                    XmlNode xnf = (XmlNode)obj;
                    XmlElement xe = (XmlElement)xnf;
                    bool judge1 = xe.GetAttribute("name") == "CCDTYPE1";
                    if (judge1)
                    {
                        xe.SetAttribute("value", this.textBox15.Text);
                    }
                    bool judge2 = xe.GetAttribute("name") == "CCDTYPE2";
                    if (judge2)
                    {
                        xe.SetAttribute("value", this.textBox16.Text);
                    }
                    bool judge3 = xe.GetAttribute("name") == "CCDTYPE3";
                    if (judge3)
                    {
                        xe.SetAttribute("value", this.textBox17.Text);
                    }
                    bool judge4 = xe.GetAttribute("name") == "CCDTYPE4";
                    if (judge4)
                    {
                        xe.SetAttribute("value", this.textBox18.Text);
                    }
                    bool judge5 = xe.GetAttribute("name") == "CCDTYPE5";
                    if (judge5)
                    {
                        xe.SetAttribute("value", this.textBox19.Text);
                    }
                    bool judge6 = xe.GetAttribute("name") == "CCDTYPE6";
                    if (judge6)
                    {
                        xe.SetAttribute("value", this.textBox20.Text);
                    }
                    bool judge7 = xe.GetAttribute("name") == "CCDTYPE7";
                    if (judge7)
                    {
                        xe.SetAttribute("value", this.textBox21.Text);
                    }
                    bool judge8 = xe.GetAttribute("name") == "CCDTYPE8";
                    if (judge8)
                    {
                        xe.SetAttribute("value", this.textBox22.Text);
                    }
                    bool judge9 = xe.GetAttribute("name") == "CCDTYPE9";
                    if (judge9)
                    {
                        xe.SetAttribute("value", this.textBox23.Text);
                    }
                    bool judge10 = xe.GetAttribute("name") == "CCDTYPE10";
                    if (judge10)
                    {
                        xe.SetAttribute("value", this.textBox24.Text);
                    }
                    bool flag_5 = xe.GetAttribute("name") == "DayShift";
                    if (flag_5)
                    {
                        xe.SetAttribute("value", this.textBox13.Text);
                    }
                    bool flag_6 = xe.GetAttribute("name") == "NightShift";
                    if (flag_6)
                    {
                        xe.SetAttribute("value", this.textBox14.Text);
                    }
                    bool flag_1 = xe.GetAttribute("name") == "ModelName";
                    if (flag_1)
                    {
                        xe.SetAttribute("value", this.text_ModelName.Text);
                    }
                    bool flag_2 = xe.GetAttribute("name") == "SampleSN";
                    if (flag_2)
                    {
                        xe.SetAttribute("value", this.text_SampleSN.Text);
                    }
                    bool flag = xe.GetAttribute("name") == "COM_PortNum";
                    if (flag)
                    {
                    }
                    bool flag1 = xe.GetAttribute("name") == "CurrentRecipeName";
                    if (flag1)
                    {
                        xe.SetAttribute("value", this.text_CurrentRecipeName.Text);
                    }
                    bool flag2 = xe.GetAttribute("name") == "COM_BaudRate";
                    if (flag2)
                    {
                    }
                    bool flag3 = xe.GetAttribute("name") == "COM_DataBits";
                    if (flag3)
                    {
                    }
                    bool flag4 = xe.GetAttribute("name") == "COM_StopBits";
                    if (flag4)
                    {
                    }
                    bool flag5 = xe.GetAttribute("name") == "COM_Parity";
                    if (flag5)
                    {
                    }
                    bool flag6 = xe.GetAttribute("name") == "PIS2_IP";
                    if (flag6)
                    {
                        xe.SetAttribute("value", this.Data.Text);
                    }
                    bool flag7 = xe.GetAttribute("name") == "PIS2_Port";
                    if (flag7)
                    {
                        xe.SetAttribute("value", this.textBox1.Text);
                    }
                    bool flag8 = xe.GetAttribute("name") == "JINCE_IP";
                    if (flag8)
                    {
                        xe.SetAttribute("value", this.textBox2.Text);
                    }
                    bool flag9 = xe.GetAttribute("name") == "JINCE_Port";
                    if (flag9)
                    {
                        xe.SetAttribute("value", this.textBox3.Text);
                    }
                    bool flag10 = xe.GetAttribute("name") == "SendQueue";
                    if (flag10)
                    {
                        xe.SetAttribute("value", this.textBox4.Text);
                    }
                    bool flag11 = xe.GetAttribute("name") == "SendQueue_ictest";
                    if (flag11)
                    {
                        xe.SetAttribute("value", this.textBox12.Text);
                    }
                    bool flag12 = xe.GetAttribute("name") == "ASIL1_check";
                    if (flag12)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox1.Checked.ToString());
                    }
                    bool flag13 = xe.GetAttribute("name") == "ASIL1_Min";
                    if (flag13)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox1.Text);
                    }
                    bool flag14 = xe.GetAttribute("name") == "ASIL1_Max";
                    if (flag14)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox1.Text);
                    }
                    bool flag15 = xe.GetAttribute("name") == "ASIL2_check";
                    if (flag15)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox2.Checked.ToString());
                    }
                    bool flag16 = xe.GetAttribute("name") == "ASIL2_Min";
                    if (flag16)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox2.Text);
                    }
                    bool flag17 = xe.GetAttribute("name") == "ASIL2_Max";
                    if (flag17)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox2.Text);
                    }
                    bool flag18 = xe.GetAttribute("name") == "ASIL3_check";
                    if (flag18)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox3.Checked.ToString());
                    }
                    bool flag19 = xe.GetAttribute("name") == "ASIL3_Min";
                    if (flag19)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox3.Text);
                    }
                    bool flag20 = xe.GetAttribute("name") == "ASIL3_Max";
                    if (flag20)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox3.Text);
                    }
                    bool flag21 = xe.GetAttribute("name") == "ASIL4_check";
                    if (flag21)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox4.Checked.ToString());
                    }
                    bool flag22 = xe.GetAttribute("name") == "ASIL4_Min";
                    if (flag22)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox4.Text);
                    }
                    bool flag23 = xe.GetAttribute("name") == "ASIL4_Max";
                    if (flag23)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox4.Text);
                    }
                    bool flag24 = xe.GetAttribute("name") == "ASIL5_check";
                    if (flag24)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox5.Checked.ToString());
                    }
                    bool flag25 = xe.GetAttribute("name") == "ASIL5_Min";
                    if (flag25)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox5.Text);
                    }
                    bool flag26 = xe.GetAttribute("name") == "ASIL5_Max";
                    if (flag26)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox5.Text);
                    }
                    bool flag27 = xe.GetAttribute("name") == "ASIL6_check";
                    if (flag27)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox6.Checked.ToString());
                    }
                    bool flag28 = xe.GetAttribute("name") == "ASIL6_Min";
                    if (flag28)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox6.Text);
                    }
                    bool flag29 = xe.GetAttribute("name") == "ASIL6_Max";
                    if (flag29)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox6.Text);
                    }
                    bool flag30 = xe.GetAttribute("name") == "ASIL7_check";
                    if (flag30)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox7.Checked.ToString());
                    }
                    bool flag31 = xe.GetAttribute("name") == "ASIL7_Min";
                    if (flag31)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox7.Text);
                    }
                    bool flag32 = xe.GetAttribute("name") == "ASIL7_Max";
                    if (flag32)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox7.Text);
                    }
                    bool flag33 = xe.GetAttribute("name") == "ASIL8_check";
                    if (flag33)
                    {
                        xe.SetAttribute("value", this.ASILcheckBox8.Checked.ToString());
                    }
                    bool flag34 = xe.GetAttribute("name") == "ASIL8_Min";
                    if (flag34)
                    {
                        xe.SetAttribute("value", this.ASIL_Min_textBox8.Text);
                    }
                    bool flag35 = xe.GetAttribute("name") == "ASIL8_Max";
                    if (flag35)
                    {
                        xe.SetAttribute("value", this.ASIL_Max_textBox8.Text);
                    }
                    bool flag36 = xe.GetAttribute("name") == "frequency1_check";
                    if (flag36)
                    {
                        xe.SetAttribute("value", this.frequencycheckBox1.Checked.ToString());
                    }
                    bool flag37 = xe.GetAttribute("name") == "frequency1_Min";
                    if (flag37)
                    {
                        xe.SetAttribute("value", this.FreqMinTextBox1.Text);
                    }
                    bool flag38 = xe.GetAttribute("name") == "frequency1_Max";
                    if (flag38)
                    {
                        xe.SetAttribute("value", this.FreqMaxTextBox1.Text);
                    }
                    bool flag39 = xe.GetAttribute("name") == "frequency2_check";
                    if (flag39)
                    {
                        xe.SetAttribute("value", this.frequencycheckBox2.Checked.ToString());
                    }
                    bool flag40 = xe.GetAttribute("name") == "frequency2_Min";
                    if (flag40)
                    {
                        xe.SetAttribute("value", this.FreqMinTextBox2.Text);
                    }
                    bool flag41 = xe.GetAttribute("name") == "frequency2_Max";
                    if (flag41)
                    {
                        xe.SetAttribute("value", this.FreqMaxTextBox2.Text);
                    }
                    bool flag42 = xe.GetAttribute("name") == "User_ID";
                    if (flag42)
                    {
                        xe.SetAttribute("value", this.User_ID_Box.Text);
                    }
                    bool flag43 = xe.GetAttribute("name") == "Station_ID";
                    if (flag43)
                    {
                        xe.SetAttribute("value", this.Station_ID_Box.Text);
                    }
                    bool flag44 = xe.GetAttribute("name") == "Operator";
                    if (flag44)
                    {
                        xe.SetAttribute("value", this.Operator_Box.Text);
                    }
                    bool flag45 = xe.GetAttribute("name") == "EQP_ID";
                    if (flag45)
                    {
                        xe.SetAttribute("value", this.EQP_ID_Box.Text);
                    }
                    bool flag46 = xe.GetAttribute("name") == "type1";
                    if (flag46)
                    {
                        xe.SetAttribute("value", this.TYPE1.Text);
                    }
                    bool flag47 = xe.GetAttribute("name") == "type2";
                    if (flag47)
                    {
                        int tag = 11;
                        string assemble = null;
                        foreach (var item in panel1.Controls.OfType<CheckBox>())
                        {
                            --tag;
                            if (item.Checked)
                            {
                                foreach (var item1 in groupBox2.Controls.OfType<TextBox>())
                                {
                                    if (item1.Tag.ToString() == tag.ToString())
                                    {
                                        assemble += item1.Text + ",";
                                    }
                                }
                            }
                        }
                        xe.SetAttribute("value", assemble);

                    }
                    bool flag48 = xe.GetAttribute("name") == "unifomity";
                    if (flag48)
                    {
                        xe.SetAttribute("value", this.textBox7.Text);
                    }
                    bool flag49 = xe.GetAttribute("name") == "max_lumi";
                    if (flag49)
                    {
                        xe.SetAttribute("value", this.textBox6.Text);
                    }
                    bool flag50 = xe.GetAttribute("name") == "part_no";
                    if (flag50)
                    {
                        xe.SetAttribute("value", this.textBox8.Text);
                    }
                    bool flag51 = xe.GetAttribute("name") == "model_no";
                    if (flag51)
                    {
                        xe.SetAttribute("value", this.textBox9.Text);
                    }
                    bool flag52 = xe.GetAttribute("name") == "fw_version";
                    if (flag52)
                    {
                        xe.SetAttribute("value", this.textBox10.Text);
                    }
                    bool flag53 = xe.GetAttribute("name") == "PIS2_check";
                    if (flag53)
                    {
                        xe.SetAttribute("value", this.PIS2_checkBox.Checked.ToString());
                    }
                    bool flag54 = xe.GetAttribute("name") == "PanelPositionState";
                    if (flag54)
                    {
                        xe.SetAttribute("value", this.checkBox1.Checked.ToString());
                    }
                    bool flag55 = xe.GetAttribute("name") == "PanelPosition";
                    if (flag55)
                    {
                        xe.SetAttribute("value", this.textBox25.Text);
                    }
                }
                this.tc.xmlDoc.Save(this.tc.path);
                MessageBox.Show("应用成功！");
                ComAssistance.tc.Display();
                base.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存错误！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }


        #endregion

        private OpenSP OP { get; set; } = new OpenSP();
        private OpenPorts OPs { get; set; } = new OpenPorts();
        private TcClass tc { get; set; } = ComAssistance.tc;

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridViewHelper.DgvRowPostPaint((DataGridView)sender, e);
        }

        public List<string> CollectionFileName { get; set; }

        public string CurrentRecipeNamePath { get; set; }

        public string CreateRecipePath { get; set; }

        public FrmMsgBoxAffirm FrmMsgBoxAffirm { get; set; }

        /// <summary>
        /// 根据tag判断引用了哪个配方名称
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

        public string GetCollectionControlParam()
        {
            string GetValue = null;
            foreach (var item in panel1.Controls.OfType<TextBox>())
            {
                GetValue += item.Text + ",";
            }
            foreach (var item in panel1.Controls.OfType<CheckBox>())
            {
                GetValue += item.Checked.ToString() + ",";
            }
            return GetValue;
        }

        public void SetCollectionControlParam(string Parameter,bool state,string PositionPanel)
        {
            string[] Value = Parameter.Split(',');
            int index = -1;
            foreach (var item in panel1.Controls.OfType<TextBox>())
            {
                item.Text = Value[++index];
            }
            foreach (var item in panel1.Controls.OfType<CheckBox>())
            {
                item.Checked = Value[++index] == "True" ? true : false;
            }
            this.checkBox1.Checked = state;
            this.textBox25.Text = PositionPanel;
        }

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
            string Parameter = GetCollectionControlParam();

            using (File.Create(CreateRecipePath)) { }

            bool result = IniConfigHelper.WriteIniData("RecipeParam", "Parameter", Parameter, CreateRecipePath);
            bool result2 = IniConfigHelper.WriteIniData("RecipeParam", "PositionPanel", this.textBox25.Text, CurrentRecipeNamePath);
            bool result1 = IniConfigHelper.WriteIniData("RecipeParam", "PositionPanelState", this.checkBox1.Checked.ToString(), CreateRecipePath);
            if (result&& result1)
            {
                RefreshRecipe();
                MessageBox.Show($"添加配方{this.text_FileName.Text}成功");
                LogMethod.log($"添加配方{this.text_FileName.Text}成功");
            }
            else
            {
                try
                {
                    File.Delete(CreateRecipePath);
                }
                catch (Exception)
                {
                    MessageBox.Show($"添加配方{this.text_FileName.Text}失败");
                }
                MessageBox.Show($"添加配方{this.text_FileName.Text}失败");
            }
        }

        private void but_Modify_Click(object sender, EventArgs e)
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
            string value = GetCollectionControlParam();

            bool result = IniConfigHelper.WriteIniData("RecipeParam", "Parameter", value, CurrentRecipeNamePath);
            bool result2 = IniConfigHelper.WriteIniData("RecipeParam", "PositionPanel", this.textBox25.Text, CurrentRecipeNamePath);
            bool result1 = IniConfigHelper.WriteIniData("RecipeParam", "PositionPanelState", this.checkBox1.Checked.ToString(), CurrentRecipeNamePath);
            if (result&&result1&&result2)
            {
                MessageBox.Show($"成功保存{this.text_CurrentRecipeName.Text}配方参数!");
                LogMethod.log($"成功保存{this.text_CurrentRecipeName.Text}配方参数!");
                but_SaveParam_Click(null,null);
                return;
            }
            else
            {
                MessageBox.Show($"保存{this.text_CurrentRecipeName.Text}配方参数失败,请检查!");
                return;
            }
        }

        private void but_Delete_Click(object sender, EventArgs e)
        {
            FrmMsgBoxAffirm = new FrmMsgBoxAffirm("删除配方");
            if (FrmMsgBoxAffirm.ShowDialog() == DialogResult.OK)
            {
                File.Delete(CurrentRecipeNamePath);
                MessageBox.Show($"成功删除{text_FileName.Text}配方");
                LogMethod.log($"成功删除{text_FileName.Text}配方");
                RefreshRecipe();
            }
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

            string parameter = IniConfigHelper.ReadIniData("RecipeParam", "Parameter", "", CurrentRecipeNamePath);

            string PositionPanel = IniConfigHelper.ReadIniData("RecipeParam", "PositionPanel", "", CurrentRecipeNamePath);

            bool PositionPanelState = Convert.ToBoolean(IniConfigHelper.ReadIniData("RecipeParam", "PositionPanelState", "", CurrentRecipeNamePath));

            SetCollectionControlParam(parameter, PositionPanelState, PositionPanel);
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

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //if ((sender as CheckBox).Checked == true)
            //{
            //    foreach (CheckBox chk in (sender as CheckBox).Parent.Controls.OfType<CheckBox>())
            //    {
            //        if (chk != sender)
            //        {
            //            chk.Checked = false;
            //        }
            //    }
            //
        }

        private void but_SaveParam_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (object obj in this.tc.xnlist)
                {
                    XmlNode xnf = (XmlNode)obj;
                    XmlElement xe = (XmlElement)xnf;
                    bool judge1 = xe.GetAttribute("name") == "CCDTYPE1";
                    if (judge1)
                    {
                        xe.SetAttribute("value", this.textBox15.Text);
                    }
                    bool judge2 = xe.GetAttribute("name") == "CCDTYPE2";
                    if (judge2)
                    {
                        xe.SetAttribute("value", this.textBox16.Text);
                    }
                    bool judge3 = xe.GetAttribute("name") == "CCDTYPE3";
                    if (judge3)
                    {
                        xe.SetAttribute("value", this.textBox17.Text);
                    }
                    bool judge4 = xe.GetAttribute("name") == "CCDTYPE4";
                    if (judge4)
                    {
                        xe.SetAttribute("value", this.textBox18.Text);
                    }
                    bool judge5 = xe.GetAttribute("name") == "CCDTYPE5";
                    if (judge5)
                    {
                        xe.SetAttribute("value", this.textBox19.Text);
                    }
                    bool judge6 = xe.GetAttribute("name") == "CCDTYPE6";
                    if (judge6)
                    {
                        xe.SetAttribute("value", this.textBox20.Text);
                    }
                    bool judge7 = xe.GetAttribute("name") == "CCDTYPE7";
                    if (judge7)
                    {
                        xe.SetAttribute("value", this.textBox21.Text);
                    }
                    bool judge8 = xe.GetAttribute("name") == "CCDTYPE8";
                    if (judge8)
                    {
                        xe.SetAttribute("value", this.textBox22.Text);
                    }
                    bool judge9 = xe.GetAttribute("name") == "CCDTYPE9";
                    if (judge9)
                    {
                        xe.SetAttribute("value", this.textBox23.Text);
                    }
                    bool judge10 = xe.GetAttribute("name") == "CCDTYPE10";
                    if (judge10)
                    {
                        xe.SetAttribute("value", this.textBox24.Text);
                    }
                    bool flag_5 = xe.GetAttribute("name") == "DayShift";
                    if (flag_5)
                    {
                        xe.SetAttribute("value", this.textBox13.Text);
                    }
                    bool flag_6 = xe.GetAttribute("name") == "NightShift";
                    if (flag_6)
                    {
                        xe.SetAttribute("value", this.textBox14.Text);
                    }
                    bool flag_1 = xe.GetAttribute("name") == "ModelName";
                    if (flag_1)
                    {
                        xe.SetAttribute("value", this.text_ModelName.Text);
                    }
                    bool flag_2 = xe.GetAttribute("name") == "SampleSN";
                    if (flag_2)
                    {
                        xe.SetAttribute("value", this.text_SampleSN.Text);
                    }
                    bool flag = xe.GetAttribute("name") == "COM_PortNum";
                    if (flag)
                    {
                    }
                    bool flag2 = xe.GetAttribute("name") == "COM_BaudRate";
                    if (flag2)
                    {
                    }
                    bool flag3 = xe.GetAttribute("name") == "COM_DataBits";
                    if (flag3)
                    {
                    }
                    bool flag4 = xe.GetAttribute("name") == "COM_StopBits";
                    if (flag4)
                    {
                    }
                    bool flag5 = xe.GetAttribute("name") == "COM_Parity";
                    if (flag5)
                    {
                    }
                    bool flag6 = xe.GetAttribute("name") == "PIS2_IP";
                    if (flag6)
                    {
                        xe.SetAttribute("value", this.Data.Text);
                    }
                    bool flag7 = xe.GetAttribute("name") == "PIS2_Port";
                    if (flag7)
                    {
                        xe.SetAttribute("value", this.textBox1.Text);
                    }
                    bool flag8 = xe.GetAttribute("name") == "JINCE_IP";
                    if (flag8)
                    {
                        xe.SetAttribute("value", this.textBox2.Text);
                    }
                    bool flag9 = xe.GetAttribute("name") == "JINCE_Port";
                    if (flag9)
                    {
                        xe.SetAttribute("value", this.textBox3.Text);
                    }
                    bool flag10 = xe.GetAttribute("name") == "SendQueue";
                    if (flag10)
                    {
                        xe.SetAttribute("value", this.textBox4.Text);
                    }
                    bool flag11 = xe.GetAttribute("name") == "SendQueue_ictest";
                    if (flag11)
                    {
                        xe.SetAttribute("value", this.textBox12.Text);
                    }
                    bool flag42 = xe.GetAttribute("name") == "User_ID";
                    if (flag42)
                    {
                        xe.SetAttribute("value", this.User_ID_Box.Text);
                    }
                    bool flag43 = xe.GetAttribute("name") == "Station_ID";
                    if (flag43)
                    {
                        xe.SetAttribute("value", this.Station_ID_Box.Text);
                    }
                    bool flag44 = xe.GetAttribute("name") == "Operator";
                    if (flag44)
                    {
                        xe.SetAttribute("value", this.Operator_Box.Text);
                    }
                    bool flag45 = xe.GetAttribute("name") == "EQP_ID";
                    if (flag45)
                    {
                        xe.SetAttribute("value", this.EQP_ID_Box.Text);
                    }
                    bool flag46 = xe.GetAttribute("name") == "type1";
                    if (flag46)
                    {
                        xe.SetAttribute("value", this.TYPE1.Text);
                    }
                    bool flag47 = xe.GetAttribute("name") == "type2";
                    if (flag47)
                    {
                        int tag = 11;
                        string assemble = null;
                        foreach (var item in panel1.Controls.OfType<CheckBox>())
                        {
                            --tag;
                            if (item.Checked)
                            {
                                foreach (var item1 in groupBox2.Controls.OfType<TextBox>())
                                {
                                    if (item1.Tag.ToString() == tag.ToString())
                                    {
                                        assemble += item1.Text + ",";
                                    }
                                }
                            }
                        }
                        xe.SetAttribute("value", assemble);

                    }
                    bool flag48 = xe.GetAttribute("name") == "unifomity";
                    if (flag48)
                    {
                        xe.SetAttribute("value", this.textBox7.Text);
                    }
                    bool flag49 = xe.GetAttribute("name") == "max_lumi";
                    if (flag49)
                    {
                        xe.SetAttribute("value", this.textBox6.Text);
                    }
                    bool flag50 = xe.GetAttribute("name") == "part_no";
                    if (flag50)
                    {
                        xe.SetAttribute("value", this.textBox8.Text);
                    }
                    bool flag51 = xe.GetAttribute("name") == "model_no";
                    if (flag51)
                    {
                        xe.SetAttribute("value", this.textBox9.Text);
                    }
                    bool flag52 = xe.GetAttribute("name") == "fw_version";
                    if (flag52)
                    {
                        xe.SetAttribute("value", this.textBox10.Text);
                    }
                    bool flag53 = xe.GetAttribute("name") == "PIS2_check";
                    if (flag53)
                    {
                        xe.SetAttribute("value", this.PIS2_checkBox.Checked.ToString());
                    }
                    //bool flag54 = xe.GetAttribute("name") == "PanelPositionState";
                    //if (flag54)
                    //{
                    //    xe.SetAttribute("value", this.checkBox1.Checked.ToString());
                    //}
                    //bool flag55 = xe.GetAttribute("name") == "PanelPosition";
                    //if (flag55)
                    //{
                    //    xe.SetAttribute("value", this.textBox25.Text);
                    //}
                }
                this.tc.xmlDoc.Save(this.tc.path);
                MessageBox.Show("保存成功！");
                ComAssistance.tc.Display();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "保存错误！", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}

namespace SendReceiveCom
{
	// Token: 0x02000009 RID: 9
	public partial class SettingForm : global::System.Windows.Forms.Form
	{
		// Token: 0x06000070 RID: 112 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		protected override void Dispose(bool disposing)
		{
			bool flag = disposing && this.components != null;
			if (flag)
			{
				this.components.Dispose();
			}
			base.Dispose(disposing);
		}

		// Token: 0x06000071 RID: 113 RVA: 0x0000A920 File Offset: 0x00008B20
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.but_Create = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.ASILcheckBox1 = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.ASILcheckBox2 = new System.Windows.Forms.CheckBox();
            this.ASILcheckBox3 = new System.Windows.Forms.CheckBox();
            this.ASILcheckBox4 = new System.Windows.Forms.CheckBox();
            this.ASILcheckBox5 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.ASILcheckBox6 = new System.Windows.Forms.CheckBox();
            this.ASILcheckBox7 = new System.Windows.Forms.CheckBox();
            this.label13 = new System.Windows.Forms.Label();
            this.ASILcheckBox8 = new System.Windows.Forms.CheckBox();
            this.label14 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.FreqMaxTextBox2 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.FreqMinTextBox2 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.FreqMaxTextBox1 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.FreqMinTextBox1 = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox8 = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox8 = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox7 = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox7 = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox6 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox6 = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox5 = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox5 = new System.Windows.Forms.TextBox();
            this.label26 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox4 = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox4 = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox3 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox3 = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox2 = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.ASIL_Max_textBox1 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.ASIL_Min_textBox1 = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.frequencycheckBox2 = new System.Windows.Forms.CheckBox();
            this.label16 = new System.Windows.Forms.Label();
            this.frequencycheckBox1 = new System.Windows.Forms.CheckBox();
            this.label15 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.PIS2_checkBox = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Data = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.XML = new System.Windows.Forms.GroupBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.label47 = new System.Windows.Forms.Label();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.TYPE1 = new System.Windows.Forms.TextBox();
            this.EQP_ID_Box = new System.Windows.Forms.TextBox();
            this.EQP_ID = new System.Windows.Forms.Label();
            this.Operator_Box = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.Station_ID_Box = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.User_ID_Box = new System.Windows.Forms.TextBox();
            this.but_Modify = new System.Windows.Forms.Button();
            this.but_Delete = new System.Windows.Forms.Button();
            this.but_Application = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.text_SampleSN = new System.Windows.Forms.TextBox();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.text_ModelName = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.text_CurrentRecipeName = new System.Windows.Forms.TextBox();
            this.text_FileName = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.配方 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel5 = new System.Windows.Forms.Panel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.label64 = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.label58 = new System.Windows.Forms.Label();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.label60 = new System.Windows.Forms.Label();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.label59 = new System.Windows.Forms.Label();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.label56 = new System.Windows.Forms.Label();
            this.but_SaveParam = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.XML.SuspendLayout();
            this.panel6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // but_Create
            // 
            this.but_Create.BackColor = System.Drawing.Color.LightGray;
            this.but_Create.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Create.Location = new System.Drawing.Point(238, 370);
            this.but_Create.Margin = new System.Windows.Forms.Padding(2);
            this.but_Create.Name = "but_Create";
            this.but_Create.Size = new System.Drawing.Size(95, 54);
            this.but_Create.TabIndex = 71;
            this.but_Create.Text = "新建配方";
            this.but_Create.UseVisualStyleBackColor = false;
            this.but_Create.Click += new System.EventHandler(this.but_Create_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(26, 7);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(35, 12);
            this.label7.TabIndex = 76;
            this.label7.Text = "ASIL1";
            // 
            // ASILcheckBox1
            // 
            this.ASILcheckBox1.AutoSize = true;
            this.ASILcheckBox1.Location = new System.Drawing.Point(92, 7);
            this.ASILcheckBox1.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox1.Name = "ASILcheckBox1";
            this.ASILcheckBox1.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox1.TabIndex = 0;
            this.ASILcheckBox1.Text = "是否选定";
            this.ASILcheckBox1.UseVisualStyleBackColor = true;
            this.ASILcheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(26, 39);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 12);
            this.label8.TabIndex = 78;
            this.label8.Text = "ASIL2";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(26, 71);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 12);
            this.label9.TabIndex = 79;
            this.label9.Text = "ASIL3";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(26, 103);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(35, 12);
            this.label10.TabIndex = 80;
            this.label10.Text = "ASIL4";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(26, 135);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(35, 12);
            this.label11.TabIndex = 81;
            this.label11.Text = "ASIL5";
            // 
            // ASILcheckBox2
            // 
            this.ASILcheckBox2.AutoSize = true;
            this.ASILcheckBox2.Location = new System.Drawing.Point(92, 39);
            this.ASILcheckBox2.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox2.Name = "ASILcheckBox2";
            this.ASILcheckBox2.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox2.TabIndex = 1;
            this.ASILcheckBox2.Text = "是否选定";
            this.ASILcheckBox2.UseVisualStyleBackColor = true;
            this.ASILcheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // ASILcheckBox3
            // 
            this.ASILcheckBox3.AutoSize = true;
            this.ASILcheckBox3.Location = new System.Drawing.Point(92, 71);
            this.ASILcheckBox3.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox3.Name = "ASILcheckBox3";
            this.ASILcheckBox3.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox3.TabIndex = 2;
            this.ASILcheckBox3.Text = "是否选定";
            this.ASILcheckBox3.UseVisualStyleBackColor = true;
            this.ASILcheckBox3.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // ASILcheckBox4
            // 
            this.ASILcheckBox4.AutoSize = true;
            this.ASILcheckBox4.Location = new System.Drawing.Point(92, 103);
            this.ASILcheckBox4.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox4.Name = "ASILcheckBox4";
            this.ASILcheckBox4.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox4.TabIndex = 3;
            this.ASILcheckBox4.Text = "是否选定";
            this.ASILcheckBox4.UseVisualStyleBackColor = true;
            this.ASILcheckBox4.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // ASILcheckBox5
            // 
            this.ASILcheckBox5.AutoSize = true;
            this.ASILcheckBox5.Location = new System.Drawing.Point(92, 135);
            this.ASILcheckBox5.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox5.Name = "ASILcheckBox5";
            this.ASILcheckBox5.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox5.TabIndex = 4;
            this.ASILcheckBox5.Text = "是否选定";
            this.ASILcheckBox5.UseVisualStyleBackColor = true;
            this.ASILcheckBox5.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(26, 167);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(35, 12);
            this.label12.TabIndex = 86;
            this.label12.Text = "ASIL6";
            // 
            // ASILcheckBox6
            // 
            this.ASILcheckBox6.AutoSize = true;
            this.ASILcheckBox6.Location = new System.Drawing.Point(92, 167);
            this.ASILcheckBox6.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox6.Name = "ASILcheckBox6";
            this.ASILcheckBox6.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox6.TabIndex = 5;
            this.ASILcheckBox6.Text = "是否选定";
            this.ASILcheckBox6.UseVisualStyleBackColor = true;
            this.ASILcheckBox6.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // ASILcheckBox7
            // 
            this.ASILcheckBox7.AutoSize = true;
            this.ASILcheckBox7.Location = new System.Drawing.Point(92, 199);
            this.ASILcheckBox7.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox7.Name = "ASILcheckBox7";
            this.ASILcheckBox7.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox7.TabIndex = 6;
            this.ASILcheckBox7.Text = "是否选定";
            this.ASILcheckBox7.UseVisualStyleBackColor = true;
            this.ASILcheckBox7.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(26, 199);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(35, 12);
            this.label13.TabIndex = 89;
            this.label13.Text = "ASIL7";
            // 
            // ASILcheckBox8
            // 
            this.ASILcheckBox8.AutoSize = true;
            this.ASILcheckBox8.Location = new System.Drawing.Point(92, 231);
            this.ASILcheckBox8.Margin = new System.Windows.Forms.Padding(2);
            this.ASILcheckBox8.Name = "ASILcheckBox8";
            this.ASILcheckBox8.Size = new System.Drawing.Size(72, 16);
            this.ASILcheckBox8.TabIndex = 7;
            this.ASILcheckBox8.Text = "是否选定";
            this.ASILcheckBox8.UseVisualStyleBackColor = true;
            this.ASILcheckBox8.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(26, 231);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(35, 12);
            this.label14.TabIndex = 91;
            this.label14.Text = "ASIL8";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.label44);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.label43);
            this.panel1.Controls.Add(this.FreqMaxTextBox2);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.FreqMinTextBox2);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.FreqMaxTextBox1);
            this.panel1.Controls.Add(this.label33);
            this.panel1.Controls.Add(this.FreqMinTextBox1);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.ASIL_Max_textBox8);
            this.panel1.Controls.Add(this.label31);
            this.panel1.Controls.Add(this.ASIL_Min_textBox8);
            this.panel1.Controls.Add(this.label32);
            this.panel1.Controls.Add(this.ASIL_Max_textBox7);
            this.panel1.Controls.Add(this.label29);
            this.panel1.Controls.Add(this.ASIL_Min_textBox7);
            this.panel1.Controls.Add(this.label30);
            this.panel1.Controls.Add(this.ASIL_Max_textBox6);
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.ASIL_Min_textBox6);
            this.panel1.Controls.Add(this.label28);
            this.panel1.Controls.Add(this.ASIL_Max_textBox5);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.ASIL_Min_textBox5);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.ASIL_Max_textBox4);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.ASIL_Min_textBox4);
            this.panel1.Controls.Add(this.label24);
            this.panel1.Controls.Add(this.ASIL_Max_textBox3);
            this.panel1.Controls.Add(this.label21);
            this.panel1.Controls.Add(this.ASIL_Min_textBox3);
            this.panel1.Controls.Add(this.label22);
            this.panel1.Controls.Add(this.ASIL_Max_textBox2);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.ASIL_Min_textBox2);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.ASIL_Max_textBox1);
            this.panel1.Controls.Add(this.label17);
            this.panel1.Controls.Add(this.ASIL_Min_textBox1);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.frequencycheckBox2);
            this.panel1.Controls.Add(this.label16);
            this.panel1.Controls.Add(this.frequencycheckBox1);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.ASILcheckBox8);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.ASILcheckBox7);
            this.panel1.Controls.Add(this.ASILcheckBox6);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.ASILcheckBox5);
            this.panel1.Controls.Add(this.ASILcheckBox4);
            this.panel1.Controls.Add(this.ASILcheckBox3);
            this.panel1.Controls.Add(this.ASILcheckBox2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.ASILcheckBox1);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(237, 11);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(386, 349);
            this.panel1.TabIndex = 92;
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(180, 321);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(56, 21);
            this.textBox7.TabIndex = 30;
            // 
            // label44
            // 
            this.label44.AutoSize = true;
            this.label44.Location = new System.Drawing.Point(116, 323);
            this.label44.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(59, 12);
            this.label44.TabIndex = 138;
            this.label44.Text = "unifomity";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(313, 321);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(56, 21);
            this.textBox6.TabIndex = 31;
            // 
            // label43
            // 
            this.label43.AutoSize = true;
            this.label43.Location = new System.Drawing.Point(249, 324);
            this.label43.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(53, 12);
            this.label43.TabIndex = 136;
            this.label43.Text = "max_lumi";
            // 
            // FreqMaxTextBox2
            // 
            this.FreqMaxTextBox2.Location = new System.Drawing.Point(319, 294);
            this.FreqMaxTextBox2.Name = "FreqMaxTextBox2";
            this.FreqMaxTextBox2.Size = new System.Drawing.Size(50, 21);
            this.FreqMaxTextBox2.TabIndex = 29;
            // 
            // label35
            // 
            this.label35.AutoSize = true;
            this.label35.Location = new System.Drawing.Point(289, 298);
            this.label35.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(23, 12);
            this.label35.TabIndex = 134;
            this.label35.Text = "Max";
            // 
            // FreqMinTextBox2
            // 
            this.FreqMinTextBox2.Location = new System.Drawing.Point(213, 294);
            this.FreqMinTextBox2.Name = "FreqMinTextBox2";
            this.FreqMinTextBox2.Size = new System.Drawing.Size(50, 21);
            this.FreqMinTextBox2.TabIndex = 28;
            // 
            // label36
            // 
            this.label36.AutoSize = true;
            this.label36.Location = new System.Drawing.Point(185, 298);
            this.label36.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(23, 12);
            this.label36.TabIndex = 132;
            this.label36.Text = "Min";
            // 
            // FreqMaxTextBox1
            // 
            this.FreqMaxTextBox1.Location = new System.Drawing.Point(319, 262);
            this.FreqMaxTextBox1.Name = "FreqMaxTextBox1";
            this.FreqMaxTextBox1.Size = new System.Drawing.Size(50, 21);
            this.FreqMaxTextBox1.TabIndex = 27;
            // 
            // label33
            // 
            this.label33.AutoSize = true;
            this.label33.Location = new System.Drawing.Point(289, 266);
            this.label33.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(23, 12);
            this.label33.TabIndex = 130;
            this.label33.Text = "Max";
            // 
            // FreqMinTextBox1
            // 
            this.FreqMinTextBox1.Location = new System.Drawing.Point(213, 262);
            this.FreqMinTextBox1.Name = "FreqMinTextBox1";
            this.FreqMinTextBox1.Size = new System.Drawing.Size(50, 21);
            this.FreqMinTextBox1.TabIndex = 26;
            // 
            // label34
            // 
            this.label34.AutoSize = true;
            this.label34.Location = new System.Drawing.Point(185, 266);
            this.label34.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(23, 12);
            this.label34.TabIndex = 128;
            this.label34.Text = "Min";
            // 
            // ASIL_Max_textBox8
            // 
            this.ASIL_Max_textBox8.Location = new System.Drawing.Point(319, 230);
            this.ASIL_Max_textBox8.Name = "ASIL_Max_textBox8";
            this.ASIL_Max_textBox8.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox8.TabIndex = 25;
            // 
            // label31
            // 
            this.label31.AutoSize = true;
            this.label31.Location = new System.Drawing.Point(289, 234);
            this.label31.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(23, 12);
            this.label31.TabIndex = 126;
            this.label31.Text = "Max";
            // 
            // ASIL_Min_textBox8
            // 
            this.ASIL_Min_textBox8.Location = new System.Drawing.Point(213, 230);
            this.ASIL_Min_textBox8.Name = "ASIL_Min_textBox8";
            this.ASIL_Min_textBox8.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox8.TabIndex = 24;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Location = new System.Drawing.Point(185, 234);
            this.label32.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(23, 12);
            this.label32.TabIndex = 124;
            this.label32.Text = "Min";
            // 
            // ASIL_Max_textBox7
            // 
            this.ASIL_Max_textBox7.Location = new System.Drawing.Point(319, 198);
            this.ASIL_Max_textBox7.Name = "ASIL_Max_textBox7";
            this.ASIL_Max_textBox7.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox7.TabIndex = 23;
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(289, 202);
            this.label29.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(23, 12);
            this.label29.TabIndex = 122;
            this.label29.Text = "Max";
            // 
            // ASIL_Min_textBox7
            // 
            this.ASIL_Min_textBox7.Location = new System.Drawing.Point(213, 198);
            this.ASIL_Min_textBox7.Name = "ASIL_Min_textBox7";
            this.ASIL_Min_textBox7.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox7.TabIndex = 22;
            // 
            // label30
            // 
            this.label30.AutoSize = true;
            this.label30.Location = new System.Drawing.Point(185, 202);
            this.label30.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(23, 12);
            this.label30.TabIndex = 120;
            this.label30.Text = "Min";
            // 
            // ASIL_Max_textBox6
            // 
            this.ASIL_Max_textBox6.Location = new System.Drawing.Point(319, 166);
            this.ASIL_Max_textBox6.Name = "ASIL_Max_textBox6";
            this.ASIL_Max_textBox6.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox6.TabIndex = 21;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Location = new System.Drawing.Point(289, 170);
            this.label27.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(23, 12);
            this.label27.TabIndex = 118;
            this.label27.Text = "Max";
            // 
            // ASIL_Min_textBox6
            // 
            this.ASIL_Min_textBox6.Location = new System.Drawing.Point(213, 166);
            this.ASIL_Min_textBox6.Name = "ASIL_Min_textBox6";
            this.ASIL_Min_textBox6.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox6.TabIndex = 20;
            // 
            // label28
            // 
            this.label28.AutoSize = true;
            this.label28.Location = new System.Drawing.Point(185, 170);
            this.label28.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(23, 12);
            this.label28.TabIndex = 116;
            this.label28.Text = "Min";
            // 
            // ASIL_Max_textBox5
            // 
            this.ASIL_Max_textBox5.Location = new System.Drawing.Point(319, 134);
            this.ASIL_Max_textBox5.Name = "ASIL_Max_textBox5";
            this.ASIL_Max_textBox5.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox5.TabIndex = 19;
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Location = new System.Drawing.Point(289, 138);
            this.label25.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(23, 12);
            this.label25.TabIndex = 114;
            this.label25.Text = "Max";
            // 
            // ASIL_Min_textBox5
            // 
            this.ASIL_Min_textBox5.Location = new System.Drawing.Point(213, 134);
            this.ASIL_Min_textBox5.Name = "ASIL_Min_textBox5";
            this.ASIL_Min_textBox5.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox5.TabIndex = 18;
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Location = new System.Drawing.Point(185, 138);
            this.label26.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(23, 12);
            this.label26.TabIndex = 112;
            this.label26.Text = "Min";
            // 
            // ASIL_Max_textBox4
            // 
            this.ASIL_Max_textBox4.Location = new System.Drawing.Point(319, 102);
            this.ASIL_Max_textBox4.Name = "ASIL_Max_textBox4";
            this.ASIL_Max_textBox4.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox4.TabIndex = 17;
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(289, 106);
            this.label23.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(23, 12);
            this.label23.TabIndex = 110;
            this.label23.Text = "Max";
            // 
            // ASIL_Min_textBox4
            // 
            this.ASIL_Min_textBox4.Location = new System.Drawing.Point(213, 102);
            this.ASIL_Min_textBox4.Name = "ASIL_Min_textBox4";
            this.ASIL_Min_textBox4.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox4.TabIndex = 16;
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Location = new System.Drawing.Point(185, 106);
            this.label24.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(23, 12);
            this.label24.TabIndex = 108;
            this.label24.Text = "Min";
            // 
            // ASIL_Max_textBox3
            // 
            this.ASIL_Max_textBox3.Location = new System.Drawing.Point(319, 70);
            this.ASIL_Max_textBox3.Name = "ASIL_Max_textBox3";
            this.ASIL_Max_textBox3.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox3.TabIndex = 15;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(289, 74);
            this.label21.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(23, 12);
            this.label21.TabIndex = 106;
            this.label21.Text = "Max";
            // 
            // ASIL_Min_textBox3
            // 
            this.ASIL_Min_textBox3.Location = new System.Drawing.Point(213, 70);
            this.ASIL_Min_textBox3.Name = "ASIL_Min_textBox3";
            this.ASIL_Min_textBox3.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox3.TabIndex = 14;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(185, 74);
            this.label22.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(23, 12);
            this.label22.TabIndex = 104;
            this.label22.Text = "Min";
            // 
            // ASIL_Max_textBox2
            // 
            this.ASIL_Max_textBox2.Location = new System.Drawing.Point(319, 38);
            this.ASIL_Max_textBox2.Name = "ASIL_Max_textBox2";
            this.ASIL_Max_textBox2.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox2.TabIndex = 13;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(289, 42);
            this.label20.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(23, 12);
            this.label20.TabIndex = 102;
            this.label20.Text = "Max";
            // 
            // ASIL_Min_textBox2
            // 
            this.ASIL_Min_textBox2.Location = new System.Drawing.Point(213, 38);
            this.ASIL_Min_textBox2.Name = "ASIL_Min_textBox2";
            this.ASIL_Min_textBox2.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox2.TabIndex = 12;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(185, 42);
            this.label19.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(23, 12);
            this.label19.TabIndex = 100;
            this.label19.Text = "Min";
            // 
            // ASIL_Max_textBox1
            // 
            this.ASIL_Max_textBox1.Location = new System.Drawing.Point(319, 6);
            this.ASIL_Max_textBox1.Name = "ASIL_Max_textBox1";
            this.ASIL_Max_textBox1.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Max_textBox1.TabIndex = 11;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(290, 10);
            this.label17.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(23, 12);
            this.label17.TabIndex = 98;
            this.label17.Text = "Max";
            // 
            // ASIL_Min_textBox1
            // 
            this.ASIL_Min_textBox1.Location = new System.Drawing.Point(213, 6);
            this.ASIL_Min_textBox1.Name = "ASIL_Min_textBox1";
            this.ASIL_Min_textBox1.Size = new System.Drawing.Size(50, 21);
            this.ASIL_Min_textBox1.TabIndex = 10;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(185, 10);
            this.label18.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(23, 12);
            this.label18.TabIndex = 96;
            this.label18.Text = "Min";
            // 
            // frequencycheckBox2
            // 
            this.frequencycheckBox2.AutoSize = true;
            this.frequencycheckBox2.Location = new System.Drawing.Point(92, 295);
            this.frequencycheckBox2.Margin = new System.Windows.Forms.Padding(2);
            this.frequencycheckBox2.Name = "frequencycheckBox2";
            this.frequencycheckBox2.Size = new System.Drawing.Size(72, 16);
            this.frequencycheckBox2.TabIndex = 9;
            this.frequencycheckBox2.Text = "是否选定";
            this.frequencycheckBox2.UseVisualStyleBackColor = true;
            this.frequencycheckBox2.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(8, 295);
            this.label16.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(65, 12);
            this.label16.TabIndex = 94;
            this.label16.Text = "frequency2";
            // 
            // frequencycheckBox1
            // 
            this.frequencycheckBox1.AutoSize = true;
            this.frequencycheckBox1.Location = new System.Drawing.Point(92, 263);
            this.frequencycheckBox1.Margin = new System.Windows.Forms.Padding(2);
            this.frequencycheckBox1.Name = "frequencycheckBox1";
            this.frequencycheckBox1.Size = new System.Drawing.Size(72, 16);
            this.frequencycheckBox1.TabIndex = 8;
            this.frequencycheckBox1.Text = "是否选定";
            this.frequencycheckBox1.UseVisualStyleBackColor = true;
            this.frequencycheckBox1.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(8, 263);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(65, 12);
            this.label15.TabIndex = 92;
            this.label15.Text = "frequency1";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.groupBox3);
            this.panel2.Location = new System.Drawing.Point(455, 372);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(651, 116);
            this.panel2.TabIndex = 94;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox25);
            this.groupBox3.Controls.Add(this.label37);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.textBox3);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.textBox2);
            this.groupBox3.Controls.Add(this.textBox12);
            this.groupBox3.Controls.Add(this.label49);
            this.groupBox3.Controls.Add(this.checkBox1);
            this.groupBox3.Controls.Add(this.PIS2_checkBox);
            this.groupBox3.Controls.Add(this.textBox4);
            this.groupBox3.Controls.Add(this.label51);
            this.groupBox3.Controls.Add(this.textBox5);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.textBox1);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.Data);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(651, 116);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "精测机/MCMQ";
            // 
            // textBox25
            // 
            this.textBox25.Location = new System.Drawing.Point(508, 85);
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(98, 21);
            this.textBox25.TabIndex = 142;
            this.textBox25.Text = "A1左屏";
            // 
            // label37
            // 
            this.label37.AutoSize = true;
            this.label37.Location = new System.Drawing.Point(254, 89);
            this.label37.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(0, 15);
            this.label37.TabIndex = 141;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(274, 87);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 15);
            this.label4.TabIndex = 140;
            this.label4.Text = "精测机_Port";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(362, 85);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(57, 21);
            this.textBox3.TabIndex = 139;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 87);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 15);
            this.label3.TabIndex = 138;
            this.label3.Text = "精测监听_IP";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(98, 85);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 21);
            this.textBox2.TabIndex = 137;
            // 
            // textBox12
            // 
            this.textBox12.Location = new System.Drawing.Point(551, 53);
            this.textBox12.Name = "textBox12";
            this.textBox12.Size = new System.Drawing.Size(98, 21);
            this.textBox12.TabIndex = 135;
            // 
            // label49
            // 
            this.label49.AutoSize = true;
            this.label49.Location = new System.Drawing.Point(422, 54);
            this.label49.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(124, 15);
            this.label49.TabIndex = 136;
            this.label49.Text = "SendQueue_ictest";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(425, 86);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(78, 19);
            this.checkBox1.TabIndex = 134;
            this.checkBox1.Text = "位置信息";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // PIS2_checkBox
            // 
            this.PIS2_checkBox.AutoSize = true;
            this.PIS2_checkBox.Location = new System.Drawing.Point(425, 24);
            this.PIS2_checkBox.Margin = new System.Windows.Forms.Padding(2);
            this.PIS2_checkBox.Name = "PIS2_checkBox";
            this.PIS2_checkBox.Size = new System.Drawing.Size(90, 19);
            this.PIS2_checkBox.TabIndex = 134;
            this.PIS2_checkBox.Text = "PIS2_OFF";
            this.PIS2_checkBox.UseVisualStyleBackColor = true;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(98, 53);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(115, 21);
            this.textBox4.TabIndex = 132;
            // 
            // label51
            // 
            this.label51.AutoSize = true;
            this.label51.Location = new System.Drawing.Point(14, 55);
            this.label51.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(82, 15);
            this.label51.TabIndex = 130;
            this.label51.Text = "SendQueue";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(303, 53);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(115, 21);
            this.textBox5.TabIndex = 133;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(214, 56);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 15);
            this.label6.TabIndex = 131;
            this.label6.Text = "ReplyQueue";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(352, 22);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(66, 21);
            this.textBox1.TabIndex = 129;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(276, 25);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 15);
            this.label2.TabIndex = 128;
            this.label2.Text = "ISP2_Port";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 22);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 15);
            this.label1.TabIndex = 127;
            this.label1.Text = "PIS2_IP";
            // 
            // Data
            // 
            this.Data.Location = new System.Drawing.Point(79, 20);
            this.Data.Name = "Data";
            this.Data.Size = new System.Drawing.Size(193, 21);
            this.Data.TabIndex = 126;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Silver;
            this.panel4.Controls.Add(this.XML);
            this.panel4.Location = new System.Drawing.Point(790, 10);
            this.panel4.Margin = new System.Windows.Forms.Padding(2);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(176, 349);
            this.panel4.TabIndex = 101;
            // 
            // XML
            // 
            this.XML.Controls.Add(this.textBox11);
            this.XML.Controls.Add(this.label48);
            this.XML.Controls.Add(this.textBox10);
            this.XML.Controls.Add(this.label47);
            this.XML.Controls.Add(this.textBox9);
            this.XML.Controls.Add(this.label46);
            this.XML.Controls.Add(this.textBox8);
            this.XML.Controls.Add(this.label45);
            this.XML.Controls.Add(this.label41);
            this.XML.Controls.Add(this.TYPE1);
            this.XML.Controls.Add(this.EQP_ID_Box);
            this.XML.Controls.Add(this.EQP_ID);
            this.XML.Controls.Add(this.Operator_Box);
            this.XML.Controls.Add(this.label40);
            this.XML.Controls.Add(this.Station_ID_Box);
            this.XML.Controls.Add(this.label39);
            this.XML.Controls.Add(this.label38);
            this.XML.Controls.Add(this.User_ID_Box);
            this.XML.Dock = System.Windows.Forms.DockStyle.Fill;
            this.XML.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.XML.Location = new System.Drawing.Point(0, 0);
            this.XML.Margin = new System.Windows.Forms.Padding(2);
            this.XML.Name = "XML";
            this.XML.Padding = new System.Windows.Forms.Padding(2);
            this.XML.Size = new System.Drawing.Size(176, 349);
            this.XML.TabIndex = 120;
            this.XML.TabStop = false;
            this.XML.Text = "XML";
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(86, 86);
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(84, 21);
            this.textBox11.TabIndex = 139;
            // 
            // label48
            // 
            this.label48.AutoSize = true;
            this.label48.Location = new System.Drawing.Point(9, 91);
            this.label48.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(71, 15);
            this.label48.TabIndex = 138;
            this.label48.Text = "unique_id";
            // 
            // textBox10
            // 
            this.textBox10.Location = new System.Drawing.Point(86, 292);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(84, 21);
            this.textBox10.TabIndex = 137;
            // 
            // label47
            // 
            this.label47.AutoSize = true;
            this.label47.Location = new System.Drawing.Point(9, 298);
            this.label47.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(75, 15);
            this.label47.TabIndex = 136;
            this.label47.Text = "fw_version";
            // 
            // textBox9
            // 
            this.textBox9.Location = new System.Drawing.Point(86, 258);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(84, 21);
            this.textBox9.TabIndex = 135;
            // 
            // label46
            // 
            this.label46.AutoSize = true;
            this.label46.Location = new System.Drawing.Point(9, 263);
            this.label46.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(71, 15);
            this.label46.TabIndex = 134;
            this.label46.Text = "model_no";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(86, 223);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(84, 21);
            this.textBox8.TabIndex = 133;
            // 
            // label45
            // 
            this.label45.AutoSize = true;
            this.label45.Location = new System.Drawing.Point(9, 229);
            this.label45.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(56, 15);
            this.label45.TabIndex = 132;
            this.label45.Text = "part_no";
            // 
            // label41
            // 
            this.label41.AutoSize = true;
            this.label41.Location = new System.Drawing.Point(9, 194);
            this.label41.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(67, 15);
            this.label41.TabIndex = 129;
            this.label41.Text = "trx_name";
            // 
            // TYPE1
            // 
            this.TYPE1.Location = new System.Drawing.Point(86, 189);
            this.TYPE1.Name = "TYPE1";
            this.TYPE1.Size = new System.Drawing.Size(84, 21);
            this.TYPE1.TabIndex = 128;
            // 
            // EQP_ID_Box
            // 
            this.EQP_ID_Box.Location = new System.Drawing.Point(86, 154);
            this.EQP_ID_Box.Name = "EQP_ID_Box";
            this.EQP_ID_Box.Size = new System.Drawing.Size(84, 21);
            this.EQP_ID_Box.TabIndex = 127;
            // 
            // EQP_ID
            // 
            this.EQP_ID.AutoSize = true;
            this.EQP_ID.Location = new System.Drawing.Point(14, 160);
            this.EQP_ID.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.EQP_ID.Name = "EQP_ID";
            this.EQP_ID.Size = new System.Drawing.Size(51, 15);
            this.EQP_ID.TabIndex = 126;
            this.EQP_ID.Text = "eqp_id";
            // 
            // Operator_Box
            // 
            this.Operator_Box.Location = new System.Drawing.Point(86, 120);
            this.Operator_Box.Name = "Operator_Box";
            this.Operator_Box.Size = new System.Drawing.Size(84, 21);
            this.Operator_Box.TabIndex = 125;
            // 
            // label40
            // 
            this.label40.AutoSize = true;
            this.label40.Location = new System.Drawing.Point(14, 126);
            this.label40.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(43, 15);
            this.label40.TabIndex = 124;
            this.label40.Text = "jig_id";
            // 
            // Station_ID_Box
            // 
            this.Station_ID_Box.Location = new System.Drawing.Point(86, 51);
            this.Station_ID_Box.Name = "Station_ID_Box";
            this.Station_ID_Box.Size = new System.Drawing.Size(84, 21);
            this.Station_ID_Box.TabIndex = 123;
            // 
            // label39
            // 
            this.label39.AutoSize = true;
            this.label39.Location = new System.Drawing.Point(6, 57);
            this.label39.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(70, 15);
            this.label39.TabIndex = 122;
            this.label39.Text = "station_id";
            // 
            // label38
            // 
            this.label38.AutoSize = true;
            this.label38.Enabled = false;
            this.label38.Location = new System.Drawing.Point(6, 22);
            this.label38.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(59, 15);
            this.label38.TabIndex = 121;
            this.label38.Text = "lm_user";
            // 
            // User_ID_Box
            // 
            this.User_ID_Box.Enabled = false;
            this.User_ID_Box.Location = new System.Drawing.Point(86, 17);
            this.User_ID_Box.Name = "User_ID_Box";
            this.User_ID_Box.Size = new System.Drawing.Size(84, 21);
            this.User_ID_Box.TabIndex = 120;
            // 
            // but_Modify
            // 
            this.but_Modify.BackColor = System.Drawing.Color.LightGray;
            this.but_Modify.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Modify.Location = new System.Drawing.Point(346, 370);
            this.but_Modify.Margin = new System.Windows.Forms.Padding(2);
            this.but_Modify.Name = "but_Modify";
            this.but_Modify.Size = new System.Drawing.Size(95, 54);
            this.but_Modify.TabIndex = 71;
            this.but_Modify.Text = "保存配方";
            this.but_Modify.UseVisualStyleBackColor = false;
            this.but_Modify.Click += new System.EventHandler(this.but_Modify_Click);
            // 
            // but_Delete
            // 
            this.but_Delete.BackColor = System.Drawing.Color.LightGray;
            this.but_Delete.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Delete.Location = new System.Drawing.Point(238, 437);
            this.but_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.but_Delete.Name = "but_Delete";
            this.but_Delete.Size = new System.Drawing.Size(95, 54);
            this.but_Delete.TabIndex = 71;
            this.but_Delete.Text = "删除配方";
            this.but_Delete.UseVisualStyleBackColor = false;
            this.but_Delete.Click += new System.EventHandler(this.but_Delete_Click);
            // 
            // but_Application
            // 
            this.but_Application.BackColor = System.Drawing.Color.LightGray;
            this.but_Application.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Application.Location = new System.Drawing.Point(346, 437);
            this.but_Application.Margin = new System.Windows.Forms.Padding(2);
            this.but_Application.Name = "but_Application";
            this.but_Application.Size = new System.Drawing.Size(95, 54);
            this.but_Application.TabIndex = 71;
            this.but_Application.Text = "应用配方";
            this.but_Application.UseVisualStyleBackColor = false;
            this.but_Application.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.Silver;
            this.panel6.Controls.Add(this.groupBox1);
            this.panel6.Location = new System.Drawing.Point(972, 10);
            this.panel6.Margin = new System.Windows.Forms.Padding(2);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(134, 293);
            this.panel6.TabIndex = 103;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBox14);
            this.groupBox1.Controls.Add(this.text_SampleSN);
            this.groupBox1.Controls.Add(this.label53);
            this.groupBox1.Controls.Add(this.label54);
            this.groupBox1.Controls.Add(this.textBox13);
            this.groupBox1.Controls.Add(this.text_ModelName);
            this.groupBox1.Controls.Add(this.label52);
            this.groupBox1.Controls.Add(this.label55);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(134, 293);
            this.groupBox1.TabIndex = 73;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Check Time ";
            // 
            // textBox14
            // 
            this.textBox14.Location = new System.Drawing.Point(14, 104);
            this.textBox14.Name = "textBox14";
            this.textBox14.Size = new System.Drawing.Size(110, 21);
            this.textBox14.TabIndex = 75;
            this.textBox14.Text = "19:00";
            // 
            // text_SampleSN
            // 
            this.text_SampleSN.Location = new System.Drawing.Point(14, 230);
            this.text_SampleSN.Name = "text_SampleSN";
            this.text_SampleSN.Size = new System.Drawing.Size(110, 21);
            this.text_SampleSN.TabIndex = 79;
            this.text_SampleSN.Text = "S2C313MAR02";
            // 
            // label53
            // 
            this.label53.AutoSize = true;
            this.label53.Location = new System.Drawing.Point(10, 78);
            this.label53.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(70, 15);
            this.label53.TabIndex = 73;
            this.label53.Text = "NightShift";
            // 
            // label54
            // 
            this.label54.AutoSize = true;
            this.label54.Location = new System.Drawing.Point(10, 202);
            this.label54.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(83, 15);
            this.label54.TabIndex = 77;
            this.label54.Text = "Sample SN:";
            // 
            // textBox13
            // 
            this.textBox13.Location = new System.Drawing.Point(14, 49);
            this.textBox13.Name = "textBox13";
            this.textBox13.Size = new System.Drawing.Size(110, 21);
            this.textBox13.TabIndex = 76;
            this.textBox13.Text = "7:50";
            // 
            // text_ModelName
            // 
            this.text_ModelName.Location = new System.Drawing.Point(14, 167);
            this.text_ModelName.Name = "text_ModelName";
            this.text_ModelName.Size = new System.Drawing.Size(110, 21);
            this.text_ModelName.TabIndex = 80;
            this.text_ModelName.Text = "C313RAM01.0";
            // 
            // label52
            // 
            this.label52.AutoSize = true;
            this.label52.Location = new System.Drawing.Point(10, 22);
            this.label52.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(60, 15);
            this.label52.TabIndex = 74;
            this.label52.Text = "DayShift";
            // 
            // label55
            // 
            this.label55.AutoSize = true;
            this.label55.Location = new System.Drawing.Point(10, 141);
            this.label55.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(93, 15);
            this.label55.TabIndex = 78;
            this.label55.Text = "Model Name:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(8, 361);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 72;
            this.label5.Text = "当前配方名称";
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(8, 415);
            this.label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(91, 14);
            this.label50.TabIndex = 72;
            this.label50.Text = "新建配方名称";
            // 
            // text_CurrentRecipeName
            // 
            this.text_CurrentRecipeName.Enabled = false;
            this.text_CurrentRecipeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_CurrentRecipeName.Location = new System.Drawing.Point(104, 356);
            this.text_CurrentRecipeName.Name = "text_CurrentRecipeName";
            this.text_CurrentRecipeName.Size = new System.Drawing.Size(98, 26);
            this.text_CurrentRecipeName.TabIndex = 73;
            this.text_CurrentRecipeName.Tag = "1";
            this.text_CurrentRecipeName.TextChanged += new System.EventHandler(this.text_FileName_TextChanged);
            // 
            // text_FileName
            // 
            this.text_FileName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_FileName.Location = new System.Drawing.Point(104, 410);
            this.text_FileName.Name = "text_FileName";
            this.text_FileName.Size = new System.Drawing.Size(98, 26);
            this.text_FileName.TabIndex = 73;
            this.text_FileName.Tag = "2";
            this.text_FileName.TextChanged += new System.EventHandler(this.text_FileName_TextChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.配方});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 5);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(200, 332);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // 配方
            // 
            this.配方.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.配方.HeaderText = "配方";
            this.配方.MinimumWidth = 6;
            this.配方.Name = "配方";
            this.配方.ReadOnly = true;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.text_FileName);
            this.panel5.Controls.Add(this.text_CurrentRecipeName);
            this.panel5.Controls.Add(this.label50);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(11, 11);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(206, 481);
            this.panel5.TabIndex = 102;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Silver;
            this.groupBox2.Controls.Add(this.textBox22);
            this.groupBox2.Controls.Add(this.textBox19);
            this.groupBox2.Controls.Add(this.textBox16);
            this.groupBox2.Controls.Add(this.label64);
            this.groupBox2.Controls.Add(this.label61);
            this.groupBox2.Controls.Add(this.label58);
            this.groupBox2.Controls.Add(this.textBox24);
            this.groupBox2.Controls.Add(this.label65);
            this.groupBox2.Controls.Add(this.textBox23);
            this.groupBox2.Controls.Add(this.label63);
            this.groupBox2.Controls.Add(this.textBox20);
            this.groupBox2.Controls.Add(this.label60);
            this.groupBox2.Controls.Add(this.textBox17);
            this.groupBox2.Controls.Add(this.label57);
            this.groupBox2.Controls.Add(this.textBox21);
            this.groupBox2.Controls.Add(this.textBox18);
            this.groupBox2.Controls.Add(this.label62);
            this.groupBox2.Controls.Add(this.label59);
            this.groupBox2.Controls.Add(this.textBox15);
            this.groupBox2.Controls.Add(this.label56);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(627, 11);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(159, 349);
            this.groupBox2.TabIndex = 140;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "CCD_TYPE";
            // 
            // textBox22
            // 
            this.textBox22.Location = new System.Drawing.Point(65, 245);
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(89, 21);
            this.textBox22.TabIndex = 149;
            this.textBox22.Tag = "8";
            this.textBox22.Text = "ASIL_8";
            // 
            // textBox19
            // 
            this.textBox19.Location = new System.Drawing.Point(65, 149);
            this.textBox19.Name = "textBox19";
            this.textBox19.Size = new System.Drawing.Size(89, 21);
            this.textBox19.TabIndex = 152;
            this.textBox19.Tag = "5";
            this.textBox19.Text = "ASIL_5";
            // 
            // textBox16
            // 
            this.textBox16.Location = new System.Drawing.Point(65, 53);
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(89, 21);
            this.textBox16.TabIndex = 151;
            this.textBox16.Tag = "2";
            this.textBox16.Text = "ASIL_2";
            // 
            // label64
            // 
            this.label64.AutoSize = true;
            this.label64.Font = new System.Drawing.Font("宋体", 9F);
            this.label64.Location = new System.Drawing.Point(4, 248);
            this.label64.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(53, 12);
            this.label64.TabIndex = 159;
            this.label64.Text = "CCD_TYPE";
            // 
            // label61
            // 
            this.label61.AutoSize = true;
            this.label61.Font = new System.Drawing.Font("宋体", 9F);
            this.label61.Location = new System.Drawing.Point(4, 152);
            this.label61.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(53, 12);
            this.label61.TabIndex = 158;
            this.label61.Text = "CCD_TYPE";
            // 
            // label58
            // 
            this.label58.AutoSize = true;
            this.label58.Font = new System.Drawing.Font("宋体", 9F);
            this.label58.Location = new System.Drawing.Point(4, 56);
            this.label58.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(53, 12);
            this.label58.TabIndex = 156;
            this.label58.Text = "CCD_TYPE";
            // 
            // textBox24
            // 
            this.textBox24.Location = new System.Drawing.Point(65, 309);
            this.textBox24.Name = "textBox24";
            this.textBox24.Size = new System.Drawing.Size(89, 21);
            this.textBox24.TabIndex = 150;
            this.textBox24.Tag = "10";
            this.textBox24.Text = "frequent_2";
            // 
            // label65
            // 
            this.label65.AutoSize = true;
            this.label65.Font = new System.Drawing.Font("宋体", 9F);
            this.label65.Location = new System.Drawing.Point(4, 312);
            this.label65.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(53, 12);
            this.label65.TabIndex = 154;
            this.label65.Text = "CCD_TYPE";
            // 
            // textBox23
            // 
            this.textBox23.Location = new System.Drawing.Point(65, 277);
            this.textBox23.Name = "textBox23";
            this.textBox23.Size = new System.Drawing.Size(89, 21);
            this.textBox23.TabIndex = 153;
            this.textBox23.Tag = "9";
            this.textBox23.Text = "frequent_1";
            // 
            // label63
            // 
            this.label63.AutoSize = true;
            this.label63.Font = new System.Drawing.Font("宋体", 9F);
            this.label63.Location = new System.Drawing.Point(4, 280);
            this.label63.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(53, 12);
            this.label63.TabIndex = 160;
            this.label63.Text = "CCD_TYPE";
            // 
            // textBox20
            // 
            this.textBox20.Location = new System.Drawing.Point(65, 181);
            this.textBox20.Name = "textBox20";
            this.textBox20.Size = new System.Drawing.Size(89, 21);
            this.textBox20.TabIndex = 148;
            this.textBox20.Tag = "6";
            this.textBox20.Text = "ASIL_6";
            // 
            // label60
            // 
            this.label60.AutoSize = true;
            this.label60.Font = new System.Drawing.Font("宋体", 9F);
            this.label60.Location = new System.Drawing.Point(4, 184);
            this.label60.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(53, 12);
            this.label60.TabIndex = 155;
            this.label60.Text = "CCD_TYPE";
            // 
            // textBox17
            // 
            this.textBox17.Location = new System.Drawing.Point(65, 85);
            this.textBox17.Name = "textBox17";
            this.textBox17.Size = new System.Drawing.Size(89, 21);
            this.textBox17.TabIndex = 147;
            this.textBox17.Tag = "3";
            this.textBox17.Text = "ASIL_3";
            // 
            // label57
            // 
            this.label57.AutoSize = true;
            this.label57.Font = new System.Drawing.Font("宋体", 9F);
            this.label57.Location = new System.Drawing.Point(4, 88);
            this.label57.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(53, 12);
            this.label57.TabIndex = 157;
            this.label57.Text = "CCD_TYPE";
            // 
            // textBox21
            // 
            this.textBox21.Location = new System.Drawing.Point(65, 213);
            this.textBox21.Name = "textBox21";
            this.textBox21.Size = new System.Drawing.Size(89, 21);
            this.textBox21.TabIndex = 142;
            this.textBox21.Tag = "7";
            this.textBox21.Text = "ASIL_7";
            // 
            // textBox18
            // 
            this.textBox18.Location = new System.Drawing.Point(65, 117);
            this.textBox18.Name = "textBox18";
            this.textBox18.Size = new System.Drawing.Size(89, 21);
            this.textBox18.TabIndex = 141;
            this.textBox18.Tag = "4";
            this.textBox18.Text = "ASIL_4";
            // 
            // label62
            // 
            this.label62.AutoSize = true;
            this.label62.Font = new System.Drawing.Font("宋体", 9F);
            this.label62.Location = new System.Drawing.Point(4, 216);
            this.label62.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(53, 12);
            this.label62.TabIndex = 146;
            this.label62.Text = "CCD_TYPE";
            // 
            // label59
            // 
            this.label59.AutoSize = true;
            this.label59.Font = new System.Drawing.Font("宋体", 9F);
            this.label59.Location = new System.Drawing.Point(4, 120);
            this.label59.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(53, 12);
            this.label59.TabIndex = 145;
            this.label59.Text = "CCD_TYPE";
            // 
            // textBox15
            // 
            this.textBox15.Location = new System.Drawing.Point(65, 21);
            this.textBox15.Name = "textBox15";
            this.textBox15.Size = new System.Drawing.Size(89, 21);
            this.textBox15.TabIndex = 143;
            this.textBox15.Tag = "1";
            this.textBox15.Text = "ASIL_1";
            // 
            // label56
            // 
            this.label56.AutoSize = true;
            this.label56.Font = new System.Drawing.Font("宋体", 9F);
            this.label56.Location = new System.Drawing.Point(4, 24);
            this.label56.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(53, 12);
            this.label56.TabIndex = 144;
            this.label56.Text = "CCD_TYPE";
            // 
            // but_SaveParam
            // 
            this.but_SaveParam.BackColor = System.Drawing.Color.LightGray;
            this.but_SaveParam.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_SaveParam.Location = new System.Drawing.Point(972, 309);
            this.but_SaveParam.Margin = new System.Windows.Forms.Padding(2);
            this.but_SaveParam.Name = "but_SaveParam";
            this.but_SaveParam.Size = new System.Drawing.Size(134, 54);
            this.but_SaveParam.TabIndex = 141;
            this.but_SaveParam.Text = "保存并应用参数";
            this.but_SaveParam.UseVisualStyleBackColor = false;
            this.but_SaveParam.Click += new System.EventHandler(this.but_SaveParam_Click);
            // 
            // SettingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1113, 497);
            this.Controls.Add(this.but_SaveParam);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.but_Modify);
            this.Controls.Add(this.but_Application);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.but_Create);
            this.Controls.Add(this.but_Delete);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ASIL侦测上位机软件_v3.0     设置界面";
            this.Load += new System.EventHandler(this.SettingForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.XML.ResumeLayout(false);
            this.XML.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}

		// Token: 0x04000086 RID: 134
		private global::System.ComponentModel.IContainer components = null;

		// Token: 0x0400008E RID: 142
		private global::System.Windows.Forms.Button but_Create;

		// Token: 0x04000094 RID: 148
		private global::System.IO.Ports.SerialPort serialPort1;

		// Token: 0x0400009B RID: 155
		private global::System.Windows.Forms.Label label7;

		// Token: 0x0400009C RID: 156
		private global::System.Windows.Forms.CheckBox ASILcheckBox1;

		// Token: 0x0400009D RID: 157
		private global::System.Windows.Forms.Label label8;

		// Token: 0x0400009E RID: 158
		private global::System.Windows.Forms.Label label9;

		// Token: 0x0400009F RID: 159
		private global::System.Windows.Forms.Label label10;

		// Token: 0x040000A0 RID: 160
		private global::System.Windows.Forms.Label label11;

		// Token: 0x040000A1 RID: 161
		private global::System.Windows.Forms.CheckBox ASILcheckBox2;

		// Token: 0x040000A2 RID: 162
		private global::System.Windows.Forms.CheckBox ASILcheckBox3;

		// Token: 0x040000A3 RID: 163
		private global::System.Windows.Forms.CheckBox ASILcheckBox4;

		// Token: 0x040000A4 RID: 164
		private global::System.Windows.Forms.CheckBox ASILcheckBox5;

		// Token: 0x040000A5 RID: 165
		private global::System.Windows.Forms.Label label12;

		// Token: 0x040000A6 RID: 166
		private global::System.Windows.Forms.CheckBox ASILcheckBox6;

		// Token: 0x040000A7 RID: 167
		private global::System.Windows.Forms.CheckBox ASILcheckBox7;

		// Token: 0x040000A8 RID: 168
		private global::System.Windows.Forms.Label label13;

		// Token: 0x040000A9 RID: 169
		private global::System.Windows.Forms.CheckBox ASILcheckBox8;

		// Token: 0x040000AA RID: 170
		private global::System.Windows.Forms.Label label14;

		// Token: 0x040000AB RID: 171
		private global::System.Windows.Forms.Panel panel1;

		// Token: 0x040000AC RID: 172
		private global::System.Windows.Forms.Label label15;

		// Token: 0x040000AD RID: 173
		private global::System.Windows.Forms.CheckBox frequencycheckBox2;

		// Token: 0x040000AE RID: 174
		private global::System.Windows.Forms.Label label16;

		// Token: 0x040000AF RID: 175
		private global::System.Windows.Forms.CheckBox frequencycheckBox1;

		// Token: 0x040000B0 RID: 176
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox1;

		// Token: 0x040000B1 RID: 177
		private global::System.Windows.Forms.Label label17;

		// Token: 0x040000B2 RID: 178
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox1;

		// Token: 0x040000B3 RID: 179
		private global::System.Windows.Forms.Label label18;

		// Token: 0x040000B4 RID: 180
		private global::System.Windows.Forms.TextBox FreqMaxTextBox2;

		// Token: 0x040000B5 RID: 181
		private global::System.Windows.Forms.Label label35;

		// Token: 0x040000B6 RID: 182
		private global::System.Windows.Forms.TextBox FreqMinTextBox2;

		// Token: 0x040000B7 RID: 183
		private global::System.Windows.Forms.Label label36;

		// Token: 0x040000B8 RID: 184
		private global::System.Windows.Forms.TextBox FreqMaxTextBox1;

		// Token: 0x040000B9 RID: 185
		private global::System.Windows.Forms.Label label33;

		// Token: 0x040000BA RID: 186
		private global::System.Windows.Forms.TextBox FreqMinTextBox1;

		// Token: 0x040000BB RID: 187
		private global::System.Windows.Forms.Label label34;

		// Token: 0x040000BC RID: 188
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox8;

		// Token: 0x040000BD RID: 189
		private global::System.Windows.Forms.Label label31;

		// Token: 0x040000BE RID: 190
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox8;

		// Token: 0x040000BF RID: 191
		private global::System.Windows.Forms.Label label32;

		// Token: 0x040000C0 RID: 192
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox7;

		// Token: 0x040000C1 RID: 193
		private global::System.Windows.Forms.Label label29;

		// Token: 0x040000C2 RID: 194
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox7;

		// Token: 0x040000C3 RID: 195
		private global::System.Windows.Forms.Label label30;

		// Token: 0x040000C4 RID: 196
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox6;

		// Token: 0x040000C5 RID: 197
		private global::System.Windows.Forms.Label label27;

		// Token: 0x040000C6 RID: 198
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox6;

		// Token: 0x040000C7 RID: 199
		private global::System.Windows.Forms.Label label28;

		// Token: 0x040000C8 RID: 200
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox5;

		// Token: 0x040000C9 RID: 201
		private global::System.Windows.Forms.Label label25;

		// Token: 0x040000CA RID: 202
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox5;

		// Token: 0x040000CB RID: 203
		private global::System.Windows.Forms.Label label26;

		// Token: 0x040000CC RID: 204
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox4;

		// Token: 0x040000CD RID: 205
		private global::System.Windows.Forms.Label label23;

		// Token: 0x040000CE RID: 206
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox4;

		// Token: 0x040000CF RID: 207
		private global::System.Windows.Forms.Label label24;

		// Token: 0x040000D0 RID: 208
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox3;

		// Token: 0x040000D1 RID: 209
		private global::System.Windows.Forms.Label label21;

		// Token: 0x040000D2 RID: 210
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox3;

		// Token: 0x040000D3 RID: 211
		private global::System.Windows.Forms.Label label22;

		// Token: 0x040000D4 RID: 212
		private global::System.Windows.Forms.TextBox ASIL_Max_textBox2;

		// Token: 0x040000D5 RID: 213
		private global::System.Windows.Forms.Label label20;

		// Token: 0x040000D6 RID: 214
		private global::System.Windows.Forms.TextBox ASIL_Min_textBox2;

		// Token: 0x040000D7 RID: 215
		private global::System.Windows.Forms.Label label19;

		// Token: 0x040000D8 RID: 216
		private global::System.Windows.Forms.Panel panel2;

		// Token: 0x040000DC RID: 220
		private global::System.Windows.Forms.Panel panel4;

		// Token: 0x040000E9 RID: 233
		private global::System.Windows.Forms.TextBox textBox6;

		// Token: 0x040000EA RID: 234
		private global::System.Windows.Forms.Label label43;

		// Token: 0x040000EB RID: 235
		private global::System.Windows.Forms.TextBox textBox7;

		// Token: 0x040000EC RID: 236
		private global::System.Windows.Forms.Label label44;
        private System.Windows.Forms.Button but_Modify;
        private System.Windows.Forms.Button but_Delete;
        private System.Windows.Forms.Button but_Application;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.GroupBox XML;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label48;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.Label label47;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label46;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.Label label45;
        private System.Windows.Forms.Label label41;
        private System.Windows.Forms.TextBox TYPE1;
        private System.Windows.Forms.TextBox EQP_ID_Box;
        private System.Windows.Forms.Label EQP_ID;
        private System.Windows.Forms.TextBox Operator_Box;
        private System.Windows.Forms.Label label40;
        private System.Windows.Forms.TextBox Station_ID_Box;
        private System.Windows.Forms.Label label39;
        private System.Windows.Forms.Label label38;
        private System.Windows.Forms.TextBox User_ID_Box;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBox14;
        private System.Windows.Forms.TextBox text_SampleSN;
        private System.Windows.Forms.Label label53;
        private System.Windows.Forms.Label label54;
        private System.Windows.Forms.TextBox textBox13;
        private System.Windows.Forms.TextBox text_ModelName;
        private System.Windows.Forms.Label label52;
        private System.Windows.Forms.Label label55;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label37;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox12;
        private System.Windows.Forms.Label label49;
        private System.Windows.Forms.CheckBox PIS2_checkBox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label51;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Data;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.TextBox text_CurrentRecipeName;
        private System.Windows.Forms.TextBox text_FileName;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn 配方;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox textBox22;
        private System.Windows.Forms.TextBox textBox19;
        private System.Windows.Forms.TextBox textBox16;
        private System.Windows.Forms.Label label64;
        private System.Windows.Forms.Label label61;
        private System.Windows.Forms.Label label58;
        private System.Windows.Forms.TextBox textBox24;
        private System.Windows.Forms.Label label65;
        private System.Windows.Forms.TextBox textBox23;
        private System.Windows.Forms.Label label63;
        private System.Windows.Forms.TextBox textBox20;
        private System.Windows.Forms.Label label60;
        private System.Windows.Forms.TextBox textBox17;
        private System.Windows.Forms.Label label57;
        private System.Windows.Forms.TextBox textBox21;
        private System.Windows.Forms.TextBox textBox18;
        private System.Windows.Forms.Label label62;
        private System.Windows.Forms.Label label59;
        private System.Windows.Forms.TextBox textBox15;
        private System.Windows.Forms.Label label56;
        private System.Windows.Forms.Button but_SaveParam;
        private System.Windows.Forms.TextBox textBox25;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

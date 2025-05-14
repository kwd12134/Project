namespace BL12
{
    partial class FrmConfigSelect
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.but_Application = new System.Windows.Forms.Button();
            this.but_Delete = new System.Windows.Forms.Button();
            this.but_Modify = new System.Windows.Forms.Button();
            this.but_Create = new System.Windows.Forms.Button();
            this.text_FileName = new System.Windows.Forms.TextBox();
            this.text_CurrentRecipeName = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.text_NtcModel = new System.Windows.Forms.TextBox();
            this.num_Vmin = new System.Windows.Forms.NumericUpDown();
            this.text_NtcChannel = new System.Windows.Forms.TextBox();
            this.num_Ntcmin = new System.Windows.Forms.NumericUpDown();
            this.num_Imin = new System.Windows.Forms.NumericUpDown();
            this.label15 = new System.Windows.Forms.Label();
            this.num_Vmax = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.num_Imax = new System.Windows.Forms.NumericUpDown();
            this.num_Ntcmax = new System.Windows.Forms.NumericUpDown();
            this.num_DV = new System.Windows.Forms.NumericUpDown();
            this.label13 = new System.Windows.Forms.Label();
            this.num_I = new System.Windows.Forms.NumericUpDown();
            this.label14 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.text_SHorl = new System.Windows.Forms.TextBox();
            this.text_Channel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_ChannelNum = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Vmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ntcmin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Imin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Vmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Imax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ntcmax)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_I)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // but_Application
            // 
            this.but_Application.BackColor = System.Drawing.Color.LightGray;
            this.but_Application.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Application.Location = new System.Drawing.Point(684, 390);
            this.but_Application.Margin = new System.Windows.Forms.Padding(2);
            this.but_Application.Name = "but_Application";
            this.but_Application.Size = new System.Drawing.Size(107, 62);
            this.but_Application.TabIndex = 72;
            this.but_Application.Text = "应用";
            this.but_Application.UseVisualStyleBackColor = false;
            this.but_Application.Click += new System.EventHandler(this.but_Application_Click);
            // 
            // but_Delete
            // 
            this.but_Delete.BackColor = System.Drawing.Color.LightGray;
            this.but_Delete.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Delete.Location = new System.Drawing.Point(539, 391);
            this.but_Delete.Margin = new System.Windows.Forms.Padding(2);
            this.but_Delete.Name = "but_Delete";
            this.but_Delete.Size = new System.Drawing.Size(107, 62);
            this.but_Delete.TabIndex = 73;
            this.but_Delete.Text = "删除";
            this.but_Delete.UseVisualStyleBackColor = false;
            this.but_Delete.Click += new System.EventHandler(this.but_Delete_Click);
            // 
            // but_Modify
            // 
            this.but_Modify.BackColor = System.Drawing.Color.LightGray;
            this.but_Modify.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Modify.Location = new System.Drawing.Point(684, 320);
            this.but_Modify.Margin = new System.Windows.Forms.Padding(2);
            this.but_Modify.Name = "but_Modify";
            this.but_Modify.Size = new System.Drawing.Size(107, 62);
            this.but_Modify.TabIndex = 74;
            this.but_Modify.Text = "保存";
            this.but_Modify.UseVisualStyleBackColor = false;
            this.but_Modify.Click += new System.EventHandler(this.but_Save_Click);
            // 
            // but_Create
            // 
            this.but_Create.BackColor = System.Drawing.Color.LightGray;
            this.but_Create.Font = new System.Drawing.Font("宋体", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Create.Location = new System.Drawing.Point(539, 320);
            this.but_Create.Margin = new System.Windows.Forms.Padding(2);
            this.but_Create.Name = "but_Create";
            this.but_Create.Size = new System.Drawing.Size(107, 62);
            this.but_Create.TabIndex = 75;
            this.but_Create.Text = "新建";
            this.but_Create.UseVisualStyleBackColor = false;
            this.but_Create.Click += new System.EventHandler(this.but_Create_Click);
            // 
            // text_FileName
            // 
            this.text_FileName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_FileName.Location = new System.Drawing.Point(102, 343);
            this.text_FileName.Name = "text_FileName";
            this.text_FileName.Size = new System.Drawing.Size(119, 26);
            this.text_FileName.TabIndex = 73;
            this.text_FileName.Tag = "2";
            this.text_FileName.TextChanged += new System.EventHandler(this.text_FileName_TextChanged);
            // 
            // text_CurrentRecipeName
            // 
            this.text_CurrentRecipeName.Enabled = false;
            this.text_CurrentRecipeName.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_CurrentRecipeName.Location = new System.Drawing.Point(102, 277);
            this.text_CurrentRecipeName.Name = "text_CurrentRecipeName";
            this.text_CurrentRecipeName.Size = new System.Drawing.Size(119, 26);
            this.text_CurrentRecipeName.TabIndex = 73;
            this.text_CurrentRecipeName.Tag = "1";
            this.text_CurrentRecipeName.TextChanged += new System.EventHandler(this.text_FileName_TextChanged);
            // 
            // label50
            // 
            this.label50.AutoSize = true;
            this.label50.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label50.Location = new System.Drawing.Point(6, 348);
            this.label50.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(91, 14);
            this.label50.TabIndex = 72;
            this.label50.Text = "新建型号名称";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(6, 282);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 14);
            this.label5.TabIndex = 72;
            this.label5.Text = "当前型号名称";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.Silver;
            this.panel5.Controls.Add(this.dataGridView1);
            this.panel5.Controls.Add(this.text_FileName);
            this.panel5.Controls.Add(this.text_CurrentRecipeName);
            this.panel5.Controls.Add(this.label50);
            this.panel5.Controls.Add(this.label5);
            this.panel5.Location = new System.Drawing.Point(11, 43);
            this.panel5.Margin = new System.Windows.Forms.Padding(2);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(224, 409);
            this.panel5.TabIndex = 103;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.ControlDark;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(218, 262);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.HeaderText = "产品型号";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Silver;
            this.panel1.Controls.Add(this.num_Vmin);
            this.panel1.Controls.Add(this.num_Imin);
            this.panel1.Controls.Add(this.num_Vmax);
            this.panel1.Controls.Add(this.num_Imax);
            this.panel1.Controls.Add(this.num_DV);
            this.panel1.Controls.Add(this.num_I);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.text_SHorl);
            this.panel1.Controls.Add(this.text_Channel);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.text_ChannelNum);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Location = new System.Drawing.Point(253, 46);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(265, 407);
            this.panel1.TabIndex = 104;
            // 
            // text_NtcModel
            // 
            this.text_NtcModel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_NtcModel.Location = new System.Drawing.Point(124, 64);
            this.text_NtcModel.Name = "text_NtcModel";
            this.text_NtcModel.Size = new System.Drawing.Size(112, 26);
            this.text_NtcModel.TabIndex = 12;
            // 
            // num_Vmin
            // 
            this.num_Vmin.DecimalPlaces = 1;
            this.num_Vmin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Vmin.Location = new System.Drawing.Point(123, 352);
            this.num_Vmin.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_Vmin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_Vmin.Name = "num_Vmin";
            this.num_Vmin.Size = new System.Drawing.Size(112, 26);
            this.num_Vmin.TabIndex = 82;
            // 
            // text_NtcChannel
            // 
            this.text_NtcChannel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_NtcChannel.Location = new System.Drawing.Point(124, 16);
            this.text_NtcChannel.Name = "text_NtcChannel";
            this.text_NtcChannel.Size = new System.Drawing.Size(112, 26);
            this.text_NtcChannel.TabIndex = 12;
            // 
            // num_Ntcmin
            // 
            this.num_Ntcmin.DecimalPlaces = 1;
            this.num_Ntcmin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Ntcmin.Location = new System.Drawing.Point(124, 160);
            this.num_Ntcmin.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_Ntcmin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_Ntcmin.Name = "num_Ntcmin";
            this.num_Ntcmin.Size = new System.Drawing.Size(112, 26);
            this.num_Ntcmin.TabIndex = 82;
            // 
            // num_Imin
            // 
            this.num_Imin.DecimalPlaces = 1;
            this.num_Imin.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Imin.Location = new System.Drawing.Point(123, 226);
            this.num_Imin.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_Imin.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_Imin.Name = "num_Imin";
            this.num_Imin.Size = new System.Drawing.Size(112, 26);
            this.num_Imin.TabIndex = 82;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label15.Location = new System.Drawing.Point(13, 66);
            this.label15.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(87, 16);
            this.label15.TabIndex = 79;
            this.label15.Text = "NTC_Model:";
            // 
            // num_Vmax
            // 
            this.num_Vmax.DecimalPlaces = 1;
            this.num_Vmax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Vmax.Location = new System.Drawing.Point(123, 310);
            this.num_Vmax.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_Vmax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_Vmax.Name = "num_Vmax";
            this.num_Vmax.Size = new System.Drawing.Size(112, 26);
            this.num_Vmax.TabIndex = 82;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label12.Location = new System.Drawing.Point(13, 114);
            this.label12.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(71, 16);
            this.label12.TabIndex = 81;
            this.label12.Text = "NTC max:";
            // 
            // num_Imax
            // 
            this.num_Imax.DecimalPlaces = 1;
            this.num_Imax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Imax.Location = new System.Drawing.Point(123, 184);
            this.num_Imax.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_Imax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_Imax.Name = "num_Imax";
            this.num_Imax.Size = new System.Drawing.Size(112, 26);
            this.num_Imax.TabIndex = 82;
            // 
            // num_Ntcmax
            // 
            this.num_Ntcmax.DecimalPlaces = 1;
            this.num_Ntcmax.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_Ntcmax.Location = new System.Drawing.Point(124, 112);
            this.num_Ntcmax.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_Ntcmax.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_Ntcmax.Name = "num_Ntcmax";
            this.num_Ntcmax.Size = new System.Drawing.Size(112, 26);
            this.num_Ntcmax.TabIndex = 82;
            // 
            // num_DV
            // 
            this.num_DV.DecimalPlaces = 1;
            this.num_DV.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_DV.Location = new System.Drawing.Point(123, 268);
            this.num_DV.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_DV.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_DV.Name = "num_DV";
            this.num_DV.Size = new System.Drawing.Size(112, 26);
            this.num_DV.TabIndex = 82;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label13.Location = new System.Drawing.Point(13, 162);
            this.label13.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 16);
            this.label13.TabIndex = 81;
            this.label13.Text = "NTC min:";
            // 
            // num_I
            // 
            this.num_I.DecimalPlaces = 1;
            this.num_I.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.num_I.Location = new System.Drawing.Point(123, 142);
            this.num_I.Maximum = new decimal(new int[] {
            300,
            0,
            0,
            0});
            this.num_I.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.num_I.Name = "num_I";
            this.num_I.Size = new System.Drawing.Size(112, 26);
            this.num_I.TabIndex = 82;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label14.Location = new System.Drawing.Point(13, 18);
            this.label14.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(103, 16);
            this.label14.TabIndex = 79;
            this.label14.Text = "NTC_Channel:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 354);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 16);
            this.label4.TabIndex = 81;
            this.label4.Text = "V min:";
            // 
            // text_SHorl
            // 
            this.text_SHorl.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_SHorl.Location = new System.Drawing.Point(123, 100);
            this.text_SHorl.Name = "text_SHorl";
            this.text_SHorl.Size = new System.Drawing.Size(112, 26);
            this.text_SHorl.TabIndex = 12;
            // 
            // text_Channel
            // 
            this.text_Channel.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_Channel.Location = new System.Drawing.Point(123, 58);
            this.text_Channel.Name = "text_Channel";
            this.text_Channel.Size = new System.Drawing.Size(112, 26);
            this.text_Channel.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 228);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 16);
            this.label1.TabIndex = 81;
            this.label1.Text = "I(ma) min:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(12, 312);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 16);
            this.label3.TabIndex = 81;
            this.label3.Text = "V max:";
            // 
            // text_ChannelNum
            // 
            this.text_ChannelNum.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_ChannelNum.Location = new System.Drawing.Point(123, 16);
            this.text_ChannelNum.Name = "text_ChannelNum";
            this.text_ChannelNum.Size = new System.Drawing.Size(112, 26);
            this.text_ChannelNum.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 270);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 80;
            this.label2.Text = "DV:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label11.Location = new System.Drawing.Point(12, 186);
            this.label11.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(87, 16);
            this.label11.TabIndex = 81;
            this.label11.Text = "I(ma) max:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 103);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 16);
            this.label6.TabIndex = 79;
            this.label6.Text = "SHorl:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label10.Location = new System.Drawing.Point(12, 144);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 16);
            this.label10.TabIndex = 80;
            this.label10.Text = "I(ma):";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label9.Location = new System.Drawing.Point(12, 61);
            this.label9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 16);
            this.label9.TabIndex = 79;
            this.label9.Text = "Channel:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.Location = new System.Drawing.Point(12, 19);
            this.label8.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 16);
            this.label8.TabIndex = 78;
            this.label8.Text = "ChannelNum:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(11, 11);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(798, 14);
            this.label7.TabIndex = 76;
            this.label7.Text = "注意! 新建产品型号名称必须跟实际产品名称大小写相同,型号名称修改不了,请重新新建.阻值对应温度表请手动追加到配置文件";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Silver;
            this.panel2.Controls.Add(this.text_NtcModel);
            this.panel2.Controls.Add(this.text_NtcChannel);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.num_Ntcmin);
            this.panel2.Controls.Add(this.num_Ntcmax);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(539, 46);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(252, 262);
            this.panel2.TabIndex = 105;
            // 
            // FrmConfigSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 469);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.but_Modify);
            this.Controls.Add(this.but_Application);
            this.Controls.Add(this.but_Delete);
            this.Controls.Add(this.but_Create);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmConfigSelect";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FrmTempResistance";
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.num_Vmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ntcmin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Imin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Vmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Imax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Ntcmax)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_DV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_I)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button but_Application;
        private System.Windows.Forms.Button but_Delete;
        private System.Windows.Forms.Button but_Modify;
        private System.Windows.Forms.Button but_Create;
        private System.Windows.Forms.TextBox text_FileName;
        private System.Windows.Forms.TextBox text_CurrentRecipeName;
        private System.Windows.Forms.Label label50;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox text_Channel;
        private System.Windows.Forms.TextBox text_ChannelNum;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.NumericUpDown num_I;
        private System.Windows.Forms.NumericUpDown num_Vmin;
        private System.Windows.Forms.NumericUpDown num_Imin;
        private System.Windows.Forms.NumericUpDown num_Vmax;
        private System.Windows.Forms.NumericUpDown num_Imax;
        private System.Windows.Forms.NumericUpDown num_DV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_SHorl;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown num_Ntcmax;
        private System.Windows.Forms.NumericUpDown num_Ntcmin;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox text_NtcChannel;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox text_NtcModel;
        private System.Windows.Forms.Panel panel2;
    }
}
namespace KWD.MTHproject
{
    partial class FrmVariableConfig
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEX1 = new KWDMHTUserLib.PanelEX();
            this.TopPanel = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chk_NegAlarm = new KWDMHTUserLib.CheckBoxEx();
            this.txt_varName = new System.Windows.Forms.TextBox();
            this.chk_posAlarm = new KWDMHTUserLib.CheckBoxEx();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_Modify = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.dgv_Mian = new System.Windows.Forms.DataGridView();
            this.cmb_groupName = new System.Windows.Forms.ComboBox();
            this.cmb_DataType = new System.Windows.Forms.ComboBox();
            this.num_Length = new System.Windows.Forms.NumericUpDown();
            this.num_Offset = new System.Windows.Forms.NumericUpDown();
            this.num_Scale = new System.Windows.Forms.NumericUpDown();
            this.num_Start = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_Remark = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.varName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OffsetOrLength = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DataType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Scale = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Offset = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.POSAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NegAlarm = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panelEX1.SuspendLayout();
            this.TopPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mian)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Offset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Scale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Start)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEX1
            // 
            this.panelEX1.BackColor = System.Drawing.Color.Transparent;
            this.panelEX1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(79)))), ((int)(((byte)(150)))));
            this.panelEX1.BorderWidth = 2;
            this.panelEX1.BottomGap = 2;
            this.panelEX1.Controls.Add(this.TopPanel);
            this.panelEX1.Controls.Add(this.chk_NegAlarm);
            this.panelEX1.Controls.Add(this.txt_varName);
            this.panelEX1.Controls.Add(this.chk_posAlarm);
            this.panelEX1.Controls.Add(this.btn_delete);
            this.panelEX1.Controls.Add(this.btn_Modify);
            this.panelEX1.Controls.Add(this.btn_Add);
            this.panelEX1.Controls.Add(this.dgv_Mian);
            this.panelEX1.Controls.Add(this.cmb_groupName);
            this.panelEX1.Controls.Add(this.cmb_DataType);
            this.panelEX1.Controls.Add(this.num_Length);
            this.panelEX1.Controls.Add(this.num_Offset);
            this.panelEX1.Controls.Add(this.num_Scale);
            this.panelEX1.Controls.Add(this.num_Start);
            this.panelEX1.Controls.Add(this.label4);
            this.panelEX1.Controls.Add(this.label9);
            this.panelEX1.Controls.Add(this.label8);
            this.panelEX1.Controls.Add(this.label3);
            this.panelEX1.Controls.Add(this.label7);
            this.panelEX1.Controls.Add(this.label5);
            this.panelEX1.Controls.Add(this.label6);
            this.panelEX1.Controls.Add(this.txt_Remark);
            this.panelEX1.Controls.Add(this.label1);
            this.panelEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEX1.LeftGap = 2;
            this.panelEX1.Location = new System.Drawing.Point(0, 0);
            this.panelEX1.Name = "panelEX1";
            this.panelEX1.RightGap = 2;
            this.panelEX1.Size = new System.Drawing.Size(1086, 650);
            this.panelEX1.TabIndex = 0;
            this.panelEX1.TopGap = 2;
            this.panelEX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelEX_MouseDown);
            this.panelEX1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEX_MouseMove);
            // 
            // TopPanel
            // 
            this.TopPanel.Controls.Add(this.button3);
            this.TopPanel.Controls.Add(this.label2);
            this.TopPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.TopPanel.Location = new System.Drawing.Point(0, 0);
            this.TopPanel.Name = "TopPanel";
            this.TopPanel.Size = new System.Drawing.Size(1086, 73);
            this.TopPanel.TabIndex = 12;
            this.TopPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panelEX_MouseDown);
            this.TopPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panelEX_MouseMove);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.FlatAppearance.BorderSize = 0;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(29)))), ((int)(((byte)(84)))));
            this.button3.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("微软雅黑", 11.8F);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1010, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(55, 41);
            this.button3.TabIndex = 5;
            this.button3.Text = "X";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(26, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(109, 34);
            this.label2.TabIndex = 2;
            this.label2.Text = "变量配置";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chk_NegAlarm
            // 
            this.chk_NegAlarm.CheckBackColor = System.Drawing.Color.White;
            this.chk_NegAlarm.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_NegAlarm.DefaultChackBoxWidth = 20;
            this.chk_NegAlarm.ForeColor = System.Drawing.Color.White;
            this.chk_NegAlarm.Location = new System.Drawing.Point(444, 157);
            this.chk_NegAlarm.Name = "chk_NegAlarm";
            this.chk_NegAlarm.Size = new System.Drawing.Size(133, 43);
            this.chk_NegAlarm.TabIndex = 11;
            this.chk_NegAlarm.Text = "下降沿报警";
            this.chk_NegAlarm.UseVisualStyleBackColor = true;
            // 
            // txt_varName
            // 
            this.txt_varName.Location = new System.Drawing.Point(406, 92);
            this.txt_varName.Name = "txt_varName";
            this.txt_varName.Size = new System.Drawing.Size(124, 31);
            this.txt_varName.TabIndex = 3;
            this.txt_varName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chk_posAlarm
            // 
            this.chk_posAlarm.CheckBackColor = System.Drawing.Color.White;
            this.chk_posAlarm.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_posAlarm.DefaultChackBoxWidth = 20;
            this.chk_posAlarm.ForeColor = System.Drawing.Color.White;
            this.chk_posAlarm.Location = new System.Drawing.Point(296, 157);
            this.chk_posAlarm.Name = "chk_posAlarm";
            this.chk_posAlarm.Size = new System.Drawing.Size(133, 43);
            this.chk_posAlarm.TabIndex = 11;
            this.chk_posAlarm.Text = "上升沿报警";
            this.chk_posAlarm.UseVisualStyleBackColor = true;
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(885, 225);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(111, 38);
            this.btn_delete.TabIndex = 10;
            this.btn_delete.Text = "删除变量";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_Modify
            // 
            this.btn_Modify.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Modify.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modify.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Modify.ForeColor = System.Drawing.Color.White;
            this.btn_Modify.Location = new System.Drawing.Point(715, 227);
            this.btn_Modify.Name = "btn_Modify";
            this.btn_Modify.Size = new System.Drawing.Size(111, 38);
            this.btn_Modify.TabIndex = 10;
            this.btn_Modify.Text = "修改变量";
            this.btn_Modify.UseVisualStyleBackColor = false;
            this.btn_Modify.Click += new System.EventHandler(this.btn_Modify_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(559, 227);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(111, 38);
            this.btn_Add.TabIndex = 10;
            this.btn_Add.Text = "新增变量";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // dgv_Mian
            // 
            this.dgv_Mian.AllowUserToAddRows = false;
            this.dgv_Mian.AllowUserToDeleteRows = false;
            this.dgv_Mian.AllowUserToResizeColumns = false;
            this.dgv_Mian.AllowUserToResizeRows = false;
            this.dgv_Mian.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            this.dgv_Mian.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Mian.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mian.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Mian.ColumnHeadersHeight = 45;
            this.dgv_Mian.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.varName,
            this.Start,
            this.OffsetOrLength,
            this.DataType,
            this.Scale,
            this.Offset,
            this.POSAlarm,
            this.NegAlarm,
            this.groupName,
            this.Remark});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Mian.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Mian.EnableHeadersVisualStyles = false;
            this.dgv_Mian.Location = new System.Drawing.Point(12, 298);
            this.dgv_Mian.Name = "dgv_Mian";
            this.dgv_Mian.ReadOnly = true;
            this.dgv_Mian.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mian.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_Mian.RowHeadersWidth = 51;
            this.dgv_Mian.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Mian.RowTemplate.Height = 32;
            this.dgv_Mian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Mian.Size = new System.Drawing.Size(1062, 340);
            this.dgv_Mian.TabIndex = 9;
            this.dgv_Mian.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Mian_CellClick);
            this.dgv_Mian.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Mian_CellContentClick);
            this.dgv_Mian.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_Mian_CellFormatting);
            this.dgv_Mian.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dgv_Mian_RowPostPaint);
            // 
            // cmb_groupName
            // 
            this.cmb_groupName.BackColor = System.Drawing.SystemColors.Window;
            this.cmb_groupName.FormattingEnabled = true;
            this.cmb_groupName.Location = new System.Drawing.Point(159, 90);
            this.cmb_groupName.Name = "cmb_groupName";
            this.cmb_groupName.Size = new System.Drawing.Size(121, 32);
            this.cmb_groupName.TabIndex = 8;
            this.cmb_groupName.UseWaitCursor = true;
            // 
            // cmb_DataType
            // 
            this.cmb_DataType.FormattingEnabled = true;
            this.cmb_DataType.Location = new System.Drawing.Point(154, 162);
            this.cmb_DataType.Name = "cmb_DataType";
            this.cmb_DataType.Size = new System.Drawing.Size(121, 32);
            this.cmb_DataType.TabIndex = 8;
            // 
            // num_Length
            // 
            this.num_Length.Location = new System.Drawing.Point(901, 95);
            this.num_Length.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.num_Length.Name = "num_Length";
            this.num_Length.Size = new System.Drawing.Size(96, 31);
            this.num_Length.TabIndex = 7;
            this.num_Length.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // num_Offset
            // 
            this.num_Offset.DecimalPlaces = 1;
            this.num_Offset.Location = new System.Drawing.Point(906, 168);
            this.num_Offset.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_Offset.Name = "num_Offset";
            this.num_Offset.Size = new System.Drawing.Size(91, 31);
            this.num_Offset.TabIndex = 7;
            this.num_Offset.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // num_Scale
            // 
            this.num_Scale.DecimalPlaces = 1;
            this.num_Scale.Location = new System.Drawing.Point(684, 165);
            this.num_Scale.Name = "num_Scale";
            this.num_Scale.Size = new System.Drawing.Size(91, 31);
            this.num_Scale.TabIndex = 7;
            this.num_Scale.Value = new decimal(new int[] {
            10,
            0,
            0,
            65536});
            // 
            // num_Start
            // 
            this.num_Start.Location = new System.Drawing.Point(654, 95);
            this.num_Start.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.num_Start.Name = "num_Start";
            this.num_Start.Size = new System.Drawing.Size(95, 31);
            this.num_Start.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(786, 92);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(109, 34);
            this.label4.TabIndex = 6;
            this.label4.Text = "位偏移/长度";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(801, 165);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(109, 34);
            this.label9.TabIndex = 6;
            this.label9.Text = "偏移量";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(579, 162);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 34);
            this.label8.TabIndex = 6;
            this.label8.Text = "线行系数";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(548, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 34);
            this.label3.TabIndex = 6;
            this.label3.Text = "起始索引";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(291, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(109, 34);
            this.label7.TabIndex = 6;
            this.label7.Text = "变量名称";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(44, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(109, 34);
            this.label5.TabIndex = 6;
            this.label5.Text = "数据名称";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(44, 229);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(109, 34);
            this.label6.TabIndex = 6;
            this.label6.Text = "备注";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txt_Remark
            // 
            this.txt_Remark.Location = new System.Drawing.Point(154, 232);
            this.txt_Remark.Name = "txt_Remark";
            this.txt_Remark.Size = new System.Drawing.Size(369, 31);
            this.txt_Remark.TabIndex = 3;
            this.txt_Remark.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(44, 88);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 34);
            this.label1.TabIndex = 6;
            this.label1.Text = "通信组名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // varName
            // 
            this.varName.DataPropertyName = "VarName";
            this.varName.HeaderText = "变量名称";
            this.varName.MinimumWidth = 6;
            this.varName.Name = "varName";
            this.varName.ReadOnly = true;
            this.varName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.varName.Width = 110;
            // 
            // Start
            // 
            this.Start.DataPropertyName = "Start";
            this.Start.HeaderText = "起始索引";
            this.Start.MinimumWidth = 6;
            this.Start.Name = "Start";
            this.Start.ReadOnly = true;
            this.Start.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Start.Width = 110;
            // 
            // OffsetOrLength
            // 
            this.OffsetOrLength.DataPropertyName = "OffsetOrLength";
            this.OffsetOrLength.HeaderText = "长度或位偏移";
            this.OffsetOrLength.MinimumWidth = 6;
            this.OffsetOrLength.Name = "OffsetOrLength";
            this.OffsetOrLength.ReadOnly = true;
            this.OffsetOrLength.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.OffsetOrLength.Width = 125;
            // 
            // DataType
            // 
            this.DataType.DataPropertyName = "DataType";
            this.DataType.HeaderText = "数据类型";
            this.DataType.MinimumWidth = 6;
            this.DataType.Name = "DataType";
            this.DataType.ReadOnly = true;
            this.DataType.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.DataType.Width = 125;
            // 
            // Scale
            // 
            this.Scale.DataPropertyName = "Scale";
            this.Scale.HeaderText = "线性系数";
            this.Scale.MinimumWidth = 6;
            this.Scale.Name = "Scale";
            this.Scale.ReadOnly = true;
            this.Scale.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Scale.Width = 90;
            // 
            // Offset
            // 
            this.Offset.DataPropertyName = "Offset";
            this.Offset.HeaderText = "偏移量";
            this.Offset.MinimumWidth = 6;
            this.Offset.Name = "Offset";
            this.Offset.ReadOnly = true;
            this.Offset.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.Offset.Width = 80;
            // 
            // POSAlarm
            // 
            this.POSAlarm.DataPropertyName = "PosAlarm";
            this.POSAlarm.HeaderText = "上升沿";
            this.POSAlarm.MinimumWidth = 6;
            this.POSAlarm.Name = "POSAlarm";
            this.POSAlarm.ReadOnly = true;
            this.POSAlarm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.POSAlarm.Width = 80;
            // 
            // NegAlarm
            // 
            this.NegAlarm.DataPropertyName = "NegAlarm";
            this.NegAlarm.HeaderText = "下降沿";
            this.NegAlarm.MinimumWidth = 6;
            this.NegAlarm.Name = "NegAlarm";
            this.NegAlarm.ReadOnly = true;
            this.NegAlarm.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.NegAlarm.Width = 80;
            // 
            // groupName
            // 
            this.groupName.DataPropertyName = "groupName";
            this.groupName.HeaderText = "通信组";
            this.groupName.MinimumWidth = 6;
            this.groupName.Name = "groupName";
            this.groupName.ReadOnly = true;
            this.groupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.groupName.Width = 80;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "备注说明";
            this.Remark.MinimumWidth = 6;
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // FrmVariableConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KWD.MTHproject.Properties.Resources.BackGround;
            this.ClientSize = new System.Drawing.Size(1086, 650);
            this.Controls.Add(this.panelEX1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmVariableConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmGroupConfig";
            this.panelEX1.ResumeLayout(false);
            this.panelEX1.PerformLayout();
            this.TopPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mian)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Length)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Offset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Scale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.num_Start)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txt_varName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_Remark;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown num_Start;
        private System.Windows.Forms.NumericUpDown num_Scale;
        private System.Windows.Forms.NumericUpDown num_Offset;
        private System.Windows.Forms.NumericUpDown num_Length;
        private System.Windows.Forms.ComboBox cmb_DataType;
        private System.Windows.Forms.ComboBox cmb_groupName;
        private System.Windows.Forms.DataGridView dgv_Mian;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Modify;
        private System.Windows.Forms.Button btn_delete;
        private KWDMHTUserLib.CheckBoxEx chk_posAlarm;
        private KWDMHTUserLib.CheckBoxEx chk_NegAlarm;
        private System.Windows.Forms.Panel TopPanel;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private KWDMHTUserLib.PanelEX panelEX1;
        private System.Windows.Forms.DataGridViewTextBoxColumn varName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn OffsetOrLength;
        private System.Windows.Forms.DataGridViewTextBoxColumn DataType;
        private new System.Windows.Forms.DataGridViewTextBoxColumn Scale;
        private System.Windows.Forms.DataGridViewTextBoxColumn Offset;
        private System.Windows.Forms.DataGridViewTextBoxColumn POSAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn NegAlarm;
        private System.Windows.Forms.DataGridViewTextBoxColumn groupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
    }
}
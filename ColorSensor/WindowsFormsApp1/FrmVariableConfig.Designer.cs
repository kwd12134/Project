namespace WindowsFormsApp1
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
            this.label1 = new System.Windows.Forms.Label();
            this.text_DeviceName = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.DeviceName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IRMIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IRMAX = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(53, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "机种名称:";
            // 
            // text_DeviceName
            // 
            this.text_DeviceName.Location = new System.Drawing.Point(140, 33);
            this.text_DeviceName.Margin = new System.Windows.Forms.Padding(4);
            this.text_DeviceName.Name = "text_DeviceName";
            this.text_DeviceName.Size = new System.Drawing.Size(173, 26);
            this.text_DeviceName.TabIndex = 1;
            this.text_DeviceName.Text = "Device";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 27);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 34);
            this.button1.TabIndex = 2;
            this.button1.Text = "新增设备配置";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(691, 27);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 34);
            this.button2.TabIndex = 2;
            this.button2.Text = "删除设备配置";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(522, 27);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(120, 34);
            this.button3.TabIndex = 2;
            this.button3.Text = "修改设备配置";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(80, 93);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "RMIN:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(135, 90);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(118, 26);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(80, 151);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "RMAX:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(135, 148);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(118, 26);
            this.textBox2.TabIndex = 1;
            this.textBox2.Text = "1000";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(266, 93);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 16);
            this.label4.TabIndex = 0;
            this.label4.Text = "GMIN:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(321, 90);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(118, 26);
            this.textBox3.TabIndex = 1;
            this.textBox3.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(266, 151);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(47, 16);
            this.label5.TabIndex = 0;
            this.label5.Text = "GMAX:";
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(321, 148);
            this.textBox4.Margin = new System.Windows.Forms.Padding(4);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(118, 26);
            this.textBox4.TabIndex = 1;
            this.textBox4.Text = "1000";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(452, 96);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(47, 16);
            this.label6.TabIndex = 0;
            this.label6.Text = "BMIN:";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(507, 93);
            this.textBox5.Margin = new System.Windows.Forms.Padding(4);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(118, 26);
            this.textBox5.TabIndex = 1;
            this.textBox5.Text = "0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(638, 96);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 16);
            this.label7.TabIndex = 0;
            this.label7.Text = "IRMIN:";
            // 
            // textBox7
            // 
            this.textBox7.Location = new System.Drawing.Point(693, 93);
            this.textBox7.Margin = new System.Windows.Forms.Padding(4);
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(118, 26);
            this.textBox7.TabIndex = 1;
            this.textBox7.Text = "0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(452, 154);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 16);
            this.label8.TabIndex = 0;
            this.label8.Text = "BMAX:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(638, 154);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(55, 16);
            this.label9.TabIndex = 0;
            this.label9.Text = "IRMAX:";
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(507, 151);
            this.textBox6.Margin = new System.Windows.Forms.Padding(4);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(118, 26);
            this.textBox6.TabIndex = 1;
            this.textBox6.Text = "1000";
            // 
            // textBox8
            // 
            this.textBox8.Location = new System.Drawing.Point(693, 151);
            this.textBox8.Margin = new System.Windows.Forms.Padding(4);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(118, 26);
            this.textBox8.TabIndex = 1;
            this.textBox8.Text = "1000";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DeviceName,
            this.RMIN,
            this.RMAX,
            this.GMIN,
            this.GMAX,
            this.BMIN,
            this.BMAX,
            this.IRMIN,
            this.IRMAX});
            this.dataGridView1.Location = new System.Drawing.Point(12, 207);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(858, 291);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            this.dataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.dataGridView1_RowPostPaint);
            // 
            // DeviceName
            // 
            this.DeviceName.DataPropertyName = "DeviceName";
            this.DeviceName.HeaderText = "设备名称";
            this.DeviceName.Name = "DeviceName";
            this.DeviceName.ReadOnly = true;
            this.DeviceName.Width = 115;
            // 
            // RMIN
            // 
            this.RMIN.DataPropertyName = "RMIN";
            this.RMIN.HeaderText = "RMIM";
            this.RMIN.Name = "RMIN";
            this.RMIN.ReadOnly = true;
            this.RMIN.Width = 90;
            // 
            // RMAX
            // 
            this.RMAX.DataPropertyName = "RMAX";
            this.RMAX.HeaderText = "RMAX";
            this.RMAX.Name = "RMAX";
            this.RMAX.ReadOnly = true;
            this.RMAX.Width = 90;
            // 
            // GMIN
            // 
            this.GMIN.DataPropertyName = "GMIN";
            this.GMIN.HeaderText = "GMIN";
            this.GMIN.Name = "GMIN";
            this.GMIN.ReadOnly = true;
            this.GMIN.Width = 90;
            // 
            // GMAX
            // 
            this.GMAX.DataPropertyName = "GMAX";
            this.GMAX.HeaderText = "GMAX";
            this.GMAX.Name = "GMAX";
            this.GMAX.ReadOnly = true;
            this.GMAX.Width = 90;
            // 
            // BMIN
            // 
            this.BMIN.DataPropertyName = "BMIN";
            this.BMIN.HeaderText = "BMIN";
            this.BMIN.Name = "BMIN";
            this.BMIN.ReadOnly = true;
            this.BMIN.Width = 90;
            // 
            // BMAX
            // 
            this.BMAX.DataPropertyName = "BMAX";
            this.BMAX.HeaderText = "BMAX";
            this.BMAX.Name = "BMAX";
            this.BMAX.ReadOnly = true;
            this.BMAX.Width = 90;
            // 
            // IRMIN
            // 
            this.IRMIN.DataPropertyName = "IRMIN";
            this.IRMIN.HeaderText = "IRMIN";
            this.IRMIN.Name = "IRMIN";
            this.IRMIN.ReadOnly = true;
            this.IRMIN.Width = 90;
            // 
            // IRMAX
            // 
            this.IRMAX.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.IRMAX.DataPropertyName = "IRMAX";
            this.IRMAX.HeaderText = "IRMAX";
            this.IRMAX.Name = "IRMAX";
            this.IRMAX.ReadOnly = true;
            // 
            // FrmVariableConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(886, 522);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.text_DeviceName);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmVariableConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmVariableConfig";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox text_DeviceName;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn DeviceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn RMAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn GMAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn BMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn BMAX;
        private System.Windows.Forms.DataGridViewTextBoxColumn IRMIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn IRMAX;
    }
}
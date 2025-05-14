namespace Danikor
{
    partial class FrmHistory
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            this.uiIntegerUpDown1 = new Sunny.UI.UIIntegerUpDown();
            this.uiLabel3 = new Sunny.UI.UILabel();
            this.uiButton_Sender = new Sunny.UI.UIButton();
            this.uiDataGridView1 = new Sunny.UI.UIDataGridView();
            this.时间 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.模式 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.扭矩 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.角度 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.时长 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.拧紧结果状态 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.错误码ID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.错误码信息 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.uiLabel5 = new Sunny.UI.UILabel();
            this.uiButton_output = new Sunny.UI.UIButton();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.deviceHistoryDataBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceHistoryDataBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // uiIntegerUpDown1
            // 
            this.uiIntegerUpDown1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiIntegerUpDown1.Location = new System.Drawing.Point(102, 60);
            this.uiIntegerUpDown1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiIntegerUpDown1.MinimumSize = new System.Drawing.Size(100, 0);
            this.uiIntegerUpDown1.Name = "uiIntegerUpDown1";
            this.uiIntegerUpDown1.ShowText = false;
            this.uiIntegerUpDown1.Size = new System.Drawing.Size(118, 29);
            this.uiIntegerUpDown1.TabIndex = 17;
            this.uiIntegerUpDown1.Text = "uiIntegerUpDown1";
            this.uiIntegerUpDown1.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiIntegerUpDown1.Value = 1;
            // 
            // uiLabel3
            // 
            this.uiLabel3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel3.Location = new System.Drawing.Point(15, 60);
            this.uiLabel3.Name = "uiLabel3";
            this.uiLabel3.Size = new System.Drawing.Size(90, 29);
            this.uiLabel3.TabIndex = 16;
            this.uiLabel3.Text = "读取数量:";
            this.uiLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton_Sender
            // 
            this.uiButton_Sender.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_Sender.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Sender.Location = new System.Drawing.Point(238, 60);
            this.uiButton_Sender.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_Sender.Name = "uiButton_Sender";
            this.uiButton_Sender.Size = new System.Drawing.Size(102, 29);
            this.uiButton_Sender.TabIndex = 15;
            this.uiButton_Sender.Text = "历史数据读取";
            this.uiButton_Sender.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_Sender.Click += new System.EventHandler(this.uiButton_Sender_Click_1);
            // 
            // uiDataGridView1
            // 
            this.uiDataGridView1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.uiDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.uiDataGridView1.ColumnHeadersHeight = 32;
            this.uiDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.uiDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.时间,
            this.模式,
            this.扭矩,
            this.角度,
            this.时长,
            this.拧紧结果状态,
            this.错误码ID,
            this.错误码信息});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            this.uiDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.uiDataGridView1.EnableHeadersVisualStyles = false;
            this.uiDataGridView1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(104)))), ((int)(((byte)(173)))), ((int)(((byte)(255)))));
            this.uiDataGridView1.ImeMode = System.Windows.Forms.ImeMode.Close;
            this.uiDataGridView1.Location = new System.Drawing.Point(16, 129);
            this.uiDataGridView1.Name = "uiDataGridView1";
            this.uiDataGridView1.ReadOnly = true;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(249)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(160)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(236)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            this.uiDataGridView1.RowTemplate.Height = 23;
            this.uiDataGridView1.SelectedIndex = -1;
            this.uiDataGridView1.Size = new System.Drawing.Size(1170, 442);
            this.uiDataGridView1.TabIndex = 18;
            this.uiDataGridView1.RowPostPaint += new System.Windows.Forms.DataGridViewRowPostPaintEventHandler(this.uiDataGridView1_RowPostPaint);
            // 
            // 时间
            // 
            this.时间.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.时间.DataPropertyName = "时间";
            this.时间.HeaderText = "时间";
            this.时间.Name = "时间";
            this.时间.ReadOnly = true;
            // 
            // 模式
            // 
            this.模式.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.模式.DataPropertyName = "模式";
            this.模式.HeaderText = "模式";
            this.模式.Name = "模式";
            this.模式.ReadOnly = true;
            // 
            // 扭矩
            // 
            this.扭矩.DataPropertyName = "扭矩";
            this.扭矩.HeaderText = "扭矩";
            this.扭矩.Name = "扭矩";
            this.扭矩.ReadOnly = true;
            // 
            // 角度
            // 
            this.角度.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.角度.DataPropertyName = "角度";
            this.角度.HeaderText = "角度";
            this.角度.Name = "角度";
            this.角度.ReadOnly = true;
            // 
            // 时长
            // 
            this.时长.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.时长.DataPropertyName = "时长";
            this.时长.HeaderText = "时长";
            this.时长.Name = "时长";
            this.时长.ReadOnly = true;
            // 
            // 拧紧结果状态
            // 
            this.拧紧结果状态.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.拧紧结果状态.DataPropertyName = "拧紧结果状态";
            this.拧紧结果状态.HeaderText = "拧紧结果状态";
            this.拧紧结果状态.Name = "拧紧结果状态";
            this.拧紧结果状态.ReadOnly = true;
            // 
            // 错误码ID
            // 
            this.错误码ID.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.错误码ID.DataPropertyName = "错误码ID";
            this.错误码ID.HeaderText = "错误码ID";
            this.错误码ID.Name = "错误码ID";
            this.错误码ID.ReadOnly = true;
            // 
            // 错误码信息
            // 
            this.错误码信息.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.错误码信息.DataPropertyName = "错误码信息";
            this.错误码信息.HeaderText = "错误码信息";
            this.错误码信息.Name = "错误码信息";
            this.错误码信息.ReadOnly = true;
            // 
            // uiLabel5
            // 
            this.uiLabel5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel5.Location = new System.Drawing.Point(15, 103);
            this.uiLabel5.Name = "uiLabel5";
            this.uiLabel5.Size = new System.Drawing.Size(133, 23);
            this.uiLabel5.TabIndex = 19;
            this.uiLabel5.Text = "历史数据记录";
            this.uiLabel5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // uiButton_output
            // 
            this.uiButton_output.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton_output.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_output.Location = new System.Drawing.Point(1084, 60);
            this.uiButton_output.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton_output.Name = "uiButton_output";
            this.uiButton_output.Size = new System.Drawing.Size(102, 29);
            this.uiButton_output.TabIndex = 20;
            this.uiButton_output.Text = "导出为Excel";
            this.uiButton_output.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton_output.Click += new System.EventHandler(this.uiButton_output_Click);
            // 
            // deviceHistoryDataBindingSource
            // 
            this.deviceHistoryDataBindingSource.DataSource = typeof(Data.DeviceHistoryData);
            // 
            // FrmHistory
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1213, 594);
            this.Controls.Add(this.uiButton_output);
            this.Controls.Add(this.uiLabel5);
            this.Controls.Add(this.uiDataGridView1);
            this.Controls.Add(this.uiIntegerUpDown1);
            this.Controls.Add(this.uiLabel3);
            this.Controls.Add(this.uiButton_Sender);
            this.Name = "FrmHistory";
            this.Text = "FrmHistory";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            ((System.ComponentModel.ISupportInitialize)(this.uiDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deviceHistoryDataBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIIntegerUpDown uiIntegerUpDown1;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UIButton uiButton_Sender;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UILabel uiLabel5;
        private System.Windows.Forms.BindingSource deviceHistoryDataBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时间;
        private System.Windows.Forms.DataGridViewTextBoxColumn 模式;
        private System.Windows.Forms.DataGridViewTextBoxColumn 扭矩;
        private System.Windows.Forms.DataGridViewTextBoxColumn 角度;
        private System.Windows.Forms.DataGridViewTextBoxColumn 时长;
        private System.Windows.Forms.DataGridViewTextBoxColumn 拧紧结果状态;
        private System.Windows.Forms.DataGridViewTextBoxColumn 错误码ID;
        private System.Windows.Forms.DataGridViewTextBoxColumn 错误码信息;
        private Sunny.UI.UIButton uiButton_output;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
    }
}
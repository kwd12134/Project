namespace KWD.MTHproject
{
    partial class FrmRecipe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.MianpanelEX = new KWDMHTUserLib.PanelEX();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgv_Mian = new System.Windows.Forms.DataGridView();
            this.GroupName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_CurrentRecipe = new System.Windows.Forms.Label();
            this.text_RecipeName = new System.Windows.Forms.TextBox();
            this.btn_Addrecipe = new System.Windows.Forms.Button();
            this.btn_Modifyrecipe = new System.Windows.Forms.Button();
            this.btn_Deleterecipe = new System.Windows.Forms.Button();
            this.btn_Userecipe = new System.Windows.Forms.Button();
            this.MianpanelEX.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mian)).BeginInit();
            this.SuspendLayout();
            // 
            // MianpanelEX
            // 
            this.MianpanelEX.BackgroundImage = global::KWD.MTHproject.Properties.Resources.BackGround;
            this.MianpanelEX.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.MianpanelEX.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(28)))), ((int)(((byte)(59)))));
            this.MianpanelEX.BorderWidth = 2;
            this.MianpanelEX.BottomGap = 1;
            this.MianpanelEX.Controls.Add(this.splitContainer1);
            this.MianpanelEX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MianpanelEX.LeftGap = 1;
            this.MianpanelEX.Location = new System.Drawing.Point(0, 0);
            this.MianpanelEX.Name = "MianpanelEX";
            this.MianpanelEX.RightGap = 1;
            this.MianpanelEX.Size = new System.Drawing.Size(1393, 609);
            this.MianpanelEX.TabIndex = 0;
            this.MianpanelEX.TopGap = 1;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BackColor = System.Drawing.Color.Transparent;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.ForeColor = System.Drawing.Color.White;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.btn_Userecipe);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Modifyrecipe);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Deleterecipe);
            this.splitContainer1.Panel1.Controls.Add(this.btn_Addrecipe);
            this.splitContainer1.Panel1.Controls.Add(this.text_RecipeName);
            this.splitContainer1.Panel1.Controls.Add(this.label2);
            this.splitContainer1.Panel1.Controls.Add(this.lbl_CurrentRecipe);
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.dgv_Mian);
            this.splitContainer1.Size = new System.Drawing.Size(1393, 609);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.SplitterWidth = 1;
            this.splitContainer1.TabIndex = 0;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(30)))), ((int)(((byte)(78)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mian.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Mian.ColumnHeadersHeight = 30;
            this.dgv_Mian.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.GroupName,
            this.Remark});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Mian.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Mian.EnableHeadersVisualStyles = false;
            this.dgv_Mian.Location = new System.Drawing.Point(26, 12);
            this.dgv_Mian.Name = "dgv_Mian";
            this.dgv_Mian.ReadOnly = true;
            this.dgv_Mian.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(40)))), ((int)(((byte)(86)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Mian.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Mian.RowHeadersVisible = false;
            this.dgv_Mian.RowHeadersWidth = 51;
            this.dgv_Mian.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_Mian.RowTemplate.Height = 32;
            this.dgv_Mian.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Mian.Size = new System.Drawing.Size(244, 356);
            this.dgv_Mian.TabIndex = 10;
            // 
            // GroupName
            // 
            this.GroupName.DataPropertyName = "GroupName";
            this.GroupName.HeaderText = "序号";
            this.GroupName.MinimumWidth = 6;
            this.GroupName.Name = "GroupName";
            this.GroupName.ReadOnly = true;
            this.GroupName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            this.GroupName.Width = 125;
            // 
            // Remark
            // 
            this.Remark.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "配方名称";
            this.Remark.MinimumWidth = 6;
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            this.Remark.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 390);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 24);
            this.label1.TabIndex = 11;
            this.label1.Text = "当前配方:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 450);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 24);
            this.label2.TabIndex = 11;
            this.label2.Text = "配方名称:";
            // 
            // lbl_CurrentRecipe
            // 
            this.lbl_CurrentRecipe.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lbl_CurrentRecipe.Location = new System.Drawing.Point(132, 383);
            this.lbl_CurrentRecipe.Name = "lbl_CurrentRecipe";
            this.lbl_CurrentRecipe.Size = new System.Drawing.Size(125, 38);
            this.lbl_CurrentRecipe.TabIndex = 11;
            this.lbl_CurrentRecipe.Text = "1234";
            this.lbl_CurrentRecipe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // text_RecipeName
            // 
            this.text_RecipeName.Location = new System.Drawing.Point(132, 447);
            this.text_RecipeName.Name = "text_RecipeName";
            this.text_RecipeName.Size = new System.Drawing.Size(125, 31);
            this.text_RecipeName.TabIndex = 12;
            // 
            // btn_Addrecipe
            // 
            this.btn_Addrecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Addrecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Addrecipe.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Addrecipe.ForeColor = System.Drawing.Color.White;
            this.btn_Addrecipe.Location = new System.Drawing.Point(29, 495);
            this.btn_Addrecipe.Name = "btn_Addrecipe";
            this.btn_Addrecipe.Size = new System.Drawing.Size(99, 38);
            this.btn_Addrecipe.TabIndex = 13;
            this.btn_Addrecipe.Text = "添加配方";
            this.btn_Addrecipe.UseVisualStyleBackColor = false;
            // 
            // btn_Modifyrecipe
            // 
            this.btn_Modifyrecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Modifyrecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Modifyrecipe.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Modifyrecipe.ForeColor = System.Drawing.Color.White;
            this.btn_Modifyrecipe.Location = new System.Drawing.Point(160, 495);
            this.btn_Modifyrecipe.Name = "btn_Modifyrecipe";
            this.btn_Modifyrecipe.Size = new System.Drawing.Size(97, 38);
            this.btn_Modifyrecipe.TabIndex = 13;
            this.btn_Modifyrecipe.Text = "修改配方";
            this.btn_Modifyrecipe.UseVisualStyleBackColor = false;
            // 
            // btn_Deleterecipe
            // 
            this.btn_Deleterecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Deleterecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Deleterecipe.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Deleterecipe.ForeColor = System.Drawing.Color.White;
            this.btn_Deleterecipe.Location = new System.Drawing.Point(29, 554);
            this.btn_Deleterecipe.Name = "btn_Deleterecipe";
            this.btn_Deleterecipe.Size = new System.Drawing.Size(99, 38);
            this.btn_Deleterecipe.TabIndex = 13;
            this.btn_Deleterecipe.Text = "删除配方";
            this.btn_Deleterecipe.UseVisualStyleBackColor = false;
            // 
            // btn_Userecipe
            // 
            this.btn_Userecipe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Userecipe.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Userecipe.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Userecipe.ForeColor = System.Drawing.Color.White;
            this.btn_Userecipe.Location = new System.Drawing.Point(160, 554);
            this.btn_Userecipe.Name = "btn_Userecipe";
            this.btn_Userecipe.Size = new System.Drawing.Size(97, 38);
            this.btn_Userecipe.TabIndex = 13;
            this.btn_Userecipe.Text = "应用配方";
            this.btn_Userecipe.UseVisualStyleBackColor = false;
            // 
            // FrmRecipe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KWD.MTHproject.Properties.Resources.BackGround;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1393, 609);
            this.Controls.Add(this.MianpanelEX);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmRecipe";
            this.Text = "配方管理";
            this.MianpanelEX.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Mian)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private KWDMHTUserLib.PanelEX MianpanelEX;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dgv_Mian;
        private System.Windows.Forms.DataGridViewTextBoxColumn GroupName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.TextBox text_RecipeName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_CurrentRecipe;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_Userecipe;
        private System.Windows.Forms.Button btn_Modifyrecipe;
        private System.Windows.Forms.Button btn_Deleterecipe;
        private System.Windows.Forms.Button btn_Addrecipe;
    }
}
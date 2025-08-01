namespace KWD.MTHproject
{
    partial class FrmModify
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
            this.panelEX1 = new KWDMHTUserLib.PanelEX();
            this.txt_SetValue = new System.Windows.Forms.TextBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_suer = new System.Windows.Forms.Button();
            this.lbl_close = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_CurrentValue = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_VarName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbl_title = new System.Windows.Forms.Label();
            this.panelEX1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelEX1
            // 
            this.panelEX1.BackColor = System.Drawing.Color.Transparent;
            this.panelEX1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(68)))), ((int)(((byte)(150)))));
            this.panelEX1.BorderWidth = 2;
            this.panelEX1.BottomGap = 1;
            this.panelEX1.Controls.Add(this.txt_SetValue);
            this.panelEX1.Controls.Add(this.btn_cancel);
            this.panelEX1.Controls.Add(this.btn_suer);
            this.panelEX1.Controls.Add(this.lbl_close);
            this.panelEX1.Controls.Add(this.label3);
            this.panelEX1.Controls.Add(this.lbl_CurrentValue);
            this.panelEX1.Controls.Add(this.label2);
            this.panelEX1.Controls.Add(this.lbl_VarName);
            this.panelEX1.Controls.Add(this.label1);
            this.panelEX1.Controls.Add(this.lbl_title);
            this.panelEX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelEX1.LeftGap = 1;
            this.panelEX1.Location = new System.Drawing.Point(0, 0);
            this.panelEX1.Name = "panelEX1";
            this.panelEX1.RightGap = 1;
            this.panelEX1.Size = new System.Drawing.Size(438, 416);
            this.panelEX1.TabIndex = 0;
            this.panelEX1.TopGap = 1;
            this.panelEX1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.panelEX1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            // 
            // txt_SetValue
            // 
            this.txt_SetValue.Location = new System.Drawing.Point(184, 215);
            this.txt_SetValue.Name = "txt_SetValue";
            this.txt_SetValue.Size = new System.Drawing.Size(193, 34);
            this.txt_SetValue.TabIndex = 0;
            this.txt_SetValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txt_SetValue.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txt_SetValue_KeyDown);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(264, 304);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(113, 47);
            this.btn_cancel.TabIndex = 2;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_suer
            // 
            this.btn_suer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_suer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_suer.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_suer.ForeColor = System.Drawing.Color.White;
            this.btn_suer.Location = new System.Drawing.Point(48, 304);
            this.btn_suer.Name = "btn_suer";
            this.btn_suer.Size = new System.Drawing.Size(118, 47);
            this.btn_suer.TabIndex = 1;
            this.btn_suer.Text = "确认";
            this.btn_suer.UseVisualStyleBackColor = false;
            this.btn_suer.Click += new System.EventHandler(this.btn_suer_Click);
            // 
            // lbl_close
            // 
            this.lbl_close.BackColor = System.Drawing.Color.Transparent;
            this.lbl_close.FlatAppearance.BorderSize = 0;
            this.lbl_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent;
            this.lbl_close.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(28)))), ((int)(((byte)(80)))));
            this.lbl_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_close.Font = new System.Drawing.Font("微软雅黑", 11.8F);
            this.lbl_close.ForeColor = System.Drawing.Color.White;
            this.lbl_close.Location = new System.Drawing.Point(380, 2);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(55, 41);
            this.lbl_close.TabIndex = 7;
            this.lbl_close.Text = "X";
            this.lbl_close.UseVisualStyleBackColor = false;
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(42, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 25);
            this.label3.TabIndex = 4;
            this.label3.Text = "修改值";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_CurrentValue
            // 
            this.lbl_CurrentValue.BackColor = System.Drawing.Color.Transparent;
            this.lbl_CurrentValue.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lbl_CurrentValue.ForeColor = System.Drawing.Color.White;
            this.lbl_CurrentValue.Location = new System.Drawing.Point(179, 150);
            this.lbl_CurrentValue.Name = "lbl_CurrentValue";
            this.lbl_CurrentValue.Size = new System.Drawing.Size(198, 25);
            this.lbl_CurrentValue.TabIndex = 4;
            this.lbl_CurrentValue.Text = "当前值";
            this.lbl_CurrentValue.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(43, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 25);
            this.label2.TabIndex = 4;
            this.label2.Text = "当前值";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_VarName
            // 
            this.lbl_VarName.BackColor = System.Drawing.Color.Transparent;
            this.lbl_VarName.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.lbl_VarName.ForeColor = System.Drawing.Color.White;
            this.lbl_VarName.Location = new System.Drawing.Point(179, 80);
            this.lbl_VarName.Name = "lbl_VarName";
            this.lbl_VarName.Size = new System.Drawing.Size(198, 25);
            this.lbl_VarName.TabIndex = 4;
            this.lbl_VarName.Text = "参数名称";
            this.lbl_VarName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(42, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 25);
            this.label1.TabIndex = 4;
            this.label1.Text = "参数名称";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_title
            // 
            this.lbl_title.AutoSize = true;
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(92, 27);
            this.lbl_title.TabIndex = 4;
            this.lbl_title.Text = "参数修改";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FrmModify
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 27F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KWD.MTHproject.Properties.Resources.TitleBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(438, 416);
            this.Controls.Add(this.panelEX1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmModify";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModify";
            this.panelEX1.ResumeLayout(false);
            this.panelEX1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private KWDMHTUserLib.PanelEX panelEX1;
        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button lbl_close;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_suer;
        private System.Windows.Forms.Label lbl_CurrentValue;
        private System.Windows.Forms.Label lbl_VarName;
        private System.Windows.Forms.TextBox txt_SetValue;
    }
}
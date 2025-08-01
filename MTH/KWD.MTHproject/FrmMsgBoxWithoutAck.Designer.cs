namespace KWD.MTHproject
{
    partial class FrmMsgBoxWithoutAck
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
            this.lbl_title = new System.Windows.Forms.Label();
            this.lbl_close = new System.Windows.Forms.Button();
            this.lbl_content = new System.Windows.Forms.Label();
            this.btn_suer = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_title
            // 
            this.lbl_title.BackColor = System.Drawing.Color.Transparent;
            this.lbl_title.ForeColor = System.Drawing.Color.White;
            this.lbl_title.Location = new System.Drawing.Point(12, 9);
            this.lbl_title.Name = "lbl_title";
            this.lbl_title.Size = new System.Drawing.Size(109, 34);
            this.lbl_title.TabIndex = 3;
            this.lbl_title.Text = "退出系统";
            this.lbl_title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.lbl_close.Location = new System.Drawing.Point(392, 5);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(55, 41);
            this.lbl_close.TabIndex = 6;
            this.lbl_close.Text = "X";
            this.lbl_close.UseVisualStyleBackColor = false;
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // lbl_content
            // 
            this.lbl_content.BackColor = System.Drawing.Color.Transparent;
            this.lbl_content.ForeColor = System.Drawing.Color.White;
            this.lbl_content.Location = new System.Drawing.Point(12, 124);
            this.lbl_content.Name = "lbl_content";
            this.lbl_content.Size = new System.Drawing.Size(435, 67);
            this.lbl_content.TabIndex = 3;
            this.lbl_content.Text = "是否确认退出系统";
            this.lbl_content.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_suer
            // 
            this.btn_suer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_suer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_suer.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_suer.ForeColor = System.Drawing.Color.White;
            this.btn_suer.Location = new System.Drawing.Point(65, 212);
            this.btn_suer.Name = "btn_suer";
            this.btn_suer.Size = new System.Drawing.Size(111, 38);
            this.btn_suer.TabIndex = 11;
            this.btn_suer.Text = "确认";
            this.btn_suer.UseVisualStyleBackColor = false;
            this.btn_suer.Click += new System.EventHandler(this.btn_suer_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(274, 212);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(111, 38);
            this.btn_cancel.TabIndex = 11;
            this.btn_cancel.Text = "取消";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FrmMsgBoxWithoutAck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KWD.MTHproject.Properties.Resources.TitleBG;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(457, 368);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_suer);
            this.Controls.Add(this.lbl_close);
            this.Controls.Add(this.lbl_content);
            this.Controls.Add(this.lbl_title);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMsgBoxWithoutAck";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmMsgBoxWithAck";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lbl_title;
        private System.Windows.Forms.Button lbl_close;
        private System.Windows.Forms.Label lbl_content;
        private System.Windows.Forms.Button btn_suer;
        private System.Windows.Forms.Button btn_cancel;
    }
}
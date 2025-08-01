namespace KWD.MTHproject
{
    partial class FrmLogin
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_loginName = new System.Windows.Forms.TextBox();
            this.text_possword = new System.Windows.Forms.TextBox();
            this.btn_Login = new System.Windows.Forms.Button();
            this.lbl_close = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "工厂化水桶养殖系统";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(119, 169);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(229, 1);
            this.label2.TabIndex = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(119, 211);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(229, 1);
            this.label3.TabIndex = 0;
            // 
            // text_loginName
            // 
            this.text_loginName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.text_loginName.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_loginName.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.text_loginName.ForeColor = System.Drawing.Color.White;
            this.text_loginName.Location = new System.Drawing.Point(119, 141);
            this.text_loginName.Name = "text_loginName";
            this.text_loginName.Size = new System.Drawing.Size(229, 27);
            this.text_loginName.TabIndex = 0;
            this.text_loginName.Text = "Admin";
            this.text_loginName.DoubleClick += new System.EventHandler(this.text_loginName_DoubleClick);
            this.text_loginName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_loginName_KeyDown);
            // 
            // text_possword
            // 
            this.text_possword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(29)))), ((int)(((byte)(85)))));
            this.text_possword.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.text_possword.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.text_possword.ForeColor = System.Drawing.Color.White;
            this.text_possword.Location = new System.Drawing.Point(119, 181);
            this.text_possword.Name = "text_possword";
            this.text_possword.PasswordChar = '*';
            this.text_possword.Size = new System.Drawing.Size(229, 27);
            this.text_possword.TabIndex = 1;
            this.text_possword.Text = "123";
            this.text_possword.DoubleClick += new System.EventHandler(this.text_loginName_DoubleClick);
            this.text_possword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_loginName_KeyDown);
            // 
            // btn_Login
            // 
            this.btn_Login.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(27)))), ((int)(((byte)(78)))));
            this.btn_Login.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Login.Font = new System.Drawing.Font("微软雅黑", 10.8F);
            this.btn_Login.ForeColor = System.Drawing.Color.White;
            this.btn_Login.Location = new System.Drawing.Point(89, 224);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(259, 32);
            this.btn_Login.TabIndex = 2;
            this.btn_Login.Text = "登录";
            this.btn_Login.UseVisualStyleBackColor = false;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
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
            this.lbl_close.Location = new System.Drawing.Point(378, 0);
            this.lbl_close.Name = "lbl_close";
            this.lbl_close.Size = new System.Drawing.Size(55, 41);
            this.lbl_close.TabIndex = 8;
            this.lbl_close.Text = "X";
            this.lbl_close.UseVisualStyleBackColor = false;
            this.lbl_close.Click += new System.EventHandler(this.lbl_close_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(114, 286);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(210, 25);
            this.label4.TabIndex = 0;
            this.label4.Text = "双击输入框可跳出软键盘";
            // 
            // FrmLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::KWD.MTHproject.Properties.Resources.Login;
            this.ClientSize = new System.Drawing.Size(430, 330);
            this.Controls.Add(this.lbl_close);
            this.Controls.Add(this.btn_Login);
            this.Controls.Add(this.text_possword);
            this.Controls.Add(this.text_loginName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmLogin";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Panel_MouseMove);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_loginName;
        private System.Windows.Forms.TextBox text_possword;
        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.Button lbl_close;
        private System.Windows.Forms.Label label4;
    }
}
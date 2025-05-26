namespace WindowsFormsApp1
{
    partial class FrmModifyAccount
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
            this.but_Modify = new System.Windows.Forms.Button();
            this.text_Pwd = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.text_ModifyPwd = new System.Windows.Forms.TextBox();
            this.text_Account = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // but_Modify
            // 
            this.but_Modify.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Modify.Location = new System.Drawing.Point(19, 149);
            this.but_Modify.Margin = new System.Windows.Forms.Padding(4);
            this.but_Modify.Name = "but_Modify";
            this.but_Modify.Size = new System.Drawing.Size(291, 47);
            this.but_Modify.TabIndex = 3;
            this.but_Modify.Text = "确   认   修   改";
            this.but_Modify.UseVisualStyleBackColor = true;
            this.but_Modify.Click += new System.EventHandler(this.but_Modify_Click);
            // 
            // text_Pwd
            // 
            this.text_Pwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_Pwd.Location = new System.Drawing.Point(99, 64);
            this.text_Pwd.Margin = new System.Windows.Forms.Padding(4);
            this.text_Pwd.Name = "text_Pwd";
            this.text_Pwd.PasswordChar = '*';
            this.text_Pwd.Size = new System.Drawing.Size(211, 23);
            this.text_Pwd.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(16, 67);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "原始密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(30, 26);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 14);
            this.label1.TabIndex = 5;
            this.label1.Text = "用户名:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(16, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 14);
            this.label3.TabIndex = 3;
            this.label3.Text = "修改密码:";
            // 
            // text_ModifyPwd
            // 
            this.text_ModifyPwd.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_ModifyPwd.Location = new System.Drawing.Point(99, 108);
            this.text_ModifyPwd.Margin = new System.Windows.Forms.Padding(4);
            this.text_ModifyPwd.Name = "text_ModifyPwd";
            this.text_ModifyPwd.PasswordChar = '*';
            this.text_ModifyPwd.Size = new System.Drawing.Size(211, 23);
            this.text_ModifyPwd.TabIndex = 2;
            // 
            // text_Account
            // 
            this.text_Account.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_Account.Location = new System.Drawing.Point(99, 23);
            this.text_Account.Margin = new System.Windows.Forms.Padding(4);
            this.text_Account.Name = "text_Account";
            this.text_Account.PasswordChar = '*';
            this.text_Account.Size = new System.Drawing.Size(211, 23);
            this.text_Account.TabIndex = 1;
            this.text_Account.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // FrmModifyAccount
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(333, 215);
            this.Controls.Add(this.but_Modify);
            this.Controls.Add(this.text_ModifyPwd);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.text_Account);
            this.Controls.Add(this.text_Pwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmModifyAccount";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmModifyAccount";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button but_Modify;
        private System.Windows.Forms.TextBox text_Pwd;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_ModifyPwd;
        private System.Windows.Forms.TextBox text_Account;
    }
}
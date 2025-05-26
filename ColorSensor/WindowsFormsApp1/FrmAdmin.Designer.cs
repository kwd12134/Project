namespace WindowsFormsApp1
{
    partial class FrmAdmin
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
            this.but_Login = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.text_Pwd = new System.Windows.Forms.TextBox();
            this.text_Account = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 40);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "账户:";
            // 
            // but_Login
            // 
            this.but_Login.Location = new System.Drawing.Point(50, 145);
            this.but_Login.Margin = new System.Windows.Forms.Padding(4);
            this.but_Login.Name = "but_Login";
            this.but_Login.Size = new System.Drawing.Size(246, 43);
            this.but_Login.TabIndex = 1;
            this.but_Login.Text = "确   认   登   录";
            this.but_Login.UseVisualStyleBackColor = true;
            this.but_Login.Click += new System.EventHandler(this.but_Login_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 92);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "密码:";
            // 
            // text_Pwd
            // 
            this.text_Pwd.Location = new System.Drawing.Point(85, 89);
            this.text_Pwd.Margin = new System.Windows.Forms.Padding(4);
            this.text_Pwd.Name = "text_Pwd";
            this.text_Pwd.PasswordChar = '*';
            this.text_Pwd.Size = new System.Drawing.Size(211, 26);
            this.text_Pwd.TabIndex = 0;
            this.text_Pwd.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_Pwd_KeyDown);
            // 
            // text_Account
            // 
            this.text_Account.FormattingEnabled = true;
            this.text_Account.Items.AddRange(new object[] {
            "Admin",
            "Operator"});
            this.text_Account.Location = new System.Drawing.Point(85, 37);
            this.text_Account.Name = "text_Account";
            this.text_Account.Size = new System.Drawing.Size(211, 24);
            this.text_Account.TabIndex = 0;
            this.text_Account.Text = "Admin";
            // 
            // FrmAdmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 225);
            this.Controls.Add(this.text_Account);
            this.Controls.Add(this.but_Login);
            this.Controls.Add(this.text_Pwd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FrmAdmin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Admin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button but_Login;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox text_Pwd;
        private System.Windows.Forms.ComboBox text_Account;
    }
}
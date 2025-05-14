namespace BL12
{
    partial class FrmChangePwd
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TextBox_Original = new System.Windows.Forms.TextBox();
            this.TextBox_Modify = new System.Windows.Forms.TextBox();
            this.TextBox_Confirm = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 116);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 16);
            this.label3.TabIndex = 3;
            this.label3.Text = "确认修改密码:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(24, 67);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "修改密码:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "原密码:";
            // 
            // TextBox_Original
            // 
            this.TextBox_Original.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBox_Original.Location = new System.Drawing.Point(182, 12);
            this.TextBox_Original.Name = "TextBox_Original";
            this.TextBox_Original.Size = new System.Drawing.Size(222, 29);
            this.TextBox_Original.TabIndex = 10;
            // 
            // TextBox_Modify
            // 
            this.TextBox_Modify.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBox_Modify.Location = new System.Drawing.Point(182, 62);
            this.TextBox_Modify.Name = "TextBox_Modify";
            this.TextBox_Modify.Size = new System.Drawing.Size(222, 29);
            this.TextBox_Modify.TabIndex = 10;
            // 
            // TextBox_Confirm
            // 
            this.TextBox_Confirm.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TextBox_Confirm.Location = new System.Drawing.Point(182, 111);
            this.TextBox_Confirm.Name = "TextBox_Confirm";
            this.TextBox_Confirm.Size = new System.Drawing.Size(222, 29);
            this.TextBox_Confirm.TabIndex = 10;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button1.Location = new System.Drawing.Point(27, 157);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(377, 38);
            this.button1.TabIndex = 11;
            this.button1.Text = "确 认 修 改";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button_Click);
            // 
            // FrmChangePwd
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(416, 213);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.TextBox_Confirm);
            this.Controls.Add(this.TextBox_Original);
            this.Controls.Add(this.TextBox_Modify);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmChangePwd";
            this.Text = "FrmChangePwd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TextBox_Original;
        private System.Windows.Forms.TextBox TextBox_Modify;
        private System.Windows.Forms.TextBox TextBox_Confirm;
        private System.Windows.Forms.Button button1;
    }
}
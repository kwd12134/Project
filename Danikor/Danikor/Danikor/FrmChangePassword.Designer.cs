namespace Danikor
{
    partial class FrmChangePassword
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
            this.uiTextBox_Original = new Sunny.UI.UITextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.uiTextBox_Modify = new Sunny.UI.UITextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.uiTextBox_Confirm = new Sunny.UI.UITextBox();
            this.uiButton = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Password:";
            // 
            // uiTextBox_Original
            // 
            this.uiTextBox_Original.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_Original.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_Original.Location = new System.Drawing.Point(175, 49);
            this.uiTextBox_Original.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_Original.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_Original.Name = "uiTextBox_Original";
            this.uiTextBox_Original.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_Original.PasswordChar = '*';
            this.uiTextBox_Original.ShowText = false;
            this.uiTextBox_Original.Size = new System.Drawing.Size(222, 29);
            this.uiTextBox_Original.TabIndex = 0;
            this.uiTextBox_Original.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_Original.Watermark = "";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 104);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(135, 16);
            this.label2.TabIndex = 0;
            this.label2.Text = "Modify Password:";
            // 
            // uiTextBox_Modify
            // 
            this.uiTextBox_Modify.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_Modify.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_Modify.Location = new System.Drawing.Point(175, 99);
            this.uiTextBox_Modify.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_Modify.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_Modify.Name = "uiTextBox_Modify";
            this.uiTextBox_Modify.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_Modify.PasswordChar = '*';
            this.uiTextBox_Modify.ShowText = false;
            this.uiTextBox_Modify.Size = new System.Drawing.Size(222, 29);
            this.uiTextBox_Modify.TabIndex = 1;
            this.uiTextBox_Modify.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_Modify.Watermark = "";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 153);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Confirm Password:";
            // 
            // uiTextBox_Confirm
            // 
            this.uiTextBox_Confirm.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiTextBox_Confirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiTextBox_Confirm.Location = new System.Drawing.Point(175, 148);
            this.uiTextBox_Confirm.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiTextBox_Confirm.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiTextBox_Confirm.Name = "uiTextBox_Confirm";
            this.uiTextBox_Confirm.Padding = new System.Windows.Forms.Padding(5);
            this.uiTextBox_Confirm.PasswordChar = '*';
            this.uiTextBox_Confirm.ShowText = false;
            this.uiTextBox_Confirm.Size = new System.Drawing.Size(222, 29);
            this.uiTextBox_Confirm.TabIndex = 2;
            this.uiTextBox_Confirm.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiTextBox_Confirm.Watermark = "";
            // 
            // uiButton
            // 
            this.uiButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton.Location = new System.Drawing.Point(20, 204);
            this.uiButton.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton.Name = "uiButton";
            this.uiButton.Size = new System.Drawing.Size(377, 38);
            this.uiButton.TabIndex = 2;
            this.uiButton.Text = "确认修改";
            this.uiButton.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton.Click += new System.EventHandler(this.uiButton_Click);
            // 
            // FrmChangePassword
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(423, 268);
            this.Controls.Add(this.uiButton);
            this.Controls.Add(this.uiTextBox_Confirm);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.uiTextBox_Modify);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.uiTextBox_Original);
            this.Controls.Add(this.label1);
            this.Name = "FrmChangePassword";
            this.Text = "ChangePassword";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private Sunny.UI.UITextBox uiTextBox_Original;
        private System.Windows.Forms.Label label2;
        private Sunny.UI.UITextBox uiTextBox_Modify;
        private System.Windows.Forms.Label label3;
        private Sunny.UI.UITextBox uiTextBox_Confirm;
        private Sunny.UI.UIButton uiButton;
    }
}
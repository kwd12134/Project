namespace Danikor
{
    partial class FrmRefreshParameter
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
            this.uiButton1 = new Sunny.UI.UIButton();
            this.uiButton2 = new Sunny.UI.UIButton();
            this.uiNumPadTextBox1 = new Sunny.UI.UITextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(20, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(204, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "请输入对应Pset序号:";
            // 
            // uiButton1
            // 
            this.uiButton1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Location = new System.Drawing.Point(224, 108);
            this.uiButton1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton1.Name = "uiButton1";
            this.uiButton1.Size = new System.Drawing.Size(199, 35);
            this.uiButton1.TabIndex = 2;
            this.uiButton1.Text = "确认";
            this.uiButton1.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton1.Click += new System.EventHandler(this.uiButton1_Click);
            // 
            // uiButton2
            // 
            this.uiButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.uiButton2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Location = new System.Drawing.Point(24, 108);
            this.uiButton2.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiButton2.Name = "uiButton2";
            this.uiButton2.Size = new System.Drawing.Size(173, 35);
            this.uiButton2.TabIndex = 2;
            this.uiButton2.Text = "取消";
            this.uiButton2.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiButton2.Click += new System.EventHandler(this.uiButton2_Click);
            // 
            // uiNumPadTextBox1
            // 
            this.uiNumPadTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.uiNumPadTextBox1.DoubleValue = 1D;
            this.uiNumPadTextBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiNumPadTextBox1.IntValue = 1;
            this.uiNumPadTextBox1.Location = new System.Drawing.Point(224, 52);
            this.uiNumPadTextBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiNumPadTextBox1.MinimumSize = new System.Drawing.Size(1, 16);
            this.uiNumPadTextBox1.Name = "uiNumPadTextBox1";
            this.uiNumPadTextBox1.Padding = new System.Windows.Forms.Padding(5);
            this.uiNumPadTextBox1.ShowText = false;
            this.uiNumPadTextBox1.Size = new System.Drawing.Size(199, 29);
            this.uiNumPadTextBox1.TabIndex = 3;
            this.uiNumPadTextBox1.Text = "1";
            this.uiNumPadTextBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiNumPadTextBox1.Watermark = "";
            // 
            // FrmRefreshParameter
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(437, 162);
            this.Controls.Add(this.uiNumPadTextBox1);
            this.Controls.Add(this.uiButton2);
            this.Controls.Add(this.uiButton1);
            this.Controls.Add(this.label1);
            this.Name = "FrmRefreshParameter";
            this.Text = "FrmRefreshParameter";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmRefreshParameter_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UITextBox uiNumPadTextBox1;
    }
}
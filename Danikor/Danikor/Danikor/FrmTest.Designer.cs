namespace Danikor
{
    partial class FrmTest
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
            this.but_stop = new Sunny.UI.UIButton();
            this.but_Start = new Sunny.UI.UIButton();
            this.but_CancelStop = new Sunny.UI.UIButton();
            this.but_Reverse = new Sunny.UI.UIButton();
            this.but_Reset = new Sunny.UI.UIButton();
            this.SuspendLayout();
            // 
            // but_stop
            // 
            this.but_stop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_stop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_stop.Location = new System.Drawing.Point(321, 105);
            this.but_stop.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_stop.Name = "but_stop";
            this.but_stop.Size = new System.Drawing.Size(92, 47);
            this.but_stop.TabIndex = 0;
            this.but_stop.Text = "急停";
            this.but_stop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_stop.Click += new System.EventHandler(this.but_stop_Click);
            // 
            // but_Start
            // 
            this.but_Start.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Start.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Start.Location = new System.Drawing.Point(24, 105);
            this.but_Start.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_Start.Name = "but_Start";
            this.but_Start.Size = new System.Drawing.Size(92, 47);
            this.but_Start.TabIndex = 0;
            this.but_Start.Text = "正转";
            this.but_Start.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Start.Click += new System.EventHandler(this.but_Start_Click);
            // 
            // but_CancelStop
            // 
            this.but_CancelStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_CancelStop.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_CancelStop.Location = new System.Drawing.Point(222, 105);
            this.but_CancelStop.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_CancelStop.Name = "but_CancelStop";
            this.but_CancelStop.Size = new System.Drawing.Size(92, 47);
            this.but_CancelStop.TabIndex = 1;
            this.but_CancelStop.Text = "取消急停";
            this.but_CancelStop.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_CancelStop.Click += new System.EventHandler(this.butCancelStop_Click);
            // 
            // but_Reverse
            // 
            this.but_Reverse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Reverse.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Reverse.Location = new System.Drawing.Point(123, 105);
            this.but_Reverse.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_Reverse.Name = "but_Reverse";
            this.but_Reverse.Size = new System.Drawing.Size(92, 47);
            this.but_Reverse.TabIndex = 1;
            this.but_Reverse.Text = "反转";
            this.but_Reverse.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Reverse.Click += new System.EventHandler(this.but_Reverse_Click);
            // 
            // but_Reset
            // 
            this.but_Reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_Reset.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Reset.Location = new System.Drawing.Point(420, 105);
            this.but_Reset.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_Reset.Name = "but_Reset";
            this.but_Reset.Size = new System.Drawing.Size(92, 47);
            this.but_Reset.TabIndex = 1;
            this.but_Reset.Text = "复位";
            this.but_Reset.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_Reset.Click += new System.EventHandler(this.but_Reset_Click);
            // 
            // 
            // FrmTest
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(541, 217);
            this.Controls.Add(this.but_Reset);
            this.Controls.Add(this.but_Reverse);
            this.Controls.Add(this.but_CancelStop);
            this.Controls.Add(this.but_Start);
            this.Controls.Add(this.but_stop);
            this.Name = "FrmTest";
            this.Text = "FrmTest";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 800, 450);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIButton but_stop;
        private Sunny.UI.UIButton but_Start;
        private Sunny.UI.UIButton but_CancelStop;
        private Sunny.UI.UIButton but_Reverse;
        private Sunny.UI.UIButton but_Reset;
    }
}
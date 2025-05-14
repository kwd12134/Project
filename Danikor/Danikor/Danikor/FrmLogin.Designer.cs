namespace Danikor
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
            this.uiComboBox1 = new Sunny.UI.UIComboBox();
            this.uiAvatar1 = new Sunny.UI.UIAvatar();
            this.uiLabel1 = new Sunny.UI.UILabel();
            this.text_Password = new Sunny.UI.UITextBox();
            this.uiLabel2 = new Sunny.UI.UILabel();
            this.but_cLear = new Sunny.UI.UIButton();
            this.but_affirm = new Sunny.UI.UIButton();
            this.text_accont = new Sunny.UI.UIComboBox();
            this.SuspendLayout();
            // 
            // uiComboBox1
            // 
            this.uiComboBox1.DataSource = null;
            this.uiComboBox1.FillColor = System.Drawing.Color.White;
            this.uiComboBox1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiComboBox1.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Items.AddRange(new object[] {
            "Admin",
            "Operator"});
            this.uiComboBox1.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.uiComboBox1.Location = new System.Drawing.Point(4, 121);
            this.uiComboBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.uiComboBox1.MinimumSize = new System.Drawing.Size(63, 0);
            this.uiComboBox1.Name = "uiComboBox1";
            this.uiComboBox1.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.uiComboBox1.Size = new System.Drawing.Size(182, 29);
            this.uiComboBox1.SymbolSize = 24;
            this.uiComboBox1.TabIndex = 6;
            this.uiComboBox1.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.uiComboBox1.Watermark = "请选择登录账号";
            // 
            // uiAvatar1
            // 
            this.uiAvatar1.AvatarSize = 55;
            this.uiAvatar1.Font = new System.Drawing.Font("宋体", 12F);
            this.uiAvatar1.Location = new System.Drawing.Point(28, 84);
            this.uiAvatar1.MinimumSize = new System.Drawing.Size(1, 1);
            this.uiAvatar1.Name = "uiAvatar1";
            this.uiAvatar1.Size = new System.Drawing.Size(73, 80);
            this.uiAvatar1.SymbolSize = 48;
            this.uiAvatar1.TabIndex = 25;
            this.uiAvatar1.Text = "uiAvatar1";
            // 
            // uiLabel1
            // 
            this.uiLabel1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel1.Location = new System.Drawing.Point(116, 84);
            this.uiLabel1.Name = "uiLabel1";
            this.uiLabel1.Size = new System.Drawing.Size(51, 29);
            this.uiLabel1.TabIndex = 28;
            this.uiLabel1.Text = "账户:";
            this.uiLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_Password
            // 
            this.text_Password.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.text_Password.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_Password.Location = new System.Drawing.Point(174, 135);
            this.text_Password.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_Password.MinimumSize = new System.Drawing.Size(1, 16);
            this.text_Password.Name = "text_Password";
            this.text_Password.Padding = new System.Windows.Forms.Padding(5);
            this.text_Password.PasswordChar = '*';
            this.text_Password.ShowText = false;
            this.text_Password.Size = new System.Drawing.Size(179, 29);
            this.text_Password.TabIndex = 0;
            this.text_Password.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            this.text_Password.Watermark = "请输入密码";
            this.text_Password.KeyDown += new System.Windows.Forms.KeyEventHandler(this.text_Password_KeyDown);
            // 
            // uiLabel2
            // 
            this.uiLabel2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiLabel2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(48)))), ((int)(((byte)(48)))));
            this.uiLabel2.Location = new System.Drawing.Point(116, 135);
            this.uiLabel2.Name = "uiLabel2";
            this.uiLabel2.Size = new System.Drawing.Size(51, 29);
            this.uiLabel2.TabIndex = 28;
            this.uiLabel2.Text = "密码:";
            this.uiLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // but_cLear
            // 
            this.but_cLear.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_cLear.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cLear.Location = new System.Drawing.Point(74, 196);
            this.but_cLear.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_cLear.Name = "but_cLear";
            this.but_cLear.Size = new System.Drawing.Size(118, 39);
            this.but_cLear.TabIndex = 29;
            this.but_cLear.Text = "清除";
            this.but_cLear.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_cLear.Click += new System.EventHandler(this.but_cLear_Click);
            // 
            // but_affirm
            // 
            this.but_affirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.but_affirm.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_affirm.Location = new System.Drawing.Point(235, 196);
            this.but_affirm.MinimumSize = new System.Drawing.Size(1, 1);
            this.but_affirm.Name = "but_affirm";
            this.but_affirm.Size = new System.Drawing.Size(118, 39);
            this.but_affirm.TabIndex = 1;
            this.but_affirm.Text = "确认";
            this.but_affirm.TipsFont = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.but_affirm.Click += new System.EventHandler(this.but_affirm_Click);
            // 
            // text_accont
            // 
            this.text_accont.DataSource = null;
            this.text_accont.FillColor = System.Drawing.Color.White;
            this.text_accont.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.text_accont.ItemHoverColor = System.Drawing.Color.FromArgb(((int)(((byte)(155)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
            this.text_accont.Items.AddRange(new object[] {
            "Admin",
            "Operator"});
            this.text_accont.ItemSelectForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(243)))), ((int)(((byte)(255)))));
            this.text_accont.Location = new System.Drawing.Point(174, 84);
            this.text_accont.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.text_accont.MaxLength = 2;
            this.text_accont.MinimumSize = new System.Drawing.Size(63, 0);
            this.text_accont.Name = "text_accont";
            this.text_accont.Padding = new System.Windows.Forms.Padding(0, 0, 30, 2);
            this.text_accont.Size = new System.Drawing.Size(179, 29);
            this.text_accont.Sorted = true;
            this.text_accont.SymbolSize = 24;
            this.text_accont.TabIndex = 30;
            this.text_accont.Text = "Admin";
            this.text_accont.TextAlignment = System.Drawing.ContentAlignment.MiddleCenter;
            this.text_accont.Watermark = "";
            // 
            // FrmLogin
            // 
            this.ClientSize = new System.Drawing.Size(431, 264);
            this.Controls.Add(this.text_accont);
            this.Controls.Add(this.but_affirm);
            this.Controls.Add(this.but_cLear);
            this.Controls.Add(this.uiLabel2);
            this.Controls.Add(this.uiLabel1);
            this.Controls.Add(this.text_Password);
            this.Controls.Add(this.uiAvatar1);
            this.Name = "FrmLogin";
            this.ZoomScaleRect = new System.Drawing.Rectangle(15, 15, 451, 261);
            this.ResumeLayout(false);

        }

        #endregion

        private Sunny.UI.UIComboBox uiComboBox1;
        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox text_Password;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UIButton but_cLear;
        private Sunny.UI.UIButton but_affirm;
        private Sunny.UI.UIComboBox text_accont;
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWDMHTUserLib
{
    public partial class CheckBoxEx : CheckBox
    {
        public CheckBoxEx()
        {
            InitializeComponent();

            StringFormat.LineAlignment = StringAlignment.Center;
            StringFormat.Alignment = StringAlignment.Center;

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private StringFormat StringFormat = new StringFormat();

        private int defaultChackBoxWidth = 20;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取选中框的宽度")]
        public int DefaultChackBoxWidth
        {
            get { return defaultChackBoxWidth; }
            set { defaultChackBoxWidth = value; 
            this.Invalidate();
            }
        }

        private Color checkColor = Color.FromArgb(3, 25, 66);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取选中颜色")]
        public Color CheckColor
        {
            get { return checkColor; }
            set
            {
                checkColor = value;
                this.Invalidate();
            }
        }

        private Color checkBackColor = Color.White;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取选中颜色")]
        public Color CheckBackColor
        {
            get { return checkBackColor; }
            set
            {
                checkBackColor = value;
                this.Invalidate();
            }
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //   
            base.OnPaintBackground(e);
            //获取画布 
            Graphics graphics = e.Graphics;

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

            Rectangle CheckBox;
            Rectangle TextBox;

            CalculatorRectangle(out CheckBox,out TextBox);

            SolidBrush solidBrush = new SolidBrush(checkBackColor);

            graphics.FillRectangle(solidBrush, CheckBox);

            Pen pen = new Pen(Color.LightGray);

            graphics.DrawRectangle(pen, CheckBox);

            if (this.CheckState==CheckState.Checked)
            {
                //画勾选
                DrawCheckedFlag(graphics,CheckBox,checkColor);

            }

            //绘制文本
            graphics.DrawString(this.Text, this.Font, new SolidBrush(this.ForeColor), TextBox, StringFormat);
        }
        /// <summary>
        /// 计算矩形
        /// </summary>
        /// <param name="CheckBox"></param>
        /// <param name="TextBox"></param>
        private void CalculatorRectangle(out Rectangle CheckBox ,out Rectangle TextBox)
        {
            CheckBox = new Rectangle
                (3,(this.defaultChackBoxWidth)/2,this.defaultChackBoxWidth,this.defaultChackBoxWidth);

            TextBox = new Rectangle(CheckBox.Right + 3, 0, this.Width - CheckBox.Right - 6, this.Height);
        }

        private void DrawCheckedFlag(Graphics graphics , Rectangle rectangle , Color color)
        {
            PointF[] pointFs = new PointF[3];

            pointFs[0] = new PointF(rectangle.X + rectangle.Width / 4.5f, rectangle.Y + rectangle.Height / 2.5f);
            pointFs[1] = new PointF(rectangle.X + rectangle.Width / 2.0f, rectangle.Bottom - rectangle.Height / 3.0f);
            pointFs[2] = new PointF(rectangle.Right - rectangle.Width / 4.0f, rectangle.Y + rectangle.Height / 4.5f);

            Pen pen = new Pen(color,2.0f);

            graphics.DrawLines(pen, pointFs);
        }
    }
}

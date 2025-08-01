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
    public partial class PanelEX : Panel
    {
        public PanelEX()
        {
            InitializeComponent();
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

        }

        private int topGap = 1;
        [Browsable(true)]
        [Category("自定义大小")]
        [Description("设置或者显示上边的间隙间隔距离")]
        public int TopGap
        {
            get { return topGap; }
            set
            {
                topGap = value;
                this.Invalidate();
            }
        }

        private int bottomGap = 1;
        [Browsable(true)]
        [Category("自定义大小")]
        [Description("设置或者显示下边的间隙间隔距离")]
        public int BottomGap
        {
            get { return bottomGap; }
            set
            {
                bottomGap = value; this.Invalidate();
            }
        }

        private int leftGap = 1;
        [Browsable(true)]
        [Category("自定义大小")]
        [Description("设置或者显示左边的间隙间隔距离")]
        public int LeftGap
        {
            get { return leftGap; }
            set
            {
                leftGap = value; this.Invalidate();
            }
        }

        private int rightGap = 1;
        [Browsable(true)]
        [Category("自定义大小")]
        [Description("设置或者显示右边的间隙间隔距离")]
        public int RightGap
        {
            get { return rightGap; }
            set
            {
                rightGap = value; this.Invalidate();
            }
        }

        private int borderWidth = 2;
        [Browsable(true)]
        [Category("自定义大小")]
        [Description("设置或者显示边框的宽度")]
        public int BorderWidth
        {
            get { return borderWidth; }
            set
            {
                borderWidth = value; this.Invalidate();
            }
        }

        private Color borderColor = Color.FromArgb(35, 255, 255);
        [Browsable(true)]
        [Category("自定义大小")]
        [Description("设置或者显示边框的颜色")]
        public Color BorderColor
        {
            get { return borderColor; }
            set
            {
                borderColor = value; this.Invalidate();
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //准备画布
            Graphics graphics = e.Graphics;
            //准备画笔颜色
            Pen pen = new Pen(borderColor,borderWidth);
            //边框距离控件的距离高度宽度   矩形参数
            float x = leftGap + borderWidth * 0.5f;

            float y = topGap + borderWidth * 0.5f;

            float width = this.Width - leftGap - rightGap - borderWidth;

            float height = this.Height - topGap - bottomGap - borderWidth;
            //绘制矩形
            graphics.DrawRectangle(pen, x, y, width, height);

        }
    }
}

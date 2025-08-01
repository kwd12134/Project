using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWDMHTUserLib
{
    public partial class DialPlate : UserControl
    {
        public DialPlate()
        {
            InitializeComponent();
            stringformat.Alignment = StringAlignment.Center;
            stringformat.LineAlignment = StringAlignment.Center;

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private StringFormat stringformat = new StringFormat();

        #region 外环设计


        private Color alarmColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取报警颜色")]
        public Color AlarmColor
        {
            get { return alarmColor; }
            set
            {
                alarmColor = value;
                this.Invalidate();
            }
        }

        private Color ringColor = Color.FromArgb(187, 187, 187);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取圆环整体颜色")]
        public Color RingColor
        {
            get { return ringColor; }
            set
            {
                ringColor = value;
                this.Invalidate();
            }
        }

        private float alarmAngle = 120.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取报警圆环角度")]
        public float AlarmAngle
        {
            get { return alarmAngle; }
            set
            {
                alarmAngle = value;
                this.Invalidate();
            }
        }

        private int outthickness = 8;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取外环的宽度")]
        public int OutThickness
        {
            get { return outthickness; }
            set
            {
                outthickness = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 内环设计


        private float tempScale = 0.6f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取温度环比例，默认低于1.0f")]
        public float TempScale
        {
            get { return tempScale; }
            set
            {
                if (tempScale >= 1.0f) return;
                tempScale = value;
                this.Invalidate();
            }
        }

        private Color tempColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取温度环颜色")]
        public Color TempColor
        {
            get { return tempColor; }
            set
            {
                tempColor = value;
                this.Invalidate();
            }
        }

        private float humidityScale = 0.35f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取湿度环比例，默认低于1.0f")]
        public float HumiditScale
        {
            get { return humidityScale; }
            set
            {
                if (humidityScale >= 1.0f) return;
                humidityScale = value;
                this.Invalidate();
            }
        }

        private Color humiditColor = Color.FromArgb(36, 184, 196);
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取湿度环颜色")]
        public Color HumiditColor
        {
            get { return humiditColor; }
            set
            {
                humiditColor = value;
                this.Invalidate();
            }
        }

        private int inthickness = 16;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取内环的宽度")]
        public int inThickness
        {
            get { return inthickness; }
            set
            {
                inthickness = value;
                this.Invalidate();
            }
        }
        #endregion

        #region 刻度环设置

        private float textScale = 0.85f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取刻度环环比例，默认低于1.0f")]
        public float TextScale
        {
            get { return textScale; }
            set
            {
                if (textScale >= 1.0f) return;
                textScale = value;
                this.Invalidate();
            }
        }

        private float rangeMin = 0.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取量程低限")]
        public float RangeMin
        {
            get { return rangeMin; }
            set
            {
                if (value > rangeMax) return;
                rangeMin = value;
                this.Invalidate();
            }
        }

        private float rangeMax = 90.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取量程高限")]
        public float RangeMax
        {
            get { return rangeMax; }
            set
            {
                if (value < rangeMin) return;
                rangeMax = value;
                this.Invalidate();
            }
        }

        #endregion

        #region 实时显示

        private float temp = 10.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取温度实时值")]
        public float Temp
        {
            get { return temp; }
            set
            {
                if (value < rangeMin)
                {
                    value = rangeMin;
                }
                if (value > rangeMax)
                {
                    value = rangeMax;
                }

                temp = value;
                this.Invalidate();

            }
        }

        private float humidity = 10.0f;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取湿度实时值")]
        public float Humidity
        {
            get { return humidity; }
            set
            {
                if (value < rangeMin)
                {
                    value = rangeMin;
                }
                if (value > rangeMax)
                {
                    value = rangeMax;
                }

                humidity = value;
                this.Invalidate();

            }
        }

        #endregion

        #region 画布设置

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //获取画布
            Graphics graphics = e.Graphics;

            graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            //异常情况处理
            if (this.Width <= 20 || this.Height <= 20) return;

            if (this.Height < this.Width / 2) return;
            //画外环

            Pen pen = new Pen(alarmColor, OutThickness);

            graphics.DrawArc(pen, new RectangleF(10, 10, this.Width - 20, this.Width - 20), 180, alarmAngle);

            pen = new Pen(ringColor, OutThickness);

            graphics.DrawArc(pen, new RectangleF(10, 10, this.Width - 20, this.Width - 20), 180 + alarmAngle, 180 - alarmAngle);

            //坐标系转移          

            graphics.TranslateTransform(this.Width * 0.5f, this.Width * 0.5f);

            //坐标系旋转

            graphics.RotateTransform(-90);

            SolidBrush brush;

            for (int i = 0; i < 7; i++)
            {
                if (30 * i <= alarmAngle)
                {
                    brush = new SolidBrush(alarmColor);
                }
                else
                {
                    brush = new SolidBrush(ringColor);
                }

                float x = -3.0f;
                float width = 6.0f;
                float heigth = outthickness + 4;
                float y = ((this.Width * 0.5f - 10 + heigth * 0.5f) * (-1.0f));
                //绘制矩形   brush相当于画笔
                graphics.FillRectangle(brush, new RectangleF(x, y, width, heigth));

                graphics.RotateTransform(30);

            }

            //坐标系旋转回去

            graphics.RotateTransform(-210);

            graphics.RotateTransform(90);

            float rangeAvg = (rangeMax - rangeMin) % 6 == 0 ? Convert.ToSingle((rangeMax - rangeMin) / 6) :
                Convert.ToSingle(((rangeMax - rangeMin) / 6).ToString("f1"));

            for (int i = 0; i < 7; i++)
            {

                float angle = -180 + i * 30;

                float pointX = Convert.ToSingle(this.Width * textScale * 0.5f * Math.Cos(angle * Math.PI / 180.0f));
                float pointY = Convert.ToSingle(this.Width * textScale * 0.5f * Math.Sin(angle * Math.PI / 180.0f));

                string text = (rangeMin + rangeAvg * i).ToString();

                SizeF sizeF = graphics.MeasureString(text, this.Font);

                RectangleF rectangleF = new RectangleF(pointX - sizeF.Width * 0.5f, pointY, sizeF.Width, sizeF.Height);

                graphics.DrawString(text, this.Font, new SolidBrush(this.ForeColor), rectangleF, stringformat);
            }

            //画制实际的温度湿度环

            pen = new Pen(this.tempColor, inthickness);

            //实际角度
            float sweepAngle = (temp - rangeMin) / (rangeMax - rangeMin) * 180.0f;

            float tempX = this.Width * tempScale * 0.5f * (-1.0f);
            float tempY = this.Width * tempScale * 0.5f * (-1.0f);

            graphics.DrawArc(pen, new RectangleF
                (tempX, tempY, this.Width * tempScale, this.Width * tempScale), -180.0f, sweepAngle);



            pen = new Pen(this.humiditColor, inthickness);

            //实际角度
            sweepAngle = (humidity - rangeMin) / (rangeMax - rangeMin) * 180.0f;

            tempX = this.Width * humidityScale * 0.5f * (-1.0f);
            tempY = this.Width * humidityScale * 0.5f * (-1.0f);

            graphics.DrawArc(pen, new RectangleF
                (tempX, tempY, this.Width * humidityScale, this.Width * humidityScale), -180.0f, sweepAngle);


        }

        #endregion


    }
}

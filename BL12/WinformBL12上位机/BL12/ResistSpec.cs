using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BL12
{
    public partial class ResistSpec : UserControl
    {
        public ResistSpec()
        {
            InitializeComponent();

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string paramName1 = "Typical";
        [Browsable(true)]
        [Category("自定义属性")]
        public string ParamName1
        {
            get { return paramName1; }
            set
            {
                paramName1 = value;
                this.label1.Text = paramName1;
            }
        }

        private string paramName2 = "LSL";
        [Browsable(true)]
        [Category("自定义属性")]
        public string ParamName2
        {
            get { return paramName2; }
            set
            {
                paramName2 = value;
                this.label2.Text = paramName2;
            }
        }

        private string paramName3 = "USL";
        [Browsable(true)]
        [Category("自定义属性")]
        public string ParamName3
        {
            get { return paramName3; }
            set
            {
                paramName3 = value;
                this.label3.Text = paramName3;
            }
        }

        private double param1 = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        public double Param1
        {
            get { return param1; }
            set
            {
                param1 = value;
                this.num1.Value = (decimal)param1;
            }
        }

        private double param2 = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        public double Param2
        {
            get { return param2; }
            set
            {
                param2 = value;
                this.num2.Value = (decimal)param2;
            }
        }

        private double param3 = 0;
        [Browsable(true)]
        [Category("自定义属性")]
        public double Param3
        {
            get { return param3; }
            set
            {
                param3 = value;
                this.num3.Value = (decimal)param3;
            }
        }

    }
}

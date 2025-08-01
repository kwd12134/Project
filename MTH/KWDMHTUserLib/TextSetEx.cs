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
    [DefaultEvent("ControlDoubleClick")]
    public partial class TextSetEx : UserControl
    {
        public TextSetEx()
        {
            InitializeComponent();

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }
        /// <summary>
        /// 通过dictionary的key值对应返回的变量解析到currentVariable
        /// </summary>
        private string titleName = "1#站点温度高限";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取标题名")]
        public string TitleName
        {
            get { return titleName; }
            set
            {
                titleName = value;
                this.lbl_Title.Text = titleName;
            }
        }

        private string bindAlarmName = "模块1温度高";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取绑定报警名称")]
        public string BindAlarmName
        {
            get { return bindAlarmName; }
            set
            {
                bindAlarmName = value;
            }
        }

        private string unit = "℃";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取单位名")]
        public string Unit
        {
            get { return unit; }
            set
            {
                unit = value;
                this.label3.Text = unit;
            }
        }

        private string currentVariable = "0.0";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取绑定当前变量数值")]
        public string CurrentVariable
        {
            get { return currentVariable; }
            set
            {
                if (currentVariable != value)
                {
                    currentVariable = value;
                    this.numericUpDown1.Text = currentVariable;
                }
            }
        }

        private string bindAlarmVarName = "模块1温度高限";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或获取绑定报警变量限制值名称")]
        public string BindAlarmVarName
        {
            get { return bindAlarmVarName; }
            set
            {
                bindAlarmVarName = value;
            }
        }

        //private bool isAlarm;
        //[Browsable(true)]
        //[Category("自定义属性")]
        //[Description("设置或获取当前的报警状态")]
        //public bool IsAlarm
        //{
        //    get { return isAlarm; }
        //    set
        //    {
        //        if (isAlarm != value)
        //        {
        //            isAlarm = value;
        //            this.led_State.Value = isAlarm;
        //        }
        //    }
        //}

        
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("设置控件双击事件")]
        public event  EventHandler ControlDoubleClick;
        private void lbl_Variable_DoubleClick(object sender, EventArgs e)
        {
            ControlDoubleClick?.Invoke(this, e);
        }

    }
}

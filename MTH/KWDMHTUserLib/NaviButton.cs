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
    [DefaultEvent("Cilck")]
    public partial class NaviButton : UserControl
    {
        public NaviButton()
        {
            InitializeComponent();
            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }


        private bool isSelected = false;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或者显示导航栏是否选中")]
        public bool IsSelected
        {
            get { return isSelected; }
            set { isSelected = value;
                UpDateImage();
            }
        }

        private bool isLeft = true;
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或者显示导航栏是否为左边")]
        public bool IsLeft
        {
            get { return isLeft; }
            set { isLeft = value;
                UpDateImage();
            }
        }


        private string titleName="导航按钮";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置或者显示导航栏文本")]
        public string TitleName
        {
            get { return titleName; }
            set { titleName= value; 
            this.lbl_title.Text = titleName;
            }
        }


        private void UpDateImage()
        {
            if (this.isLeft)
            {
                this.BackgroundImage = isSelected ? Properties.Resources.LeftSelected : Properties.Resources.LeftUnSelected;
            }
            else
            {
                this.BackgroundImage = isSelected ? Properties.Resources.RightSelected : Properties.Resources.RightUnSelected;
            }
        }
        [Browsable(true)]
        [Category("自定义事件")]
        [Description("设置或者显示导航栏文本")]
        ///点击label事件出发控件的click事件
        public new EventHandler Click;

        private void lbl_title_Click(object sender, EventArgs e)
        {
            this.Click?.Invoke(this, e);
        }
    }
}

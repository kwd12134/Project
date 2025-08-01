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

    public partial class Title : UserControl
    {
        public Title()
        {
            InitializeComponent();

            //设置控件样式
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
        }

        private string titleNiame = "标题名称";
        [Browsable(true)]
        [Category("自定义属性")]
        [Description("设置标题名字")]
        public string TitleNiame
        {
            get { return titleNiame; }
            set
            {
                titleNiame = value;
                this.lbl_Title.Text = titleNiame;
            }

        }
    }
}

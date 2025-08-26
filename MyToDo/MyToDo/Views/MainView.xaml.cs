using MaterialDesignThemes.Wpf;
using MyToDo.Extensions;
using MyToDo.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MyToDo.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        /// <summary>
        /// DialogContent 的作用
        ///专门用来放置对话框的内容（UI 元素）。
        ///当你调用 DialogHost.Show() 或者打开对话框时，DialogContent 里面的内容会显示出来。
        ///类似于 WinForms/WPF 的 对话框窗口，但它是嵌在页面里的，不需要单独开一个 Window
        /// </summary>
        /// <param name="aggregator"></param>
        public MainView(IEventAggregator aggregator)
        {
            InitializeComponent();

            //目前的窗口也都是注册在当前MainView当中 
            //而因为是c/s架构使用在等待数据返回时使界面加载一下等待的窗口
            aggregator.Register(arg =>
            {
                this.DialogHost.IsOpen = arg.IsOpen;

                if (this.DialogHost.IsOpen)
                {
                    DialogHost.DialogContent = new ProgressView();
                }
            });

            btnMin.Click += (s, e) => { this.WindowState = WindowState.Minimized; };
            btnMax.Click += (s, e) =>
            {
                //HttpRestClient httpRestClient = new HttpRestClient("");
                //var a = httpRestClient.GetDeepSeek();
                if (this.WindowState == WindowState.Maximized)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Maximized;
            };
            btnClose.Click += async (s, e) =>
            {
                this.Close();
            };
            Topic.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                    this.DragMove();
            };

            Topic.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                    this.WindowState = WindowState.Maximized;
                else
                    this.WindowState = WindowState.Normal;
            };

            menubar.SelectionChanged += (s, e) =>
            {
                DrawerHost.IsLeftDrawerOpen = false;
            };
        }
    }
}

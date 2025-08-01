using KWDHTMmodels;
using KWDMHTUserLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KWD.MTHproject
{
    public partial class FrmMonitor : Form
    {
        public FrmMonitor()
        {
            InitializeComponent();

            SetChart();

            //设置间隔时间
            this.UpdateTimer.Interval = 1000;
            //当指定的定时器已经过去但是计时器还在启用状态    
            this.UpdateTimer.Tick += UpdateTimer_Tick;

            this.UpdateTimer.Start();
            //关闭窗体之前发生的事件  lambda表达式  语法糖表示创建的事件事件处理
            this.FormClosing += (sender, e) =>
            {
                this.UpdateTimer.Stop();
            };

        }

        /// <summary>
        /// 设置动态图标曲线视图
        /// </summary>
        private void SetChart()
        {

            //设置X轴数据类型及样式
            this.Chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.TimeStamp;
            this.Chart_ActualTrend.TimeStampFormat = "HH-mm-ss";
            //设置图表
            this.Chart_ActualTrend.LegendVisible = true;
            //设置显示数据点
            this.Chart_ActualTrend.DisplayPoints = 4000;
            //Y轴范围
            this.Chart_ActualTrend.AxisY.Minimum = 0.0f;
            this.Chart_ActualTrend.AxisX.Maximum = 100.0f;
            this.Chart_ActualTrend.AxisX.AutoScale = false;
            //清除曲线
            this.Chart_ActualTrend.Series.Clear();
            //设置曲线数量
            this.Chart_ActualTrend.SeriesCount = 12;
            //设置曲线
            for (int i = 0; i < 12; i++)
            {

                //设置曲线名称
                this.Chart_ActualTrend.Series[i].Name = i % 2 == 0 ? $"{i / 2 + 1}#站点温度" : $"{i / 2 + 1}#站点湿度";
                //设置曲线不可见
                this.Chart_ActualTrend.Series[i].Visible = false;
                //设置曲线的粗细
                this.Chart_ActualTrend.Series[i].Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Middle;
                //设置曲线的Y轴
                this.Chart_ActualTrend.Series[i].YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;

            }
            this.chk_himidity1.Checked = true;
            this.chk_Temp1.Checked = true;

        }

        private Timer UpdateTimer = new Timer();

        /// <summary>
        /// 设置了一个间隔时间以间隔时间来对此方法进行调用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            //为连接状态获取变量值进行窗体数据刷新
            if (CommonMethod.Deviced.IsConnected)
            {

                foreach (var item in this.MianPanel.Controls.OfType<THMControl1>())
                {
                    UpdateTHMcontrol(item);
                }
                //对图表曲线进行数据绑定显示
                List<double> yData = new List<double>();

                for (int i = 1; i <= 6; i++)
                {

                    yData.Add(Convert.ToDouble(CommonMethod.Deviced[$"模块{i}温度"]));
                    yData.Add(Convert.ToDouble(CommonMethod.Deviced[$"模块{i}湿度"]));

                }
                this.Chart_ActualTrend.PlotSingle(yData.ToArray());

            }
        }

        /// <summary>
        /// 对THMControl控件的数据进行更新
        /// </summary>
        /// <param name="tHMControl1"></param>
        private void UpdateTHMcontrol(THMControl1 tHMControl1)
        {
            if (CommonMethod.Deviced[tHMControl1.TempVarName] != null)
            {
                //   根据控件绑定变量的名称做为一个key 来绑定对应的变量在device里所设的值
                tHMControl1.Temp = CommonMethod.Deviced[tHMControl1.TempVarName].ToString();
            }
            //根据控件绑定变量的名称做为一个key 来绑定对应的变量
            if (CommonMethod.Deviced[tHMControl1.HumidityVarName] != null)
            {
                tHMControl1.Humidity = CommonMethod.Deviced[tHMControl1.HumidityVarName].ToString();
            }
            if (CommonMethod.Deviced[tHMControl1.StateVarName] != null)
            {
                tHMControl1.ModuleError = CommonMethod.Deviced[tHMControl1.StateVarName].ToString() == "True";
            }
        }

        /// <summary>
        /// 设置listView的时间变量
        /// </summary>
        private string CurrentTime { get { return DateTime.Now.ToString("yyyy-MM--dd hh:mm-ss"); } }
        /// <summary>
        /// 通用日志方法
        /// </summary>
        /// <param name="Level"></param>
        /// <param name="Log"></param>
        public void AddLog(int Level, string Log)
        {

            if (Level > 2)
            {
                Level = 2;
            }
            if (Level < 0)
            {
                Level = 2;
            }

            if (this.list_info.InvokeRequired)
            {
                //跨线程访问会调用方法体的invoke属性所以在这边加判断并把快线程的的数据传进来编程本地函数内部调用
                //new Action<int, string>(AddLog),Level,Log 后面的参数是外部委托传进来的参数
                this.list_info.Invoke(new Action<int, string>(AddLog), Level, Log);
            }
            else
            {
                //上面的委托把跨线程访问该为内部委托调用  不用调用invoke方法从而还会跳转到else分支里面
                //没有跨线程的处理方法      
                ListViewItem listViewItem = new ListViewItem("   " + CurrentTime, Level);

                listViewItem.SubItems.Add(Log);

                this.list_info.Items.Add(listViewItem);

                //让最新的显示出来

                this.list_info.Items[this.list_info.Items.Count - 1].EnsureVisible();


            }
        }

        private void chk_Common_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkbox)
            {
                if (checkbox.Tag != null && checkbox.Tag.ToString().Length > 0)
                {
                    int Index = Convert.ToInt32(checkbox.Tag.ToString());
                    this.Chart_ActualTrend.Series[Index].Visible = checkbox.Checked;
                }
            }
        }
    }
}

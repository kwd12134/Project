namespace KWD.MTHproject
{
    partial class FrmMonitor
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMonitor));
            SeeSharpTools.JY.GUI.StripChartXSeries stripChartXSeries1 = new SeeSharpTools.JY.GUI.StripChartXSeries();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.MianPanel = new KWDMHTUserLib.PanelEnhanced();
            this.list_info = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.thmControl15 = new KWDMHTUserLib.THMControl1();
            this.Chart_ActualTrend = new SeeSharpTools.JY.GUI.StripChartX();
            this.thmControl11 = new KWDMHTUserLib.THMControl1();
            this.checkBoxEx12 = new KWDMHTUserLib.CheckBoxEx();
            this.thmControl12 = new KWDMHTUserLib.THMControl1();
            this.checkBoxEx8 = new KWDMHTUserLib.CheckBoxEx();
            this.thmControl14 = new KWDMHTUserLib.THMControl1();
            this.checkBoxEx4 = new KWDMHTUserLib.CheckBoxEx();
            this.thmControl13 = new KWDMHTUserLib.THMControl1();
            this.checkBoxEx11 = new KWDMHTUserLib.CheckBoxEx();
            this.thmControl16 = new KWDMHTUserLib.THMControl1();
            this.checkBoxEx10 = new KWDMHTUserLib.CheckBoxEx();
            this.title1 = new KWDMHTUserLib.Title();
            this.checkBoxEx7 = new KWDMHTUserLib.CheckBoxEx();
            this.title2 = new KWDMHTUserLib.Title();
            this.checkBoxEx6 = new KWDMHTUserLib.CheckBoxEx();
            this.chk_Temp1 = new KWDMHTUserLib.CheckBoxEx();
            this.checkBoxEx9 = new KWDMHTUserLib.CheckBoxEx();
            this.chk_himidity1 = new KWDMHTUserLib.CheckBoxEx();
            this.checkBoxEx3 = new KWDMHTUserLib.CheckBoxEx();
            this.checkBoxEx5 = new KWDMHTUserLib.CheckBoxEx();
            this.MianPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "info.png");
            this.imageList1.Images.SetKeyName(1, "warning.png");
            this.imageList1.Images.SetKeyName(2, "error.png");
            // 
            // MianPanel
            // 
            this.MianPanel.BackgroundImage = global::KWD.MTHproject.Properties.Resources.BackGround;
            this.MianPanel.Controls.Add(this.list_info);
            this.MianPanel.Controls.Add(this.thmControl15);
            this.MianPanel.Controls.Add(this.Chart_ActualTrend);
            this.MianPanel.Controls.Add(this.thmControl11);
            this.MianPanel.Controls.Add(this.checkBoxEx12);
            this.MianPanel.Controls.Add(this.thmControl12);
            this.MianPanel.Controls.Add(this.checkBoxEx8);
            this.MianPanel.Controls.Add(this.thmControl14);
            this.MianPanel.Controls.Add(this.checkBoxEx4);
            this.MianPanel.Controls.Add(this.thmControl13);
            this.MianPanel.Controls.Add(this.checkBoxEx11);
            this.MianPanel.Controls.Add(this.thmControl16);
            this.MianPanel.Controls.Add(this.checkBoxEx10);
            this.MianPanel.Controls.Add(this.title1);
            this.MianPanel.Controls.Add(this.checkBoxEx7);
            this.MianPanel.Controls.Add(this.title2);
            this.MianPanel.Controls.Add(this.checkBoxEx6);
            this.MianPanel.Controls.Add(this.chk_Temp1);
            this.MianPanel.Controls.Add(this.checkBoxEx9);
            this.MianPanel.Controls.Add(this.chk_himidity1);
            this.MianPanel.Controls.Add(this.checkBoxEx3);
            this.MianPanel.Controls.Add(this.checkBoxEx5);
            this.MianPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MianPanel.Location = new System.Drawing.Point(0, 0);
            this.MianPanel.Name = "MianPanel";
            this.MianPanel.Size = new System.Drawing.Size(1392, 609);
            this.MianPanel.TabIndex = 7;
            // 
            // list_info
            // 
            this.list_info.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.list_info.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.list_info.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.list_info.ForeColor = System.Drawing.Color.White;
            this.list_info.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.list_info.HideSelection = false;
            this.list_info.HoverSelection = true;
            this.list_info.Location = new System.Drawing.Point(660, 445);
            this.list_info.Name = "list_info";
            this.list_info.ShowItemToolTips = true;
            this.list_info.Size = new System.Drawing.Size(701, 148);
            this.list_info.SmallImageList = this.imageList1;
            this.list_info.TabIndex = 5;
            this.list_info.UseCompatibleStateImageBehavior = false;
            this.list_info.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "日志时间";
            this.columnHeader1.Width = 200;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "日志内容";
            this.columnHeader2.Width = 200;
            // 
            // thmControl15
            // 
            this.thmControl15.BackColor = System.Drawing.Color.Transparent;
            this.thmControl15.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl15.Humidity = "0.0";
            this.thmControl15.HumidityVarName = "模块5湿度";
            this.thmControl15.Location = new System.Drawing.Point(328, 208);
            this.thmControl15.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl15.ModuleError = false;
            this.thmControl15.Name = "thmControl15";
            this.thmControl15.Size = new System.Drawing.Size(308, 200);
            this.thmControl15.StateVarName = "模块5状态";
            this.thmControl15.TabIndex = 0;
            this.thmControl15.Temp = "0.0";
            this.thmControl15.TempVarName = "模块5温度";
            this.thmControl15.Title = "5#站点";
            // 
            // Chart_ActualTrend
            // 
            this.Chart_ActualTrend.AxisX.AutoScale = false;
            this.Chart_ActualTrend.AxisX.AutoZoomReset = false;
            this.Chart_ActualTrend.AxisX.Color = System.Drawing.Color.White;
            this.Chart_ActualTrend.AxisX.InitWithScaleView = false;
            this.Chart_ActualTrend.AxisX.IsLogarithmic = false;
            this.Chart_ActualTrend.AxisX.LabelAngle = 0;
            this.Chart_ActualTrend.AxisX.LabelEnabled = true;
            this.Chart_ActualTrend.AxisX.LabelFormat = null;
            this.Chart_ActualTrend.AxisX.MajorGridColor = System.Drawing.Color.White;
            this.Chart_ActualTrend.AxisX.MajorGridCount = 5;
            this.Chart_ActualTrend.AxisX.MajorGridEnabled = true;
            this.Chart_ActualTrend.AxisX.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualTrend.AxisX.Maximum = 1000D;
            this.Chart_ActualTrend.AxisX.Minimum = 0D;
            this.Chart_ActualTrend.AxisX.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisX.MinorGridEnabled = false;
            this.Chart_ActualTrend.AxisX.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualTrend.AxisX.TickWidth = 1F;
            this.Chart_ActualTrend.AxisX.Title = "";
            this.Chart_ActualTrend.AxisX.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualTrend.AxisX.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualTrend.AxisX.ViewMaximum = 1000D;
            this.Chart_ActualTrend.AxisX.ViewMinimum = 0D;
            this.Chart_ActualTrend.AxisX2.AutoScale = false;
            this.Chart_ActualTrend.AxisX2.AutoZoomReset = false;
            this.Chart_ActualTrend.AxisX2.Color = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisX2.InitWithScaleView = false;
            this.Chart_ActualTrend.AxisX2.IsLogarithmic = false;
            this.Chart_ActualTrend.AxisX2.LabelAngle = 0;
            this.Chart_ActualTrend.AxisX2.LabelEnabled = true;
            this.Chart_ActualTrend.AxisX2.LabelFormat = null;
            this.Chart_ActualTrend.AxisX2.MajorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisX2.MajorGridCount = 6;
            this.Chart_ActualTrend.AxisX2.MajorGridEnabled = true;
            this.Chart_ActualTrend.AxisX2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualTrend.AxisX2.Maximum = 1000D;
            this.Chart_ActualTrend.AxisX2.Minimum = 0D;
            this.Chart_ActualTrend.AxisX2.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisX2.MinorGridEnabled = false;
            this.Chart_ActualTrend.AxisX2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualTrend.AxisX2.TickWidth = 1F;
            this.Chart_ActualTrend.AxisX2.Title = "";
            this.Chart_ActualTrend.AxisX2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualTrend.AxisX2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualTrend.AxisX2.ViewMaximum = 1000D;
            this.Chart_ActualTrend.AxisX2.ViewMinimum = 0D;
            this.Chart_ActualTrend.AxisY.AutoScale = true;
            this.Chart_ActualTrend.AxisY.AutoZoomReset = false;
            this.Chart_ActualTrend.AxisY.Color = System.Drawing.Color.White;
            this.Chart_ActualTrend.AxisY.InitWithScaleView = false;
            this.Chart_ActualTrend.AxisY.IsLogarithmic = false;
            this.Chart_ActualTrend.AxisY.LabelAngle = 0;
            this.Chart_ActualTrend.AxisY.LabelEnabled = true;
            this.Chart_ActualTrend.AxisY.LabelFormat = null;
            this.Chart_ActualTrend.AxisY.MajorGridColor = System.Drawing.Color.White;
            this.Chart_ActualTrend.AxisY.MajorGridCount = 6;
            this.Chart_ActualTrend.AxisY.MajorGridEnabled = true;
            this.Chart_ActualTrend.AxisY.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualTrend.AxisY.Maximum = 3D;
            this.Chart_ActualTrend.AxisY.Minimum = 0D;
            this.Chart_ActualTrend.AxisY.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisY.MinorGridEnabled = false;
            this.Chart_ActualTrend.AxisY.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualTrend.AxisY.TickWidth = 1F;
            this.Chart_ActualTrend.AxisY.Title = "";
            this.Chart_ActualTrend.AxisY.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualTrend.AxisY.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualTrend.AxisY.ViewMaximum = 3.5D;
            this.Chart_ActualTrend.AxisY.ViewMinimum = 0.5D;
            this.Chart_ActualTrend.AxisY2.AutoScale = true;
            this.Chart_ActualTrend.AxisY2.AutoZoomReset = false;
            this.Chart_ActualTrend.AxisY2.Color = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisY2.InitWithScaleView = false;
            this.Chart_ActualTrend.AxisY2.IsLogarithmic = false;
            this.Chart_ActualTrend.AxisY2.LabelAngle = 0;
            this.Chart_ActualTrend.AxisY2.LabelEnabled = true;
            this.Chart_ActualTrend.AxisY2.LabelFormat = null;
            this.Chart_ActualTrend.AxisY2.MajorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisY2.MajorGridCount = 6;
            this.Chart_ActualTrend.AxisY2.MajorGridEnabled = true;
            this.Chart_ActualTrend.AxisY2.MajorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.Dash;
            this.Chart_ActualTrend.AxisY2.Maximum = 3.5D;
            this.Chart_ActualTrend.AxisY2.Minimum = 0.5D;
            this.Chart_ActualTrend.AxisY2.MinorGridColor = System.Drawing.Color.Black;
            this.Chart_ActualTrend.AxisY2.MinorGridEnabled = false;
            this.Chart_ActualTrend.AxisY2.MinorGridType = SeeSharpTools.JY.GUI.StripChartXAxis.GridStyle.DashDot;
            this.Chart_ActualTrend.AxisY2.TickWidth = 1F;
            this.Chart_ActualTrend.AxisY2.Title = "";
            this.Chart_ActualTrend.AxisY2.TitleOrientation = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextOrientation.Auto;
            this.Chart_ActualTrend.AxisY2.TitlePosition = SeeSharpTools.JY.GUI.StripChartXAxis.AxisTextPosition.Center;
            this.Chart_ActualTrend.AxisY2.ViewMaximum = 3.5D;
            this.Chart_ActualTrend.AxisY2.ViewMinimum = 0.5D;
            this.Chart_ActualTrend.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.Chart_ActualTrend.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Chart_ActualTrend.ChartAreaBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(5)))), ((int)(((byte)(28)))), ((int)(((byte)(68)))));
            this.Chart_ActualTrend.Direction = SeeSharpTools.JY.GUI.StripChartX.ScrollDirection.LeftToRight;
            this.Chart_ActualTrend.DisplayPoints = 4000;
            this.Chart_ActualTrend.Font = new System.Drawing.Font("微软雅黑", 11F);
            this.Chart_ActualTrend.ForeColor = System.Drawing.Color.White;
            this.Chart_ActualTrend.GradientStyle = SeeSharpTools.JY.GUI.StripChartX.ChartGradientStyle.None;
            this.Chart_ActualTrend.LegendBackColor = System.Drawing.Color.Transparent;
            this.Chart_ActualTrend.LegendFont = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Chart_ActualTrend.LegendForeColor = System.Drawing.Color.White;
            this.Chart_ActualTrend.LegendVisible = true;
            stripChartXSeries1.Color = System.Drawing.Color.Red;
            stripChartXSeries1.Marker = SeeSharpTools.JY.GUI.StripChartXSeries.MarkerType.None;
            stripChartXSeries1.Name = "1#号站点温度";
            stripChartXSeries1.Type = SeeSharpTools.JY.GUI.StripChartXSeries.LineType.FastLine;
            stripChartXSeries1.Visible = true;
            stripChartXSeries1.Width = SeeSharpTools.JY.GUI.StripChartXSeries.LineWidth.Thin;
            stripChartXSeries1.XPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            stripChartXSeries1.YPlotAxis = SeeSharpTools.JY.GUI.StripChartXAxis.PlotAxis.Primary;
            this.Chart_ActualTrend.LineSeries.Add(stripChartXSeries1);
            this.Chart_ActualTrend.Location = new System.Drawing.Point(660, 45);
            this.Chart_ActualTrend.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Chart_ActualTrend.Miscellaneous.CheckInfinity = false;
            this.Chart_ActualTrend.Miscellaneous.CheckNaN = false;
            this.Chart_ActualTrend.Miscellaneous.CheckNegtiveOrZero = false;
            this.Chart_ActualTrend.Miscellaneous.DirectionChartCount = 3;
            this.Chart_ActualTrend.Miscellaneous.Fitting = SeeSharpTools.JY.GUI.StripChartX.FitType.Range;
            this.Chart_ActualTrend.Miscellaneous.MaxSeriesCount = 32;
            this.Chart_ActualTrend.Miscellaneous.MaxSeriesPointCount = 4000;
            this.Chart_ActualTrend.Miscellaneous.SplitLayoutColumnInterval = 0F;
            this.Chart_ActualTrend.Miscellaneous.SplitLayoutDirection = SeeSharpTools.JY.GUI.StripChartXUtility.LayoutDirection.LeftToRight;
            this.Chart_ActualTrend.Miscellaneous.SplitLayoutRowInterval = 0F;
            this.Chart_ActualTrend.Miscellaneous.SplitViewAutoLayout = true;
            this.Chart_ActualTrend.Name = "Chart_ActualTrend";
            this.Chart_ActualTrend.NextTimeStamp = new System.DateTime(((long)(0)));
            this.Chart_ActualTrend.ScrollType = SeeSharpTools.JY.GUI.StripChartX.StripScrollType.Cumulation;
            this.Chart_ActualTrend.SeriesCount = 1;
            this.Chart_ActualTrend.Size = new System.Drawing.Size(701, 238);
            this.Chart_ActualTrend.SplitView = false;
            this.Chart_ActualTrend.StartIndex = 0;
            this.Chart_ActualTrend.TabIndex = 4;
            this.Chart_ActualTrend.TimeInterval = System.TimeSpan.Parse("00:00:00");
            this.Chart_ActualTrend.TimeStampFormat = null;
            this.Chart_ActualTrend.XCursor.AutoInterval = true;
            this.Chart_ActualTrend.XCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.Chart_ActualTrend.XCursor.Interval = 0.001D;
            this.Chart_ActualTrend.XCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Zoom;
            this.Chart_ActualTrend.XCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.Chart_ActualTrend.XCursor.Value = double.NaN;
            this.Chart_ActualTrend.XDataType = SeeSharpTools.JY.GUI.StripChartX.XAxisDataType.Index;
            this.Chart_ActualTrend.YCursor.AutoInterval = true;
            this.Chart_ActualTrend.YCursor.Color = System.Drawing.Color.DeepSkyBlue;
            this.Chart_ActualTrend.YCursor.Interval = 0.001D;
            this.Chart_ActualTrend.YCursor.Mode = SeeSharpTools.JY.GUI.StripChartXCursor.CursorMode.Disabled;
            this.Chart_ActualTrend.YCursor.SelectionColor = System.Drawing.Color.LightGray;
            this.Chart_ActualTrend.YCursor.Value = double.NaN;
            // 
            // thmControl11
            // 
            this.thmControl11.BackColor = System.Drawing.Color.Transparent;
            this.thmControl11.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl11.Humidity = "0.0";
            this.thmControl11.HumidityVarName = "模块1湿度";
            this.thmControl11.Location = new System.Drawing.Point(12, 10);
            this.thmControl11.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl11.ModuleError = false;
            this.thmControl11.Name = "thmControl11";
            this.thmControl11.Size = new System.Drawing.Size(308, 200);
            this.thmControl11.StateVarName = "模块1状态";
            this.thmControl11.TabIndex = 0;
            this.thmControl11.Temp = "0.0";
            this.thmControl11.TempVarName = "模块1温度";
            this.thmControl11.Title = "1#站点";
            // 
            // checkBoxEx12
            // 
            this.checkBoxEx12.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx12.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx12.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx12.DefaultChackBoxWidth = 16;
            this.checkBoxEx12.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx12.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx12.Location = new System.Drawing.Point(1206, 366);
            this.checkBoxEx12.Name = "checkBoxEx12";
            this.checkBoxEx12.Size = new System.Drawing.Size(155, 32);
            this.checkBoxEx12.TabIndex = 2;
            this.checkBoxEx12.Tag = "11";
            this.checkBoxEx12.Text = "6号站点含氧量";
            this.checkBoxEx12.UseVisualStyleBackColor = false;
            this.checkBoxEx12.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // thmControl12
            // 
            this.thmControl12.BackColor = System.Drawing.Color.Transparent;
            this.thmControl12.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl12.Humidity = "0.0";
            this.thmControl12.HumidityVarName = "模块2湿度";
            this.thmControl12.Location = new System.Drawing.Point(12, 208);
            this.thmControl12.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl12.ModuleError = false;
            this.thmControl12.Name = "thmControl12";
            this.thmControl12.Size = new System.Drawing.Size(308, 200);
            this.thmControl12.StateVarName = "模块2状态";
            this.thmControl12.TabIndex = 0;
            this.thmControl12.Temp = "0.0";
            this.thmControl12.TempVarName = "模块2温度";
            this.thmControl12.Title = "2#站点";
            // 
            // checkBoxEx8
            // 
            this.checkBoxEx8.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx8.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx8.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx8.DefaultChackBoxWidth = 16;
            this.checkBoxEx8.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx8.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx8.Location = new System.Drawing.Point(1206, 329);
            this.checkBoxEx8.Name = "checkBoxEx8";
            this.checkBoxEx8.Size = new System.Drawing.Size(155, 32);
            this.checkBoxEx8.TabIndex = 2;
            this.checkBoxEx8.Tag = "7";
            this.checkBoxEx8.Text = "4号站点含氧量";
            this.checkBoxEx8.UseVisualStyleBackColor = false;
            this.checkBoxEx8.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // thmControl14
            // 
            this.thmControl14.BackColor = System.Drawing.Color.Transparent;
            this.thmControl14.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl14.Humidity = "0.0";
            this.thmControl14.HumidityVarName = "模块4湿度";
            this.thmControl14.Location = new System.Drawing.Point(328, 10);
            this.thmControl14.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl14.ModuleError = false;
            this.thmControl14.Name = "thmControl14";
            this.thmControl14.Size = new System.Drawing.Size(308, 200);
            this.thmControl14.StateVarName = "模块4状态";
            this.thmControl14.TabIndex = 0;
            this.thmControl14.Temp = "0.0";
            this.thmControl14.TempVarName = "模块4温度";
            this.thmControl14.Title = "4#站点";
            // 
            // checkBoxEx4
            // 
            this.checkBoxEx4.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx4.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx4.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx4.DefaultChackBoxWidth = 16;
            this.checkBoxEx4.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx4.Location = new System.Drawing.Point(1206, 291);
            this.checkBoxEx4.Name = "checkBoxEx4";
            this.checkBoxEx4.Size = new System.Drawing.Size(155, 32);
            this.checkBoxEx4.TabIndex = 2;
            this.checkBoxEx4.Tag = "3";
            this.checkBoxEx4.Text = "2号站点含氧量";
            this.checkBoxEx4.UseVisualStyleBackColor = false;
            this.checkBoxEx4.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // thmControl13
            // 
            this.thmControl13.BackColor = System.Drawing.Color.Transparent;
            this.thmControl13.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl13.Humidity = "0.0";
            this.thmControl13.HumidityVarName = "模块3湿度";
            this.thmControl13.Location = new System.Drawing.Point(12, 406);
            this.thmControl13.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl13.ModuleError = false;
            this.thmControl13.Name = "thmControl13";
            this.thmControl13.Size = new System.Drawing.Size(308, 200);
            this.thmControl13.StateVarName = "模块3状态";
            this.thmControl13.TabIndex = 0;
            this.thmControl13.Temp = "0.0";
            this.thmControl13.TempVarName = "模块3温度";
            this.thmControl13.Title = "3#站点";
            // 
            // checkBoxEx11
            // 
            this.checkBoxEx11.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx11.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx11.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx11.DefaultChackBoxWidth = 16;
            this.checkBoxEx11.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx11.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx11.Location = new System.Drawing.Point(1024, 366);
            this.checkBoxEx11.Name = "checkBoxEx11";
            this.checkBoxEx11.Size = new System.Drawing.Size(127, 32);
            this.checkBoxEx11.TabIndex = 2;
            this.checkBoxEx11.Tag = "10";
            this.checkBoxEx11.Text = "6号站点温度";
            this.checkBoxEx11.UseVisualStyleBackColor = false;
            this.checkBoxEx11.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // thmControl16
            // 
            this.thmControl16.BackColor = System.Drawing.Color.Transparent;
            this.thmControl16.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.thmControl16.Humidity = "0";
            this.thmControl16.HumidityVarName = "模块6湿度";
            this.thmControl16.Location = new System.Drawing.Point(328, 406);
            this.thmControl16.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.thmControl16.ModuleError = false;
            this.thmControl16.Name = "thmControl16";
            this.thmControl16.Size = new System.Drawing.Size(308, 200);
            this.thmControl16.StateVarName = "模块6状态";
            this.thmControl16.TabIndex = 0;
            this.thmControl16.Temp = "0";
            this.thmControl16.TempVarName = "模块6温度";
            this.thmControl16.Title = "6#站点";
            // 
            // checkBoxEx10
            // 
            this.checkBoxEx10.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx10.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx10.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx10.DefaultChackBoxWidth = 16;
            this.checkBoxEx10.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx10.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx10.Location = new System.Drawing.Point(842, 366);
            this.checkBoxEx10.Name = "checkBoxEx10";
            this.checkBoxEx10.Size = new System.Drawing.Size(148, 32);
            this.checkBoxEx10.TabIndex = 2;
            this.checkBoxEx10.Tag = "9";
            this.checkBoxEx10.Text = "5号站点含氧量";
            this.checkBoxEx10.UseVisualStyleBackColor = false;
            this.checkBoxEx10.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title1
            // 
            this.title1.BackColor = System.Drawing.Color.Transparent;
            this.title1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title1.BackgroundImage")));
            this.title1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title1.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title1.Location = new System.Drawing.Point(688, 4);
            this.title1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title1.Name = "title1";
            this.title1.Size = new System.Drawing.Size(109, 31);
            this.title1.TabIndex = 1;
            this.title1.TitleNiame = "实时趋势";
            // 
            // checkBoxEx7
            // 
            this.checkBoxEx7.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx7.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx7.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx7.DefaultChackBoxWidth = 16;
            this.checkBoxEx7.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx7.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx7.Location = new System.Drawing.Point(1024, 329);
            this.checkBoxEx7.Name = "checkBoxEx7";
            this.checkBoxEx7.Size = new System.Drawing.Size(127, 32);
            this.checkBoxEx7.TabIndex = 2;
            this.checkBoxEx7.Tag = "6";
            this.checkBoxEx7.Text = "4号站点温度";
            this.checkBoxEx7.UseVisualStyleBackColor = false;
            this.checkBoxEx7.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // title2
            // 
            this.title2.BackColor = System.Drawing.Color.Transparent;
            this.title2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("title2.BackgroundImage")));
            this.title2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.title2.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title2.Location = new System.Drawing.Point(688, 406);
            this.title2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.title2.Name = "title2";
            this.title2.Size = new System.Drawing.Size(109, 31);
            this.title2.TabIndex = 1;
            this.title2.TitleNiame = "系统日志";
            // 
            // checkBoxEx6
            // 
            this.checkBoxEx6.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx6.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx6.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx6.DefaultChackBoxWidth = 16;
            this.checkBoxEx6.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx6.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx6.Location = new System.Drawing.Point(842, 329);
            this.checkBoxEx6.Name = "checkBoxEx6";
            this.checkBoxEx6.Size = new System.Drawing.Size(148, 32);
            this.checkBoxEx6.TabIndex = 2;
            this.checkBoxEx6.Tag = "5";
            this.checkBoxEx6.Text = "3号站点含氧量";
            this.checkBoxEx6.UseVisualStyleBackColor = false;
            this.checkBoxEx6.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_Temp1
            // 
            this.chk_Temp1.BackColor = System.Drawing.Color.Transparent;
            this.chk_Temp1.CheckBackColor = System.Drawing.Color.White;
            this.chk_Temp1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_Temp1.DefaultChackBoxWidth = 16;
            this.chk_Temp1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chk_Temp1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chk_Temp1.Location = new System.Drawing.Point(660, 291);
            this.chk_Temp1.Name = "chk_Temp1";
            this.chk_Temp1.Size = new System.Drawing.Size(127, 32);
            this.chk_Temp1.TabIndex = 2;
            this.chk_Temp1.Tag = "0";
            this.chk_Temp1.Text = "1号站点温度";
            this.chk_Temp1.UseVisualStyleBackColor = false;
            this.chk_Temp1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx9
            // 
            this.checkBoxEx9.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx9.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx9.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx9.DefaultChackBoxWidth = 16;
            this.checkBoxEx9.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx9.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx9.Location = new System.Drawing.Point(660, 366);
            this.checkBoxEx9.Name = "checkBoxEx9";
            this.checkBoxEx9.Size = new System.Drawing.Size(127, 32);
            this.checkBoxEx9.TabIndex = 2;
            this.checkBoxEx9.Tag = "8";
            this.checkBoxEx9.Text = "5号站点温度";
            this.checkBoxEx9.UseVisualStyleBackColor = false;
            this.checkBoxEx9.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // chk_himidity1
            // 
            this.chk_himidity1.BackColor = System.Drawing.Color.Transparent;
            this.chk_himidity1.CheckBackColor = System.Drawing.Color.White;
            this.chk_himidity1.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.chk_himidity1.DefaultChackBoxWidth = 16;
            this.chk_himidity1.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.chk_himidity1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.chk_himidity1.Location = new System.Drawing.Point(842, 291);
            this.chk_himidity1.Name = "chk_himidity1";
            this.chk_himidity1.Size = new System.Drawing.Size(148, 32);
            this.chk_himidity1.TabIndex = 2;
            this.chk_himidity1.Tag = "1";
            this.chk_himidity1.Text = "1号站点含氧量";
            this.chk_himidity1.UseVisualStyleBackColor = false;
            this.chk_himidity1.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx3
            // 
            this.checkBoxEx3.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx3.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx3.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx3.DefaultChackBoxWidth = 16;
            this.checkBoxEx3.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx3.Location = new System.Drawing.Point(1024, 291);
            this.checkBoxEx3.Name = "checkBoxEx3";
            this.checkBoxEx3.Size = new System.Drawing.Size(127, 32);
            this.checkBoxEx3.TabIndex = 2;
            this.checkBoxEx3.Tag = "2";
            this.checkBoxEx3.Text = "2号站点温度";
            this.checkBoxEx3.UseVisualStyleBackColor = false;
            this.checkBoxEx3.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // checkBoxEx5
            // 
            this.checkBoxEx5.BackColor = System.Drawing.Color.Transparent;
            this.checkBoxEx5.CheckBackColor = System.Drawing.Color.White;
            this.checkBoxEx5.CheckColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(25)))), ((int)(((byte)(66)))));
            this.checkBoxEx5.DefaultChackBoxWidth = 16;
            this.checkBoxEx5.Font = new System.Drawing.Font("微软雅黑", 10F);
            this.checkBoxEx5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.checkBoxEx5.Location = new System.Drawing.Point(660, 329);
            this.checkBoxEx5.Name = "checkBoxEx5";
            this.checkBoxEx5.Size = new System.Drawing.Size(127, 32);
            this.checkBoxEx5.TabIndex = 2;
            this.checkBoxEx5.Tag = "4";
            this.checkBoxEx5.Text = "3号站点温度";
            this.checkBoxEx5.UseVisualStyleBackColor = false;
            this.checkBoxEx5.CheckedChanged += new System.EventHandler(this.chk_Common_CheckedChanged);
            // 
            // FrmMonitor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1392, 609);
            this.Controls.Add(this.MianPanel);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "FrmMonitor";
            this.Text = "集中监控";
            this.MianPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private KWDMHTUserLib.THMControl1 thmControl11;
        private KWDMHTUserLib.THMControl1 thmControl12;
        private KWDMHTUserLib.THMControl1 thmControl13;
        private KWDMHTUserLib.THMControl1 thmControl14;
        private KWDMHTUserLib.THMControl1 thmControl15;
        private KWDMHTUserLib.THMControl1 thmControl16;
        private KWDMHTUserLib.Title title1;
        private KWDMHTUserLib.Title title2;
        private KWDMHTUserLib.CheckBoxEx chk_Temp1;
        private SeeSharpTools.JY.GUI.StripChartX Chart_ActualTrend;
        private KWDMHTUserLib.CheckBoxEx chk_himidity1;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx3;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx4;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx5;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx6;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx7;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx8;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx9;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx10;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx11;
        private KWDMHTUserLib.CheckBoxEx checkBoxEx12;
        private System.Windows.Forms.ListView list_info;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private KWDMHTUserLib.PanelEnhanced MianPanel;
        private System.Windows.Forms.ColumnHeader columnHeader1;
    }
}
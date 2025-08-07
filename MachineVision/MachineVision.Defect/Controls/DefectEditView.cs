using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Shared.Controls;
using MachineVision.Shared.Extensions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace MachineVision.Defect.Controls
{
    /// <summary>
    /// 自定义控件直接新建一个类继承Control然后再新建一个资源字典跟当前类一样就行了对应视频62  根据63还要添加到资源字典Themes\Generic当中
    /// </summary>
    public class DefectEditView : System.Windows.Controls.Control
    {

        #region 缺陷结果



        public InspectionResult Result
        {
            get { return (InspectionResult)GetValue(ResultProperty); }
            set { SetValue(ResultProperty, value); }
        }

        public static readonly DependencyProperty ResultProperty =
            DependencyProperty.Register("Result", typeof(InspectionResult), typeof(DefectEditView), new PropertyMetadata(DefectResultCallBack));

        public static void DefectResultCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DefectEditView view)
            {
                view.ClearHDrawingObjects();
                view.DisplayDefectResult();
            }
        }
        /// <summary>
        /// 显示图像的缺陷检测结果
        /// </summary>
        private void DisplayDefectResult()
        {
            if (Result != null && Result.ContextResults != null)
            {
                if (Result.IsSuccess)
                {
                    txtMsg.Foreground = System.Windows.Media.Brushes.Green;
                    txtMsg.Text = "OK, 耗时: "+Result.TimeSpan+"ms";
                }
                else
                {
                    txtMsg.Foreground = System.Windows.Media.Brushes.Red;
                    txtMsg.Text = "NG, 耗时: " + Result.TimeSpan +"ms,"+ Result.Message;
                }
                foreach (var context in Result.ContextResults)
                {
                    //显示实际的检测区域
                    var location = context.Location;
                    HOperatorSet.GenRectangle1(out HObject rectangle, location.Y1, location.X1, location.Y2, location.X2);
                    HOperatorSet.GenContourRegionXld(rectangle, out HObject contours, "border");
                    rectangle?.Dispose();
                    HOperatorSet.SetColor(hWindow, "blue");
                    HOperatorSet.DispObj(contours, hWindow);
                    contours?.Dispose();

                    if (context.Render == null) return;

                    //显示亮缺陷
                    HOperatorSet.SetColor(hWindow, "green");
                    if (context.Render.Light != null)
                        hWindow.DispObj(context.Render.Light.Move(location.Y1, location.X1).GetRegionContour());

                    //显示暗缺陷
                    HOperatorSet.SetColor(hWindow, "red");
                    if (context.Render.Dark != null)
                        hWindow.DispObj(context.Render.Dark.Move(location.Y1, location.X1).GetRegionContour());
                }
            }
        }

        #endregion


        private HSmartWindowControlWPF hSmart { get; set; }
        private HWindow hWindow { get; set; }

        /// <summary> 
        /// ImageChangeCallBack 注入进去的值都为Hobject的类型 依赖属性的变化回调函数（PropertyChangedCallback）只会在调用 SetValue() 设置值时被触发
        /// </summary>
        public HObject Image
        {
            get { return (HObject)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        // 使用DependencyProperty作为Image的后备存储。它支持动画、样式、绑定等DependencyObject =propertyType DependencyPropertyChangedEventArgs=ImageEditView
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(HObject), typeof(DefectEditView), new PropertyMetadata(ImageChangeCallBack));

        public HObject MaskObject
        {
            get { return (HObject)GetValue(MaskObjectProperty); }
            set { SetValue(MaskObjectProperty, value); }
        }

        public static readonly DependencyProperty MaskObjectProperty =
            DependencyProperty.Register("MaskObject", typeof(HObject), typeof(DefectEditView), new PropertyMetadata(null));


        public HWindow HWindow
        {
            get { return (HWindow)GetValue(HWindowProperty); }
            set { SetValue(HWindowProperty, value); }
        }

        public static readonly DependencyProperty HWindowProperty =
            DependencyProperty.Register("HWindow", typeof(HWindow), typeof(DefectEditView), new PropertyMetadata(null));


        #region 缺陷检测相关



        public InspecRegionModel SelectedRegion
        {
            get { return (InspecRegionModel)GetValue(SelectedRegionProperty); }
            set { SetValue(SelectedRegionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedRegion.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedRegionProperty =
            DependencyProperty.Register("SelectedRegion", typeof(InspecRegionModel), typeof(DefectEditView), new PropertyMetadata(SelectedRegionModelChangeCallBack));



        public ObservableCollection<HDrawingObjectInfo> DrawingObjectInfos
        {
            get { return (ObservableCollection<HDrawingObjectInfo>)GetValue(DrawingObjectInfosProperty); }
            set { SetValue(DrawingObjectInfosProperty, value); }
        }
        /// <summary>
        /// PropertyMetadata  属性的默认值或当属性值改变时触发的回调函数
        /// </summary>
        public static readonly DependencyProperty DrawingObjectInfosProperty =
            DependencyProperty.Register("DrawingObjectInfos", typeof(ObservableCollection<HDrawingObjectInfo>), typeof(DefectEditView));

        public ProjectModel Model
        {
            get { return (ProjectModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(ProjectModel), typeof(DefectEditView), new PropertyMetadata(ModelChangeCallBack));



        public bool IsModelEditModel
        {
            get { return (bool)GetValue(IsModelEditModelProperty); }
            set { SetValue(IsModelEditModelProperty, value); }
        }

        public static readonly DependencyProperty IsModelEditModelProperty =
            DependencyProperty.Register("IsModelEditModel", typeof(bool), typeof(DefectEditView), new PropertyMetadata(IsModelEditModelChangeCallBack));



        public ICommand UpdateModelCommand
        {
            get { return (ICommand)GetValue(UpdateModelCommandProperty); }
            set { SetValue(UpdateModelCommandProperty, value); }
        }
        /// <summary>
        /// 自定义内部command绑定
        /// </summary>
        public static readonly DependencyProperty UpdateModelCommandProperty =
            DependencyProperty.Register("UpdateModelCommand", typeof(ICommand), typeof(DefectEditView));



        public ICommand UpdateRegionCommand
        {
            get { return (ICommand)GetValue(UpdateRegionCommandProperty); }
            set { SetValue(UpdateRegionCommandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for UpdateRegionCommand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty UpdateRegionCommandProperty =
            DependencyProperty.Register("UpdateRegionCommand", typeof(ICommand), typeof(DefectEditView));



        //----------------------------------------------------------------------------------------------------------------------------------------

        public static void SelectedRegionModelChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DefectEditView view && e.NewValue != null)
            {
                view.txtMsg.Text = $"当前选中区域{view.SelectedRegion.Name}";

                view.ClearHDrawingObjects();

                var setting = view.SelectedRegion.MatchSetting;
                if (setting.Y1 != 0 && setting.X1 != 0 && setting.Y2 != 0 && setting.X2 != 0)
                {
                    view.AttachDrawingObjectToWindow("red", setting.Y1, setting.X1, setting.Y2, setting.X2);
                }

                view.Menu_Refer.Visibility = Visibility.Collapsed;
                view.Menu_Update.Visibility = Visibility.Collapsed;
                view.Menu_Region.Visibility = Visibility.Visible;
                view.Menu_RegionUpdate.Visibility = Visibility.Visible;
            }
        }

        public static void IsModelEditModelChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ModelChangeCallBack(d, e);
        }
        /// <summary>
        /// 跨线程调用
        /// </summary>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public static void ModelChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DefectEditView view)
            {
                if (view.Image == null || view.Model == null) return;
                view.Menu_Refer.Visibility = Visibility.Visible;
                view.Menu_Update.Visibility = Visibility.Visible;
                view.ClearHDrawingObjects();
                view.RefreshProjectParameter();
            }
        }
        /// <summary>
        /// 刷新项目参数   如果是新项目的话就不做操作
        /// </summary>
        public void RefreshProjectParameter()
        {
            var refer = Model.ReferSetting;//项目的参考点数据
            if (refer != null)
            {
                if (refer.Y1 != 0 && refer.Y2 != 0 && refer.X1 != 0 && refer.X2 != 0)
                    AttachDrawingObjectToWindow("green", refer.Y1, refer.X1, refer.Y2, refer.X2);
            }
        }

        /// <summary>
        /// 把绘制的框框附加到界面上  改框框可进行推动改变
        /// </summary>
        /// <param name="color"></param>
        /// <param name="param"></param>
        public void AttachDrawingObjectToWindow(string color, params HTuple[] param)
        {
            //根据参考点的参数创建一个矩形
            var drawingObj = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, param);
            if (drawingObj == null) return;
            if (param[0] == param[2] && param[1] == param[3]) return;
            drawingObj.SetDrawingObjectParams("color", color);
            //缓存这个矩形参数
            var drawObjInfo = new HDrawingObjectInfo()
            {
                HDrawingObject = drawingObj,
                Color = color,
                HTuples = param
            };

            //绘制对象发生移动或者尺寸发送变化进行刷新
            drawingObj.OnDrag(OnDragDrawingObj);
            drawingObj.OnResize(OnResizeDrawingObj);

            DrawingObjectInfos.Add(drawObjInfo);

            //把绘制的框框固定到界面上
            hWindow.AttachDrawingObjectToWindow(drawingObj);
        }

        private void OnDragDrawingObj(HDrawingObject obj, HWindow hwin, string type)
        {
            RefreshDrawingObj(obj);
        }
        private void OnResizeDrawingObj(HDrawingObject obj, HWindow hwin, string type)
        {
            RefreshDrawingObj(obj);
        }
        /// <summary>
        /// 刷新绘制对象移动或尺寸参数
        /// </summary>
        /// <param name="obj"></param>
        private void RefreshDrawingObj(HDrawingObject obj)
        {
            if (obj == null) return;

            var hv_type = obj.GetDrawingObjectParams("type");
            var hv_tuple = obj.GetTuples(hv_type);

            var objInfo = DrawingObjectInfos.FirstOrDefault((q => q.HDrawingObject != null && q.HDrawingObject.ID == obj.ID));

            if (objInfo != null)
            {
                objInfo.HTuples = hv_tuple;
            }
        }

        private async void DrawReferRectangle(string color)
        {
            HTuple[] hTuples = new HTuple[4];
            if (Image == null) return;
            txtMsg.Text = "按鼠标左键绘制，右键结束。";
            HObject drawObj;
            HOperatorSet.GenEmptyObj(out drawObj);
            HOperatorSet.SetColor(hWindow, color);
            //绘制时取消缩放
            hSmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.Off;
            await Task.Run(() =>
            {
                HOperatorSet.DrawRectangle1(hWindow, out hTuples[0], out hTuples[1], out hTuples[2], out hTuples[3]);
                drawObj = hTuples.GenRectangle();
            });

            txtMsg.Text = string.Empty;
            hSmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.WheelForwardZoomsIn;

            if (drawObj != null)
            {
                //把控件绘制的形状全部储存到集合中

                //绘制轮廓 绘制可拖动的矩形轮廓
                AttachDrawingObjectToWindow(color, hTuples);
            }

        }

        #endregion

        public static void ImageChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DefectEditView view && e.NewValue != null)
            {
                view.Display((HObject)e.NewValue);
            }
        }
        public void Display(HObject hObject)
        {
            if (Image == null) return;
            hWindow.DispObj(hObject);
            hWindow.SetPart(0, 0, -2, -2);
        }


        /// <summary>
        /// 不直接在 foreach 中修改集合，避免运行时异常；
        /// projectList 是临时列表，用于过滤要删除的元素，不会打乱 DrawingObjectInfos 的迭代顺序；
        /// 删除的是原集合 DrawingObjectInfos 中的元素，释放资源并同步移除 UI 中的数据引用。
        /// </summary>
        public void ClearHDrawingObjects()
        {
            if (DrawingObjectInfos == null) return;

            //var projectList = DrawingObjectInfos.Where(q => q.Color == "red").ToList();

            for (int i = DrawingObjectInfos.Count - 1; i >= 0; i--)
            {
                //由于是地址引用界面上关联的也是当前的数据,释放他相当于释放界面上的数据
                var item = DrawingObjectInfos[i];
                item.HDrawingObject?.Dispose();

                DrawingObjectInfos.Remove(item);
            }
        }

        private MenuItem Menu_Refer, Menu_Update, Menu_Region, Menu_RegionUpdate;
        private TextBlock txtMsg;

        /// <summary>
        /// 初始化界面控件
        /// </summary>
        public override void OnApplyTemplate()
        {
            //能够加载ui控件对象
            txtMsg = (TextBlock)GetTemplateChild("PART_Msg");
            if (GetTemplateChild("PART_Smart") is HSmartWindowControlWPF hsmart)
            {
                this.hSmart = hsmart;
                this.hSmart.Loaded += HSmart_Loaded;
            }
            //新项目默认自己绘制参考点范围
            Menu_Refer = (MenuItem)GetTemplateChild("PART_Refer");
            Menu_Refer.Click += (s, e) =>
            {
                if (Image == null) return;
                DrawReferRectangle("green");
            };
            //更新参考点   控件内部command绑定外部
            Menu_Update = (MenuItem)GetTemplateChild("PART_Update");
            Menu_Update.Click += (s, e) =>
            {
                UpdateModelCommand?.Execute(this);
            };

            //绘制检测区域
            Menu_Region = (MenuItem)GetTemplateChild("PART_Region");
            Menu_Region.Click += (s, e) =>
            {
                if (Image == null) return;
                DrawReferRectangle("red");
            };
            //更新检测区域
            Menu_RegionUpdate = (MenuItem)GetTemplateChild("PART_UpdateRegion");
            Menu_RegionUpdate.Click += (s, e) =>
            {
                UpdateRegionCommand?.Execute(this);
            };

            var Menu_Clear = (MenuItem)GetTemplateChild("PART_Clear");
            Menu_Clear.Click += (s, e) =>
            {
                ClearHDrawingObjects();
            };
            base.OnApplyTemplate();
        }

        private void HSmart_Loaded(object sender, RoutedEventArgs e)
        {
            this.hWindow = hSmart.HalconWindow;
            HWindow = hWindow;
        }

    }
}

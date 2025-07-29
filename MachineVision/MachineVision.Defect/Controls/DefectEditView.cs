using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Models;
using MachineVision.Shared.Controls;
using MachineVision.Shared.Extensions;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MachineVision.Defect.Controls
{
    /// <summary>
    /// 自定义控件直接新建一个类继承Control然后再新建一个资源字典跟当前类一样就行了对应视频62  根据63还要添加到资源字典Themes\Generic当中
    /// </summary>
    public class DefectEditView : System.Windows.Controls.Control
    {

        private HSmartWindowControlWPF hSmart;
        private HWindow hWindow;
        private TextBlock txtMsg;

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



        //----------------------------------------------------------------------------------------------------------------------------------------


        public static void IsModelEditModelChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ModelChangeCallBack(d, e);
        }

        public static void ModelChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is DefectEditView view)
            {
                if (view.Image == null || view.Model == null) return;

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

            DrawingObjectInfos.Add(drawObjInfo); 

            //把绘制的框框固定到界面上
            hWindow.AttachDrawingObjectToWindow(drawingObj);
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

        private MenuItem Menu_Refer, Menu_Update;

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
            Menu_Refer.Click += async (s, e) =>
            {
                if (Image == null) return;
                DrawReferRectangle("green");
            };

            Menu_Update = (MenuItem)GetTemplateChild("PART_Update");
            Menu_Update.Click += (s, e) =>
            {
                UpdateModelCommand?.Execute(this);
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

using HalconDotNet;
using MachineVision.Defect.Models;
using MachineVision.Shared.Controls;
using MachineVision.Shared.Extensions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

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
            set { SetValue(ImageProperty, value); }//
        }

        // 使用DependencyProperty作为Image的后备存储。它支持动画、样式、绑定等DependencyObject =propertyType DependencyPropertyChangedEventArgs=ImageEditView
        public static readonly DependencyProperty ImageProperty =
            DependencyProperty.Register("Image", typeof(HObject), typeof(DefectEditView), new PropertyMetadata(ImageChangeCallBack));

        public HObject MaskObject
        {
            get { return (HObject)GetValue(MaskObjectProperty); }
            set { SetValue(MaskObjectProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MaskObject.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MaskObjectProperty =
            DependencyProperty.Register("MaskObject", typeof(HObject), typeof(DefectEditView), new PropertyMetadata(null));


        public HWindow HWindow
        {
            get { return (HWindow)GetValue(HWindowProperty); }
            set { SetValue(HWindowProperty, value); }
        }

        // Using a DependencyProperty as the backing store for HWindow.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty HWindowProperty =
            DependencyProperty.Register("HWindow", typeof(HWindow), typeof(DefectEditView), new PropertyMetadata(null));


        /// <summary>
        /// 基本用于自定义控件的属性参数设置或者传递  快捷键propdp  绘制的形状集合
        /// </summary>
        public ObservableCollection<DrawingObjectInfo> DrawObjectList
        {
            get { return (ObservableCollection<DrawingObjectInfo>)GetValue(DrawObjectListProperty); }
            set { SetValue(DrawObjectListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawObjectListProperty =
            DependencyProperty.Register("DrawObjectList", typeof(ObservableCollection<DrawingObjectInfo>), typeof(DefectEditView), new PropertyMetadata(new ObservableCollection<DrawingObjectInfo>()));



        #region 缺陷检测相关

        public ObservableCollection<HDrawingObjectInfo> DrawingObjectInfos
        {
            get { return (ObservableCollection<HDrawingObjectInfo>)GetValue(DrawingObjectInfosProperty); }
            set { SetValue(DrawingObjectInfosProperty, value); }
        }

        // Using a DependencyProperty as the backing store for DrawingObjectInfos.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawingObjectInfosProperty =
            DependencyProperty.Register("DrawingObjectInfos", typeof(ObservableCollection<HDrawingObjectInfo>), typeof(DefectEditView), new PropertyMetadata());

        public ProjectModel Model
        {
            get { return (ProjectModel)GetValue(ModelProperty); }
            set { SetValue(ModelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ModelProperty =
            DependencyProperty.Register("Model", typeof(ProjectModel), typeof(DefectEditView), new PropertyMetadata(ModelChangeCallBack));


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
                //根据参考点的参数创建一个矩形
                var drawingObj = HDrawingObject.CreateDrawingObject(HDrawingObject.HDrawingObjectType.RECTANGLE1, refer.Y1, refer.X1, refer.Y2, refer.X2);
                if (drawingObj != null) return;

                drawingObj.SetDrawingObjectParams("color", "green");
                //缓存这个矩形参数
                var drawObjInfo = new HDrawingObjectInfo()
                {
                    HDrawingObject = drawingObj,
                    Color = "green",
                    HTuples = new HTuple[] { refer.Y1, refer.X1, refer.Y2, refer.X2 }
                };

                DrawingObjectInfos.Add(drawObjInfo);

                hWindow.AttachDrawingObjectToWindow(drawingObj);
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
        private void HSmart_Loaded(object sender, RoutedEventArgs e)
        {
            this.hWindow = hSmart.HalconWindow;
            HWindow = hWindow;
        }

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
            if (GetTemplateChild("PART_Refer") is MenuItem Menu_Refer)
                Menu_Refer.Click += async (s, e) =>
                {
                    if (Image == null) return;
                    var htuples = await  DrawRectangle();
                    if (Model!=null)
                    {
                        var setting = Model.ReferSetting;
                        setting.Y1 = htuples[0];
                        setting.X1 = htuples[1];
                        setting.Y2 = htuples[2];
                        setting.X2 = htuples[3];
                    }
                };
            base.OnApplyTemplate();
        }

        private async Task<HTuple[]> DrawRectangle()
        {
            HTuple[] hTuples = new HTuple[4];
            if (Image == null) return hTuples;
            txtMsg.Text = "按鼠标左键绘制，右键结束。";
            HObject drawObj;
            HOperatorSet.GenEmptyObj(out drawObj);
            HOperatorSet.SetColor(hWindow, "red");
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
                DrawObjectList.Add(new DrawingObjectInfo()
                {
                    hTuples = hTuples,
                    ShapeType = ShapeType.Rectangle,
                    Hobject = drawObj
                });
                //绘制轮廓  获取对象的轮廓
                HOperatorSet.GenContourRegionXld(drawObj, out HObject contours, "border");
                HOperatorSet.DispObj(contours, hWindow);
            }

            return hTuples;
        }

    }
}

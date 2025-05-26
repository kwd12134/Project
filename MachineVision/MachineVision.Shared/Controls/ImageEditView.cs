using HalconDotNet;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Media3D;
using MachineVision.Shared.Extensions;
using System;
namespace MachineVision.Shared.Controls
{
    /// <summary>
    //它继承自 Control（而不是 UserControl）
    //它不直接包含 UI 元素，而是通过 OnApplyTemplate 绑定控件行为（响应点击、绘图等）
    /// </summary>
    public class ImageEditView : Control
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
            DependencyProperty.Register("Image", typeof(HObject), typeof(ImageEditView), new PropertyMetadata(ImageChangeCallBack));

        /// <summary>
        /// 基本用于自定义控件的属性参数设置或者传递
        /// </summary>
        public ObservableCollection<DrawingObjectInfo> DrawObjectList
        {
            get { return (ObservableCollection<DrawingObjectInfo>)GetValue(DrawObjectListProperty); }
            set { SetValue(DrawObjectListProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DrawObjectListProperty =
            DependencyProperty.Register("DrawObjectList", typeof(ObservableCollection<DrawingObjectInfo>), typeof(ImageEditView), new PropertyMetadata(new ObservableCollection<DrawingObjectInfo>()));


        public static void ImageChangeCallBack(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is ImageEditView view && e.NewValue != null)
            {
                view.Display((HObject)e.NewValue);
            }
        }

        public void Display(HObject hObject)
        {
            hWindow.DispObj(hObject);
            //hWindow.SetPart(0, 0, image.GetHeight() - 1, image.GetWidth() - 1);
            hWindow.SetPart(0, 0, -2, -2);
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
            //绘制矩形
            if (GetTemplateChild("PART_Rect") is Button BtnRect)
                BtnRect.Click += BtnRect_Click;
            if (GetTemplateChild("PART_Ellipse") is Button BtnEllipse)
                BtnEllipse.Click += BtnEllipse_Click;
            if (GetTemplateChild("PART_Circle") is Button BtnCircle)
                BtnCircle.Click += BtnCircle_Click;
            if (GetTemplateChild("PART_Region") is Button BtnRegion)
                BtnRegion.Click += BtnRegion_Click;
            if (GetTemplateChild("PART_Clear") is Button BtnClear)
                BtnClear.Click += (s, e) =>
                {
                    DrawObjectList.Clear();
                    hWindow.ClearWindow();
                    Display(Image);
                };
            base.OnApplyTemplate();
        }

        private void BtnRegion_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(ShapeType.Region);
        }

        private void BtnCircle_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(ShapeType.Circle, new HTuple(), new HTuple(), new HTuple());
            //HTuple row;
            //HTuple column;
            //HTuple radius;
            //HObject circleObject = null;
            //await Task.Run(() =>
            //{
            //    //此方法会堵塞线程
            //    HOperatorSet.SetColor(hWindow, "blue");
            //    HOperatorSet.DrawCircle(hWindow, out row, out column, out radius);
            //    HOperatorSet.GenCircle(out circleObject, row, column, radius);

            //    if (circleObject == null) return;

            //    //BeginInvoke 是异步调度，不会阻塞当前线程。
            //    this.Dispatcher.Invoke(() =>
            //    {
            //        // 这里写对主控件 UI 的访问逻辑
            //        txtMsg.Text = string.Empty;
            //        DrawObjectList.Add(new DrawingObjectInfo()
            //        {
            //            hTuples = new HTuple[] { row, column, radius },
            //            ShapeType = ShapeType.Circle
            //        });
            //    });
            //});
            //HOperatorSet.DispObj(circleObject, hWindow);
        }

        private void BtnEllipse_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(ShapeType.Ellipse, new HTuple(), new HTuple(), new HTuple(), new HTuple(), new HTuple());
        }

        private void BtnRect_Click(object sender, RoutedEventArgs e)
        {
            DrawShape(ShapeType.Rectangle, new HTuple(), new HTuple(), new HTuple(), new HTuple());
        }

        private void HSmart_Loaded(object sender, RoutedEventArgs e)
        {
            this.hWindow = hSmart.HalconWindow;
        }

        /// <summary>
        /// 绘制不同形状
        /// </summary>
        /// <param name="shapeType"></param>
        /// <param name="hTuples"></param>
        private async void DrawShape(ShapeType shapeType, params HTuple[] hTuples)
        {
            txtMsg.Text = "按鼠标左键绘制，右键结束。";
            HObject drawObj;
            HOperatorSet.GenEmptyObj(out drawObj);
            HOperatorSet.SetColor(hWindow, "red");
            //绘制时取消缩放
            hSmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.Off;
            await Task.Run(() =>
            {
                switch (shapeType)
                {
                    case ShapeType.Rectangle:
                        {
                            HOperatorSet.DrawRectangle1(hWindow, out hTuples[0], out hTuples[1], out hTuples[2], out hTuples[3]);
                            drawObj = hTuples.GenRectangle();
                            break;
                        }
                    case ShapeType.Ellipse:
                        {
                            HOperatorSet.DrawEllipse(hWindow, out hTuples[0], out hTuples[1], out hTuples[2], out hTuples[3], out hTuples[4]);
                            drawObj = hTuples.GenEllipse();
                            break;
                        }
                    case ShapeType.Circle:
                        {
                            HOperatorSet.DrawCircle(hWindow, out hTuples[0], out hTuples[1], out hTuples[2]);
                            drawObj = hTuples.GenCircle();
                            break;
                        }
                    case ShapeType.Region:
                        {
                            //绘制自定义区域
                            HOperatorSet.DrawRegion(out drawObj, hWindow);
                            break;
                        }
                }
            });
            txtMsg.Text = string.Empty;
            hSmart.HZoomContent = HSmartWindowControlWPF.ZoomContent.WheelForwardZoomsIn;
            if (drawObj != null)
            {
                DrawObjectList.Add(new DrawingObjectInfo()
                {
                    hTuples = hTuples,
                    ShapeType = shapeType,
                    Hobject = drawObj
                });
                HOperatorSet.DispObj(drawObj, hWindow);
            }
        }


    }
}

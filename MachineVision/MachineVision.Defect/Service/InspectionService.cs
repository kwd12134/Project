using HalconDotNet;
using MachineVision.Core.Extensions;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MachineVision.Defect.Service
{
    /*
    *  检测服务功能
    * 
    * 1. 根据输入的图像源，以及当前项目和需要待检测的区域数据
    * 2. 执行检测, 并且输出结果
    * 3. 针对检测产生的对象进行资源管理。 非托管资源释放
    * 4. 统一参数检测的结果数据
    */
    public class InspectionService
    {

        public readonly TargetService TargetService;
        public InspectionService(TargetService targetService)
        {
            this.TargetService = targetService;
        }

        /// <summary>
        /// 1. Parallel.For 示例：并行 for 循环
        /// Parallel.For(0, 10, i =>
        ///{
        ///    Console.WriteLine($"任务 {i} 正在由线程 {Thread.CurrentThread.ManagedThreadId} 执行");
        ///});
        /// Parallel.Invoke 示例：多个方法并行执行
        /// Parallel.Invoke
        /// (
        ///     () => ReadPLC1(),
        ///     () => ReadPLC2(),
        ///     () => StartCamera1(),
        ///     () => StartCamera2()
        /// );
        /// </summary>
        /// <param name="ImageSource"></param>
        /// <param name="Model"></param>
        /// <param name="RegionList"></param>
        /// <returns></returns>
        public InspectionResult ExecuteAsync(HObject ImageSource, ProjectModel Model, ObservableCollection<InspecRegionModel> RegionList)
        {
            //先查找基准点
            bool refer = TargetService.GetRefer(ImageSource, Model);
            InspectionResult result = new InspectionResult();
            result.ContextResults = new List<RegionContextResult>();
            if (refer)
            {
                var queues = new ConcurrentQueue<RegionContextResult>();
                result.TimeSpan = SetTimerHelper.SetTimer(() =>
                {
                    //它是 .NET 中的一个线程安全的队列类，位于 System.Collections.Concurrent 命名空间下
                    //特点是：多线程环境下不需要加锁就能安全使用。
                    //遵循先进先出（FIFO）原则。
                    //支持多个线程并发地 Enqueue()（入队） 和 TryDequeue()（出队）。
                    //对 RegionList 中的每一项 Item，使用多线程并行执行括号 {} 中的代码块，提高运行效率。
                    //Parallel.ForEach 是阻塞式执行，会等所有线程执行完毕后才继续往下走。
                    Parallel.ForEach(RegionList, Item =>
                    {
                        //根据基准点来计算出预取的图像
                        var checkImage = Item.GetInspectImage(ImageSource, Model.ReferSetting.Row, Model.ReferSetting.Column);
                        checkImage.SaveIamge("C:\\Users\\86153\\OneDrive\\图片\\Image\\test.bmp");
                        //执行检测服务算法
                        var ItemResult = Item.Context.Run(checkImage, Item);
                        if (!ItemResult.IsSuccess)
                        {
                            queues.Enqueue(ItemResult);
                        }
                    });
                });
                if (queues.Count > 0)
                {
                    foreach (var item in queues)
                    {
                        result.ContextResults.Add(item);
                    }
                }
                if (result.ContextResults.Count > 0)
                {
                    result.IsSuccess = false;
                    result.Message = $"存在: {result.ContextResults.Count}处缺陷";
                }
                else
                {
                    result.IsSuccess = true;
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "未匹配图像基准";
            }

            return result;

        }

        public InspectionResult Execute(HObject ImageSource, ProjectModel Model, ObservableCollection<InspecRegionModel> RegionList)
        {
            //先查找基准点
            bool refer = TargetService.GetRefer(ImageSource, Model);
            InspectionResult result = new InspectionResult();
            result.ContextResults = new List<RegionContextResult>();
            if (refer)
            {
                result.TimeSpan = SetTimerHelper.SetTimer(() =>
                {
                    foreach (var Item in RegionList)
                    {
                        var checkImage = Item.GetInspectImage(ImageSource, Model.ReferSetting.Row, Model.ReferSetting.Column);
                        var ItemResult = Item.Context.Run(checkImage, Item);
                        if (!ItemResult.IsSuccess)
                        {
                            result.ContextResults.Add(ItemResult);
                        }
                    }
                });

                if (result.ContextResults.Count > 0)
                {
                    result.IsSuccess = false;
                    result.Message = $"存在: {result.ContextResults.Count}处缺陷";
                }
                else
                {
                    result.IsSuccess = true;
                }
            }
            else
            {
                result.IsSuccess = false;
                result.Message = "未匹配图像基准";
            }
            return result;
        }

    }
}

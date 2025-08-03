using HalconDotNet;
using MachineVision.Defect.Extensions;
using MachineVision.Defect.Models;
using System;
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
        public async Task ExecuteAsync(HObject ImageSource, ProjectModel Model, ObservableCollection<InspecRegionModel> RegionList)
        {
            //先查找基准点
            bool refer = TargetService.GetRefer(ImageSource, Model);

            if (refer)
            {
                //对 RegionList 中的每一项 Item，使用多线程并行执行括号 {} 中的代码块，提高运行效率。
                Parallel.ForEach(RegionList, Item =>
                {
                    //根据基准点来计算出预取的图像
                    var checkImage = Item.GetInspectImage(ImageSource, Model.ReferSetting.Row, Model.ReferSetting.Column);

                    //执行检测服务算法
                    Item.Context.Run(checkImage,Item);
                });
            }
        }

    }
}

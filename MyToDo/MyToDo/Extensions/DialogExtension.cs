using MyToDo.Common.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyToDo.Extensions
{
    public static class DialogExtension
    {
        public static void UpdateLoading(this IEventAggregator aggregator,UpdateModel model)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Publish(model);
        }

        /// <summary>
        /// 注册等待消息
        /// </summary>
        /// <param name="aggregator"></param>
        /// <param name="action"></param>
        public static void Register(this IEventAggregator aggregator, Action<UpdateModel> action)
        {
            aggregator.GetEvent<UpdateLoadingEvent>().Subscribe(action);
        }
    }
}

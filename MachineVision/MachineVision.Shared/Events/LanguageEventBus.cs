using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace MachineVision.Shared.Events
{
    /// <summary>
    /// 发布/订阅 事件  自定义事件订阅与发布 具体实际在mianview与settingview当中
    /// </summary>
    public class LanguageEventBus:PubSubEvent<bool>
    {

    }
}

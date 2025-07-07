using Prism.Mvvm;

namespace MachineVision.Core.TemplateMatch.Shared
{
    /// <summary>
    /// 接口无法继承,所以使用基类来进行架构
    /// </summary>
    public class BaseParameter:BindableBase
    {
        public virtual void ApplyDefaultParameter() { }
    }
}

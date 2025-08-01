using AutoMapper;
using System;

namespace MachineVision.Shared.Services
{
    /// <summary>
    /// 自动映射
    /// 主要用途场景：
    /// DTO ↔ 实体类（Entity）转换
    /// 比如你在 WPF 项目中做 MVVM 或三层架构时，经常会有：
    /// 数据库实体类（Entity）
    /// 传输模型（DTO）
    /// ViewModel（用于绑定UI）
    /// 这些类结构相似，但不能直接混用，AutoMapper 就能让你不用手动赋值，自动完成这类转换。
    /// 目前就相当于Project与ProjectModel的自动转换
    /// </summary>
    public interface IAppMapper
    {
        IMapper Current { get; }
        T Map<T>(object source);
    }
    public class AppMapper : IAppMapper
    {
        public AppMapper()
        {
            var config = new MapperConfiguration(config =>
            {
                //AppDomain.CurrentDomain.GetAssemblies()：获取当前 AppDomain 中加载的所有程序集。
                var assembly = AppDomain.CurrentDomain.GetAssemblies();
                //config.AddMaps(assembly)：自动查找这些程序集里通过 [AutoMap] 特性、或者 Profile 注册过的映射配置类。
                config.AddMaps(assembly);
            });
            Current = config.CreateMapper();
        }

        public IMapper Current { get; }

        public T Map<T>(object source) => Current.Map<T>(source);
    }
}

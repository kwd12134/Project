using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace BL12.Model
{
    /// <summary>
    /// 依赖注入容器
    /// </summary>
    public static class ServiceLocator
    {
        /// <summary>
        /// 服务提供者
        /// </summary>
        private static ServiceProvider _serviceProvider;

        public static void Init(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        /// <summary>
        /// 每次获取注册的服务
        /// Transient：每次请求都会创建一个新的实例，适用于无状态服务。
        /// Scoped：   在同一个请求范围内共享实例，适用于基于请求的服务，如Web应用中的服务。
        /// Singleton：整个应用程序生命周期内共享同一个实例，适用于无状态且需要全局共享的服务。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T GetService<T>()
        {
            return _serviceProvider.GetService<T>();
        }
    }
}

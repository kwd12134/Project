using System;
using System.Diagnostics;

namespace MachineVision.Shared.Services
{
    public class BaseService
    {
        // 单例模式（Singleton） 确保整个程序只有一个 IFreeSql 实例，避免重复创建数据库连接，节省资源。
        //Lazy<T> 是 .NET 提供的延迟初始化类，确保 IFreeSql 实例只在第一次访问时才被创建
        //这样可以避免不必要的资源消耗，实现按需初始化
        static Lazy<IFreeSql> sqliteLazy = new Lazy<IFreeSql>(() =>
        {
            var fsql = new FreeSql.FreeSqlBuilder()
                .UseMonitorCommand(cmd => Trace.WriteLine($"Sql：{cmd.CommandText}"))
                .UseAdoConnectionPool(true)
                .UseConnectionString(FreeSql.DataType.Sqlite, @"Data Source=freedb.db")
                .UseAutoSyncStructure(true) //自动同步实体结构到数据库，只有CRUD时才会生成表
                .Build();
            return fsql;
        });
        public static IFreeSql Sqlite => sqliteLazy.Value;
    }
}

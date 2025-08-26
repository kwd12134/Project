using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyToDo.Api.Context
{
    /// <summary>
    /// 上下文
    /// </summary>
    public class MyToDoContext : DbContext
    {
        public MyToDoContext(DbContextOptions<MyToDoContext> options) : base(options)
        {

        }
        /// <summary>
        /// 实体
        /// </summary>
        public DbSet<ToDo> ToDo { get; set; }
        /// <summary>
        /// 实体
        /// </summary>
        public DbSet<User> User { get; set; }
        /// <summary>
        /// 实体
        /// </summary>
        public DbSet<Memo> Memo { get; set; }
    }
}

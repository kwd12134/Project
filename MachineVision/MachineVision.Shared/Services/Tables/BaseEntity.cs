using FreeSql.DataAnnotations;

namespace MachineVision.Shared.Services.Tables
{
    /// <summary>
    /// 架构
    /// </summary>
    public class BaseEntity
    {
        [Column(IsIdentity = true, IsPrimary = true)]
        public int Id { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Database.Base.Entities
{
    [Table("User")]
    public class UserEntity
    {
        //public Guid Id { get; set; } = Guid.NewGuid(); // 方式1：默认值
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自增
        public int Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public int HosipitalId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Database.Base.Entities
{
    [Table("Hospital")]
    public class HospitalEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]//自增
        public int Id { get; set; }

        public string Name { get; set; }
    }
}

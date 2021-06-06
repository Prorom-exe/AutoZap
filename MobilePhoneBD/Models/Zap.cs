using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneBD.Models
{
    public class Zap
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<Products> Products { get; set; }

        [ForeignKey("Auto")]
        public int AutoId { get; set; }
    }
}

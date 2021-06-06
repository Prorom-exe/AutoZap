using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneBD.Models
{
    public class Products
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public int Quality { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public string Link { get; set; }

        [ForeignKey("Auto")]
        public int AutoId { get; set; }

        public virtual Auto Category { get; set; }

        [ForeignKey("Zap")]
        public int ZapId { get; set; }

        public virtual Zap Zap { get; set; }

        public ICollection<Basket> Baskets { get; set; }
    }
}

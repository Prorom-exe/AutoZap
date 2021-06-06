using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneBD.Models.ViewMode
{
    public class IndexViewModel
    {
        public List<Products> Products { get; set; }

        public List<Auto> Category { get; set; }

        public CreateViewModel CreateViewModel { get; set; }

        public int Count { get; set; }
    }
}

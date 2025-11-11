using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coffee
{
    public class Coffee
    {
        public string Title { get; set; }
        public int Price { get; set; }
        public List<Addition> Additions { get; set; } = new List<Addition>();

    }
}

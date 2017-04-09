using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarSnap.Models
{
    public class TescoProduct
    {
        public string gtin { get; set; } = "";
        public string Description { get; set; } = "";
        public Dictionary<string, object> ProductCharacteristics { get; set; }
        public List<string> Ingredients { get; set; }
    }
}

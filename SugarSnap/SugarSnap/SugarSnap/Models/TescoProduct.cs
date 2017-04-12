using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SugarSnap.Models
{
    public class TescoProduct
    {
        public string Gtin { get; set; } = "";
        public string Description { get; set; } = "";
        public Dictionary<string, object> ProductCharacteristics { get; set; }
        public List<string> Ingredients { get; set; }
        public ProductNutrition CalcNutrition { get; set; }
        public Dictionary<string,object> QtyContents { get; set; }
    }

    public class ProductNutrition
    {
        public string Per100Header { get; set; }
        public string PerServingHeader { get; set; }
        public Dictionary<string,string>[] CalcNutrients { get; set; }
    }

}

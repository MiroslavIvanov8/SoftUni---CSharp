using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class ExportCategoriesByProductCountDto
    {
        public string Category { get; set; } = null!;

        public int ProductsCount { get; set; } 

        public string AveragePrice { get; set; } = null!;

        public string TotalRevenue { get; set; } = null!;
    

    }
}

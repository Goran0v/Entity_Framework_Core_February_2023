using ProductShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductShop.DTOs.Export
{
    public class ExportSoldProductsDto
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public ICollection<Product> SoldProducts { get; set; } = new HashSet<Product>();
    }
}

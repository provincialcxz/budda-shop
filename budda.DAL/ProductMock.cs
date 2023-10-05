using budda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace budda.DAL
{
    public class ProductMock
    {
        List<Product> products = new List<Product>
        {
            // dapper orm  https://habr.com/ru/articles/665836
            new Product { Id = 1, ProductName = "xyz1", Price = 999, Description = "xxx" },
            new Product { Id = 2, ProductName = "xyz2", Price = 999, Description = "yyy" },
            new Product { Id = 3, ProductName = "xyz3", Price = 999, Description = "zzz" }
        };
    }
}

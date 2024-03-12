using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_2.Common
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        public Product()
        {

        }
        public Product(int ID, string name, decimal price, int stock)
        {
            this.ID = ID;
            Name = name;
            Price = price;
            Stock = stock;
        }
    }
}

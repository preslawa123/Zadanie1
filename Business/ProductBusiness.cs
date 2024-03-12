using CRUD_2.Common;
using CRUD_2.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_2.Business
{
    public static class ProductBusiness
    {
        private static ProductData manager = new ProductData();
        public static List<Product>GetAll()
        {
            return manager.GetAll();
        }
        public static Product Get(int id)
        {
            return manager.Get(id);
        }
        public static void Add(Product product)
        {
            manager.Add(product);
        } 
        public static void Update(Product product) 
        {
            manager.Update(product);

        }
        public static void Delete(int id)
        {
            manager.Delete(id);
        }
    }
}

using CRUD_2.Business;
using CRUD_2.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_2.Presentation
{
    public class Display
    {
        private void Show()
        {
            Console.WriteLine(new string('-',40));
            Console.WriteLine(new string('-', 18) + "Menu" + new string(' ', 18));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List All entries");
            Console.WriteLine("2. Add new entry");
            Console.WriteLine("3. Update entry");
            Console.WriteLine("4. Fetch entry by ID");
            Console.WriteLine("5. Delete entry by ID");
            Console.WriteLine("6. Exit");
        }
        public void Input()
        {
            var operation = 0;
            do
            {
                Show();
                operation = int.Parse(Console.ReadLine());
                switch (operation)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default: break;
                }
            }
            while (operation != 6);
        }

        public Display()
        {
            Input();

        }


        public void Add()
        {
            Product product= new Product();
            Console.WriteLine("Enter name");
            product.Name= Console.ReadLine();
            Console.WriteLine("Enter price");
            product.Price = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Enter Stock");
            product.Stock = int.Parse(Console.ReadLine());
           ProductBusiness.Add(product); 
        }


        public void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string('-', 16) + "Menu" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            List<Product> products = ProductBusiness.GetAll();
            foreach(var item in products)
            {
                Console.WriteLine("{0} {1} {2} {3}", item.ID, item.Name, item.Price, item.Stock);
            }
        }


        public void Update()
        {
            Console.WriteLine("Enter ID to update");
            int id = int.Parse(Console.ReadLine());
            Product product= ProductBusiness.Get(id);
            if (product!= null)
            {
                Console.WriteLine("Enter name");
                product.Name= Console.ReadLine();
                Console.WriteLine("Enter price");
                product.Price= decimal.Parse(Console.ReadLine());
                Console.WriteLine("Enter Stock");
                product.Stock= int.Parse(Console.ReadLine());
                ProductBusiness.Update(product);
            }
            else
                Console.WriteLine("Product is not found");

        }

        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch");
            int id = int.Parse(Console.ReadLine());
            Product product= ProductBusiness.Get(id);
            if (product != null)
            {
                Console.WriteLine("ID" + product.ID);
                Console.WriteLine("Name" + product.Name);
                Console.WriteLine("Price" + product.Price);
                Console.WriteLine("Stock" + product.Stock);

            }
            else
                Console.WriteLine("Product is not found");
        }


        private void Delete()
        {
            Console.WriteLine("Enter ID tp delete");
            int id = int.Parse(Console.ReadLine());
            ProductBusiness.Delete(id);
            Console.WriteLine("Done");

        }
    }
}

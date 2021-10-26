using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAndShip
{
    class Program
    {
        static void Main(string[] args)
        {
            OnlineStore store = new OnlineStore();              
            store.products.Add(new Product(1.5f, "box", 15f));
            store.products.Add(new Product(105f, "dox", 25f));
            store.products.Add(new Product(80.5f, "fox", 5f));

            store.cartProducts.Add(store.GetProduct("box"));
            store.cartProducts.Add(store.GetProduct("dox"));
            List<Product> orderedProducts1 = store.Order();
            store.Shipping();
            store.CashDeleting();

            UsaWarehouse usa = new UsaWarehouse();
            UsaWarehouse.collection.AddRange(orderedProducts1);
            usa.Shipping();
            usa.CashDeleting();
            float MyCost = usa.Cost(orderedProducts1[0].Weight);
            Console.WriteLine(MyCost);

            store.cartProducts.Add(store.GetProduct("fox"));
            store.cartProducts.Add(store.GetProduct("fox"));
            List<Product> orderedProducts2 = store.Order();

            IShipService russia = new RussiaWarehouse();
            RussiaWarehouse.collection.AddRange(orderedProducts2);
            russia.Shipping();


            Console.Read();
        }
    }
}


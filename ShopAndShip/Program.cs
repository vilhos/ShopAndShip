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
            store.products.Add(new Product(1.5f, "box", 15f));    // adding products to store
            store.products.Add(new Product(105f, "dox", 25f));
            store.products.Add(new Product(80.5f, "fox", 5f));
            store.products.Add(new Product(80.5f, "mox", 7f));

            store.cartProducts.Add(store.GetProduct("box"));     // adding products to cart
            store.cartProducts.Add(store.GetProduct("dox"));
            List<Product> orderedProducts1 = store.Order();
            store.Shipping();                                    // dispatch of products 
            store.CashDeleting();                                // cleaning cache

            UsaWarehouse usa = new UsaWarehouse();
            UsaWarehouse.collection.AddRange(orderedProducts1);  // Acceptance of delivered products
            usa.Shipping();                                      
            usa.CashDeleting();                                  
            float MyCost = usa.Cost(orderedProducts1[0].Weight); // cost for one item delivery
            Console.WriteLine(MyCost);

            store.cartProducts.Add(store.GetProduct("fox"));
            store.cartProducts.Add(store.GetProduct("mox"));
            List<Product> orderedProducts2 = store.Order();
            store.Shipping();
            store.CashDeleting();

            IShipService russia = new RussiaWarehouse();
            RussiaWarehouse.collection.AddRange(orderedProducts2);
            russia.Shipping();

            Console.Read();
        }
    }
}

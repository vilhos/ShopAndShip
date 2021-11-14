using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAndShip
{
    public class OnlineStore : IShipService, ICartGenerate, ICashDelete
    {
        public List<Product> products = new List<Product>();
        public List<Product> cartProducts = new List<Product>();

        public Product GetProduct(string id)
        {
            Product requestedItem = null;
            for (int i = 0; i < products.Count; i++)
            {
                try
                {
                    if (products[i].Name == id)
                    {
                        requestedItem = products[i];
                        products.RemoveAt(i);
                        break;
                    }
                    else if(products[i].Name != id && i == products.Count - 1)
                    {
                        throw new Exception();
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry, product not available");
                    break;
                }
            }
            return requestedItem;
        }

        public List<Product> Order()
        {
            return cartProducts;
        }

        public List<Product> Shipping()
        {
            Console.WriteLine("Product is shipped to Usa Warehouse");
            return cartProducts;
        }
        public float Cost(float weight)
        {
            float cost = weight * 3000;
            return cost;
        }

        public void CashDeleting()
        {
            cartProducts = new List<Product>();
        }
    }
}

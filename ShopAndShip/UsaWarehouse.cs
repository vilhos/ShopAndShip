using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAndShip
{
    public class UsaWarehouse : IShipService, ICashDelete
    {
        public static List<Product> collection = new List<Product>();

        public float Cost(float weight)
        {
            float cost = weight * 5000;
            return cost;
        }

        public List<Product> Shipping()
        {
            foreach (var item in collection)
            {
                try
                {
                    if (item.Weight > 100)
                        throw new Exept(item);
                }

                catch (Exept)
                {
                    Console.WriteLine("Weight limit error");
                }
            }
            Console.WriteLine("Product is shipped to Armenia");
            return collection;
        }
        public void CashDeleting()
        {
            collection = null;
        }
    }

    public class Exept : Exception
    {
        List<Product> SeaProducts = new List<Product>();

        public Exept(Product item)
        {
            SeaProducts.Add(item);
        }
    }
}

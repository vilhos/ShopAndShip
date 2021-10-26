using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAndShip
{
    public class RussiaWarehouse : IShipService, ICashDelete
    {
        public static List<Product> collection = new List<Product>();

        public float Cost(float weight)
        {
            float cost = weight * 2000;
            return cost;
        }

        public List<Product> Shipping()
        {
            float sumWeightLimit = 150;
            float calculatedWeight = 0;

            foreach (var item in collection)
            {
                calculatedWeight += item.Weight; 
                try
                {
                    if(calculatedWeight > sumWeightLimit)
                        throw new Exception();
                }
                catch (Exception)
                {
                    Console.WriteLine("Limit reached, send on another flight");
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
}

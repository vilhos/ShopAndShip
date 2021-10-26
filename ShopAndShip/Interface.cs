using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopAndShip
{
    public interface IShipCost
    {
        float Cost(float weight);
    }

    public interface IShipService : IShipCost
    {
        List<Product> Shipping();
    }

    public interface ICashDelete
    {
        void CashDeleting();
    }

    public interface ICartGenerate
    {
        Product GetProduct(string id);
    }

    public interface IAddRemove
    {
        Product AddProduct(string id);
        Product RemoveProduct(string id);
    }
}

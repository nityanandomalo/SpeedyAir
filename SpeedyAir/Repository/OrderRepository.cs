using Newtonsoft.Json;
using SpeedyAir.Models;
using SpeedyAir.Extention;

namespace SpeedyAir.Repository
{
    interface IOrderRepository
    {
        IList<OrderModel> GetOrders();
    }

    internal class OrderRepository : IOrderRepository
    {
        public IList<OrderModel> GetOrders()
        {
            var jsonString = FileReader.ReadAllText("coding-assigment-orders.json");

            var orders = JsonConvert.DeserializeObject<Dictionary<string, OrderModel>>(jsonString).Select(i => new OrderModel { OrderId = i.Key, Destination = i.Value.Destination, Priority = int.Parse(i.Key.Substring(i.Key.LastIndexOf('-') + 1)) }).ToList();

            return orders;
        }
    }
}

using SpeedyAir.Models;

namespace SpeedyAir.BusinessLogic
{
    internal class ItinenaryManager
    {
        public static string Itinerary(OrderModel order)
        {
            return order.IsNotLoaded() ? $"order: {order.OrderId}, flightNumber: not scheduled"
                : $"order: {order.OrderId}, flightNumber: {order.Schedule.FlightNumber}, departure: {order.Schedule.Departure}, arrival: {order.Schedule.Arrival}, day: {order.Schedule.Day}";
        }
    }
}

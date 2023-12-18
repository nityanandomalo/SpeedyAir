using SpeedyAir.Models;
using SpeedyAir.Repository;

namespace SpeedyAir.BusinessLogic
{
    internal class InventoryManager
    {
        public IList<OrderModel> Orders { get; private set; }
        public IList<FlightModel> FlightsScheduled { get; private set; }
        public IList<ScheduleModel> Schedules { get; private set; }

        public InventoryManager()
        {
            FlightsScheduled = new List<FlightModel>();
            Schedules = new ScheduleRepository().GetSchedules();
        }

        public void ProcessFlightScheduleMenuUserChoice(int userChoice)
        {
            if (userChoice > 0 && userChoice <= Schedules.Count)
            {
                var selectedSchedule = Schedules.FirstOrDefault(i => !i.IsLoaded && i.FlightNumber == userChoice);
                if (selectedSchedule != null)
                {
                    var scheduledFlight = new FlightModel(20, selectedSchedule);
                    FlightsScheduled.Add(scheduledFlight);
                    FlightsScheduled = FlightsScheduled.OrderBy(i => i.Schedule.FlightNumber).ToList();
                    DisplayScheduleLoadedMessage(selectedSchedule);
                }
            }
        }

        public void DisplayScheduleLoadedMessage(ScheduleModel schedule)
        {
            var menu = new MenuModel()
            {
                Items = new List<string>()
                {
                    $"{ScheduleManager.LoadedMessage(schedule)}"
                }
            };

            new InformationManager().DisplayAndRead(menu);
        }

        public void DisplayLoadedSchedules()
        {
            var menu = new MenuModel()
            {
                Header = "\n======= Loaded schedules =======\n"
            };

            foreach (var flight in FlightsScheduled)
            {
                menu.Items.Add(flight.FlightSchedule());
            }

            new InformationManager().DisplayAndRead(menu);
        }

        public void DisplayFlightItineraries()
        {
            LoadOrdersInFlights();

            var menu = new MenuModel()
            {
                Header = "\n======= Flight itineraries =======\n"
            };

            foreach (var order in Orders)
            {
                menu.Items.Add(ItinenaryManager.Itinerary(order));
            }

            new InformationManager().DisplayAndRead(menu);
        }

        private void LoadOrdersInFlights()
        {
            Orders = new OrderRepository().GetOrders().OrderBy(o => o.Priority).ToList();

            foreach (var schedule in Schedules)
            {
                if (schedule.IsLoaded)
                {
                    var loadedFlights = FlightsScheduled.Where(i => i.Schedule == schedule).ToList();

                    foreach (var flight in loadedFlights)
                    {
                        var flightOrders = Orders.Where(i => i.IsNotLoaded() && i.Destination == schedule.Arrival).Take(flight.Capacity).Select(i => { i.Schedule = schedule; return i; }).ToList();
                        flight.Orders = flightOrders;
                    }
                }
            }
        }

        public MenuModel GetFlightScheduleMenu()
        {
            var menu = new MenuModel
            {
                Header = "Choose a schedule to load"
            };

            foreach (var item in Schedules)
            {
                if (!item.IsLoaded)
                {
                    menu.Items.Add(item.ToString());
                }
            }

            menu.ExitValue = Schedules.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Main menu");

            return menu;
        }
    }
}

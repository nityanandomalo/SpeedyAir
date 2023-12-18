using SpeedyAir.Models;
using SpeedyAir.BusinessLogic;

namespace SpeedyAir
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var inventory = new InventoryManager();

            ReadMainMenuUserChoice(inventory);
        }

        private static void ReadMainMenuUserChoice(InventoryManager inventory)
        {
            int userChoice;
            MenuModel menu = GetMainMenu();

            do
            {
                userChoice = new MenuManager().DisplayAndRead(menu);
                ProcessMainMenuUserChoice(userChoice, inventory);
            } while (userChoice != menu.ExitValue);
        }

        private static void ProcessMainMenuUserChoice(int userChoice, InventoryManager inventory)
        {
            switch (userChoice)
            {
                case 1:
                    ReadFlightScheduleMenuUserChoice(inventory);
                    break;
                case 2:
                    inventory.DisplayLoadedSchedules();
                    break;
                case 3:
                    inventory.DisplayFlightItineraries();
                    break;
                case 4:
                    Environment.Exit(0);
                    break;
            }
        }


        private static void ReadFlightScheduleMenuUserChoice(InventoryManager inventory)
        {
            int userChoice;
            MenuModel menu;

            do
            {
                menu = inventory.GetFlightScheduleMenu();
                userChoice = new MenuManager().DisplayAndRead(menu);
                inventory.ProcessFlightScheduleMenuUserChoice(userChoice);
            } while (userChoice != menu.ExitValue);
        }

        private static MenuModel GetMainMenu()
        {
            var menu = new MenuModel
            {
                Header = "SpeedyAir.ly",
                Items = new List<string>()
            {
                "1. Load schedule",
                "2. List out loaded flight schedules",
                "3. Generate flight itineraries",
            }
            };

            menu.ExitValue = menu.Items.Count + 1;
            menu.Items.Add($"{menu.ExitValue}. Exit");

            return menu;
        }
    }
}
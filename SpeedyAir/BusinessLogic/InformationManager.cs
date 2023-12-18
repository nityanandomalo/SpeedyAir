using SpeedyAir.Models;

namespace SpeedyAir.BusinessLogic
{
    internal class InformationManager : MenuManager
    {
        public override int DisplayAndRead(MenuModel menu)
        {
            Console.WriteLine(menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nPress any key to return to main menu... ");
            Console.ReadKey();

            return 0;
        }
    }
}

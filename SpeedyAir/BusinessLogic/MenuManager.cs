using SpeedyAir.Models;

namespace SpeedyAir.BusinessLogic
{
    internal class MenuManager
    {
        public virtual int DisplayAndRead(MenuModel menu)
        {
            Console.Clear();
            Console.WriteLine("======= {0} =======\n", menu.Header);

            foreach (var item in menu.Items)
            {
                Console.WriteLine(item);
            }

            Console.Write("\nEnter your choice: ");

            int userInput;
            int.TryParse(Console.ReadLine(), out userInput);

            return userInput;
        }
    }
}

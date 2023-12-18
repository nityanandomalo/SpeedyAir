using SpeedyAir.Models;

namespace SpeedyAir.BusinessLogic
{
    internal class ScheduleManager
    {
        public static string LoadedMessage(ScheduleModel schedule)
        {
            return $"Schedule {schedule.FlightNumber} loaded";
        }
    }
}

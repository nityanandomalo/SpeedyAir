namespace SpeedyAir.Models
{
    internal class FlightModel
    {
        public int Capacity { get; private set; }
        public ScheduleModel Schedule { get; private set; }
        public IList<OrderModel> Orders { get; set; }

        public FlightModel(int capacity, ScheduleModel schedule)
        {
            Capacity = capacity;
            schedule.IsLoaded = true;
            Schedule = schedule;
            Orders = new List<OrderModel>();
        }

        public string FlightSchedule()
        {
            return $"Flight: {Schedule.FlightNumber}, departure: {Schedule.Departure}, arrival: {Schedule.Arrival}, day: {Schedule.Day}";
        }
    }
}

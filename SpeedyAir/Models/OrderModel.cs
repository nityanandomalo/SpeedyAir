namespace SpeedyAir.Models
{
    internal class OrderModel
    {
        public int Priority { get; set; }
        public string OrderId { get; set; }
        public string Destination { get; set; }
        public ScheduleModel Schedule { get; set; }

        public bool IsNotLoaded()
        {
            return Schedule == null;
        }
    }
}

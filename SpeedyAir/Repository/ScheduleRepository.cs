using SpeedyAir.Models;

namespace SpeedyAir.Repository
{
    interface IScheduleRepository
    {
        IList<ScheduleModel> GetSchedules();
    }

    internal class ScheduleRepository : IScheduleRepository
    {
        public IList<ScheduleModel> GetSchedules()
        {
            var flightNo = 1;
            var day = 1;
            var schedules = new List<ScheduleModel>();

            schedules.Add(new ScheduleModel { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYZ", Day = day, IsLoaded = false });
            schedules.Add(new ScheduleModel { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYC", Day = day, IsLoaded = false });
            schedules.Add(new ScheduleModel { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YVR", Day = day, IsLoaded = false });

            day++;
            schedules.Add(new ScheduleModel { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYZ", Day = day, IsLoaded = false });
            schedules.Add(new ScheduleModel { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YYC", Day = day, IsLoaded = false });
            schedules.Add(new ScheduleModel { FlightNumber = flightNo++, Departure = "YUL", Arrival = "YVR", Day = day, IsLoaded = false });

            return schedules;
        }
    }
}

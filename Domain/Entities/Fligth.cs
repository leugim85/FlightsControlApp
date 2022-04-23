using System;

namespace Business.Entities
{
    public class Fligth
    {
        public int FligthId { get; set; }

        public DateOnly Date { get; set; }

        public TimeOnly DepartureTime { get; set; }

        public TimeOnly ArrivalTime { get; set; }

        public string Airline { get; set; }

        public string OriginCity { get; set; }

        public string DestinationCity  { get; set;}

        public string FlightStatus { get; set; }
    }
}

using System;

namespace Business.Models
{
    public class FligthDto
    {
        public DateTime Date { get; set; }

        public DateTime DepartureTime { get; set; }

        public DateTime ArrivalTime { get; set; }

        public int AirlineId { get; set; }

        public string Airline { get; set; }

        public int OriginCityId { get; set; }

        public string OriginCity { get; set; }

        public int DestinationCityId { get; set; }

        public string DestinationCity { get; set; }

        public int FlightStatusId { get; set; }

        public string FlightStatus { get; set; }
    }
}

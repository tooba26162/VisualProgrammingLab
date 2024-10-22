using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AirLine_ReservationSystem
{
    public abstract class Customer
    {
        public int CustomerId
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }
        public string FirstName
        {
            get;
            set;
        }
        public string Street
        {
            get;
            set;
        }
        public string City
        {
            get;
            set;
        }
        public string State
        {
            get;
            set;
        }
        public string ZipCode
        {
            get;
            set;
        }
        public string Phone
        {
            get;
            set;
        }
        public string Email
        {
            get;
            set;
        }
        public string Password

        {
            get;
            set;
        }
    }

    public class RetailCustomer : Customer
    {
        public string CreditCardType
        {
            get;
            set;
        }
        public string CreditCardNo
        {
            get;
            set;
        }
    }
    public class CorporateCustomer : Customer
    {
        public string CompanyName
        {
            get;
            set;
        }
        public int FrequentFlyerPts
        {
            get;
            set;
        }
        public string BillingAccountNo
        {
            get;
            set;
        }
    }

    // Reservation Class
    public class Reservation
    {
        public int ReservationNo
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public Customer Customer
        {
            get;
            set;
        }
        public List<Seat> Seats
        {
            get;
            set;
        }
            = new List<Seat>();
    }

    // Seat Class
    public class Seat
    {
        public int RowNo
        {
            get;
            set;
        }
        public int SeatNo
        {
            get;
            set;
        }
        public decimal Price
        {
            get;
            set;
        }
        public string Status
        {
            get;
            set;
        }
    }

    public class Flight
    {
        public int FlightId
        {
            get;
            set;
        }
        public DateTime Date
        {
            get;
            set;
        }
        public string Origin
        {
            get;
            set;
        }
        public string Destination
        {
            get;
            set;
        }
        public DateTime DepartureTime
        {
            get;
            set;
        }
        public DateTime ArrivalTime
        {
            get;
            set;
        }
        public int SeatingCapacity
        {
            get;
            set;
        }
        public List<Seat> Seats
        {
            get;
            set;
        }
            = new List<Seat>();
    }

    class Program
    {
        static void Main(string[] args)
        {

            Flight flight = new Flight
            {
                FlightId = 1,
                Date = DateTime.Now,
                Origin = "New York",
                Destination = "Los Angeles",
                DepartureTime = DateTime.Now.AddHours(2),
                ArrivalTime = DateTime.Now.AddHours(5),
                SeatingCapacity = 200
            };

            for (int i = 1; i <= 200; i++)
            {
                Seat seat = new Seat
                {
                    RowNo = (i / 10) + 1,
                    SeatNo = i % 10,
                    Price = 100,
                    Status = "Available"
                };
                flight.Seats.Add(seat);
            }


            RetailCustomer retailCustomer = new RetailCustomer
            {
                CustomerId = 1,
                LastName = "Doe",
                FirstName = "John",
                Street = "123 Main St",
                City = "New York",
                State = "NY",
                ZipCode = "10001",
                Phone = "1234567890",
                Email = "john.doe@example.com",
                Password = "password",
                CreditCardType = "Visa",
                CreditCardNo = "1234567890123456"
            };

            // Create a new reservation
            Reservation reservation = new Reservation
            {
                ReservationNo = 1,
                Date = DateTime.Now,
                Customer = retailCustomer
            };

            // Add seats to the reservation
            for (int i = 1; i <= 2; i++)
            {
                Seat seat = flight.Seats[i - 1];
                seat.Status = "Reserved";
                reservation.Seats.Add(seat);
            }

            Console.WriteLine("Reservation Details:");
            Console.WriteLine($"Reservation No: {reservation.ReservationNo}");
            Console.WriteLine($"Date: {reservation.Date}");
            Console.WriteLine($"Customer: {reservation.Customer.FirstName} {reservation.Customer.LastName}");
            Console.WriteLine("Seats:");
            foreach (var seat in reservation.Seats)
            {
                Console.WriteLine($"Row: {seat.RowNo}, Seat: {seat.SeatNo}, Price: {seat.Price}, Status: {seat.Status}");
            }
        }
    }
}
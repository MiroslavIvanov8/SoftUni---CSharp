using BookingApp.Core.Contracts;
using BookingApp.Models;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private readonly IRepository<IHotel> hotels = new HotelRepository();
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel = new Hotel(hotelName, category);

            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }

            hotels.AddNew(hotel);

            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }
        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel is null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }

            IRoom room;
            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else
            {
                room = new Apartment();
            }

            hotel.Rooms.AddNew(room);

            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.Select(hotelName);

            if(hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            if (!hotel.Rooms.All().Any(r=>r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }

            IRoom room = hotel.Rooms.Select(roomTypeName);

            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);                
            }

            room.SetPrice(price);

            return string.Format(OutputMessages.PriceSetSuccessfully,roomTypeName,hotelName);

        }
        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            if (!hotels.All().Any(h => h.Category >= category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            List<IRoom> availableRooms = new List<IRoom>();

            foreach (IHotel hotel in hotels.All().OrderBy(h => h.FullName).Where(h => h.Category >= category))
            {
                foreach (var currRoom in hotel.Rooms.All())
                {
                    if (currRoom.PricePerNight > 0)
                    {
                        availableRooms.Add(currRoom);
                    }
                }
            }

            availableRooms = availableRooms.OrderBy(r => r.BedCapacity).ToList();
            if (!availableRooms.Any())
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }
            IRoom room = availableRooms.FirstOrDefault(r=>r.BedCapacity >= adults + children); // need to refactor right here
           
            if (room == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }

            room = availableRooms.FirstOrDefault(r => r.BedCapacity >= adults + children);

            if (room == null)
            {
                return string.Format(OutputMessages.RoomNotAppropriate);
            }


            IBooking booking;
            foreach (var hotel in hotels.All())
            {
                foreach (var thisRoom in hotel.Rooms.All())
                {
                    if (thisRoom.Equals(room))
                    {
                        booking = new Booking(room,duration,adults,children,hotel.Bookings.All().Count() + 1);
                        hotel.Bookings.AddNew(booking);

                        return string.Format(OutputMessages.BookingSuccessful,hotel.Bookings.All().Count(),hotel.FullName);
                    }
                }
            }
            return string.Format(OutputMessages.RoomNotAppropriate);
        }


        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.Select(hotelName);

            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid,hotelName);
            }

            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Hotel name: {hotelName}")
              .AppendLine($"--{hotel.Category} star hotel")
              .AppendLine($"--Turnover: {hotel.Turnover:F2} $")
              .AppendLine($"--Bookings: ")
              .AppendLine(Environment.NewLine);

            if (!hotel.Bookings.All().Any())
            {
                sb.AppendLine("none");
            }
            else
            {
                foreach (IBooking booking in hotel.Bookings.All())
                {
                    sb.AppendLine(booking.BookingSummary());
                    sb.AppendLine(Environment.NewLine);
                }
            }

            return sb.ToString().TrimEnd();   
        }


    }
}

using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly List<IBooking> bookings = new List<IBooking>();
        
        public void AddNew(IBooking model) => bookings.Add(model);

        public IReadOnlyCollection<IBooking> All() => bookings;

        public IBooking Select(string bookingNumberToString) 
            => bookings.FirstOrDefault(b => b.BookingNumber.ToString() == bookingNumberToString);
    }
}

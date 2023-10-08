using FrontDeskApp;
using NUnit.Framework;
using System;

namespace BookigApp.Tests
{
    public class BookingTests
    {
        private Room room;
        private Booking booking;
        [SetUp]
        public void Setup()
        {
            Room room = new Room(2, 25);
            Booking booking = new Booking(1,room,5);
        }
        [TestCase(1,5)]
        [TestCase(2,10)]
        public void BookingConstructorShouldWorkProperly(int number,int duration)
        {
            booking = new Booking(number,room,duration);

            Assert.AreEqual(booking.BookingNumber,number);
            Assert.AreEqual(booking.ResidenceDuration, duration);
            Assert.AreSame(booking.Room,room);

        }
        

    }
}
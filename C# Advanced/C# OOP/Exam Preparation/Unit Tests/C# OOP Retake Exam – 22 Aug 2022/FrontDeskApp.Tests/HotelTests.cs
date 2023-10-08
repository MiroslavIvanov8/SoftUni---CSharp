using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace BookigApp.Tests
{
    public class HotelTests
    {
        private Room room1;
        private Room room2;
        private Booking booking;
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            Hotel hotel = new Hotel("LandMark", 5);
            Room room1 = new Room(2, 25);
            Room room2 = new Room(4,50);

        }
        [TestCase("Frigopan",5)]
        [TestCase("MirkosPlace",4)]
        public void HotelConstructorShouldWorkProperly(string name,int category)
        {
            hotel = new Hotel(name, category);

            Assert.AreEqual(hotel.FullName, name);
            Assert.AreEqual(hotel.Category,category );
            Assert.AreEqual(hotel.Bookings.Count, 0);
            Assert.AreEqual(hotel.Rooms.Count, 0);
            Assert.AreEqual(hotel.Turnover, 0);

        }
        [TestCase("", 5)]
        [TestCase(null, 4)]
        [TestCase(" ", 4)]
        public void HotelConstructorShouldThrowArgumentNullExceptionIfNameIsNullOrWhiteSpace(string name, int category)
        {
            Assert.Throws<ArgumentNullException>(() => new Hotel(name, category));
        }
        [Test]
        public void AddMethodShouldWorkCorrectly()
        {
            hotel = new Hotel("LandMark", 5);
            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            Assert.AreEqual(hotel.Rooms.Count, 2);
        }
        [TestCase(0,2,7,300)]
        [TestCase(-1,2,7,300)]
        [TestCase(1, -1, 7, 300)]        
        [TestCase(1, 2, -7, 300)]

        public void BookRoomMethodShouldThrowExceptionIfAdultsAreZeroOrNegative(int adults,int children, int duration , int budget)
        {
            hotel = new Hotel("LandMark", 5);
            Assert.Throws<ArgumentException>(() => hotel.BookRoom(adults, children, duration, budget));
        }
        [TestCase(2,0,2,300)]
        public void BookRoomMethodShouldWorkCorrectly(int adults, int children, int duration, int budget)
        {
            hotel = new Hotel("LandMark", 5);
            room1 = new Room(2, 25);
            room2 = new Room(4, 50);
            hotel.AddRoom(room1);
            hotel.AddRoom(room2);

            hotel.BookRoom(adults, children, duration, budget);

            Assert.AreEqual(hotel.Bookings.Count, 2);
            Assert.AreEqual(hotel.Turnover, 150);

        }
    }
}
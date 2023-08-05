using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Xml.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Room room;
        [SetUp]
        public void Setup()
        {
            Room room;
        }

        [TestCase(5,25)]
        [TestCase(1, 50)]
        public void RoomConstructorShouldInitializeCorrectValues(int capacity, int price)
        {
            Room room = new Room(capacity, price);

            Assert.AreEqual(capacity, room.BedCapacity);
            Assert.AreEqual(price, room.PricePerNight);
        }
        [TestCase(0, 25)]
        [TestCase(-1, 50)]
        public void RoomConstructorShouldThrowExceptionIfCapacityIsZeroOrNegative(int capacity, int price)
        {
            Assert.Throws<ArgumentException>(() => new Room(capacity, price));
        }
        [TestCase(1, 0)]
        [TestCase(2, -50)]
        public void RoomConstructorShouldThrowExceptionIfPricePerNightIsZeroOrNegative(int capacity, int price)
        {
            Assert.Throws<ArgumentException>(() => new Room(capacity, price));

        }

    }
}
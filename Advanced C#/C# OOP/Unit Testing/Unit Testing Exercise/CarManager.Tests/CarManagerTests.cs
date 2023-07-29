namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;
    using System.Reflection;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;
        [SetUp]
        public void SetUp()
        {
            Car car = new Car("VW", "Golf", 5.5, 100);
        }

        [Test]
        public void ConstuctorInitializeCorrectValues()
        {
            Car car = new Car("VW","Golf",5.5,100);

            Assert.AreEqual(0, car.FuelAmount);
            Assert.AreEqual("VW", car.Make);
            Assert.AreEqual("Golf", car.Model);
            Assert.AreEqual(5.5, car.FuelConsumption);
            Assert.AreEqual(100, car.FuelCapacity);
        }

        
        [TestCase("Golf", 5.5, 100)]        
        public void ConstuctorThrowsExceptionWhenMakeIsStringEmpty( string model, double fuelConsumption,double fuelCapacity)
        {
            string make = string.Empty;
            ArgumentException ex =  Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Make cannot be null or empty!",ex.Message);
        }

        [TestCase("Golf", 5.5, 100)]
        public void ConstuctorThrowsExceptionWhenMakeIsNull(string model, double fuelConsumption, double fuelCapacity)
        {
            string make = null;
            ArgumentException ex = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Make cannot be null or empty!", ex.Message);
        }

        [TestCase("VW", 5.5, 100)]
        public void ConstuctorThrowsExceptionWhenModelIsStringEmpty(string make, double fuelConsumption, double fuelCapacity)
        {
            string model = string.Empty;
            ArgumentException ex = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }
        [TestCase("VW", 5.5, 100)]
        public void ConstuctorThrowsExceptionWhenModelIsNull(string make, double fuelConsumption, double fuelCapacity)
        {
            string model = null;
            ArgumentException ex = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Model cannot be null or empty!", ex.Message);
        }

        [TestCase("VW","Gold", 0, 100)]
        [TestCase("VW", "Gold", -10, 100)]
        public void ConstuctorThrowsExceptionWhenFuelConsumptionIsZeroOrLower(string make,string model, double fuelConsumption, double fuelCapacity)
        {
            
            ArgumentException ex = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Fuel consumption cannot be zero or negative!", ex.Message);
        }

        [TestCase("VW", "Gold", 10, 0)]
        [TestCase("VW", "Gold", 10, -10)]
        public void ConstuctorThrowsExceptionWhenFuelCapacity(string make, string model, double fuelConsumption, double fuelCapacity)
        {

            ArgumentException ex = Assert.Throws<ArgumentException>(() => car = new Car(make, model, fuelConsumption, fuelCapacity));

            Assert.AreEqual("Fuel capacity cannot be zero or negative!", ex.Message);
        }

        
        [TestCase("VW", "Gold", 10, 50)]        
        public void RefuelMethodShouldWorkCorrectlyIfRefuelAmountIsMoreThanCapacity(string make, string model, double fuelConsumption, double fuelCapacity)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(100);
            Assert.AreEqual(50, car.FuelAmount);
        }

        [TestCase("VW", "Gold", 10, 100,100)]
        [TestCase("VW", "Gold", 10, 100, 50)]
        public void RefuelMethodShouldWorkCorrectlyIfRefuelAmountLessOrEqualToCapacity(string make, string model, double fuelConsumption, double fuelCapacity,double refuelAmount)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refuelAmount);
            
            Assert.AreEqual(refuelAmount, car.FuelAmount);
        }
        
        [TestCase("VW", "Gold", 10, 100, 0)]
        [TestCase("VW", "Gold", 10, 100, -20)]
        public void RefuelMethodShouldThrowExceptionIfRefuelAmountIsZeroOrLower(string make, string model, double fuelConsumption, double fuelCapacity, double refuelAmount)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            ArgumentException  ex = Assert.Throws<ArgumentException>(()=>car.Refuel(refuelAmount));

            Assert.AreEqual("Fuel amount cannot be zero or negative!", ex.Message);
            
        }

        [TestCase("VW", "Gold", 10, 100, 100, 10)]
        [TestCase("VW", "Gold", 10, 100, 100, 50)]
        public void DriveMethodShouldWorkCorrectly(string make, string model, double fuelConsumption, double fuelCapacity, double distance,int refuelAmount)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(refuelAmount);

            double fuelNeeded = (distance / 100) * car.FuelConsumption;

            double expectedResult = car.FuelAmount - fuelNeeded;

            car.Drive(distance);            
            
            Assert.AreEqual(expectedResult, car.FuelAmount);

        }

        [TestCase("VW", "Gold", 10, 100, 200)]
        public void RefuelMethodShouldThrowExceptionIfFuelAmountIsLessThanRequiredFuel(string make, string model, double fuelConsumption, double fuelCapacity, double distance)
        {
            car = new Car(make, model, fuelConsumption, fuelCapacity);

            car.Refuel(10);
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => car.Drive(distance));

            Assert.AreEqual("You don't have enough fuel to drive!", ex.Message);

        }
    }
}

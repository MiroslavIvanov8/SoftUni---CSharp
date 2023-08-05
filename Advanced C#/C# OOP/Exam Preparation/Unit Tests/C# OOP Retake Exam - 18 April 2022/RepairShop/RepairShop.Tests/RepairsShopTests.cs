using NUnit.Framework;
using System;

namespace RepairShop.Tests
{
    public class Tests
    {
        public class RepairsShopTests
        {
            [Test]
            public void CarConstructiorShouldInitializeCorrectValues()
            {
                Car car = new Car("Volvo",0);
                Assert.AreEqual(car.CarModel, "Volvo");
                Assert.AreEqual(car.NumberOfIssues, 0);
                Assert.IsTrue(car.IsFixed);
            }
            [Test]
            public void CarConstructiorShouldInitializeCorrectValuesAndBoolShouldThrowFalse()
            {
                Car car = new Car("Volvo", 1);
                Assert.AreEqual(car.CarModel, "Volvo");
                Assert.AreEqual(car.NumberOfIssues, 1);
                Assert.IsFalse(car.IsFixed);
            }
            [Test]
            public void GarageConstuctorShouldInitializeCorrectValues()
            {
                Garage garage = new Garage("ABS", 3);
                Assert.AreEqual(garage.Name, "ABS");
                Assert.AreEqual(garage.MechanicsAvailable, 3);
                Assert.AreEqual(garage.CarsInGarage, 0);

                Car car = new Car("Volvo", 1);
                garage.AddCar(car);
                Assert.AreEqual(garage.CarsInGarage, 1);
            }
            [TestCase("", 3)]
            [TestCase(null, 3)]            
            public void GarageConstuctorShouldThrowExceptionIfNameIsNullOrempty(string name,int mechanics)
            {
                Assert.Throws<ArgumentNullException>(() => new Garage(name, mechanics));
            }
            [TestCase("ABS", 0)]
            [TestCase("ABS", -3)]
            public void GarageConstuctorShouldThrowExceptionIfMechanicsAreZeroOrNegative(string name, int mechanics)
            {
                Assert.Throws<ArgumentException>(() => new Garage(name, mechanics));
            }
            [Test]
            public void GarageFixCarMethodShouldWorkCorrect()
            {
                Garage garage = new Garage("ABS", 3);
                Car car = new Car("Volvo", 1);

                garage.AddCar(car);
                garage.FixCar(car.CarModel);

                Assert.AreEqual(car.NumberOfIssues, 0);
                
            }
            [Test]
            public void GarageFixCarMethodShouldThrowExce3ptionIfCarIsNull()
            {
                Garage garage = new Garage("ABS", 3);
                Car car = new Car("Volvo", 1);

                garage.AddCar(car);
                Assert.Throws<InvalidOperationException>(()=> garage.FixCar("Nissan"));
            }
            [Test]
            public void GarageAddMethodShouldWorkCorrectly()
            {
                Garage garage = new Garage("ABS", 3);
                Car car = new Car("Volvo", 1);

                garage.AddCar(car);
                Assert.AreEqual(garage.CarsInGarage, 1);
                
            }
            [Test]
            public void GarageAddMethodShouldThrowExceptionWhenAvailableMechanicsAreEqualToCarsInGarage()
            {
                Garage garage = new Garage("ABS", 3);
                Car car1 = new Car("Volvo", 1);
                Car car2 = new Car("Volvo", 2);
                Car car3 = new Car("Volvo", 3);
                Car car4 = new Car("Volvo", 4);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                Assert.Throws<InvalidOperationException>(() => garage.AddCar(car4));

            }
            [Test]
            public void GarageRemoveFixedCarsShouldWorkCorrect()
            {
                Garage garage = new Garage("ABS", 3);
                Car car1 = new Car("Volvo1", 1);
                Car car2 = new Car("Volvo2", 2);
                Car car3 = new Car("Volvo3", 3);                

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                garage.FixCar("Volvo1");
                garage.FixCar("Volvo2");

                garage.RemoveFixedCar();
                Assert.AreEqual(garage.CarsInGarage, 1);

            }
            [Test]
            public void GarageRemoveFixedCarsShouldThrowExceptionWhenThereAreNoFixedCars()
            {
                Garage garage = new Garage("ABS", 3);
                Car car1 = new Car("Volvo1", 1);
                Car car2 = new Car("Volvo2", 2);
                Car car3 = new Car("Volvo3", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                Assert.Throws<InvalidOperationException>(() => garage.RemoveFixedCar());
            }
            [Test]
            public void GarageReportShouldWorkCorrectly()
            {
                Garage garage = new Garage("ABS", 3);
                Car car1 = new Car("Audi", 1);
                Car car2 = new Car("BMW", 2);
                Car car3 = new Car("Volvo", 3);

                garage.AddCar(car1);
                garage.AddCar(car2);
                garage.AddCar(car3);

                string expected = $"There are 3 which are not fixed: Audi, BMW, Volvo.";

                Assert.AreEqual(expected, garage.Report());
            }
            [Test]
            public void GarageReportShouldWorkCorrectlyWithZeroCars()
            {
                Garage garage = new Garage("ABS", 3);
                

                

                string expected = $"There are 0 which are not fixed: .";

                Assert.AreEqual(expected, garage.Report());
            }
        }
    }
}
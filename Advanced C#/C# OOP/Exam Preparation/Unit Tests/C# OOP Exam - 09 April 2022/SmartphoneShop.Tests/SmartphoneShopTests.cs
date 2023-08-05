using NUnit.Framework;
using System;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        [Test]
        public void SmartPhoneConstrtuctorShouldInitializeCorrectly()
        {
            Smartphone phone = new Smartphone("Motorola", 100);

            Assert.AreEqual(phone.ModelName, "Motorola");
            Assert.AreEqual(phone.MaximumBatteryCharge, 100);
            Assert.AreEqual(phone.CurrentBateryCharge, 100);

            phone.CurrentBateryCharge -= 10;
            Assert.AreEqual(phone.CurrentBateryCharge, 90);
        }
        [Test]
        public void ShopConstuctorShouldInitializeCorrectValues()
        {
            Smartphone phone = new Smartphone("Motorola", 100);
            Shop shop = new Shop(2);

            Assert.AreEqual(shop.Capacity, 2);

            shop.Add(phone);
            Assert.AreEqual(shop.Count, 1);
        }
        [TestCase(-1)]
        [TestCase(-3)]
        public void ShopConstuctorShouldThrowExceptionIfCapacityIsNegative(int capacity)
        {
            Assert.Throws<ArgumentException>(() => new Shop(capacity));
        }
        [Test]
        public void ShopAddMethodShouldThrowExceptptionIfPhoneAlreadyExists()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 100);

            shop.Add(phone );
            Assert.Throws<InvalidOperationException>(()=>shop.Add(phone));
        }
        [Test]
        public void ShopAddMethodShouldThrowExceptptionIfShopIsFull()
        {
            Shop shop = new Shop(1);

            Smartphone phone1 = new Smartphone("Motorola", 100);
            Smartphone phone2 = new Smartphone("Samsung", 100);


            shop.Add(phone1);
            Assert.Throws<InvalidOperationException>(() => shop.Add(phone2));
        }
        [Test]
        public void ShopRemoveMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 100);

            shop.Add(phone);
            shop.Remove("Motorola");
            Assert.AreEqual(0, shop.Count);
        }
        [Test]
        public void ShopRemoveMethodShouldThrowExceptptionIfModelIsMissing()
        { 
            Shop shop = new Shop(1);

            Smartphone phone1 = new Smartphone("Motorola", 100);
            Smartphone phone2 = new Smartphone("Samsung", 100);

            Assert.Throws<InvalidOperationException>(() => shop.Remove("Huawei"));
        }
        [Test]
        public void ShopTestPhoneShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 100);

            shop.Add(phone);
            shop.TestPhone("Motorola", 45);
            Assert.AreEqual(55, phone.CurrentBateryCharge);
            
        }
        [Test]
        public void ShopTestPhoneShouldThrowExceptionIfPhoneIsNull()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 100);

            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Samsung", 50));
        }
        [Test]
        public void ShopTestPhoneShouldThrowExceptionIfBatteryUsageIsBiggerThanCurrentCharge()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 55);

            shop.Add(phone);
            Assert.Throws<InvalidOperationException>(() => shop.TestPhone("Motorola", 56));
        }
        [Test]
        public void ShopChargePhoneMethodShouldWorkCorrectly()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 100);

            shop.Add(phone);
            shop.TestPhone("Motorola",80);

            shop.ChargePhone("Motorola");

            Assert.AreEqual(phone.MaximumBatteryCharge, phone.CurrentBateryCharge);

        }
        [Test]
        public void ShopChargemethodShouldThrowExceptionIfPhoneIsNull()
        {
            Shop shop = new Shop(3);

            Smartphone phone = new Smartphone("Motorola", 100);

            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(() => shop.ChargePhone("Samsung"));
        }
    }
}
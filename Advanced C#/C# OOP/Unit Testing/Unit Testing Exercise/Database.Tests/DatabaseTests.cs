namespace Database.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class DatabaseTests
    {
        private Database database;

        [SetUp]
        public void SetUp()
        {
            database = new Database(1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16);
        }

        [Test]
        public void CreatingDatabaseCountShouldBeCorrect()
        {
            //Arrange
            int[] data = new int[] { 1, 2, 3, 4, 5 };
            //Act
            database = new(data);

            //Assert
            Assert.AreEqual(data.Length, database.Count);
        }

        [Test]
        public void CreatingDatabaseShouldAddElementsCorrect()
        {
            //Arrange
            int[] data = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            //Act

            database = new(data);
            int[] copyArr = database.Fetch();
            //Assert
            Assert.AreEqual(data, copyArr);
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 })]
        public void CreatingDatabaseShouldThrowAnExpectionWhenCountIsMoreThan16(int[] data)
        {
            Assert.Throws<InvalidOperationException>(() => database = new(data), "Array's capacity must be exactly 16 integers!");
        }

        [TestCase(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16 })]
        public void RemoveMethodShouldOnlyRemoveElementAtLastIndex(int[] data)
        {
            database = new Database(data);

            database.Remove();

            Assert.AreEqual(database.Count, data.Length - 1);
        }
        [TestCase(new int[] {1 })]
        public void RemoveMethodShouldOnlyRemoveElementsIfCountIsMoreThanZero(int[] data)
        {
            database = new Database(data);

            database.Remove();

            Assert.Throws<InvalidOperationException>(()
                => database.Remove(), "The collection is empty!");
        }

        [Test]
        public void DatabaseCountShouldWorkCorrectly()
        {
            int expectedresult = 16;
            int actualresult = database.Count;

            Assert.AreEqual(expectedresult, actualresult);
        }

        [TestCase(new int[] {1,2,3,4,5})]
        public void FetchMethodShouldReturnCorrectData(int[]data)
        {
            database = new Database();
            foreach (int number in data)
            {
                database.Add(number);
            }

            int[] expectedResult = database.Fetch();
            
            Assert.AreEqual(data, expectedResult);
        }
    }
}

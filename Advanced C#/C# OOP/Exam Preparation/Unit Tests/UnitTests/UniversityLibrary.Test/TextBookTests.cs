namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Text;

    public class Tests
    {
        private TextBook book;
        [SetUp]
        public void Setup()
        {
            book = new TextBook("Title!@", "I am not an author", "Horror");
        }

        [Test]
        public void ConstructorInitializeCorrectValues()
        {
            Assert.AreEqual("Title!@", book.Title);
            Assert.AreEqual("I am not an author", book.Author);
            Assert.AreEqual("Horror", book.Category);
            Assert.AreEqual(book.Holder,null);
            Assert.AreEqual(0, book.InventoryNumber);
        }
        
        [Test]
        public void textBookToStringWorksCorrectly()
        {
            string result = book.ToString();

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Book: Title!@ - 0");
            sb.AppendLine("Category: Horror");
            sb.AppendLine("Author: I am not an author");

            Assert.AreEqual(result, sb.ToString().TrimEnd());
        }
    }
}
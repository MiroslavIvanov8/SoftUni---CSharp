namespace UniversityLibrary.Test
{
    using NUnit.Framework;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    

    public class UniversityTests
    {
        private UniversityLibrary textBooks;
        private TextBook book;
        
        [SetUp]
        public void Setup()
        {
            textBooks = new UniversityLibrary();
            book = new TextBook("Title!@", "I am not an author", "Horror");
        }
        [Test]
        public void UniversityLib_ConstructorInitializeCorrectValues()
        {
            Assert.AreEqual(textBooks.Catalogue.Count, 0);
        }
        
        [Test]
        public void AddTextBookMethodShouldWorkCorrectly()
        {
            textBooks.AddTextBookToLibrary(book);
            Assert.AreEqual(textBooks.Catalogue.Count, 1);
            Assert.AreEqual(book.InventoryNumber, 1);
            string expectedResult = book.ToString();
            Assert.AreEqual(textBooks.Catalogue.Count, book.InventoryNumber);
            Assert.IsNotNull(textBooks.Catalogue);

            StringBuilder sb = new StringBuilder();

            sb.AppendLine("Book: Title!@ - 1");
            sb.AppendLine("Category: Horror");
            sb.AppendLine("Author: I am not an author");
            Assert.AreEqual(expectedResult, sb.ToString().TrimEnd());
        }
        [TestCase(1,"Miro")]
        public void LoanTextBookShouldSet_TextBookHolderToStudentName(int bookInventoryNumber,string studentName)
        {
            textBooks.AddTextBookToLibrary(book);
            
            string expectedResult = $"{book.Title} loaned to {studentName}.";

            Assert.AreEqual(expectedResult, textBooks.LoanTextBook(bookInventoryNumber, studentName));

            Assert.AreEqual(book.Holder, studentName);
        }
        [TestCase(1, "Miro")]
        public void LoanTextBookShouldReturn_TextBookHasntBeenReturnedYet(int bookInventoryNumber, string studentName)
        {
                textBooks.AddTextBookToLibrary(book);

            string expectedResult = $"{studentName} still hasn't returned {book.Title}!";

            textBooks.LoanTextBook(bookInventoryNumber, studentName);

            Assert.AreEqual(expectedResult, textBooks.LoanTextBook(bookInventoryNumber, studentName));
            
        }
        [TestCase(1)]
        public void ReturnTextBook_ShouldWorkCorrectly(int bookInventoryNumber)
        {
            textBooks.AddTextBookToLibrary(book);

            string expectedResult = $"{book.Title} is returned to the library.";

            Assert.AreEqual(expectedResult, textBooks.ReturnTextBook(bookInventoryNumber));

            Assert.AreEqual(book.Holder, string.Empty);

            
           

        }
          
    }
}
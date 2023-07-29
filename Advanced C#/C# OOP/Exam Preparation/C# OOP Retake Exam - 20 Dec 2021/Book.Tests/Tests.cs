namespace Book.Tests
{
    using System;

    using NUnit.Framework;

    public class Tests
    {
        private Book book;
        [SetUp]
        public void SetUp()
        {
            book = new Book("The Bible", "Unknown");
        }
        [TestCase("Teen Titans", "Nate Diaz")]
        public void ConstructorInitializeCorrectValues(string name, string author)
        {
            book = new Book(name, author);

            Assert.AreEqual(book.BookName, name);
            Assert.AreEqual(book.Author, author);
        }

        [TestCase(null, "Nate Diaz")]
        [TestCase("", "Nate Diaz")]
        
        public void ConstructorShouldThrowExceptionIfNameIsNullOrEmpty (string name, string author)
        {
           ArgumentException ex =  Assert.Throws<ArgumentException>(() => book = new Book(name, author));

            Assert.AreEqual("Invalid BookName!", ex.Message);
        }
        [TestCase("Nate Diaz", null)]
        [TestCase("Nate Diaz", "")]

        public void ConstructorShouldThrowExceptionIfAuthorIsNullOrEmpty(string name, string author)
        {
            ArgumentException ex = Assert.Throws<ArgumentException>(() => book = new Book(name, author));

            Assert.AreEqual("Invalid Author!", ex.Message);
        }
        [TestCase(10, "In the beginning")]
        [TestCase(1, "In the beginning")]
        public void AddFootnoteMethodShouldWorkCorrectly(int number, string text)
        {
            book.AddFootnote(number,text);

            Assert.AreEqual(1, book.FootnoteCount);           
        }
        [TestCase(1, "In the beginning")]
        public void AddFootnoteMethodShoulThrowExceptionWhenFootnoteAlreadyExists(int number, string text)
        {
            book.AddFootnote(1,"In the beginning");            

            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(()=> book.AddFootnote(number, text));

            Assert.AreEqual("Footnote already exists!", ex.Message);
        }

        [TestCase(1, "In the beginning")]
        public void FindFootnoteMethodShouldWorkCorrectly(int number, string text)
        {
            book.AddFootnote(number,text);

            string footnoteText = book.FindFootnote(number);
            string expected = $"Footnote #{number}: {text}";
            Assert.AreEqual(expected, footnoteText);
        }

        [TestCase(1)]
        [TestCase(10)]
        public void FindFootnoteMethodShouldShouldThrowExceptionWhenFootNoteIsNotExisting(int number)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => book.FindFootnote(number));

            Assert.AreEqual("Footnote doesn't exists!", ex.Message);
        }
        [TestCase(1, "In the beginning","changed text")]
        public void AlterFootnoteMethodShouldWorkCorrectly(int number, string text,string changedText)
        {
            book.AddFootnote(number, text);

            book.AlterFootnote(number, changedText);

            string expected = $"Footnote #{number}: {changedText}";

            string result = book.FindFootnote(number); 

            Assert.AreEqual(expected, result);
        }

        [TestCase(1,"something written")]
        [TestCase(10,"even more for the test")]
        public void AlterFootnoteMethodShouldShouldThrowExceptionWhenFootNoteIsNotExisting(int number,string text)
        {
            InvalidOperationException ex = Assert.Throws<InvalidOperationException>(() => book.AlterFootnote(number,text));

            Assert.AreEqual("Footnote does not exists!", ex.Message);
        }
    }
}
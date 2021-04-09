using System;
using Xunit; 
using GradeBook;

namespace BookXunitTest
{
    public delegate string WriteLogDelegate(string logMessage);
    public class TypeTest
    {
        int count = 0;
        [Fact]
        public void WriteLogDelegateCanPointToMethod()
        {
            
            WriteLogDelegate log=Returnmessage;
            log += Returnmessage;
            log += IncrementCount;
            var result = log("Hello!");
            Assert.Equal(3, count);
        }

        private string IncrementCount(string message)
        {
            count++;
            return message.ToLower();
        }
        private string Returnmessage(string message)
        {
            count++;
            return message;
        }

        [Fact]
        public void StringBehaveLikeValueTypes()
        {
            string name = "Priyanka";
            var upper = MakeUpperCase(name);

            Assert.Equal("Priyanka", name);
            Assert.Equal("PRIYANKA", upper);

        }

        private string MakeUpperCase(string parameter)
        {
           return parameter.ToUpper();
        }

        [Fact]
        public void test1()
        {
            var x = GetInt();
            SetInt(ref x);

            Assert.Equal(42, x);
        }

        private void SetInt(ref int z)
        {
            z = 42;
        }

        private int GetInt()
        {
            return 3; 
        }

        [Fact]
        public void CSharpPassByRef()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(ref book1, "New Name");

            Assert.Equal("New Name", book1.Name);

        }

        private void GetBookSetName(ref InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            
        }

        [Fact]
        public void CSharpPassByvalue()
        {
            var book1 = GetBook("Book 1");
            GetBookSetName(book1, "New Name");

            Assert.Equal("Book 1", book1.Name);

        }

        private void GetBookSetName(InMemoryBook book, string name)
        {
            book = new InMemoryBook(name);
            //book.Name = name;
        }



        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            SetName(book1, "New Name");

            Assert.Equal("New Name", book1.Name);
           
        }

        private void SetName(InMemoryBook book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");



            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
           Assert.NotSame(book1, book2);
        }


        [Fact]
        public void TwoVarsCanRefersSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(object.ReferenceEquals(book1, book2));
        }

        InMemoryBook GetBook(string name)
        {
            return new InMemoryBook(name);
        }
    }
}

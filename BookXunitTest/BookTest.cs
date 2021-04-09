using System;
using Xunit; 
using GradeBook;

namespace BookXunitTest
{
    public class BookTest
    {
        [Fact]
        public void BookCalculatesAverageGrade()
        {
            //arrange
           var bookss = new InMemoryBook("priyankas gradebook");
           bookss.AddGrade(89.1);
            bookss.AddGrade(90.5);
            bookss.AddGrade(77.3);

            //act
            var result = bookss.GetStatistics();

            //assert
            Assert.Equal(85.6, result.Average, 1);
            Assert.Equal(90.5, result.high, 1);
            Assert.Equal(77.3, result.low, 1);
            Assert.Equal('B', result.letter);
        }
    }
}

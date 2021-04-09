using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {

        static void Main(string[] args)
        {

            IBook book = new DiskBook(" Priyanka's Grade Book");
            book.GradeAdded += OnGradeAdded;

            EnterGrades(book);

            var stat = book.GetStatistics();

            Console.WriteLine("For the book named " + book.Name);
            Console.WriteLine("lowest number is            : " + stat.low);
            Console.WriteLine("highest number is           : " + stat.high);
            Console.WriteLine("the average grade is        : " + stat.Average);
            Console.WriteLine("the average letter grade is : " + stat.letter);
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                Console.WriteLine("Enter a grade or press 'q' to exit.....");
                var input = Console.ReadLine();

                if (input == "q")
                {
                    break;
                }

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }

                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}

using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new DiskBook("Peter's Grade Book");

            // can subscribe or unsubscribe (-=) to an event, and also do this multiple times
            book.GradeAdded += OnGradeAdded;

            // cannot directly assign to an event
            //book.GradeAdded = null;

            // Calling method directly
            //book.AddGrade(89.1);
            //book.AddGrade(90.5);
            //book.AddGrade(77.5);

            EnterGrades(book);

            var stats = book.GetStatistics();

            System.Console.WriteLine($"The const category is {InMemoryBook.CATEGORY}");
            System.Console.WriteLine($"The lowest grade is {stats.Low}");
            System.Console.WriteLine($"The highest grade is {stats.High}");
            System.Console.WriteLine($"The average grade is {stats.Average:N1}"); //N1 is format to 1 decimal place
            System.Console.WriteLine($"The letter grade is {stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                System.Console.WriteLine("Enter a grade or 'q' to quit");
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
                    System.Console.WriteLine(ex.Message);
                }
                catch (FormatException ex)
                {
                    System.Console.WriteLine(ex.Message);
                }
                finally
                {
                    System.Console.WriteLine("**");
                }

            }
        }

        static void OnGradeAdded(object sender, EventArgs e)
        {
            System.Console.WriteLine("A grade was added");
        }
    }
}

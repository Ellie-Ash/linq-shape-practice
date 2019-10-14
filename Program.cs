using System;
using System.Collections.Generic;
using System.Linq;

namespace linqStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> nums = new List<int>
            {
                1,2,3,4,5,78,43,11,5
            };

            // Find (js: find)
            int foundNum = nums.Find(n => n == 43);
            Console.WriteLine(foundNum);

            // Where (js: filter)
            List<int> filteredNums = nums.Where(n => n < 5).ToList();
            Console.WriteLine(filteredNums);

            // OrderBy (js: sort) with chaining
            List<int> orderedAndFiltered = 
            nums
            .Where(n => n < 5)
            .OrderBy(n => n)
            .ToList();
            Console.WriteLine(orderedAndFiltered);

            // Sum instead of JS reduce
            int sum = nums.Sum();
            Console.WriteLine($"Sum: {sum}");
            int smallest = nums.Min();
            Console.WriteLine($"Min: {smallest}");
            int biggest = nums.Max();
            Console.WriteLine($"Max: {biggest}");

            List<int>  doubled = nums.Select(num => num * 2).ToList();
            Console.WriteLine($"Doubled: {doubled}");

            List<string> stringedNums = nums.Select(n => 
            {
                return n.ToString();
            }).ToList();
            Console.WriteLine($"Stringed Nums: {stringedNums}");


            //New Syntax
            List<int> cohortStudentCount = new List<int>()
            {
                25, 12, 28, 22, 11, 25, 27, 24, 19
            };
            Console.WriteLine($"Largest cohort was {cohortStudentCount.Max()}");
            Console.WriteLine($"Smallest cohort was {cohortStudentCount.Min()}");
            Console.WriteLine($"Total students is {cohortStudentCount.Sum()}");

            IEnumerable<int> idealSizes = from count in cohortStudentCount
                where count < 27 && count > 19
                orderby count ascending
                select count;

            Console.WriteLine($"Average ideal size is {idealSizes.Average()}");

            // The @ symbol lets you create multi-line strings in C#
            Console.WriteLine($@"
            There were {idealSizes.Count()} ideally sized cohorts
            There have been {cohortStudentCount.Count()} total cohorts");

            List<int> idealSizesLambda = cohortStudentCount
            .Where(count => count < 27 && count> 19)
            .OrderBy(count => count)
            .ToList();


            //Linq with complex objects
            List<Shape> shapes = new List<Shape>()
            {
                new Shape() {NumberOfSides = 3, Height = 10.5, Width = 15.2, Color = "orange"},
                new Shape() {NumberOfSides = 4, Height = 13.0, Width = 13.0, Color = "red"},
                new Shape() {NumberOfSides = 1, Height = 6.8, Width = 6.8, Color = "blue"},
            };

            Shape foundSquare = shapes.Find(shape => shape.NumberOfSides == 4);
            Console.WriteLine($"Found Square: {foundSquare}");

            List<Shape> notCircles = shapes.Where(shape => shape.NumberOfSides > 1).ToList();
            Console.WriteLine($"Not Circles: {notCircles}");

            double sumOfHeights  = shapes.Select(shape => shape.Height).Sum();
            Console.WriteLine($"Sum Of Heights: {sumOfHeights}");
        }
    }
}

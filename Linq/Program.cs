using System;
using System.Collections.Generic;
using System.Linq;

namespace Linq
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = new List<int>() { 8, 3, 11, 3, 23, 9, 2, 7, 300 };

            // OrderBy, OrderByDescending, and Reverse
            var orderedNumbers = numbers.OrderBy(num => num);
            foreach (int num in orderedNumbers)
            {
                Console.WriteLine(num);
            }

            var descendingOrderedNumbers = numbers.OrderByDescending(num => num);
            Console.WriteLine($"descendingOrderNumbers: { String.Join(',', descendingOrderedNumbers) }");

            numbers.Reverse(); // only reverse changes the collection
            foreach (int num in numbers)
            {
                Console.WriteLine(num);
            }

            // Max, Sum, Min, Average, Count
            var maxNumber = numbers.Max();
            Console.WriteLine(maxNumber);

            var sumOfNumbers = numbers.Sum();
            Console.WriteLine(sumOfNumbers);

            var minOfNumbers = numbers.Min();
            Console.WriteLine(minOfNumbers);

            var averageNumber = numbers.Average();
            Console.WriteLine(averageNumber);

            var count = numbers.Count();
            Console.WriteLine(count);

            var biggerNumbers = numbers.Where(num => num > 9); // filters based on the condition
            Console.WriteLine($"biggerNumbers: { String.Join(',', biggerNumbers) }");

            // Select is like Array.map, returns a new collection of IEnumerable<T>
            // transforming data
            var biggerNumbers2 = numbers.Select(num => num * 12);
            Console.WriteLine($"biggerNumbers2: { String.Join(',', biggerNumbers2) }");

            var firstNumber = numbers.First();
            Console.WriteLine(firstNumber);

            var lastNumber = numbers.Last();
            Console.WriteLine(lastNumber);

            // first matching item
            var firstMatchingNumber = numbers.Where(num => num > 9).First();
            var firstMatchingNumber2 = numbers.First(num => num > 9); // does the same thing above
            Console.WriteLine(firstMatchingNumber);
            Console.WriteLine(firstMatchingNumber2);

            // Quantifier Operations
            // returns a boolean
            // all, any, contains
            var allNumbers = numbers.All(c => c > 5); // will return false
            Console.WriteLine(allNumbers);

            var anyNumbers2 = numbers.Any(c => c < 5); // will return true
            Console.WriteLine(anyNumbers2);

            var containsNumber = numbers.Contains(7) || numbers.Contains(3);
            Console.WriteLine(containsNumber);

            // set operators
            // combine the results of two queries into a single result.
            List<int> badNumbers = new List<int>() { 19, 15, 950 };

            var onlyGoodNumbers = numbers.Except(badNumbers);
            Console.WriteLine($"onlyGoodNumbers: { String.Join(',', onlyGoodNumbers) }");

            var uniqueNumbers = numbers.Distinct();
            Console.WriteLine($"uniqueNumbers: { String.Join(',', uniqueNumbers) }");

            var firstThreeNumbersAndTheSixth = numbers.Take(3).Concat(numbers.Skip(5).Take(2));
            Console.WriteLine($"firstThreeNumbersAndTheSixth: { String.Join(',', firstThreeNumbersAndTheSixth) }");

            var animals = new List<Animal>()
            {
                new Animal {Type = "Pikachu", HeightInInches = 24, WeightInPounds = 10},
                new Animal {Type = "Charzard", HeightInInches = 72, WeightInPounds = 25},
                new Animal {Type = "Bulbasaur", HeightInInches = 12, WeightInPounds = 450},
                new Animal {Type = "Jigglypuff", HeightInInches = 9, WeightInPounds = 5},
            };

            var animalsThatStartWithC = animals.Where(animal => animal.Type.ToLower().StartsWith("C"));
            foreach (var animal in animalsThatStartWithC)
            {
                Console.WriteLine(animal.Type);
            }

            // group a collection by a given key (based on a function)
            var groupAnimals = animals.GroupBy(animal => animal.Type.First()); // gets the first character of each animal
            foreach (var animalGroup in groupAnimals)
            {
                Console.WriteLine($"Animals that start with {animalGroup.Key}");

                foreach (var animal in animalGroup)
                {
                    Console.WriteLine(animal.Type);
                }
            }
        }
    }
}

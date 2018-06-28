using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestEducationProject
{
    class Program
    {
        //static IEnumerable<int> ReadData()
        //{
        //    Console.Write("Enter elements: ");
        //    string line = Console.ReadLine() ?? string.Empty;
        //    string[] parts = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //    return parts.Select(int.Parse).ToList();
        //}

        static void Main(string[] args)
        {
            //IEnumerable<int> numbers = ReadData();
            //while (numbers.Any())
            //{
            //    MyArray array = new MyArray(numbers);
            //    Console.WriteLine($"Max = {array.Maximum()}");
            //    numbers = ReadData();
            //}

            new MyArrayTests().Maximum_ArrayContainsOneElement_ResultThatValue();

            Console.WriteLine("Press enter to continue...");
            Console.ReadKey();

        }
    }

    public class MyArray
    {
        private int[] Data { get; }

        public MyArray(IEnumerable<int> values)
        {
            Data = values.ToArray();
        }

        public int Maximum()
        {
            // Assume length is > 0
            int max = this.Data[0];
            for (int i = 1; i < this.Data.Length; i++)
            {
                if (this.Data[i] > max)
                {
                    max = this.Data[i];
                }
            }
            return max;
        }
    }
}

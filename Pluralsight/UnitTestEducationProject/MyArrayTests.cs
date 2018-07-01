using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestEducationProject
{
    class MyArrayTests
    {
        // Method under test
        // Scenario which is tested
        // Expected behavior / state / result
        public void Maximum_ArrayContainsOneElement_ResultThatValue()
        {
            MyArray array = new MyArray(new[] { 5 });
            int max = array.Maximum();
            if (max != 5) { Console.WriteLine("Exception"); }
            else { Console.WriteLine("Passed"); }
        }
    }
}

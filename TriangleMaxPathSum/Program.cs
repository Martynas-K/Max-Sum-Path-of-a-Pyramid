using System;

namespace TriangleMaxPathSum
{
    class Program
    {
        static void Main()
        {
            var data = Triangle.GetData();
            int[] triangle = data.Item1;
            int lineCount = data.Item2;

            int result = PathSumCalculator.GetMaxPathSum(triangle, lineCount);

            // Adjust condition if data can have negative numbers.
            if (result < 0)
                Console.WriteLine("There is no possible path to the bottom of the pyramid.");
            else
                Console.WriteLine("The maximum sum of any path is " + result + ".");
        }
    }
}

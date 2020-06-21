using System;

namespace TriangleMaxPathSum
{
    public static class PathSumCalculator
    {
        public static bool IsEven(int number)
        {
            return number % 2 == 0;
        }

        public static int GetMaxPathSum(int[] triangle, int rowCount)
        {
            int maxPathSum;
            int[] triangleAdjusted = (int[])triangle.Clone();

            // Looping through rows, starting with second to last.
            for (int row = rowCount - 1; row > 0; --row)
            {
                int lastOfPreviousRow = (row - 1) * row / 2;
                int lastOfCurrentRow = (row + 1) * row / 2;
                
                // Looping through nodes in this row.
                for (int el = lastOfPreviousRow; el < lastOfCurrentRow; ++el)
                {
                    int elementDownwards = triangle[el + row];
                    int elementDiagonally = triangle[el + row + 1];
                    int adjustedElementDownwards = triangleAdjusted[el + row];
                    int adjustedElementDiagonally = triangleAdjusted[el + row + 1];
                    int addToEl = 0;

                    // Checking for even/odd condition, adjusting triangle accordingly.
                    if (IsEven(triangle[el]))
                    {
                        if (!IsEven(elementDownwards) && !IsEven(elementDiagonally))
                            addToEl = Math.Max(adjustedElementDownwards, adjustedElementDiagonally);
                        else if (!IsEven(elementDownwards))
                            addToEl = adjustedElementDownwards;
                        else if (!IsEven(elementDiagonally))
                            addToEl = adjustedElementDiagonally;
                        // Ensures that the path reaches bottom of the pyramid if this path is blocked, but has the highest sum.
                        else
                            triangleAdjusted[el] = int.MinValue;
                    } else { 
                        if (IsEven(elementDiagonally) && IsEven(elementDownwards))
                            addToEl = Math.Max(adjustedElementDownwards, adjustedElementDiagonally);
                        else if (IsEven(elementDownwards))
                            addToEl = adjustedElementDownwards;
                        else if (IsEven(elementDiagonally))
                            addToEl = adjustedElementDiagonally;
                        // Ensures that the path reaches bottom of the pyramid if this path is blocked, but has the highest sum.
                        else
                            triangleAdjusted[el] = int.MinValue;
                    }
                    triangleAdjusted[el] += addToEl;
                }
            }

            maxPathSum = triangleAdjusted[0];
            return maxPathSum;
        }
    }
}

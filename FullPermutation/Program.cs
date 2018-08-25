using System;

namespace FullPermutation
{
    class Program
    {
        static void Main(string[] args)
        {
            var array = new int[]{ 1, 2, 3, 4};
            var result = Permutation(array);
            for (int i = 0; i < result.row; i++)
            {
                for (int j = 0; j < result.col; j++)
                {
                    Console.Write(result.array[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.ReadLine();
        }

        static (int[,] array, int row, int col) Permutation(int[] array)
        {
            int col = array.Length;
            int row = Factorial(col);
            var result = new int[row, col];
            for (int i = 0; i < col; i++)
            {
                var repeat = Factorial(array.Length - i - 1);
                var offset = 0;
                for (int c = 0; c < row / repeat; c++)
                {
                    for (int r = c * repeat; r < (c + 1) * repeat; r++)
                    {
                        for (int t = offset; true; t++)
                        {
                            if (result[r, (c + t) % col] == 0)
                            {
                                result[r, (c + t) % col] = array[i];
                                offset = t % col;
                                break;
                            }
                        }
                    }
                }
            }
            return (result, row, col);
        }

        static int Factorial(int n)
        {
            int result = 1;
            for (int i = 1; i <= n; i++)
                result *= i;
            return result;
        }

    }
}

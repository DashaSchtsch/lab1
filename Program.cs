using System;

namespace lab1
{
    class Program
    {
        static Random rand = new Random();
        static void Main()
        {
            int matrixSize = GetUserInput("Enter matrix size:");
            int[,] matrix = GenerateRandomMatrix(matrixSize);
            OutputMatrix(matrix);

            int minValue = GetUserInput("Enter minimum value of the interval:");
            int maxValue = GetUserInput("Enter maximum value of the interval:");

            int[] sumValues = CalculateSum(matrixSize, matrix, minValue, maxValue);

            Console.WriteLine("Result:");
            OutputResult(sumValues);
        }

        static int GetUserInput(string question)
        {
            int input;
            bool isValidInput = false;

            do
            {
                Console.WriteLine(question);
                isValidInput = int.TryParse(Console.ReadLine(), out input);

                if (!isValidInput)
                {
                    Console.WriteLine("Invalid input. Please enter a valid integer value.");
                }
            } while (!isValidInput);

            return input;
        }


        static int[,] GenerateRandomMatrix(int matrixSize)
        {
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                {
                    matrix[rowIndex, columnIndex] = rand.Next(20);
                }
            }

            return matrix;
        }

        static void OutputMatrix(int[,] matrix)
        {
            int size = matrix.GetLength(0);
            for (int rowIndex = 0; rowIndex < size; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < size; columnIndex++)
                {
                    Console.Write(matrix[rowIndex, columnIndex] + "\t");
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Calculates the sum of elements in each row of the matrix that fall outside the range
        /// defined by minValue and maxValue.
        /// </summary>
        /// <param name="matrixSize">The size of the matrix</param>
        /// <param name="matrix">The matrix whose rows are to be processed</param>
        /// <param name="minValue">The lower bound of the range</param>
        /// <param name="maxValue">The upper bound of the range</param>
        /// <returns>An array containing the sum of elements for each row of the matrix</returns>
        static int[] CalculateSum(int matrixSize, int[,] matrix, int minValue, int maxValue)
        {
            int[] sumValues = new int[matrixSize];

            for (int rowIndex = 0; rowIndex < matrixSize; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < matrixSize; columnIndex++)
                {
                    if (matrix[rowIndex, columnIndex] < minValue || matrix[rowIndex, columnIndex] > maxValue)
                    {
                        sumValues[rowIndex] += matrix[rowIndex, columnIndex];
                    }
                }
            }

            return sumValues;
        }
        static void OutputResult(int[] sumValues)
        {
            foreach (int sumIndex in sumValues)
            {
                Console.Write(sumIndex + "\t");
            }
            Console.WriteLine();
        }
    }
}

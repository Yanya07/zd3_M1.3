using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите размер квадратной матрицы: ");
            int size = int.Parse(Console.ReadLine());
            int[,] matrix = GenerateMatrix(size);// Создание и заполнение матрицы случайными значениями от -50 до +50

            Console.WriteLine("\nИсходная матрица:");
            PrintMatrix(matrix);
            SortMatrixByRowSums(ref matrix);// Сортировка строк матрицы по возрастанию суммы их элементов

            Console.WriteLine("\nМатрица после сортировки строк по сумме элементов:");
            PrintMatrix(matrix);

            Console.WriteLine("Нажмите Enter, чтобы завершить.");
            Console.ReadLine();
        }
        static int[,] GenerateMatrix(int size)// Метод для создания квадратной матрицы с элементами от -50 до 50
        {
            Random rand = new Random();
            int[,] matrix = new int[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    matrix[i, j] = rand.Next(-50, 51); // Случайные значения от -50 до 50
                }
            }
            return matrix;
        }
        static void SortMatrixByRowSums(ref int[,] matrix)// Метод для сортировки строк матрицы по возрастанию суммы их элементов
        {
            int size = matrix.GetLength(0);
            int[] rowSums = new int[size];// Создаем массив сумм строк
            for (int i = 0; i < size; i++)
            {
                rowSums[i] = 0;
                for (int j = 0; j < size; j++)
                {
                    rowSums[i] += matrix[i, j];
                }
            }
            for (int i = 0; i < size - 1; i++)// Сортируем строки матрицы по сумме их элементов
            {
                for (int j = i + 1; j < size; j++)
                {
                    if (rowSums[i] > rowSums[j])
                    {
                        int tempSum = rowSums[i];// Меняем местами суммы строк
                        rowSums[i] = rowSums[j];
                        rowSums[j] = tempSum;
                        for (int k = 0; k < size; k++)// Меняем местами сами строки
                        {
                            int tempValue = matrix[i, k];
                            matrix[i, k] = matrix[j, k];
                            matrix[j, k] = tempValue;
                        }
                    }
                }
            }
        }
        static void PrintMatrix(int[,] matrix)// Метод для вывода матрицы на экран
        {
            int size = matrix.GetLength(0);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    Console.Write($"{matrix[i, j],5} ");
                }
                Console.WriteLine();
            }
        }
    }
}

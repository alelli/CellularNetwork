using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CellularNetwork
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Введите количество вышек связи (max 100): ");
            int stations = AssignValue();

            Console.Write("Введите радиус зоны покрытия частот: ");
            var radius = AssignValue();
            Console.Write(Environment.NewLine);

            Console.WriteLine("Введите расстояния между вышками: ");
            int[,] frequencyIntersection = EnterDistances(stations, radius);
            Console.Write(Environment.NewLine);

            Console.WriteLine("Матрица пересечений частот вышек связи (1 - пересекаются, 0 - не пересекаются): ");
            ShowMatrix(frequencyIntersection);
            Console.Write(Environment.NewLine);

            List<Vertex> result = GraphColoringAlgorithm.UseAlgorithm(frequencyIntersection);
            ShowResult(result);

            Console.ReadKey();
        }

        private static int AssignValue()
        {
            int value;
            while (false == int.TryParse(Console.ReadLine(), out value) || value < 0 || value > 100)
            {
                Console.WriteLine("Значение некорректно. Введите его раз: ");
            }
            return value;
        }

        private static int[,] EnterDistances(int stations, int radius)
        {
            int[,] distances = new int[stations, stations];
            int[,] frequencyIntersection = new int[stations, stations];
            for (int i = 0; i < stations; i++)
            {
                for (int j = 0; j < stations && j != i; j++)
                {
                    Console.Write("{0} и {1}: ", j + 1, i + 1);
                    distances[i, j] = AssignValue();

                    if (distances[i, j] <= 20 && distances[i, j] > 0)
                    {
                        frequencyIntersection[i, j] = 1;
                        frequencyIntersection[j, i] = 1;
                    }

                    FormatEstimationMatrix(ref frequencyIntersection, distances[i, j], radius, i, j);
                }
            }
            return frequencyIntersection;
        }

        private static void FormatEstimationMatrix(ref int[,] frequencyIntersection, int distance, int radius, int station1, int station2)
        {
            if (distance <= radius && distance > 0)
            {
                frequencyIntersection[station1, station2] = 1;
                frequencyIntersection[station2, station1] = 1;
            }
        }

        private static void ShowMatrix(int[,] matrix)
        {
            int dimension = matrix.GetLength(0);
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }

        private static void ShowResult(List<Vertex> vertices)
        {
            vertices.Sort();
            Console.WriteLine("Результат работы алгоритма: ");
            for (int i = 0; i < vertices.Count; i++)
            {
                Console.WriteLine("Вышка {0} - цвет {1}", vertices[i].Id + 1, vertices[i].Color);
            }
        }
    }
}

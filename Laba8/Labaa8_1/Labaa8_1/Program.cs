using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {

            int[] array = new int[10000];
            string path = @"C:\Users\HP\source\repos\Лаба7\lb7\sorted.dat";
            using (BinaryReader reader = new BinaryReader(File.Open(path, FileMode.Open)))
            {
                if (reader.PeekChar() > -1)
                {
                    for (int i = 0; i < array.Length - 1; i++)
                    {
                        array[i] = reader.ReadInt32();
                    }
                }
            }

            Console.WriteLine("Введите число для поиска");
            int nums = int.Parse(Console.ReadLine());
            Console.WriteLine("Линейный поиск");
            SearchLinear(array, nums);
            Console.WriteLine();
            Console.WriteLine("Бинарныйы поиск");
            SearchBinary(array, nums);
            Console.WriteLine();
            Console.WriteLine("Интерполяционный поиск");
            SearchInterpolation(array, nums);
            Console.ReadKey();

        }

        public static void SearchLinear(int[] search, int nums)
        {

            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            int[] pos = new int[search.Length];
            int cnt = 0;
            int INDEXposition = 0;
            bool res = false;

            for (int i = 0; i < search.Length; i++, cnt++)
            {
                if (search[i] == nums)
                {
                    pos[INDEXposition] = i;
                    INDEXposition++;
                    end = DateTime.Now;
                    res = true;

                }
            }
            TimeSpan interval = end - start;

            if (res == true)
            {
                Console.WriteLine($"Позиция найденного элемента:{INDEXposition}\nВремя работы алгоритма:{interval}\nКоличество сравнений: {cnt}");
            }
            else
            {
                Console.WriteLine("Не найдено");
            }
        }
        public static void SearchBinary(int[] search, int nums)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;

            int INDEXposition = 0;
            bool res = false;
            int cnt = 0;
            int low = 0;
            int high = search.Length - 1;
            int mid = 0;
            while (low <= high)
            {
                mid = (low + high) / 2;

                if (nums == search[mid])
                {
                    INDEXposition = mid;
                    res = true;
                    end = DateTime.Now;

                }
                else if (nums > search[mid])
                {
                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
                cnt++;
            }
            TimeSpan interval = end - start;

            if (res == true)
            {

                Console.WriteLine($"Позиция найденного элемента: {INDEXposition}\nВремя работы алгоритма:{interval}\nКоличество сравнений: {cnt}");
            }
            else
            {
                Console.WriteLine("Не найдено");
            }

        }
        public static void SearchInterpolation(int[] search, int nums)
        {
            DateTime start = DateTime.Now;
            DateTime end = DateTime.Now;
            int INDEXposition = 0;
            bool res = false;
            int cnt = 0;
            int low = 0;
            int mid;
            int high = search.Length - 2;
            int toFind = nums;
            while (search[low] < toFind && search[high] > toFind)
            {
                cnt++;
                mid = low + ((toFind - search[low]) * (high - low)) / (search[high] - search[low]);
                if (search[mid] < toFind)
                    low = mid + 1;
                else if (search[mid] > toFind)
                    high = mid - 1;
                else if (toFind == search[mid])
                {
                    INDEXposition = mid + 1;
                    res = true;
                    end = DateTime.Now;

                }
            }

            TimeSpan interval = end - start;

            if (res == true)
            {

                Console.WriteLine($"Позиция найденного элемента: {INDEXposition}\nВремя работы алгоритма:{interval}\nКоличество сравнений: {cnt}");
            }
            else
            {
                Console.WriteLine("Не найдено");
            }

        }
    }
}

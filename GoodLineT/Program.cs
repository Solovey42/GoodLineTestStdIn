using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GoodLineWords
{
    class Program
    {
        static void sortABC(string[] mas) ///Сортировка по алфавиту и вывод
        {
            string swap;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int k = i + 1; k < mas.Length; k++)
                {
                    if (mas[i].CompareTo(mas[k]) > 0)
                    {
                        swap = mas[i];
                        mas[i] = mas[k];
                        mas[k] = swap;
                    }
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                Console.WriteLine(mas[i]);
            }
            Console.WriteLine();
        }
        static void sortUnique(string[] mas) ///Вывод массива уникальных элементов
        {
            string[] uniques = mas.Distinct().ToArray();
            for (int i = 0; i < uniques.Length; i++)
            {
                Console.WriteLine(uniques[i]);
            }
            Console.WriteLine();
        }
        static void Count(string[] mas) ///Подсчет одинаковых элементов исходного массива и вывод их количества
        {
            int[] count = new int[mas.Length];
            for (int i = 0; i < mas.Length; i++)
            {
                for (int k = 0; k < mas.Length; k++)
                {
                    if (mas[i].CompareTo(mas[k]) == 0)
                    {
                        count[i]++;

                    }
                }
            }
            for (int i = 0; i < mas.Length; i++)
            {
                mas[i] = mas[i] + " " + count[i];

            }
            sortUnique(mas);
        }

        static void CountSort(string[] mas) ///Сортировка по количетсву элементов и авфавиту
        {
            string swap;
            for (int i = 0; i < mas.Length - 1; i++)
            {
                for (int k = i + 1; k < mas.Length; k++)
                {
                    if (Convert.ToInt32(mas[i].Substring(mas[i].Length - 1)) < Convert.ToInt32(mas[k].Substring(mas[k].Length - 1)))///по количеству
                    {
                        swap = mas[i];
                        mas[i] = mas[k];
                        mas[k] = swap;
                    }
                }

            }
            string[] uniques = mas.Distinct().ToArray();
            for (int i = 0; i < uniques.Length; i++)
            {
                for (int k = i + 1; k < uniques.Length; k++)
                {
                    if (Convert.ToInt32(uniques[i].Substring(uniques[i].Length - 1)) == Convert.ToInt32(uniques[k].Substring(uniques[k].Length - 1)))///по алфавиту если равное коилчество
                    {
                        if (uniques[i].Substring(0, uniques[i].IndexOf(' ')).CompareTo(uniques[k].Substring(0, uniques[k].IndexOf(' '))) > 0)
                        {
                            swap = uniques[i];
                            uniques[i] = uniques[k];
                            uniques[k] = swap;
                        }
                    }
                }
            }
            for (int i = 0; i < uniques.Length; i++)
            {
                Console.WriteLine(uniques[i]);
            }
        }
        static void Main(string[] args)
        {

            int caseSwitch;
            if (args.Length == 0)
                caseSwitch = 1;
            else
                caseSwitch = 2;
            switch (caseSwitch)
            {
                case 1:///Если аргументы командной строки не были введены
                    {

                        Stream inputStream = Console.OpenStandardInput();
                        byte[] bytes = new byte[100];
                        int outputLength = inputStream.Read(bytes, 0, 100);
                        char[] chars = Encoding.UTF8.GetChars(bytes, 0, outputLength);
                        string s = new string(chars);
                        s = s.Trim().Trim('"');
                        args = s.Split(' ');


                        goto case 2;
                    }
                case 2:///Если аргументы командной строки были введены
                    {
                        Console.WriteLine("Вывод слов:");
                        for (int i = 0; i < args.Length; i++)
                        {
                            Console.WriteLine(args[i]);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Сортировка по алфавиту:");
                        sortABC(args);
                        Console.WriteLine("Слова без повторений:");
                        sortUnique(args);
                        Console.WriteLine("Слова без повторений с количеством:");
                        Count(args);
                        Console.WriteLine("Отсортированные слова без повторений с количеством:");
                        CountSort(args);
                        Console.Read();
                        break;
                    }
            }
        }
    }
}

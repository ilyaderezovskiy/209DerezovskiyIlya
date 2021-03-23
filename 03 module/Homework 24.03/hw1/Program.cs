using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using library;

namespace hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            //    Задание 1
            bool correct = true;
            if (File.Exists("data.txt"))
            {
                Street[] streetsArray;
                int[] houses;
                int N;
                Console.WriteLine("Введите количество улиц:");
                if (int.TryParse(Console.ReadLine(), out N) && N > 0)
                {
                    streetsArray = new Street[N];
                    using (StreamReader sr = new StreamReader("data.txt", System.Text.Encoding.Default))
                    {
                        string line;
                        for (int j = 0; j < N; j++)
                        {
                            if ((line = sr.ReadLine()) != null)
                            {
                                string[] lines = line.Split();
                                houses = new int[lines.Length - 2];
                                if (lines.Length > 1 && Regex.IsMatch(lines[0], @"^[a-zA-Zа-яА-Я]+$") && correct)
                                {
                                    for (int i = 1; i < lines.Length - 1; i++)
                                    {
                                        if (!int.TryParse(lines[i], out houses[i - 1]) || houses[i - 1] < 1 || houses[i - 1] > 100)
                                        {
                                            correct = false;
                                        }
                                    }
                                    if (correct)
                                    {
                                        streetsArray[j] = new Street(lines[0], houses);
                                    }
                                }
                                else
                                {
                                    correct = false;
                                    Console.WriteLine("Некорректные данные!");
                                    break;
                                }
                            }
                            else
                            {
                                correct = false;
                                Console.WriteLine("Некорректные данные!");
                                break;
                            }
                        }
                    }
                    if (correct == false)
                    {
                        streetsArray = new Street[N];
                        Random rand = new Random();
                        for (int i = 0; i < N; i++)
                        {
                            houses = new int[rand.Next(1, 10)];
                            for (int j = 0; j < houses.Length; j++)
                            {
                                houses[j] = rand.Next(1, 100);
                            }
                            streetsArray[i] = new Street(new string(Enumerable.Repeat(@"abcdefghijklmnopqrstuvwxyz", rand.Next(5, 10)).Select(s => s[rand.Next(s.Length)]).ToArray()), houses);
                        }
                    }
                    using (StreamWriter sw = new StreamWriter("out.txt", false, System.Text.Encoding.Default))
                    {
                        foreach (var item in streetsArray)
                        {
                            Console.WriteLine(item.ToString());
                            sw.WriteLine(item.ToString());
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Некорректный ввод!");
                }
            }
            else
            {
                Console.WriteLine("Файл не найден!");
            }


            //    Задание 2
            if (File.Exists("out.txt"))
            {
                Street[] streetsArray;
                int[] houses;

                using (StreamReader sr = new StreamReader("out.txt", System.Text.Encoding.Default))
                {
                    string line = sr.ReadToEnd();
                    string[] lines = line.Split('\n');
                    int N = lines.Length - 1;
                    streetsArray = new Street[N];
                    for (int k = 0; k < N; k++)
                    {
                        bool correct2 = true;
                        if (lines[k] != null)
                        {
                            string[] lines2 = lines[k].Split();
                            for (int j = 0; j < lines2.Length; j++)
                            {
                                houses = new int[lines2.Length - 1];
                                if (lines2.Length > 1 && Regex.IsMatch(lines2[0], @"^[a-zA-Zа-яА-Я]+$"))
                                {
                                    for (int i = 1; i < lines2.Length ; i++)
                                    {
                                        if (!int.TryParse(lines2[i], out houses[i - 1]) || houses[i - 1] < 1 || houses[i - 1] > 100)
                                        {
                                            streetsArray[k] = new Street("-", new int[0]);
                                            correct2 = false;
                                        }
                                    }
                                    if (correct2)
                                    {
                                        streetsArray[k] = new Street(lines2[0], houses);
                                    }
                                }
                            }
                            
                        }
                        else
                        {
                            streetsArray[k] = new Street("-", new int[0]);
                        }
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Волшебные улицы:");
                foreach (var item in streetsArray)
                {
                    if (~item % 2 != 0 && !item)
                    {
                        Console.WriteLine(item.ToString());
                    }
                }
            }
            else
            {
                Console.WriteLine("Файл не найден!");
            }
        }
    }
}

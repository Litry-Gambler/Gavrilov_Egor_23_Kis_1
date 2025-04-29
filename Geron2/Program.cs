using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geron2
{
    internal class Program
    {
            static void Main(string[] args)
            {
                int k = 0;
                int n = 0;
                double[] mass = null; //null null null null null null null

                Console.WriteLine("Формула Герона");

                do
                {
                    try
                    {
                        Console.Write("Введите количество граней (сторон): ");
                        n = Convert.ToInt32(Console.ReadLine());

                        if (n <= 0)
                            Console.WriteLine("Количество граней должно быть положительным числом.");
                        else
                            k = 0;
                    }
                    catch
                    {
                        Console.WriteLine("Ошибка ввода. Введите целое число.");
                        k = 1;
                    }
                }
                while (k != 0);

                mass = new double[n];

                do
                {
                    try
                    {
                        if (k == 1)
                            Console.WriteLine("Значения не могут быть нулём или отрицательными. Введите другие значения.");

                        for (int i = 0; i < n; i++)
                        {
                            Console.Write($"Введите длину стороны {i + 1}: ");
                            mass[i] = Convert.ToDouble(Console.ReadLine());
                        }

                        k = 0;
                        for (int i = 0; i < mass.Length; i++)
                        {
                            if (mass[i] <= 0)
                            {
                                k = 1;
                                break;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Ошибка ввода: " + ex.Message);
                        k = 1;
                    }
                }
                while (k == 1);

                Triple triple1 = new Triple(mass, n);
                triple1.CheckAndGeron();

                Console.Read();
            }
        }

        public class Triple
        {
            private double[] massive;
            private int sides;

            public Triple(double[] massive, int sidesCount)
            {
                this.massive = massive;
                this.sides = sidesCount;
            }

            public void CheckAndGeron()
            {
                Console.WriteLine("Количество граней: " + sides);
                Console.Write("Стороны фигуры: ");

                string result = "";
                for (int i = 0; i < massive.Length; i++)
                {
                    if (i == 0)
                        result += massive[i];
                    else
                        result += ", " + massive[i];
                }
                Console.WriteLine(result);

                double semiperimeter = 0;
                for (int i = 0; i < massive.Length; i++)
                {
                    semiperimeter += massive[i];
                }
                semiperimeter /= 2;

                double area = Math.Sqrt(semiperimeter);
                for (int i = 0; i < massive.Length; i++)
                {
                    area *= Math.Sqrt(semiperimeter - massive[i]);
                }

                if (sides == 3)
                {
                    if (massive[0] + massive[1] > massive[2] && massive[0] + massive[2] > massive[1] && massive[1] + massive[2] > massive[0])
                    {
                        Console.WriteLine("Площадь треугольника: " + area);
                    }
                    else
                    {
                        Console.WriteLine("Такого треугольника не существует.");
                    }
                }
                else
                {
                    Console.WriteLine("Условная \"площадь\" фигуры с " + sides + " сторонами: " + area);
                    Console.WriteLine("(Проверка на существование не выполнялась)");
                }
            }
        }
    }
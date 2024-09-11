using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TriangleTest2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Ввод данных
            Console.WriteLine("Введите длины сторон треугольника:");

            double a = InputSide("a");
            double b = InputSide("b");
            double c = InputSide("c");

            // Проверка на корректность сторон
            if (!IsValidTriangle(a, b, c))
            {
                Console.WriteLine("Невозможно образовать треугольник с заданными сторонами.");
            }
            else
            {
                // Определение вида треугольника
                string triangleType = GetTriangleType(a, b, c);
                Console.WriteLine($"Треугольник: {triangleType}");

                // Вычисление площади треугольника
                double area = GetTriangleArea(a, b, c);
                Console.WriteLine($"Площадь треугольника: {area}");
            }

            // Ожидание ввода, чтобы программа не закрылась
            Console.WriteLine("Нажмите любую клавишу для завершения...");
            Console.ReadLine();
        }

        // Ввод стороны треугольника
        static double InputSide(string sideName)
        {
            double side;
            do
            {
                Console.Write($"Введите длину стороны {sideName}: ");
            } while (!double.TryParse(Console.ReadLine(), out side) || side <= 0);

            return side;
        }

        // Проверка корректности сторон треугольника
        static bool IsValidTriangle(double a, double b, double c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        // Определение вида треугольника
        static string GetTriangleType(double a, double b, double c)
        {
            // Сортируем стороны по возрастанию для удобства
            double[] sides = { a, b, c };
            Array.Sort(sides);
            a = sides[0];
            b = sides[1];
            c = sides[2];

            double a2 = a * a;
            double b2 = b * b;
            double c2 = c * c;

            // Проверяем на тип треугольника
            if (a2 + b2 == c2)
            {
                return "Прямоугольный";
            }
            else if (a2 + b2 > c2)
            {
                return "Остроугольный";
            }
            else
            {
                return "Тупоугольный";
            }
        }

        // Вычисление площади треугольника по формуле Герона
        static double GetTriangleArea(double a, double b, double c)
        {
            double s = (a + b + c) / 2; // Полупериметр
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }
    }

  }

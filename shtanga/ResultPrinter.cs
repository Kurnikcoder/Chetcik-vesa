using System;
using System.Collections.Generic;
using System.Text;

namespace shtanga
{
    internal class ResultPrinter
    {
        public void Print(string message, List<double> plates)
        {
            if (plates.Count > 0)
            {
                // 1. УСПЕХ: подсвечиваем зеленым
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"✔ {message}");
                Console.ResetColor();

                // 2. Блины рисуем бирюзовым цветом в виде дисков
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("  Навесить на сторону: ");
                foreach (var plate in plates)
                {
                    Console.Write($"[ {plate} кг ] ");
                }
                Console.WriteLine();
                Console.ResetColor();
            }
            else
            {
                // 3. ОШИБКА: подсвечиваем красным
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"✖ {message}");
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine(new string('─', 50));
            Console.ResetColor();
            Console.WriteLine();

        }
    }
}

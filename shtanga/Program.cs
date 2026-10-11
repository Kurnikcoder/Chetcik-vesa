using shtanga;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Numerics;

Barbell barbell = new Barbell();
Inventory inventory = new Inventory();
BarbellCalculator calculator = new BarbellCalculator();
ResultPrinter printer = new ResultPrinter();
for (int attempt = 1; attempt <= 3; attempt++)
{
    // 1. Спрашиваем вес для текущей попытки
    Console.Write($"Введите вес на попытку #{attempt}: ");
    double userWeight = Convert.ToDouble(Console.ReadLine().Replace('.', ','));

    // 2. Отправляем в калькулятор
    var result = calculator.schetcikvesa(userWeight, barbell, inventory);

    // 3. Отдаем результат в принтер
    printer.Print(result.Message, result.Plates);
}
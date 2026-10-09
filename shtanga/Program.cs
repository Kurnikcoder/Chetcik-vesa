using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Globalization;
Console.Write("Введите вес на первую попытку: ");
double userWeight1 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
Console.Write("Введите вес на вторую попытку: ");
double userWeight2 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
Console.Write("Введите вес на третью попытку: ");
double userWeight3 = Convert.ToDouble(Console.ReadLine().Replace('.', ','));
Inventory inv = new Inventory();
inv.schetcikvesa(userWeight1);
inv.schetcikvesa(userWeight2);
inv.schetcikvesa(userWeight3);
class Inventory
{
    static void PrintList(List<double> list)
    {
        foreach (double item in list)
        {
            Console.Write(item + " "); // печатает число и пробел в одну строчку
        }
        Console.WriteLine(); // в самом конце переносит строку
    }
    public Dictionary<double, int> weights = new()
    {
        [25] = 4,
        [20] = 6,
        [15] = 8,
        [10] = 2,
        [5] = 2,
        [2.5] = 2,
        [1.25] = 2,  

    };
    public Dictionary<double, int> weightstwo;

    public Inventory()
    {
        weightstwo = weights.ToDictionary(pair => pair.Key, pair => pair.Value/2);
    }
 
    public void schetcikvesa(double weight1)
    {
        double totalWeight = 0.0;

        foreach (KeyValuePair<double, int> blincik in weights)
        {
            double plateWeight = blincik.Key;
            int count = blincik.Value;

            double groupTotal = plateWeight * count;
            totalWeight += groupTotal;
           

        }
        if (weight1 <25)
        {
            Console.WriteLine("Вес заявленн неверно в попытку ставиться 25кг");
        }

        else if (weight1 > totalWeight +25)
        {
            Console.WriteLine("К сожалению в зале не хватает блинов для рекорда");
        }
        else if (weight1%2.5 ==0)
        {
            double weightbezgrifa = weight1 - 25;
            double weigthalf = weightbezgrifa / 2;
            if (weigthalf == 0)
            {
                Console.WriteLine("Вес заявлен успешно 25кг");
            }
            int totalcountblunov = weights.Values.Sum();
            List<double> plateList = new(totalcountblunov);
            foreach (var (weight, count) in weightstwo)
            {
                for(int i = 0; i < count; i++)
                {
                    plateList.Add(weight);
                }
            }
            List<double> plateresult = new();
            double current = 0;
            foreach(double Platte in plateList)
            {
                if (current + Platte <= weigthalf)
                {
                    current = current + Platte;
                    plateresult.Add(Platte);
                }
                if (current == weigthalf)
                {
                    break;
                }
                
            }    
            if (current == weigthalf)
            {
                Console.WriteLine($"Вес заявленн успешно {weight1} кг");
                PrintList(plateresult);
            }
           
        }
        else
        {
            Console.WriteLine("В зале нет таких блинов минимальный шаг 2,5кг");
        }
       
        
    }
    
}
            
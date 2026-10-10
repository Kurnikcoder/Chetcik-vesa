using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace shtanga
{
    internal class BarbellCalculator
    {
        public (string Message, List<double> Plates) schetcikvesa(double weight1, Barbell barbell, Inventory inventory)
        {
            Dictionary<double, int> weights = inventory.WeightsCopy();

            double totalWeight = 0.0;
            foreach (KeyValuePair<double, int> blincik in weights)
            {
                double plateWeight = blincik.Key;
                int count = blincik.Value;
                totalWeight += plateWeight * count;
            }

            // 1. Проверка: вес меньше веса самого грифа с замками
            if (weight1 < barbell.WeihhtBellfull)
            {
                return ($"Вес заявлен неверно: минимум в попытку ставится {barbell.WeihhtBellfull} кг (гриф с замками)", new List<double>());
            }

            // 2. Проверка: в зале физически не хватает блинов
            if (weight1 > totalWeight + barbell.WeihhtBellfull)
            {
                return ("К сожалению, в зале не хватает блинов для рекорда", new List<double>());
            }

            // 3. Проверка: минимальный шаг 2.5 кг
            if (weight1 % 2.5 != 0)
            {
                return ("Вес заявлен неверно: такую штангу невозможно собрать (минимальный шаг 2.5 кг)", new List<double>());
            }

            // 4. Считаем чистый вес блинов на одну сторону грифа
            double weightbezgrifa = weight1 - barbell.WeihhtBellfull;
            double weigthalf = weightbezgrifa / 2;

            if (weigthalf == 0)
            {
                return ($"Вес заявлен успешно {weight1} кг (пустой гриф без блинов)", new List<double>());
            }

            // 5. Блины на ОДНУ сторону штанги (половина от всего зала)
            var weightsHalf = weights.ToDictionary(pair => pair.Key, pair => pair.Value / 2);

            List<double> plateList = new();
            foreach (var (plateWeight, count) in weightsHalf)
            {
                for (int i = 0; i < count; i++)
                {
                    plateList.Add(plateWeight);
                }
            }

            // 6. Жадный подбор блинов
            List<double> plateresult = new();
            double current = 0;

            foreach (double platte in plateList)
            {
                if (current + platte <= weigthalf)
                {
                    current += platte;
                    plateresult.Add(platte);
                }

                if (current == weigthalf)
                {
                    break;
                }
            }

            // 7. Проверяем итог: сошёлся ли вес ровно
            if (current == weigthalf)
            {
                return ($"Вес заявлен успешно {weight1} кг", plateresult);
                
            }

            return ("К сожалению, имеющимися блинами не получается собрать точный вес", new List<double>());
        }
    }
}

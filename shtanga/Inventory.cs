using System;
using System.Collections.Generic;
using System.Text;

namespace shtanga
{
    internal class Inventory
    {
        private Dictionary<double, int> _weights = new()
        {
            [25] = 4,
            [20] = 6,
            [15] = 8,
            [10] = 2,
            [5] = 2,
            [2.5] = 2,
            [1.25] = 2,

        };
        private readonly Dictionary<double, int> _weightsmax;
        public Inventory()
        {
            _weightsmax = _weights.ToDictionary(pair => pair.Key, pair => pair.Value);
        }
        public Dictionary<double, int> WeightsCopy()
        {
            return new Dictionary<double, int>(_weights);
        }
        public void Takeitem(double weight, int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("Ошибка: число должно быть больше нуля!");
                return;
            }
            if (!_weights.ContainsKey(weight))
            {
                Console.WriteLine("Ошибка: такого товара у нас нет!");
                return;
            }
            if (_weights[weight] < count)
            {
                Console.WriteLine($"Ошибка: на складе всего {_weights[weight]} шт., а вы проситt {count}");
                return;
            }
                _weights[weight] -= count;

        }
        public void ReturnItem(double weight, int count)
        {
            if (count <= 0)
            {
                Console.WriteLine("Ошибка: число должно быть больше нуля!");
                return;
            }
            if (!_weights.ContainsKey(weight))
            {
                Console.WriteLine("Ошибка: такого товара у нас нет!");
                return;
            }
            if (_weightsmax[weight] < count + _weights[weight])
            {
                Console.WriteLine($"У нас всего было блинов {_weightsmax[weight]}, c учётом ваших блинов их {count + _weights[weight]}");
                return;
            }
            _weights[weight] += count;
        }
    }
}

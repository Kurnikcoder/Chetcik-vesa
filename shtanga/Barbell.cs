using System;
using System.Collections.Generic;
using System.Text;

namespace shtanga
{
    internal class Barbell
    {
        public double Barbellweight { get; }

        public double CollarsWeight {  get; }

        public double WeihhtBellfull => CollarsWeight + Barbellweight;

        public Barbell(double Barweight =20 , double zamokWeight = 5)
        {
            Barbellweight = Barweight;
            CollarsWeight = zamokWeight;
        }
    }
}

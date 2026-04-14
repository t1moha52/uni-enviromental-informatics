using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabenblatt_1.Units
{
    internal class Lastkraftwagen : KraftFahrzeug
    {
        private double Ladegewicht { get; set; } = 0;
        
        public void Beladen(double gewicht)
        {
            Ladegewicht += gewicht;
        }

        public void Entladen(double gewicht)
        {
            if (gewicht <= Ladegewicht)
            {
                Ladegewicht -= gewicht;
            }
        }

        public override string GetInfo()
        {
            return "Info Lastkraftwagn";
        }
    }
}

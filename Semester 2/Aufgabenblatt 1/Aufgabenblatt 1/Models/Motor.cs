using Aufgabenblatt_1.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabenblatt_1.Models
{
    internal class Motor
    {
        private double Verbrauch { get; set; }
        private Treibstoff Treibstoff { get; set; }

        public Motor(double verbrauch, Treibstoff treibstoff)
        {
            Verbrauch = verbrauch;
            Treibstoff = treibstoff;
        }

        public double GetVerbrauch()
        {
            return Verbrauch;
        }

        public double GetTreibstoffFaktor()
        {
            switch (Treibstoff)
            {
                case Treibstoff.Diesel:
                    return 470d;
                case Treibstoff.Benzin:
                    return 780d;
                default:
                    return 1d;
            }
        }
    }
}

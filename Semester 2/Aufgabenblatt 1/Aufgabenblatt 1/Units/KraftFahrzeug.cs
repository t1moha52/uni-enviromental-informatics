using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabenblatt_1.Units
{
    abstract class KraftFahrzeug
    {
        protected string? Kennzeichen {  get; set; }
        protected double Kilometerstand { get; set; } = 0;
        protected Motor? Motor { get; set; }

        public void Fahren(double distanz)
        {
            Kilometerstand += distanz;
        }

        public void SetMotor(Motor motor)
        {
            Motor = motor;
        }

        public void SetKennzeichen(string kennzeichen)
        {
            Kennzeichen = kennzeichen;
        }

        protected double BerechneCarbonFootprint()
        {
            return Motor!.GetVerbrauch() * Kilometerstand;
        }

        public abstract string GetInfo();
    }
}

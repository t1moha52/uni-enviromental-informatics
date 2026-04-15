using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabenblatt_1.Models
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
            return $"Lkw Informationen\n Kennzeichen = {this.Kennzeichen}\n Kilometerstand = {this.Kilometerstand}\n Carbon Footprint = {BerechneCarbonFootprint()}\n Ladegewicht = {this.Ladegewicht}\n-----------------------------------------------------------";
        }
    }
}

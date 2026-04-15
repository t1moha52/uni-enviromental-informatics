using System;
using System.Collections.Generic;
using System.Text;

namespace Aufgabenblatt_1.Models
{
    internal class Personenkraftwagen : KraftFahrzeug
    {
        public override string GetInfo()
        {
            return $"Pkw Informationen\n Kennzeichen = {Kennzeichen}\n Kilometerstand = {Kilometerstand}\n Carbon Footprint = {BerechneCarbonFootprint()}\n-----------------------------------------------------------";
        }
    }
}

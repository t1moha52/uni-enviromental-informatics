using Aufgabenblatt_1.Enums;
using Aufgabenblatt_1.Models;
using System;

namespace Aufgabenblatt_1.Core
{
    class Program
    {
        protected static Personenkraftwagen PkwErzeugen()
        {
            Personenkraftwagen personenkraftwagen = new Personenkraftwagen();

            personenkraftwagen.SetMotor(new Motor(10d, Treibstoff.Benzin));

            personenkraftwagen.SetKennzeichen("B-ABC 12");

            return personenkraftwagen;
        }

        protected static Lastkraftwagen LkwErzeugen()
        {
            Lastkraftwagen Lkw = new Lastkraftwagen();

            Lkw.SetMotor(new Motor(30d, Treibstoff.Diesel));

            Lkw.SetKennzeichen("B-XYZ 34");

            return Lkw;
        }

        public static void Main()
        {
            Personenkraftwagen Pkw = PkwErzeugen();

            Pkw.Fahren(200);
            Console.WriteLine(Pkw.GetInfo());

            Pkw.Fahren(300);
            Console.WriteLine(Pkw.GetInfo());



            Lastkraftwagen Lkw = LkwErzeugen();

            Lkw.Beladen(100);
            Console.WriteLine(Lkw.GetInfo());

            Lkw.Fahren(100);
            Lkw.Entladen(100);
            Console.WriteLine(Lkw.GetInfo());
        }
    }
}
using System;
using System.Reflection.Metadata.Ecma335;
using System.Xml;

namespace HTW_Programmieren
{
    class Programm
    {
        static void Main()
        {
            

            // 1 Aufgabe
            /*
            string Zeichenkette = "Irgendwelcher Satz";
            
            string? user_info = Console.ReadLine();

            System.Console.WriteLine(Zeichenkette + " " + user_info);
            /* 
            Die Zeichenkette im Programmcode ist eine Variable, die shon vor dem Programstart defeniert ist.
            Im Gegensatz wird die Benutzereingabe im Laufe der Programm defenier und als eine Variable Gespichert.
            */


            // 2 Aufgabe
            /*
            int a = 5, b = 20;
            System.Console.WriteLine(a + b);

            double user_num1;
            while (true)
            {
                System.Console.WriteLine("Geben Sie erste Zahl ein:");
                string? input = Console.ReadLine();
                if (double.TryParse(input, out user_num1))
                    break;
                else
                    System.Console.WriteLine("Nur Zahlen sind erlaubt!!!!!!!");
            }

            double user_num2;
            while (true)
            {
                System.Console.WriteLine("Geben Sie zweite Zahl ein:");
                string? input = Console.ReadLine();
                if (double.TryParse(input, out user_num2))
                    break;
                else
                    System.Console.WriteLine("Nur Zahlen sind erlaubt!!!!!!!");
            }


            System.Console.WriteLine("{0} + {1} = {2}", user_num1, user_num2, user_num1 + user_num2);
            System.Console.WriteLine("{0} - {1} = {2}", user_num1, user_num2, user_num1 - user_num2);
            System.Console.WriteLine("{0} * {1} = {2}", user_num1, user_num2, user_num1 * user_num2);
            System.Console.WriteLine("{0} / {1} = {2}", user_num1, user_num2, Math.Round(user_num1 / user_num2, 4));
            /* */


            // 3 Aufgabe
            /*
            System.Console.WriteLine("Enter the side 'a' of the triangle: ");
            double a = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Enter the side 'b' of the triangle: ");
            double b = Convert.ToDouble(Console.ReadLine());
            System.Console.WriteLine("Enter the side 'c' of the triangle: ");
            double c = Convert.ToDouble(Console.ReadLine());

            if (a + b > c && a + c > b && b + c > a)
            {
                double sp = (a + b + c) / 2;
                double area = Math.Round(Math.Sqrt(sp * (sp - a) * (sp - b) * (sp - c)), 3);
                System.Console.WriteLine("Area of triangle is: {0}", area);
            }
            else
                System.Console.WriteLine("Triangle does not exist(((");

            /* Ein güliges Dreieck ist ein, 
            bei dem die Summe von zwei belibigen Seiten
            immer gröser als die übrige Seite ist.
            */


            // 4 Aufgabe
            
            double Geldsumme;
            while (true)
            {
                System.Console.WriteLine("Geben Sie eine Geldsumme in Euro ein: ");
                string? input = Console.ReadLine();
                if (double.TryParse(input, out Geldsumme) && Geldsumme >= 0)
                {
                    break;
                }
                else
                    System.Console.WriteLine("Nur Zahlen sind erlaubt!!!!!!");
            }


            double Rabatt = 0;

            if (Geldsumme > 500 && Geldsumme <= 2000)
                Rabatt = Geldsumme * 0.02d;
            else if (Geldsumme > 2000 && Geldsumme <= 5000)
                Rabatt = Geldsumme * 0.05d;
            else if (Geldsumme > 5000)
                Rabatt = Geldsumme * 0.1d;

            System.Console.WriteLine("Ihrer Rabatt beträgt {0}€, der Endbetrag ist {1}€.", Rabatt, Geldsumme - Rabatt);

            /* */


            // 5 Aufgabe
            /*
            System.Console.WriteLine("Geben Sie Dienstjahre ein:");
            byte Dienstjahre = Convert.ToByte(Console.ReadLine());
            System.Console.WriteLine("Geben Sie den Alter ein:");
            byte Alter = Convert.ToByte(Console.ReadLine());

            int Pramie = 0;
            if (Alter >= 50)
                Pramie += 50;

            if (Dienstjahre > 1 && Dienstjahre <= 5)
                Pramie += 200;
            else if (Dienstjahre >= 6)
                Pramie += 80 + Dienstjahre * 20;

            System.Console.WriteLine("Ihre Prämie beträgt {0}€", Pramie);
            /* */

        }
    }
}

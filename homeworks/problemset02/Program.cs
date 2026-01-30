using System;
using System.Runtime.InteropServices;
using System.Security.Cryptography;

namespace Hausaufgabe2
{
    class Program
    {
        static void Main()
        {
            // 1 Aufgabe
            /*

            int summ = 0;

            for (int i = 1; i < 101; i++)
            {
                summ += i;
            }

            System.Console.WriteLine("Die Summe von Zahlen von 1 bis 100 ist gleich {0}", summ);      
        
            /* */

            // 2 Aufgabe
            /*
            int summ = 0;

            for (int i = 200; i < 301; i += 2)
            {
                summ += i;
            }

            System.Console.WriteLine("Summe der geraden Zahlen 200…300 ist gleich {0}", summ);

            /* */

            // 3 Aufgabe
            /*

            string folge = "";
            
            int i = 0;
            while (i * i < 200)
            {
                double quadrat = i * i;
                folge += " " + quadrat;
                
                i++;
            }

            System.Console.WriteLine(folge);

            /* */

            // 4 Aufgabe
            /*

            int num;
            while (true)
            {
                System.Console.WriteLine("Geben Sie eine naturliche Zahl");
                string? input = Console.ReadLine();
                if (Int32.TryParse(input, out num) && num >= 0)
                    break;
                else
                    System.Console.WriteLine("Nur naturliche Zahlen sind erlaubt!!!");
            }

            System.Console.WriteLine("Quadrat von Ihrer Zahl ist: {0}", num * num);

            System.Console.Write("Nächste 15 Zahlen sind: ");
            for (int i = 0; i < 15; i++)
            {
                num += 1;
                System.Console.Write(num + " ");
            }
            /* */

            // 5 Aufgabe
            /*

            decimal result = 0;

            for (decimal i = 1; i <= 1000; i++)
            {
                if (i % 2 == 0)
                {
                    result += -1 / i;
                }
                else
                    result += 1 / i;
            }
            System.Console.WriteLine("Die Folge ist gleich: {0}", result);
            System.Console.WriteLine("Log(2) ist gleich: {0}", Math.Log(2));

            if (Math.Abs((decimal)Math.Log(2) - result) < (decimal)1 / 1000)
            {
                System.Console.WriteLine("Erfolg!!! \nDer Fehler ist gleich: \n{0}", (((decimal)Math.Log(2)) - result));
                
            }

            /* */

            // 6 Aufgabe
            /*
            int f_2 = 0, f_1 = 1, f_n = 0;

            int num = 0;
            while (f_n < 1000000)
            {
                f_n = f_2 + f_1;
                f_2 = f_1;
                f_1 = f_n;

                num++;

                System.Console.WriteLine(f_n);
            }

            System.Console.WriteLine(num);

            /* */

            // 7 Aufgabe
            /* 

            decimal summ = 0;

            bool sign = true;

            for (decimal i = 1; i < 1000; i += 2)
            {
                if (sign)
                {
                    summ += 1 / i;
                }
                else
                {
                    summ += -1 / i;
                }
                sign = !sign;
            }

            System.Console.WriteLine("Die Folge ist gleich: \n{0}", summ);
            System.Console.WriteLine("PI/4 ist gleich: \n{0}", (decimal)(Math.PI / 4));

            if (Math.Abs((decimal)(Math.PI/4) - summ) < (decimal)1/1000)
            {
                System.Console.WriteLine("Erfolg!!! \nDer Fehler ist zwischen dieser Folge und PI/4 ist gleich: \n{0}", (decimal)(Math.PI/4) - summ);
            }

            /* */

            // 8 Aufgabe
            /*

            string password = "PASSWORD";
            char[] password_array = password.ToCharArray();
            char[] user_input = new char[password_array.Length];

            int tryes = 3;
            bool correct = false;

            while (tryes > 0 && correct == false)
            {

                for (int i = 0; i < password_array.Length; i++)
                {

                    while (true)
                    {
                        System.Console.WriteLine("Geben Sie ein Zeichen ein:");
                        string? input = Console.ReadLine();
                        if (input != null && input.Length == 1)
                        {
                            user_input[i] = input[0];
                            break;
                        }
                        else
                            System.Console.WriteLine("Nur ein Zeichen kann eingegeben werden!!!");
                    }
                }

                for (int i = 0; i < password_array.Length; i++)
                {
                    for (int j = 0; j < user_input.Length; j++)
                    {
                        if (char.ToLower(user_input[j]) == char.ToLower(password_array[i]) && user_input[j] != ' ' && password_array[i] != ' ')
                        {
                            user_input[j] = ' ';
                            password_array[i] = ' ';
                        }
                    }
                }

                int same = 0;
                for (int i = 0; i < user_input.Length; i++)
                {
                    if (user_input[i] == ' ')
                    {
                        same++;
                    }
                }

                if (same == password.Length)
                {
                    System.Console.WriteLine("Schlüsselwort ist richtig!");
                    correct = true;
                }
                else
                {
                    tryes--;
                    System.Console.WriteLine("Schlüsselwort ist falsch, Sie haben noch {0} Versuche(((", tryes);
                }

            }

            if (tryes == 0)
                System.Console.WriteLine("Keine Versuche mehr möglich(((");

            /* */

            // 8 Aufgabe 2te Losung
            

            string password = "PROG";
            password.ToLower();
            char[] array_password = password.ToCharArray();
            Array.Sort(array_password);

            int tryes = 3;

            password = "";
            foreach (char el in array_password)
            {
                password += el.ToString().ToLower();
            }

            System.Console.WriteLine(password);

            while (tryes > 0)
            {
                string user_input = "";

                while (true)
                {
                    System.Console.WriteLine("Geben Sie das Schlusselwort ein:");
                    string? input = Console.ReadLine();
                    if (input == null)
                        System.Console.WriteLine("Eingabe kann nicht leer sein!!!");
                    else
                    {
                        user_input = input.ToLower();
                        break;
                    }
                }

                char[] array_user = user_input.ToCharArray();
                Array.Sort(array_user);

                user_input = "";

                foreach (char el in array_user)
                {
                    user_input += el.ToString();
                }
                System.Console.WriteLine(user_input);

                if (user_input == password)
                {
                    System.Console.WriteLine("Erfolg!");
                    tryes = 0;
                }
                else
                {
                    tryes--;
                    System.Console.WriteLine("Falsch! \nSie haben noch {0} Versuche", tryes);
                }

            }

            /* */

            // 8 Aufgabe originale Losung

            
        }
    }
}

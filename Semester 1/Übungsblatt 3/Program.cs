using System;
using System.IO.Pipes;

namespace Ubungsblatt3
{
    class Program
    {
        static void Main()
        {
            // 1 Aufgabe
            
            double inputNumber;
            while (true)
            {
                System.Console.WriteLine("Geben Sie eine Zahl ein:");
                string? input = Console.ReadLine();
                if (double.TryParse(input, out inputNumber))
                    break;
                else
                    System.Console.WriteLine("Nur Zahlen sind erlaubt!!!");
            }
            double integerPart = Math.Floor(inputNumber);
            double fractionalPart = Math.Round(inputNumber - integerPart, inputNumber.ToString().Length - integerPart.ToString().Length);

            string binary = "";
            string octal = "";
            string hex = "";

            double binaryIntPart = integerPart;
            double binaryFracPart = fractionalPart;
            while (true)
            {
                int remainder = (int)binaryIntPart % 2;
                binary = remainder.ToString() + binary;

                binaryIntPart = Math.Floor(binaryIntPart / 2);

                if (binaryIntPart == 0)
                    break;
            }

            if (fractionalPart > 0)
                binary += ",";
            int count = 0;
            while (count < 10)
            {
                if (binaryFracPart == 0)
                    break;

                binary += Math.Floor(binaryFracPart * 2);
                binaryFracPart = binaryFracPart * 2 - Math.Floor(binaryFracPart * 2);

                count++;
            }
            System.Console.WriteLine("Binar form: " + binary);



            double otcalIntPart = integerPart;
            double octalFracPart = fractionalPart;
            while (true)
            {
                int remainder = (int)otcalIntPart % 8;
                octal = remainder.ToString() + octal;

                otcalIntPart = Math.Floor(otcalIntPart / 8);

                if (otcalIntPart == 0)
                    break;
            }
            
            if (fractionalPart > 0)
                octal += ",";
            count = 0;
            while (count < 10)
            {
                if (octalFracPart == 0)
                    break;

                octal += Math.Floor(octalFracPart * 8);
                octalFracPart = octalFracPart * 8 - Math.Floor(octalFracPart * 8);

                count++;
            }
            System.Console.WriteLine("Octal form: " + octal);


            double hexIntPart = integerPart;
            double hexFracPart = fractionalPart;
            while (true)
            {
                int remainder = (int)hexIntPart % 16;
                if (remainder == 10)
                    hex = "A" + hex;
                else if (remainder == 11)
                    hex = "B" + hex;
                else if (remainder == 12)
                    hex = "C" + hex;
                else if (remainder == 13)
                    hex = "D" + hex;
                else if (remainder == 14)
                    hex = "E" + hex;
                else if (remainder == 15)
                    hex = "F" + hex;
                else
                    hex = remainder.ToString() + hex;

                hexIntPart = Math.Floor(hexIntPart / 16);

                if (hexIntPart == 0)
                    break;
            }


            if (fractionalPart > 0)
                hex += ",";

            count = 0;
            while (count < 10)
            {
                if (hexFracPart == 0)
                    break;

                if (Math.Floor(hexFracPart * 16) == 10)
                    hex += "A";
                else if (Math.Floor(hexFracPart * 16) == 11)
                    hex += "B";
                else if (Math.Floor(hexFracPart * 16) == 12)
                    hex += "C";
                else if (Math.Floor(hexFracPart * 16) == 13)
                    hex += "D";
                else if (Math.Floor(hexFracPart * 16) == 14)
                    hex += "E";
                else if (Math.Floor(hexFracPart * 16) == 15)
                    hex += "F";
                else
                    hex += Math.Floor(hexFracPart * 16);

                hexFracPart = hexFracPart * 16 - Math.Floor(hexFracPart * 16);

                count++;
            }
            System.Console.WriteLine("Hexadecimal form: " + hex);
        
            /* */


            // 2 Aufgabe
            /*
            string palindromInput;
            while (true)
            {
                System.Console.WriteLine("Geben Sie einen Satz ein:");
                string input = Console.ReadLine();

                if (input.Length == 0)
                    System.Console.WriteLine("Sie haben nichts eingegeben! Das ist nicht Erlaubt!");
                else
                {
                    palindromInput = input;
                    break;
                }
            }
            
            string palindromTwisted = "";

            for (int i = palindromInput.Length - 1; i >= 0; i--)
            {
                palindromTwisted += palindromInput[i];
            }

            if (palindromInput.Length == 1)
                System.Console.WriteLine("Das ist nur ein Zeichen.");
            else
            {
                if (palindromInput.ToLower() == palindromTwisted.ToLower())
                    System.Console.WriteLine("Das ist ein Palindrom!");
                else
                    System.Console.WriteLine("Das ist kein Palindrom(((");
            }
            /* */


            // 3 Aufgabe
            /* 

            char[] alphabet = new char[] {'a','b','c','d','e','f','g','h','i','j','k','l','m','n','o','p','q','r','s','t','u','v','w','x','y','z'};
            string? input = Console.ReadLine();
            string decodeLower = "";

            foreach (char el in input)
            {
                if (alphabet.Contains(char.ToLower(el)))
                {
                    int index = Array.IndexOf(alphabet, char.ToLower(el));
                    if (index <= 12)
                    {
                        decodeLower += alphabet[index + 13];
                    }
                    else
                    {
                        decodeLower += alphabet[index - alphabet.Length + 13];
                    }
                }
                else
                {
                    decodeLower += el;
                }
            }

            string decodeNormal = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                    decodeNormal += char.ToUpper(decodeLower[i]);
                else
                    decodeNormal += decodeLower[i];
            }

            System.Console.WriteLine("Entschlusselter Text: \n{0}", decodeNormal);

            /* */

            // 4 Aufgabe
            /*

            int numInput;
            while (true)
            {
                System.Console.WriteLine("Geben Sie eine natürlice Zahl ein:");
                string? input = Console.ReadLine();

                if (input != null && int.TryParse(input, out numInput))
                    break;
                else
                    System.Console.WriteLine("Sie durfen nur natürlice Zahlen eingeben!!!");
            }

            int[] w6Roll = new int[numInput];
            int[] nums = new int[6];

            for (int i = 0; i < numInput; i++)
            {
                Random w6Random = new Random();
                w6Roll[i] = w6Random.Next(1, 7);
            }

            foreach (int el in w6Roll)
            {
                nums[el - 1] += 1;
            }

            for (int i = 0; i < nums.Length; i++)
            {
                System.Console.WriteLine("Die Zahl {0}: {1}", i + 1, nums[i]);
            }

            /* */

            // 5 Aufgabe
            /*
            int num;

            while (true)
            {
                System.Console.WriteLine("Geben sie eine ganze Zahl ein");
                string? input = Console.ReadLine();

                if (int.TryParse(input, out num))
                    break;
                else
                    System.Console.WriteLine("Falsche Eingabe, nur ganze Zahlen sind erlaubt!!!");
            }


            int numSqrt = (int)Math.Ceiling(Math.Sqrt(num));

            
            for (int i = 2; i < numSqrt + 1; i++)
            {
                if (num % i == 0)
                {
                    System.Console.WriteLine("Keine Primzahl");
                    break;
                }
                else if (i == numSqrt)
                {
                    System.Console.WriteLine("Das ist eine Primzahl!");
                }
            }

            /* */
        }
    }
}
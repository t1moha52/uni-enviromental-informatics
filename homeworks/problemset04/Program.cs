using System;
using System.Security.Cryptography.X509Certificates;

namespace Ubungsblatt4
{
    // Aufgabe 8
    class Gerat
    {
        public string name;
        public double inputPower;
        public double usage;
        public double dailyUsage;
        public double monthlyUsage;
        public double monthlyCost;

        private double elektroCost = 0.4;


        public Gerat(int gadgetNumber)
        {
            System.Console.WriteLine($"Gerät Nummer {gadgetNumber}");

            string? name;
            while (true)
            {   
                System.Console.WriteLine("Geben Sie den Namen des Geräts:");
                name = Console.ReadLine();
                if (name != "" && name != null) break;
                else System.Console.WriteLine("Der Name kann nicht leer sein!");

            }
            this.name = name;

            System.Console.WriteLine("Geben Sie die Leistungsaufnahme in Watt ein:");
            this.inputPower = Program.GetPositivDouble(-1);

            System.Console.WriteLine("Geben Sie  die durchschnittliche Nutzungsdauer pro Tag in Stunden:");
            this.usage = Program.GetPositivDouble(24);

            this.dailyUsage = inputPower / 1000 * usage;
            this.monthlyUsage = inputPower / 1000 * usage * 30;
            this.monthlyCost = inputPower / 1000 * usage * 30 * elektroCost;
        }
        
        

    }
    class Program
    {

        static public string InputBinary()
        {

            while (true)
            {
                System.Console.WriteLine("Gib eine binare Zahl ein:");
                string? input = Console.ReadLine();
                if (input != null && IsBinary(input))
                {
                    return input;
                }
                else System.Console.WriteLine("Du darfst nur binare Zahlen eingeben!!!");
            }
        }
        static public bool IsBinary(string num)
        {
            int commas = 0;
            foreach (char el in num)
            {
                if (el == ',') 
                    commas++;
                if ((el != '0' && el != '1' && el != ',') || commas > 1)
                    return false;


            }

            return true;
        }
        static public int GetPositivInt()
        {
            int inputNumber;
            while (true)
            {
                string? input = Console.ReadLine();
                if (Int32.TryParse(input, out inputNumber) && inputNumber >= 0)
                {
                    break;
                }
                else System.Console.WriteLine("Sie durfen nur positive ganze Zahlen eingeben!");
            } 

            return inputNumber;
        }   
        static public double GetPositivDouble(double maxValue)
        {
            double inputNumber;
            if (maxValue < 0)
            {
                while (true)
                {
                    string? input = Console.ReadLine();
                    if (double.TryParse(input, out inputNumber) && inputNumber >= 0)
                    {
                        break;
                    }
                    else System.Console.WriteLine("Sie durfen nur positive Zahlen eingeben!");
                } 
            }
            else
            {
                while (true)
                {
                    string? input = Console.ReadLine();
                    if (double.TryParse(input, out inputNumber) && inputNumber >= 0 && inputNumber <= maxValue)
                    {
                        break;
                    }
                    else System.Console.WriteLine($"Sie durfen nur positive Zahlen eingeben, die kleiner gleich {maxValue} sind!");
                } 
            }
            

            return inputNumber;
        }


        // Aufgabe 1
        static public string IntegerPart(string number)
        {
            string result = "";
            for (int i = 0; i < number.Length; i++)
            {
                if (number[i] == ',')
                    break;
                
                result = result + (number[i] - '0');
            }

            return result;
        }
        static public string FractionalPart(string number)
        {
            string result = "";
            bool IsFractional = false;

            for (int i = 0; i < number.Length; i++)
            {
                if (IsFractional)
                    result = result + (number[i] - '0');

                if (number[i] == ',')
                    IsFractional = true;
            }

            return result;
        }
        static public string SetIntegerLength(string number, int IntDiff)
        {
            string numCopy = number;

            number = "";
            for (int i = 0; i < Math.Abs(IntDiff); i++)
            {
                number += "0";
            }
            foreach (char el in numCopy)
            {
                number = number + el;
            }

            return number;
        }
        static public string SetFractionalLength(string number, int FrDiff)
        {
            for (int i = 0; i < Math.Abs(FrDiff); i++)
                {
                    number = number + "0";
                }

            return number;
        }   
        static public string[] SimpleBinaryAddition(string number1, string number2, string _result, string _transfer)
        {
            int transfer = 0;
            if (_transfer == "1")
                transfer = 1;

            for (int i = number1.Length - 1; i >= 0; i--)
            {
                int posSumm = number1[i] - '0' + (number2[i] - '0') + transfer;

                if (posSumm <= 1)
                {
                    _result = posSumm.ToString() + _result;
                    transfer = 0;
                }
                else if (posSumm == 2)
                {
                    _result = "0" + _result;
                    transfer = 1;
                }
                else if (posSumm == 3)
                {
                    _result = "1" + _result;
                    transfer = 1;
                }
            }

            string[] output = {_result, transfer.ToString()};

            return output;
        }
        static public string AdditionBinary(string num1, string num2)
        {
            string result = "";

            string integerNum1, integerNum2, fractionalNum1, fractionalNum2;

            integerNum1 = IntegerPart(num1);
            integerNum2 = IntegerPart(num2);
            
            fractionalNum1 = FractionalPart(num1);
            fractionalNum2 = FractionalPart(num2);

            int IntegerDifference = integerNum1.Length - integerNum2.Length;
            if (IntegerDifference > 0)
                integerNum2 = SetIntegerLength(integerNum2, IntegerDifference);
            else if (IntegerDifference < 0)
                integerNum1 = SetIntegerLength(integerNum1, IntegerDifference);

            int FractionalDifference = fractionalNum1.Length - fractionalNum2.Length;
            if (FractionalDifference > 0)
                fractionalNum2 = SetFractionalLength(fractionalNum2, FractionalDifference);
            else if (FractionalDifference < 0)
                fractionalNum1 = SetFractionalLength(fractionalNum1, FractionalDifference);
        
            string transfer = "0";

            result = SimpleBinaryAddition(fractionalNum1, fractionalNum2, result, transfer)[0];
            transfer = SimpleBinaryAddition(fractionalNum1, fractionalNum2, result, transfer)[1];

            if (fractionalNum1 != "" && fractionalNum2 != "")
                result = "," + result;

            result = SimpleBinaryAddition(integerNum1, integerNum2, result, transfer)[0];
            transfer = SimpleBinaryAddition(integerNum1, integerNum2, result, transfer)[1];
            
            if (transfer == "1")
            {
                result = "1" + result;
            }

            return result;
        }


        // Aufgabe 2
        static public void OutputBinaryDecimal(string binaryNum)
        {
            string integerPart = IntegerPart(binaryNum);
            string fractionalPart = FractionalPart(binaryNum);

            double resultDecimal = 0;

            for (int i = integerPart.Length - 1; i >= 0; i--)
            {
                double power = integerPart.Length - i - 1;
                double localNum = 0;

                if (integerPart[i] == '1')
                    localNum = 1d;

                resultDecimal += localNum * Math.Pow(2, power);

            }

            for (int i = 0; i < fractionalPart.Length; i++)
            {
                double power = (double) - i - 1;
                double localNum = 0;

                if (fractionalPart[i] == '1')
                    localNum = 1d;

                resultDecimal += localNum * Math.Pow(2d, power);
            }

            System.Console.WriteLine("Binär: " + binaryNum);
            System.Console.WriteLine("Decimal: " + resultDecimal);
        }


        // Aufgabe 3
        static public string MoveComma(string number, int moving)
        {
            string result = "";

            if (moving == 0) result = number;
            else if (moving > 0)
            {
                int currentMoving = -1;
                bool commaWas = false;
                for (int i = 0; i < number.Length; i++)
                {
                    if (currentMoving == moving)
                        result = result + "," + number[i];
                    else if (i == number.Length - 1 && currentMoving < moving)
                    {
                        result = result + (number[i] - '0');
                        for (int j = 0; j < moving - currentMoving - 1; j++)
                        {
                            result = result + "0";
                        }
                    }
                    else if (number[i] != ',')
                        result = result + number[i];
                    else if (number[i] == ',')
                        commaWas = true;
                    
                    if (commaWas == true)
                        currentMoving ++;
                }
            }
            else if (moving < 0)
            {
                bool hasComma = false;
                foreach (char el in number)
                {
                    if (el == ',')
                    {
                        hasComma = true;   
                        break;
                    } 
                }


                if (!hasComma)
                {
                    
                    int currentMoving = 0;

                    for (int i = number.Length - 1; i >= 0; i--)
                    {
                        
                        if (currentMoving == moving && i == 0)
                        {
                            result = "0" + "," + number[i] + result;
                        }
                        else if (currentMoving == moving && i > 0)
                        {
                            result = number[i] + "," + result;
                        }
                        else if (currentMoving > moving && i == 0)
                        {
                            result = number[i] + result;
                            for (int j = 0; j < currentMoving - moving - 1; j++)
                            {
                                result = "0" + result;
                            }
                            result = "0" + "," + result;
                        }
                        else if (currentMoving != moving)
                        {
                            result = number[i] + result;
                        }

                        currentMoving--;
                    }
                }

                else
                {
                    int currentMoving = 0;
                    bool commaWas = false;

                    for (int i = number.Length - 1; i >= 0; i--)
                    {
                        if (number[i] == ',') commaWas = true;
                        else if (currentMoving == moving && i > 0)
                        {
                            result = "," + number[i] + result;
                        }
                        else if (currentMoving == moving && i == 0)
                        {
                            result = "0" + "," + number[i] + result;
                        }
                        else if (i == 0 && currentMoving > moving)
                        {
                            result = number[i] + result;
                            for (int j = 0; j < currentMoving - moving; j++)
                            {
                                result = "0" + result;
                            }
                            result = "0" + "," + result;
                        }
                        else if (number[i] != ',')
                        {
                            result = number[i] + result;
                        }

                        if (commaWas) currentMoving--;
                    }
                }
            }

            return result;
        }
        static public string BinaryMultiplication(string number1, string number2)
        {
            string result = "0";

            string number2Integer = IntegerPart(number2);
            string number2Fractional = FractionalPart(number2);

            int power = 0;
            for (int i = number2Integer.Length - 1; i >= 0; i--)
            {
                if (number2Integer[i] == '1')
                {
                    result = AdditionBinary(MoveComma(number1, power), result);
                }
                power++;
            }

            power = -1;
            for (int i = 0; i < number2Fractional.Length; i++)
            {
                if (number2Fractional[i] == '1')
                {
                    result = AdditionBinary(MoveComma(number1, power), result);
                }
                power--;
            }


            return result;
        }

  
        // Aufgabe 4
        static public void CO2AusstossStrecke()
        {
            System.Console.WriteLine("Geben Sie die Lange der Strecke in km ein:");
            double wayLength = GetPositivDouble(-1);

            double remaining = wayLength;
            double CO2 = 0;

            while (remaining != 0)
            {
                Console.Clear();

                Console.WriteLine("Erlaubte Arte der Bewegung: 'A' - Auto, 'B' - Bahn, 'F' - Fahrrad und zu Fuss.");
                Console.WriteLine("Geben Sie einen der drei Buchstaben ein, wenn Sie die Art der Bewegung angeben müssen. \n"); 

                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Aktueller CO2-Ausstoss = {0}kg", Math.Round(CO2, 3));
                Console.WriteLine($"Sie haben noch {remaining}km übrig.\n");
                Console.ForegroundColor = ConsoleColor.Gray;
                System.Console.WriteLine("Geben Sie die Art der Bewegung ein:");

                string? transportationType;
                while (true)
                {
                    transportationType = Console.ReadLine();
                    if (transportationType == "A" || transportationType == "B" || transportationType == "F")
                    {
                        break;
                    }
                    else
                        System.Console.WriteLine("Falsche Eingabe! Nur 'A', 'B' oder 'F' sind erlaubt.");
                }

                System.Console.WriteLine("Geben Sie die Anzahl der Kilometer:");
                double currentMoving = GetPositivDouble(remaining);
                
                remaining -= currentMoving;

                if (transportationType == "A")
                {
                    CO2 += currentMoving * 0.18;
                }
                else if (transportationType == "B")
                {
                    CO2 += currentMoving * 0.04;
                }
            }
            
            Console.ForegroundColor = ConsoleColor.Green;
            System.Console.WriteLine($"\nDer CO2-Ausstoss ist {Math.Round(CO2, 3)}kg fur eine {wayLength}km Strecke.");
            Console.ForegroundColor = ConsoleColor.Gray;



        }


        // Aufgabe 5
        static string[] numbers0to19 =
        {
            "null",
            "ein",
            "zwei",
            "drei",
            "vier",
            "fünf",
            "sechs",
            "sieben",
            "acht",
            "neun",
            "zehn",
            "elf",
            "zwölf",
            "dreizehn",
            "vierzehn",
            "fünfzehn",
            "sechzehn",
            "siebzehn",
            "achtzehn",
            "neunzehn"
        };
        static string[] numbersFractional =
        {
            "null",
            "eins",
            "zwei",
            "drei",
            "vier",
            "fünf",
            "sechs",
            "sieben",
            "acht",
            "neun"
        };
        static string[] tens =
        {
            "",         // 0 (nicht benutzt)
            "",         // 1 (10–19 sind oben)
            "zwanzig",  // 2
            "dreißig",  // 3
            "vierzig",  // 4
            "fünfzig",  // 5
            "sechzig",  // 6
            "siebzig",  // 7
            "achtzig",  // 8
            "neunzig"   // 9
        };
        static public string ZahlZuWortInteger(double numberInput)
        {
            string numberString = numberInput.ToString().Split(',')[0];
            int number = Convert.ToInt32(numberString);

            

            string result = "";

            if (number < 20)
                    result += numbers0to19[number];

            else if (number < 100)
            {
                int zehner = number / 10;
                int einer = number % 10; 
                if (einer == 0)
                    result += tens[zehner];
                
                result += numbers0to19[einer] + "und" + tens[zehner];
            }

            else if (number < 1000)
            {
                int hundert = number / 100;
                int rest = number % 100;

                if (rest > 0)
                    result += numbers0to19[hundert] + "hundert" + ZahlZuWortInteger(rest);
                else result += numbers0to19[hundert] + "hundert";
            }

            else if (number < 1000000)
            {
                int tausend = number / 1000;
                int rest = number % 1000;


                
                if (rest > 0)
                    result += ZahlZuWortInteger(tausend) + "tausend" + ZahlZuWortInteger(rest);
                else result += ZahlZuWortInteger(tausend) + "tausend";
            }

            else if (number < 1000000000)
            {
                int million = number / 1000000;
                int rest = number % 1000000;

                if (rest > 0)
                {
                    if (million == 1)
                        result += "einemillion" + ZahlZuWortInteger(rest);
                    else result += ZahlZuWortInteger(million) + "millionen" + ZahlZuWortInteger(rest);
                }
                    
                else
                {
                    if (million == 1)
                        result += "einemillion";
                    else result += ZahlZuWortInteger(million) + "millionen";
                };
            }

            return result;

        }
        static public string Eins(string wortInteger)
        {
            if (wortInteger[wortInteger.Length - 2] == 'i' && wortInteger[wortInteger.Length - 1] == 'n')
                return wortInteger + "s";
            else return wortInteger;
        }
        static public string ZahlZuWortFractional(double numberInput)
        {
            string result = "";
            string numberString = numberInput.ToString().Split(',')[1];

            result += "komma";

            for (int i = 0; i < numberString.Length; i++)
            {
                int index = Convert.ToInt32(numberString[i]) - '0';
                result += numbersFractional[index];
            }

            return result;

        }
        static public void ZahlZuWort()
        {
            string result = "";
            System.Console.WriteLine("Geben Sie eine positive Zahl ein:");
            double number = GetPositivDouble(-1);
            result += Eins(ZahlZuWortInteger(number));

            if (number.ToString().Split(',').Length > 1)
                result += ZahlZuWortFractional(number);

            System.Console.WriteLine(result);
        }


        // Aufgabe 7
        static public void PascalischeDreieck()
        {
            System.Console.WriteLine("Geben Sie die Höhe des pascalischen Dreiecks ein:");
            int height = GetPositivInt();
            

            int[,] triangle = new int[height, height];

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    if (j == 0 || i == j)
                        triangle[i, j] = 1;
                    else if (j > i)
                        triangle[i, j] = 0;
                    else if (j < i)
                    {
                        triangle[i, j] = triangle[i - 1, j] + triangle[i - 1, j - 1];
                    }
                }
            }

            int maxNumLength = triangle[height - 1, height/2].ToString().Length;
            string empty = "";
            for (int i = 0; i < maxNumLength; i++)
            {
                empty += " ";
            }

            for (int i = 0; i < height; i++)
            {
                string tabulation = "";
                for (int diff = 1; diff < height - i; diff++)
                {
                    tabulation += empty + " ";
                }
                System.Console.Write(tabulation);
                for (int j = 0; j < height; j++)
                {
                    string lengthNorm = "";
                    for (int diff = 0; diff < maxNumLength - triangle[i, j].ToString().Length; diff++)
                    {
                        lengthNorm += " ";
                    }
                    
                    if (triangle[i, j] != 0)
                        System.Console.Write(triangle[i, j] + lengthNorm + " " + empty + " ");
                }
                System.Console.WriteLine();
            }

        }


        // Aufgabe 8
        static public void Haushaltsgeräte()
        {
            
            List<Gerat> list = new List<Gerat>();
            
            System.Console.WriteLine("Geben Sie die Anzahl der Gerate:");
            int number = GetPositivInt();
            for (int i = 0; i < number; i++)
            {
                Gerat a = new Gerat(i+1);
                list.Add(a);
            }
            
            string[,] matrix = new string[number+3, 6];

            matrix[0,0] = "Name";
            matrix[0,1] = "Leistung(Wt)";
            matrix[0,2] = "Nutzung(St./T.)";
            matrix[0,3] = "Verbrauch(kWh/T.)";
            matrix[0,4] = "Verbrauch(kWh/M.)";
            matrix[0,5] = "Preis(M.)";

            double wholeMonthlyUsage = 0;
            double wholeCosts = 0;

            for(int i = 0; i < number; i++)
            {
                matrix[i + 1,0] = list[i].name;
                matrix[i + 1,1] = list[i].inputPower.ToString();
                matrix[i + 1,2] = Math.Round(list[i].usage, 3).ToString();
                matrix[i + 1,3] = Math.Round(list[i].dailyUsage, 3).ToString();
                matrix[i + 1,4] = Math.Round(list[i].monthlyUsage, 3).ToString();
                matrix[i + 1,5] = Math.Round(list[i].monthlyCost, 2).ToString() + " €";

                wholeMonthlyUsage += list[i].monthlyUsage;
                wholeCosts += list[i].monthlyCost;
            }

            matrix[number + 1, 0] = "Gesamter Energieverbrauch(M.)";
            matrix[number + 2, 0] = "Gesamter Preis(M.)";
            matrix[number + 1, 1] = Math.Round(wholeMonthlyUsage, 3).ToString();
            matrix[number + 2, 1] = Math.Round(wholeCosts, 3).ToString() + " €";

            for(int i = 0; i < number + 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (matrix[i,j] == null) matrix[i,j] = "";
                }
            }


            int[] maxColWidth = new int[6];
            for (int i = 0; i < number + 2; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i == 0)
                        maxColWidth[j] = matrix[i, j].Length;
                    if (i > 0)
                    {
                        if (matrix[i,j].Length > maxColWidth[j]) maxColWidth[j] = matrix[i, j].Length;
                    }
                }
            }

            string horisontalLine = "";

            foreach (int col in maxColWidth)
            {
                for (int el = 0; el < col; el++)
                {
                    horisontalLine += "-";
                }
                horisontalLine += "|";
            }

            for (int i = 0; i < number + 3; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    string normalize = "";
                    for (int k = 0; k < maxColWidth[j] - matrix[i, j].Length; k++)
                    {
                        normalize += " ";
                    }

                    Console.Write(matrix[i, j] + normalize + "|");
                }
                Console.WriteLine();
                if (i == 0 || i == number) Console.WriteLine(horisontalLine);
            }

            



        }
        

        // Aufgabe 9
        static public void Weihnachtsbaum()
        {
            System.Console.WriteLine("Geben Sie die Höhe des Baumes(min. 1):");
            int treeHeight = GetPositivInt();
            int width = treeHeight * 2 - 1;

            string[,] tree = new string[treeHeight + 1, 1];

            for (int i = 0; i < treeHeight + 1; i++)
            {
                if (i == 0)
                    tree[i, 0] = "X"; 
                else if (i > 0 && i < treeHeight)
                {
                    for (int k = 0; k < (i + 1) * 2 - 1; k++)
                    {
                        tree[i, 0] += "#";
                    }
                }
                else if (i == treeHeight)
                    tree[i, 0] = "П";
            }

            for (int i = 0; i < treeHeight + 1; i++)
            {
                string tabulation = "";
                for (int k = 0; k < (width - tree[i, 0].Length) / 2; k++)
                {
                    tabulation += " ";
                }

                if (i == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    System.Console.WriteLine(tabulation + tree[i, 0]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (i > 0 && i < treeHeight)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGreen;
                    System.Console.WriteLine(tabulation + tree[i, 0]);
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else if (i == treeHeight)
                    System.Console.WriteLine(tabulation + tree[i, 0]);

            }
            
        }
        
        static void Main()
        {
            
            // string summ = AdditionBinary(InputBinary(), InputBinary());
            // OutputBinaryDecimal(summ);


            string mult = BinaryMultiplication(InputBinary() , InputBinary());
            OutputBinaryDecimal(mult);
            

            // ZahlZuWort();
            
            // CO2AusstossStrecke();

            // PascalischeDreieck();

            // Haushaltsgeräte();

            // Weihnachtsbaum();


        }
    }
}
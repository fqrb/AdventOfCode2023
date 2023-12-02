namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetSumIDs();
        }

        static void GetSumIDs()
        {
            int maxRed = 12;
            string red = "red";

            int maxGreen = 13;
            string green = "green";

            int maxBlue = 14;
            string blue = "blue";

            int result = 0;

            string color = string.Empty;
            int number = 0;
            int ID = 0;

            string filePath = "input.txt";

            using (FileStream fs = new(filePath, FileMode.Open))
            {
                using (StreamReader sr = new(fs))
                {
                    Console.WriteLine("======================");
                    Console.WriteLine("---------------");
                    while (!sr.EndOfStream)
                    {
                        
                        string line = sr.ReadLine();

                        string[] lineParts = line.Split(':');
                        ID++;
                        Console.WriteLine("ID: " + ID);
                        string[] cubeParts = lineParts[1].Split(';');

                        bool hasToEnd = false;
                        for (int i = 0; i < cubeParts.Length; i++)
                        {
                            
                            if (!hasToEnd)
                            {
                                string part = cubeParts[i];
                                string[] partParts = part.Split(",");
                                for (int j = 0; j < partParts.Length; j++)
                                {
                                    
                                    string part2 = partParts[j];
                                    string[] words = part2.Split(' ');
                                    color = words[2];
                                    number = 0;
                                    if (int.TryParse(words[1], out int parsedColor))
                                    {
                                        number = parsedColor;
                                    }
                                    Console.WriteLine("color:  " + color + "    number: " + number);
                                    if (color == red)
                                    {
                                        if (number > maxRed)
                                        {
                                            Console.WriteLine("number too high");
                                            hasToEnd = true;
                                        }
                                    }
                                    else if (color == green)
                                    {
                                        if (number > maxGreen)
                                        {
                                            Console.WriteLine("number too high");
                                            hasToEnd = true;
                                        }
                                    }
                                    else if (color == blue)
                                    {
                                        if (number > maxBlue)
                                        {
                                            Console.WriteLine("number too high");
                                            hasToEnd = true;
                                        }
                                    }
                                }
                            }
                            
                            Console.WriteLine("--------------");
                        }
                        if (!hasToEnd) Console.WriteLine("Valid game!");
                        if (hasToEnd) Console.WriteLine("Invalid game!");
                        Console.WriteLine("result before: " + result);
                        if (!hasToEnd) result += ID;
                        Console.WriteLine("result after: " + result);
                        
                        Console.WriteLine("=========================");

                    }
                }
            }
            Console.WriteLine(result);
        }


    }
}

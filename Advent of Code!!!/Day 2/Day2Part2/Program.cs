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
            int maxRed = 0;
            string red = "red";

            int maxGreen = 0;
            string green = "green";

            int maxBlue = 0;
            string blue = "blue";

            int result = 0;

            string color = string.Empty;
            int number = 0;
            int ID = 0;
            int power = 0;

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

                        for (int i = 0; i < cubeParts.Length; i++)
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
                                        maxRed = number;
                                }
                                else if (color == green)
                                {
                                    if (number > maxGreen)
                                        maxGreen = number;
                                }
                                else if (color == blue)
                                {
                                    if (number > maxBlue)
                                        maxBlue = number;
                                }
                                
                            }
                            
                            Console.WriteLine("--------------");
                        }
                        power = maxRed * maxGreen * maxBlue;
                        maxRed = 0; maxGreen = 0; maxBlue = 0;
                        Console.WriteLine("result before: " + result);
                        result += power;
                        Console.WriteLine("result after: " + result);

                        Console.WriteLine("=========================");

                    }
                }
            }
            Console.WriteLine(result);
        }


    }
}

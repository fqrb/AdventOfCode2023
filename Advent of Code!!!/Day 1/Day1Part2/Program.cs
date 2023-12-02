namespace ConsoleApp1
{
    internal class Program
    {
        static Dictionary<string, int> spelledDigits = new Dictionary<string, int>
            {
                {"one", 1}, {"two", 2}, {"three", 3},
                {"four", 4}, {"five", 5}, {"six", 6},
                {"seven", 7}, {"eight", 8}, {"nine", 9}
            };
        static List<char> chars = new List<char>();
        static string currentLine;

        static void Main(string[] args)
        {
            GetCalibrationValue();
        }

        static void GetCalibrationValue()
        {
            int result = 0;
            string filePath = "input.txt";
            using (FileStream fs = new(filePath, FileMode.Open))
            {
                using (StreamReader sr = new(fs))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string firstlast = FirstLast(line);
                        int a = Convert.ToInt32(firstlast);
                        result += a;

                    }
                }
            }
            Console.WriteLine(result);
        }

        static string FirstLast(string line)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];
                if (char.IsDigit(c))
                {
                    chars.Add(c);
                    currentLine = string.Empty;
                }
                else if (char.IsLetter(c))
                {
                    ConvertCharsToNumber(c);
                }
            }

            foreach (char c in chars)
            {
                Console.WriteLine(c);
            }
            string firstCharacter = Convert.ToString(chars[0]);
            string lastCharacter = Convert.ToString(chars[chars.Count - 1]);
            chars.Clear();
            return firstCharacter + lastCharacter;
        }

        static void ConvertCharsToNumber(char c)
        {
            currentLine += c;

            foreach (var a in spelledDigits)
            {
                if (currentLine.EndsWith(a.Key))
                {
                    chars.AddRange(a.Value.ToString().ToCharArray());
                }
            }
        }
    }
}
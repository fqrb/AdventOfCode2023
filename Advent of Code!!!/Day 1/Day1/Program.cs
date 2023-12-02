using System;
using System.Diagnostics;
using System.IO;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetCalibrationValue();
        }


        static void GetCalibrationValue()
        {
            int firstInt = 0, lastInt = 0, result = 0;
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
            List<char> chars = new List<char>();
            for (int i = 0; i < line.Length; i++)
            {
                char c = line.ElementAt(i);
                if (char.IsDigit(c))
                {
                    chars.Add(c);
                }
            }
            string firstCharacter = Convert.ToString(chars[0]);
            string lastCharacter = Convert.ToString(chars[chars.Count - 1]);
            string firstlast = firstCharacter + lastCharacter;
            return firstlast;
        }
    }
}
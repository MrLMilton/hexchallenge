using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace hexchallenge
{
    internal class Program
    {
        static bool firstChar(string hex) {
            if (hex[0] == '#')
            {
                return true;
            }
            else {
                return false;
            }
        }
        static bool lengthCheck(string hex)
        {
            if (hex.Length == 7)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        static bool charCheck(string hex, char[] hexadecimal)
        {
            bool valid = true;
            bool checks = false;
            for (int i = 1; i < 7; i++) {
                checks = false;
                for (int j = 0; j < 16; j++) {
                    char hexarr = hexadecimal[j];
                    if (hex[i] == hexarr)
                    {
                        checks = true;
                    }
                }if (checks == false) { 
                    valid = false;
                }
            }
            return valid;
        }
        static int valueFinder(int pos, string hex, char[] hexadecimal)
        {
            char HexValue = Convert.ToChar(hex[pos]);
            int position=0;
            for (int i = 0; i < hexadecimal.Length; i++)
            {
                if (HexValue == hexadecimal[i])
                {
                    position = i;
                }
            } return position;
        }
        static void Main(string[] args)
        {
            char[] hexadecimal = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            Console.WriteLine("Please enter a hex code for a colour\nThe code must start with a #\nThe number code after the # must be 6 numbers in length");
            string Hexcode = Console.ReadLine().ToUpper();
            bool hash = firstChar(Hexcode);
            bool length = lengthCheck(Hexcode);
            bool chars = charCheck(Hexcode, hexadecimal);
            while(hash == false || length == false || chars == false) 
            {
                Console.WriteLine("Invalid hex code\nPlease enter a hex code for a colour\nThe code must start with a #\nThe number code after the # must be 6 numbers in length");
                Hexcode = Console.ReadLine().ToUpper();
                hash = firstChar(Hexcode);
                length = lengthCheck(Hexcode);
                if (length == true) 
                {
                    chars = charCheck(Hexcode, hexadecimal);
                }
            }
            int Red = (valueFinder(1, Hexcode, hexadecimal) * 16) + valueFinder(2, Hexcode, hexadecimal);
            int Green = (valueFinder(3, Hexcode, hexadecimal) * 16) + valueFinder(4, Hexcode, hexadecimal);
            int Blue = (valueFinder(5, Hexcode, hexadecimal) * 16) + valueFinder(6, Hexcode, hexadecimal);

            Console.WriteLine(Hexcode);
            Console.WriteLine(hash);
            Console.WriteLine(length);
            Console.WriteLine(chars);
            Console.WriteLine($"{Red}, {Green}, {Blue}");
        }
    }
}

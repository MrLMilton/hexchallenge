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
        static void Main(string[] args)
        {
            char[] hexadecimal = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };
            string Hexcode = Console.ReadLine().ToUpper();
            bool hash = firstChar(Hexcode);
            bool length = lengthCheck(Hexcode);
            bool chars = charCheck(Hexcode, hexadecimal);
            Console.WriteLine(Hexcode);
            Console.WriteLine(hash);
            Console.WriteLine(length);
            Console.WriteLine(chars);
            
        }
    }
}

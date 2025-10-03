using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection.PortableExecutable;
using System.Runtime.CompilerServices;

namespace hexchallenge
{
    internal class Program
    {
        static void validStatments(bool a, bool b, bool c) //subroutine to tell the user which criteria they have met
        {
            Console.WriteLine($"The code starts with a #: {a}");
            Console.WriteLine($"The length of the code is valid: {b}");
            Console.WriteLine($"All charecters in the hexcode are valid: {c}");
        }
        static bool firstChar(string hex)
        { //Mark E ,Mark I
           if (hex[0] == '#')
            {
                return true;
            }
            else {
                return false;
            }
        }
        static bool lengthCheck(string hex) //Mark E, Mark G
        {
            if (hex.Length == 7) //Mark H
            {
                return true;
            }
            else
            { 
                return false;
            }
        }
        static bool charCheck(string hex, char[] hexadecimal) //Mark E, Mark J
        {
            bool valid = true;
            bool checks = false;
            for (int i = 1; i < hex.Length; i++)
            { //Mark L
                checks = false;//Mark M
                for (int j = 0; j < 16; j++) {
                    char hexarr = hexadecimal[j];
                    if (hex[i] == hexarr)
                    {
                        checks = true;//Mark M
                    }
                }if (checks == false)
                { //Mark M
                    valid = false;
                }
            }
            return valid;
        }
        static int valueFinder(int pos, string hex, char[] hexadecimal) //Mark E,Mark N
        {
            char HexValue = Convert.ToChar(hex[pos]);
            int position=0;
            for (int i = 0; i < hexadecimal.Length; i++)//Mark O
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
            bool hash = firstChar(Hexcode), length = lengthCheck(Hexcode), chars = charCheck(Hexcode, hexadecimal);
            while(!hash||!length||!chars) 
            {
                validStatments(hash, length, chars);
                Console.WriteLine("Invalid hex code\nPlease enter a hex code for a colour\nThe code must start with a #\nThe number code after the # must be 6 numbers in length");
                Hexcode = Console.ReadLine().ToUpper();//Mark K
                hash = firstChar(Hexcode); //Mark B
                length = lengthCheck(Hexcode); //Mark A
                chars = charCheck(Hexcode, hexadecimal); //Mark C
            }
            int Red/*Mark P, Mark Q*/ = (valueFinder(1, Hexcode, hexadecimal) * 16) + valueFinder(2, Hexcode, hexadecimal)/*Mark D, Mark N*/, Green = (valueFinder(3, Hexcode, hexadecimal) * 16) + valueFinder(4, Hexcode, hexadecimal), Blue = (valueFinder(5, Hexcode, hexadecimal) * 16) + valueFinder(6, Hexcode, hexadecimal);

            Console.WriteLine($"You entered {Hexcode} as your colour code");//Mark R
            validStatments(hash, length, chars);
            Console.WriteLine($"The hexcode you entered is equal to the values of Red - {Red}, Grren - {Green}, Blue - {Blue}");//Mark R
        }
    }/*Program Design

Note that AO3 (design) marks are for selecting appropriate techniques to use to solve the problem, so should be credited whether the syntax of programming language statements is correct or not and regardless of whether the solution works.

Mark A taking a user's input and attempting to check the length of the input;

Mark B taking a user's input and attempting to check the first character is a #;

Mark C taking a user's input and attempting to check the other characters are 0-F hex code characters ;

Mark D attempting to calculate the RBG values from the pairs of Hexadecimal values, multiplying the first by 16 and adding the second;

Mark E having all above marks as individual subroutines in the code;

Mark F outputting the RBG values in an appropriate place;

Program Logic

Mark G creating a subroutine that takes the users input as a parameter and checks the length, returns either length or Boolean value;

Mark H using selections to determine if the length of the code is valid ;

Mark I creating a subroutine that takes the users input as a parameter and checks the first character using substring method, returns Boolean value;

Mark J creating a subroutine that takes the users input as a parameter and checks each character within the hexcode is 0-F;

Mark K using a method to ensure that the a-f can be upper or lowercase and still be valid ;

Mark L using iteration to check each character in the hexcode starting at index 1;

Mark M a mechanism which will correctly identify is the WHOLE hexcode is valid;

Mark N creating a solution that takes the users input as a parameter and breaks the value into 3 pairs;

Mark O creating a solution that takes the users input as a parameter converts the first hex value into denary and multiply it by 16 AND takes the second value in denary and adds it to the total;

Mark P assigning the previous value as one of the Red, Green or Blue colour channels;

Mark Q converting the hexcode into 3 denary values for the RGB channels;

Mark R at least one correct set of messages output in appropriate places to show the denary values of the RGB values;
 */
}

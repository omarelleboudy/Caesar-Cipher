using CeasarCypher.Shifters;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Text;

namespace Encryption.CaesarCipher
{
    public class Program
    {
        public static void Main(string[] args)
        {

            bool isRunning = true;
            while (isRunning)
            {
                Console.Write("Enter 1 to Encrypt, 2 to Decrypt or 0 to Exit: ");
                string option = Console.ReadLine();
                switch (option)
                {
                    case "0": 
                        isRunning= false;
                        break;

                    case "1":
                        Execute(option);
                        break;

                    case "2":
                        Execute(option);
                        break;
                    default:
                        Console.WriteLine("Enter a valid option.");
                        break;
                }

            }
        }
        private static void Execute(string option)
        {

            Console.Write("Input a string of digits, lowercase letters and/or uppercase letters: ");
            string input = Console.ReadLine();

            Console.Write("Shift: ");
            string shiftChar = Console.ReadLine();
            if (!int.TryParse(shiftChar, out int shift))
            {
                Console.WriteLine("Shift must be a number.");
                return;
            }

            if (option == "1") Shift(input, shift);
            if (option == "2") Decrypt(input, shift);
        }
        private static void Decrypt(string? input, int shift)
        {
            StringBuilder output = new StringBuilder();
            if (input != null)
            {
                var lowerCaseShifter = new LowerCaseShifter();
                var upperCaseShifter = new UpperCaseShifter();
                var numberShifter = new NumberShifter();

                for (int i = 0; i < input.Length; i++)
                {
                    char decryptedCharacter = Char.MinValue;

                    if (lowerCaseShifter.CanShift(input[i])) decryptedCharacter = lowerCaseShifter.Decrypt(input[i], shift);

                    if (upperCaseShifter.CanShift(input[i])) decryptedCharacter = upperCaseShifter.Decrypt(input[i], shift);

                    if (numberShifter.CanShift(input[i])) decryptedCharacter = numberShifter.Decrypt(input[i], shift);

                    if (decryptedCharacter == char.MinValue)
                    {
                        Console.WriteLine("Input must only contain digits, lowercase letters and/or uppercase letters.");
                        return;
                    }
                    output.Append(decryptedCharacter);
                }
            }
            Console.WriteLine("Output: " + output);
            Console.WriteLine("----------------------");
        }

        public static void Shift(string input, int shift)
        {
            StringBuilder output = new StringBuilder();

            if (input != null)
            {
                var lowerCaseShifter = new LowerCaseShifter();
                var upperCaseShifter = new UpperCaseShifter();
                var numberShifter = new NumberShifter();

                for (int i = 0; i < input.Length; i++)
                {
                    char shiftedCharacter = Char.MinValue;

                    if (lowerCaseShifter.CanShift(input[i])) shiftedCharacter = lowerCaseShifter.Encrypt(input[i], shift);

                    if (upperCaseShifter.CanShift(input[i])) shiftedCharacter = upperCaseShifter.Encrypt(input[i], shift);

                    if (numberShifter.CanShift(input[i])) shiftedCharacter = numberShifter.Encrypt(input[i], shift);

                    if (shiftedCharacter == char.MinValue)
                    {
                        Console.WriteLine("Input must only contain digits, lowercase letters and/or uppercase letters");
                        return;
                    }
                    output.Append(shiftedCharacter);
                }
            }
            Console.WriteLine("Output: " + output);
            Console.WriteLine("----------------------");
        }
    }
}

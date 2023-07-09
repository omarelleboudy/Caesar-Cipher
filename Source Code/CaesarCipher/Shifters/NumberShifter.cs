using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarCypher.Shifters
{
    public class NumberShifter : IShifter
    {
        public bool CanShift(char c)
        {
            return ('0' <= c && c <= '9');
        }

        public char Decrypt(char digit, int shift)
        {
            char[] numbers = new char[] { '0','1','2','3','4','5','6','7','8','9' };

            int numberCount = 10;

            int currentIndex = Array.IndexOf(numbers, digit);

            int decodedIndex = ((currentIndex - shift) % numberCount);
            if (decodedIndex < 0) decodedIndex += numberCount;

            char decodedDigit = numbers[decodedIndex];
            
            return decodedDigit;
        }

        public char Encrypt(char digit, int shift)
        {
            int numberCount = 10;

            int encodedDigit = (((digit - '0') + shift) % numberCount) + '0';

            return (char)encodedDigit;

        }
    }
}

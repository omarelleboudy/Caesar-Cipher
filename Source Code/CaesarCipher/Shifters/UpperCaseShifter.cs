using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarCypher.Shifters
{
    public class UpperCaseShifter : IShifter
    {
        public bool CanShift(char c)
        {
            return ('A' <= c && c <= 'Z');
        }
       
        public char Encrypt(char c, int shift)
        {
            int alphabetCharacterCount = 26;

            int encodedChar = (((c - 'A') + shift) % alphabetCharacterCount) + 'A';

            return (char)encodedChar;

        }
        public char Decrypt(char c, int shift)
        {
            char[] alphabet = new char[] { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };

            int alphabetCharacterCount = 26;

            int currentIndex = Array.IndexOf(alphabet, c);

            int decodedIndex = ((currentIndex - shift) % alphabetCharacterCount);
            if (decodedIndex < 0) decodedIndex += alphabetCharacterCount;

            char decodedChar = alphabet[decodedIndex];

            return decodedChar;
        }
    }
}

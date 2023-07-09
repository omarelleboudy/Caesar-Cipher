using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarCypher.Shifters
{
    public class LowerCaseShifter : IShifter
    {
        public bool CanShift(char c)
        {
            return ('a' <= c && c <= 'z');
        }

        public char Encrypt(char c, int shift)
        {
            int alphabetCharacterCount = 26;

            int encodedChar = (((c - 'a') + shift) % alphabetCharacterCount) + 'a';

            return (char)encodedChar;


        }
        public char Decrypt(char c, int shift)
        {
            char[] alphabet = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            
            int alphabetCharacterCount = 26;

            int currentIndex = Array.IndexOf(alphabet, c);

            int decodedIndex = ((currentIndex - shift) % alphabetCharacterCount);
            if (decodedIndex < 0) decodedIndex += alphabetCharacterCount;

            char decodedChar = alphabet[decodedIndex];

            return decodedChar;
        }
    }
}

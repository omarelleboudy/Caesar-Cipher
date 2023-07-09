using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarCypher.Shifters
{
    public interface IShifter
    {
        public bool CanShift(char c);
        public char Encrypt(char c,int shift);
        public char Decrypt(char c,int shift);
    }
}

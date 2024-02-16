using SoftwareSecurityProject.ServicesContract;

namespace SoftwareSecurityProject.Services
{
    public class Affine : IModernAlgorithm
    {
        private const int a = 15;
        private const int b = 20;
        private const int n = 52;
        private List<char> Keys = new List<char>(Alphabet.alphabet.Keys);
        private int MultiInverse(int a, int n)
        {
            for (int i = 1; i < n; i++)
            {
                if ((a * i) % n == 1)
                    return i;
            }
            return -1;
        }
        public string Encryption(string PlainText)
        {
            string Cipher = "";
            foreach (char c in PlainText)
            {
                if (Char.IsLetter(c))
                {
                    int PlainValue = Alphabet.alphabet[c];
                    int CipherValue = ((a*PlainValue)+b)%n;
                    char CipherChar = Keys[CipherValue];
                    Cipher += CipherChar;
                }
                else
                    Cipher += c;
            }
            return Cipher;

        }
        public string Decryption(string CipherText)
        {
            string Plain = "";
            int Inverse = MultiInverse(a, n);
            foreach(char c in CipherText)
            {
                if (Char.IsLetter(c))
                {
                    int CipherValue = Alphabet.alphabet[c];
                    int PlainValue = (Inverse * (CipherValue - b + n)) % n;
                    char PlainChar = Keys[PlainValue];
                    Plain += PlainChar;
                }
                else
                    Plain+= c;
            }
            return Plain;
        }
    }
}

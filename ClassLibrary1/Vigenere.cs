using ServicesContracts;
using SoftwareSecurityProject.Services;
using SoftwareSecurityProject.ServicesContract;


namespace Services
{
    public class Vigenere : IViginereAlgorithm
    {
        private const int n = 52;

        private List<char> Keys = new List<char>(Alphabet.alphabet.Keys);
        public string Encrypt(string plaintext, string key)
        {
            int PlainLength = plaintext.Length;
            int KeyLength = key.Length;
            string Cipher = "";
            for(int i = 0; i< PlainLength; i++)
            {
                if (Char.IsLetter(plaintext[i]))
                {
                    int PlainValue = Alphabet.alphabet[plaintext[i]];
                    int KeyValue = Alphabet.alphabet[key[i % KeyLength]];
                    int CipherValue = (PlainValue + KeyValue) % n;
                    char CipherChar = Keys[CipherValue];
                    Cipher += CipherChar;
                }
                else
                    Cipher += plaintext[i];
            }
            return Cipher;
        }
        public string Decrypt(string ciphertext, string key)
        {
            int CipherLength = ciphertext.Length;
            int KeyLength = key.Length;
            string Plain = "";
            for(int i = 0; i<CipherLength; i++)
            {
                if (Char.IsLetter(ciphertext[i]))
                {
                    int CipherValue = Alphabet.alphabet[ciphertext[i]];
                    int KeyValue = Alphabet.alphabet[key[i% KeyLength]];
                    int PlainValue = (CipherValue - KeyValue + n) % n;
                    char PlainChar = Keys[PlainValue];
                    Plain += PlainChar;
                }
                else
                    Plain+= ciphertext[i];
            }
            return Plain;

        }
    }
}
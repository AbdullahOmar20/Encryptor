using SoftwareSecurityProject.ServicesContract;


namespace SoftwareSecurityProject.Services
{
    public class Ceaser : ICeaserAlgorithm
    {
        
        private List<char> Keys = new List<char>(Alphabet.alphabet.Keys);
        //private static List<int> Values = new List<int>(Alphabet.alphabet.Values);

        public string Encrypt(string plaintext, int key)
        {
            
            string ciphertext = "";
            foreach (char c in plaintext)
            {
                if (Char.IsLetter(c))
                {
                    int PlainValue = Alphabet.alphabet[c];
                    
                    int CipherValue = (PlainValue + key) % 52;
                    char Cipher =  Keys[CipherValue];
                    ciphertext += Cipher;
                }
                else
                {
                    ciphertext += c;
                }
            }
            return ciphertext;

        }

        public string Decrypt(string ciphertext, int key)
        {
            
            string plaintext = "";
            foreach (char c in ciphertext)
            {
                if (Char.IsLetter(c))
                {
                    int CipherValue = Alphabet.alphabet[c];
                    int PlainValue = (CipherValue - key + 52) % 52;
                    char Plain = Keys[PlainValue];
                    plaintext += Plain;
                }
                else
                {
                    plaintext += c;
                }
            }
            return plaintext;

        }

    }
}

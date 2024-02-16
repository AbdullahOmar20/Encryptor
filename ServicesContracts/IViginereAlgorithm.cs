using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesContracts
{
    public interface IViginereAlgorithm
    {
        public string Encrypt(string plaintext, string key);
        public string Decrypt(string ciphertext, string key);
    }
}

namespace SoftwareSecurityProject.ServicesContract
{
    public interface ICeaserAlgorithm
    {
        public string Encrypt(string plaintext, int key);
        public string Decrypt(string ciphertext, int key);
    }
}

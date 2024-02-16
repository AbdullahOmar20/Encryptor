namespace SoftwareSecurityProject.ServicesContract
{
    public interface IModernAlgorithm
    {
        public string Encryption(string PlainText);
        public string Decryption(string CipherText);
    }
}

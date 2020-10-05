namespace cipherNg.Services
{
    public interface IEncoder
    {
        public string MakeEncode(string origstr);
        public void LogNow(string origstr);
    }
}
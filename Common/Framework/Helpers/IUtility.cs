namespace Framework.Helpers
{
    public interface IUtility
    {
        string Hash(string clearText);
        string BaseUrl { get; }
        bool Verify(string clearText, string encryptedText);

    }
}
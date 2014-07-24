namespace Aspector.Interface
{
    public interface ISerializer
    {
        string Serialize<T>(T value);
    }
}
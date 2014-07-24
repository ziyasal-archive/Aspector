using ServiceStack.Text;
using Aspector.Interface;

namespace Aspector.Serialization.ServiceStack
{
    public class ServiceStackSerializer : ISerializer
    {
        public string Serialize<T>(T value)
        {
            return JsonSerializer.SerializeToString(value);
        }
    }
}

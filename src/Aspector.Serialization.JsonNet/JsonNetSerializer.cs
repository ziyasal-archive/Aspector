using Newtonsoft.Json;
using Aspector.Interface;

namespace Aspector.Serialization.JsonNet
{
    public class JsonNetSerializer : ISerializer
    {
        public string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }
    }
}

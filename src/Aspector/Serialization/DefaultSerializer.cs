using Aspector.Interface;
using System.Web.Script.Serialization;

namespace Aspector.Serialization
{
    public class DefaultSerializer : ISerializer
    {
        public string Serialize<T>(T value)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            return serializer.Serialize(value);
        }
    }
}
using Newtonsoft.Json.Linq;

namespace GraphicsViewer.Core.Extensions
{
    public static class JsonExtensions
    {
        public static string Get(this JObject jObject, string name)
        {
            return jObject[name].ToString();
        }
    }
}
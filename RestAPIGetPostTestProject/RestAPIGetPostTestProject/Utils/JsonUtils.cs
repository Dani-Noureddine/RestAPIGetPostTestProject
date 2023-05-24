using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace RestAPI_GetPost_task
{
    public static class JsonUtils
    {
        public static bool IsJsonFormat(string json)
        {
            try
            {
                JContainer.Parse(json);
                return true;
            }
            catch (JsonReaderException)
            {
                return false;
            }
        }
    }
}

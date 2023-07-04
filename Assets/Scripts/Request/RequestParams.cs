using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public abstract class RequestParams
    {
        public abstract JObject GetParams();
    }
}

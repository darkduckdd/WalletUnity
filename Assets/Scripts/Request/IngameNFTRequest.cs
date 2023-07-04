using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class IngameNFTRequest : RequestParams
    {
        public string Hash;
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Hash", Hash }
            };
            return json;
        }
    }
}

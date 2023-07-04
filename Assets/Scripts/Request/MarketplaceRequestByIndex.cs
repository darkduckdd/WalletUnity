using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class MarketplaceRequestByIndex : RequestParams
    {
        public int Index;
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Index", Index }
            };
            return json;
        }
    }
}

using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class MarketplaceRequestById : RequestParams
    {
        public string ItemId;

        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "ItemId", ItemId }
            };
            return json;
        }
    }
}

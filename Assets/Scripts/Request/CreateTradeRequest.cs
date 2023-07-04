using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class CreateTradeRequest : RequestParams
    {
        public string SkinId;
        public int Price;
        public string CurrencyId;
        public string SkinClass;
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "SkinId", SkinId },
            };

            if (Price != 0)
            {
                json.Add("Price", Price);
            }

            if (CurrencyId != null)
            {
                json.Add("CurrencyId", CurrencyId);
            }
            if (SkinClass != null)
            {
                json.Add("SkinClass", SkinClass);
            }

            return json;
        }
    }
}

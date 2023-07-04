using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class MarkeplaceTradeRequest : RequestParams
    {
        public int Index;
        public string ItemId;
        public int SortOrder;
        public string CurrencyType;
        public string PriceRange;

        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Index", Index },
                {"ItemId",ItemId }
            };

            if (SortOrder != 0)
            {
                json.Add("SortOrder", SortOrder);
            }
            if (CurrencyType != null)
            {
                json.Add("CurrencyType", CurrencyType);
            }
            if (PriceRange != null)
            {
                json.Add("PriceRange", PriceRange);
            }
            return json;
        }
    }
}

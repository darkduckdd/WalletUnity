using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class WalletNFTRequest : RequestParams
    {
        public int Amount;
        public string ToAddress = "0xeB28f4D9986D1323B3AbAc52ecC262DAa0d50AD8";
        public string ItemId = "Cube1";
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Amount", Amount },
                { "ToAddress", ToAddress },
                {"ItemId",ItemId }

            };
            return json;
        }
    }
}

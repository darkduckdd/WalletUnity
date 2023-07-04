using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class ToWalletRequest : TokenRequest
    {
        public string ToAddress;
        public int Amount;
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Amount", Amount },
                { "TokenType", TokenType },
                { "ToAddress", "0xeB28f4D9986D1323B3AbAc52ecC262DAa0d50AD8" },
            };
            return json;
        }
    }
}

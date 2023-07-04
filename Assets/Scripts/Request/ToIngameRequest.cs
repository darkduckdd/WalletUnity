using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class ToIngameRequest : TokenRequest
    {
        public string Hash;
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Hash", Hash },
                { "TokenType", TokenType },
            };
            return json;
        }
    }
}

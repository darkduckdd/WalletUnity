using Assets.Scripts;
using Newtonsoft.Json.Linq;

namespace Assets
{
    public class TokenRequest : RequestParams
    {
        public string TokenType;

        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "TokenType", TokenType },
            };
            return json;
        }
    }


}

using Newtonsoft.Json.Linq;

namespace Assets.Scripts
{
    public class GroupedTradesRequest : RequestParams
    {

        public int Index;
        public string Rarity;
        public string Weapon;
        public string Collection;
        public override JObject GetParams()
        {
            var json = new JObject
            {
                { "Index", Index },
            };

            if (Rarity != null)
            {
                json.Add("Rarity", Rarity);
            }

            if (Weapon != null)
            {
                json.Add("Weapon", Weapon);
            }
            if (Collection != null)
            {
                json.Add("Collection", Collection);
            }

            return json;
        }
    }
}

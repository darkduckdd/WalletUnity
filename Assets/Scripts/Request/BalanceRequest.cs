using Assets.Scripts;
using Newtonsoft.Json.Linq;

public class BalanceRequest : RequestParams
{
    public string Address;
    public int NFTId;
    public override JObject GetParams()
    {
        var json = new JObject
            {
                { "Address", Address },
                {"NFTId",NFTId }
            };
        return json;
    }


}

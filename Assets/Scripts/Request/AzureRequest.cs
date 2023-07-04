
using Newtonsoft.Json.Linq;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace Assets.Scripts
{
    public class AzureRequest
    {

        public static async void SendTokenToCryptoWallet(ToWalletRequest request)
        {
            await AzureSendRequest("https://workwithdb.azurewebsites.net/api/SendTokentoCryptoWallet?", RequestMethod.POST, request);
        }
        public static async void SendTokenToIngame(ToIngameRequest request)
        {
            await AzureSendRequest("https://workwithdb.azurewebsites.net/api/SendTokenToIngame?", RequestMethod.POST, request);
        }
        public static async void SendNFTToCryptoWallet(WalletNFTRequest request)
        {
            await AzureSendRequest("https://workwithdb.azurewebsites.net/api/TransferNFTToCryptoWallet?", RequestMethod.POST, request);
        }
        public static async void SendNFTToIngame(IngameNFTRequest request)
        {
            await AzureSendRequest("https://workwithdb.azurewebsites.net/api/TransferNFTToIngame?", RequestMethod.POST, request);
        }

        public static async void BuyMarketplaceItem(MarketplaceRequestById request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/BuyItem?", RequestMethod.POST, request);
        }
        public static async void DeleteMarketplaceItem(MarketplaceRequestById request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/DeleteItem?", RequestMethod.POST, request);
        }

        public static async void GetActiveMarketplaceTrades(MarketplaceRequestByIndex request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/GetActiveTrades?", RequestMethod.POST, request);
        }
        public static async void GetHistoryMarketplaceTrades(MarketplaceRequestByIndex request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/GetTradesHistory?", RequestMethod.POST, request);
        }
        public static async void GetTradesByItemId(MarkeplaceTradeRequest request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/GetItemByItemId?", RequestMethod.POST, request);
        }

        public static async void GetGroupedTrades(GroupedTradesRequest request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/GetGroupedTrades?", RequestMethod.POST, request);
        }

        public static async void CreateTrade(CreateTradeRequest request)
        {
            await AzureSendRequest("https://idosgamesmarketplace.azurewebsites.net/api/AddItem?", RequestMethod.POST, request);
        }

        public static async void GetBalance(BalanceRequest request)
        {
            await AzureSendRequest("https://workwithdb.azurewebsites.net/api/GetNFTBalance?", RequestMethod.POST, request);
        }



        private static async Task<string> AzureSendRequest(string uri, RequestMethod method, RequestParams requestParams)
        {
            var jsonBody = new JObject
            {
                { "PlayfabId", PlayfabLogin.PlayFabID },
                { "EntityToken", PlayfabLogin.EntityToken },
                { "EntityType", PlayfabLogin.EntityType },
                { "EntityId", PlayfabLogin.EntityID },
                { "TitleId", PlayfabLogin.TitleId }
            };

            jsonBody.Merge(requestParams.GetParams());
            var jsonString = jsonBody.ToString();
            UnityWebRequest webRequest = new UnityWebRequest(uri, method.ToString());
            byte[] bodyRaw = new System.Text.UTF8Encoding(true).GetBytes(jsonString);
            webRequest.uploadHandler = new UploadHandlerRaw(bodyRaw);
            webRequest.downloadHandler = new DownloadHandlerBuffer();
            webRequest.SetRequestHeader("Content-Type", "application/json");
            UnityWebRequestAsyncOperation asyncOperation = webRequest.SendWebRequest();
            TaskCompletionSource<string> tcs = new TaskCompletionSource<string>();

            asyncOperation.completed += (op) =>
            {
                if (webRequest.result != UnityWebRequest.Result.Success)
                {
                    Debug.LogError($"Request failed: {webRequest.error}");
                    tcs.SetResult(webRequest.error);
                    return;
                }

                string result = webRequest.downloadHandler.text;
                Debug.Log($"Request successful: {result}");
                tcs.SetResult(result);
            };
            return await tcs.Task;


        }
    }
}

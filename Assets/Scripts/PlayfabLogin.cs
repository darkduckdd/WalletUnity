using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

public class PlayfabLogin : MonoBehaviour
{

    public static string SessionTicket { get; private set; }
    public static string EntityToken { get; private set; }
    public static string EntityType { get; private set; }
    public static string EntityID { get; private set; }
    public static string PlayFabID { get; private set; }
    public static string TitleId { get; private set; }

    private void Awake()
    {
        Login();
    }

    private void Login()
    {
        var request = new LoginWithCustomIDRequest
        {
            CustomId = SystemInfo.deviceUniqueIdentifier,
            CreateAccount = true
        };
        PlayFabClientAPI.LoginWithCustomID(request, onSuccess, OnError);
    }

    private void onSuccess(LoginResult result)
    {
        /*  PlayFabAuthenticationAPI.GetEntityToken(new PlayFab.AuthenticationModels.GetEntityTokenRequest() { }, (result) =>
          {
              EntityToken = result.EntityToken;
              Debug.Log(EntityToken);
          }, (error) =>
          {
              Debug.Log(error.GenerateErrorReport()); ;
          });*/
        EntityToken = result.AuthenticationContext.EntityToken;
        EntityID = result.AuthenticationContext.EntityId;
        EntityType = result.AuthenticationContext.EntityType;
        SessionTicket = result.SessionTicket;
        PlayFabID = result.PlayFabId;
        TitleId = PlayFabSettings.TitleId;
        Debug.Log(TitleId);




    }

    private void OnError(PlayFabError error)
    {
        Debug.Log(error.GenerateErrorReport()); ;
    }
}

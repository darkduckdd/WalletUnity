using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTest : MonoBehaviour
{
    [SerializeField] private Button button;
    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(Click);
    }

    private void Click()
    {
        AzureRequest.SendNFTToIngame(new IngameNFTRequest { Hash = "0x68dfe213e7dea8cffe13af920d57841d88cf46811bde8735ec7e63691077c011" });
        //AzureRequest.GetBalance(new BalanceRequest { Address = "0xeB28f4D9986D1323B3AbAc52ecC262DAa0d50AD8" });
    }

}

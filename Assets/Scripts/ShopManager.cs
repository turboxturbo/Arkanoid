using UnityEngine;

public class ShopManager : MonoBehaviour
{
    void Start()
    {
        LoadShopData();
    }
    void LoadShopData()
    {
        int userid = PlayerPrefs.GetInt("CurrentUserId", 0);
        if (userid == 0)
        {
            return;
        }
        ApiRequests.GetMyScins(OnLoadScinsReceived, new CurrentUser { userId = userid });
        ApiRequests.GetMyCoins(OnLoadCoinsReceived, new CurrentUser { userId = userid });
    }
    void OnLoadScinsReceived(Answer answer)
    {
         Debug.Log("Scins received: " + answer.data.userscins.Count);
    }
    void OnLoadCoinsReceived(Coins coins)
    {
        Debug.Log("Coins received: " + coins.coins);
    }
}

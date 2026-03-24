using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [SerializeField] Text coinstext;
    [SerializeField] Transform scrollContent;
    [SerializeField] GameObject itemscroll;
    private List<UserScins> myscins = new();
    private List<Scins> allscins = new();
    private bool myscinsLoaded = false;
    private bool allscinsisloaded = false;

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
        ApiRequests.GetMyScins(OnLoadMyScinsReceived, new CurrentUser { userId = userid });
        ApiRequests.GetMyCoins(OnLoadCoinsReceived, new CurrentUser { userId = userid });
        ApiRequests.GetAllScins(OnLoadAllScinsReceived);
    }
    void OnLoadMyScinsReceived(Answer answer)
    {
         Debug.Log("Scins received: " + answer.data.userscins.Count);
         myscins = answer.data.userscins;
         myscinsLoaded = true;
        TryLoadScrollView();
    }
    void OnLoadAllScinsReceived(AllScins scins)
    {
        Debug.Log("All scins received: " + scins.data.scins.Count);
        allscins = scins.data.scins;
        allscinsisloaded = true;
        TryLoadScrollView();
    }
    void TryLoadScrollView()
    {
        if (allscinsisloaded && myscinsLoaded && allscins.Count > 0)
        {
            LoadScrollView();
        }
    }
    void OnLoadCoinsReceived(CoinsAnswer coins)
    {
        Debug.Log("Coins received: " + coins.user.coins);
        PlayerPrefs.SetInt("CurrentUserCoins", coins.user.coins);
        PlayerPrefs.Save();
        coinstext.text = "Coins: " + coins.user.coins.ToString();
    }
    void LoadScrollView()
    {
        Debug.Log("activate loadscroll");
        foreach (Transform item in scrollContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var scin in allscins)
        {
            bool isOwned = myscins.Any(u => u.idScin == scin.idScin);
            
            var iteminscroll = Instantiate(itemscroll, scrollContent);
            var itemview = iteminscroll.GetComponent<ScrollViewItems>();
            itemview.SetData(scin, isOwned);
        }
    }
}

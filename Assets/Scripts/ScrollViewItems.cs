using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollViewItems : MonoBehaviour
{
    [SerializeField] private Text namescin;
    [SerializeField] private Text price;
    [SerializeField] private GameObject isowned;
    [SerializeField] private GameObject button;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Image scinimage;
    private bool coinsisloaded = false;
    private bool scinisloaded = false;
    private Scins currentscin;

    public void SetData(Scins scin, bool owned)
    {
        currentscin = scin;
        namescin.text = scin.nameScin;
        price.text = scin.price.ToString();
        isowned.SetActive(owned);
        button.SetActive(!owned);
        LoadScin(scin);
    }
    private void LoadScin(Scins scin)
    {
        Sprite sprite = sprites.Find(s => s.name == scin.nameScin);
        scinimage.sprite = sprite;
    }
    private void ClicikBtnBuy()
    {
        int userid = PlayerPrefs.GetInt("CurrentUserId", 0);
        int coins = PlayerPrefs.GetInt("CurrentUserCoins", 0);
        if (userid == 0 )
        {
            return;
        }
        if (coins >= currentscin.price)
        {
            scinisloaded = false;
            coinsisloaded = false;

            ApiRequests.BuyScin(OnBuyScinResponseReceived, new BuyScin { userId = userid, scinId = currentscin.idScin });
            ApiRequests.DecreaseCoins(OnDecreaseCoinsResponseReceived, new BuyScin { userId = userid, scinId = currentscin.idScin });
        }

    }

    private void OnBuyScinResponseReceived(BuyScinResponse response)
    {
        Debug.Log(response.status);
        scinisloaded = true;
        TryLoadScene();
    }
    private void OnDecreaseCoinsResponseReceived(UpdateCoinsResponse response)
    {
        Debug.Log(response.status);
        coinsisloaded = true;
        TryLoadScene();
    }
    private void TryLoadScene()
    {
        if (scinisloaded && coinsisloaded)
        {
            SceneManager.LoadScene("Shop");
        }
    }
}

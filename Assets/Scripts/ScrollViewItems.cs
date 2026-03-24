using NUnit.Framework;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollViewItems : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private Text namescin;
    [SerializeField] private Text price;
    [SerializeField] private GameObject isowned;
    [SerializeField] private GameObject button;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Image scinimage;
    //[SerializeField] private GameObject selectbutton;
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

        Button buybtn = button.GetComponent<Button>();
        buybtn.onClick.RemoveAllListeners();
        buybtn.onClick.AddListener(ClickBtnBuy);

        //Button selectbtn = selectbutton.GetComponent<Button>();
        //selectbtn.onClick.RemoveAllListeners();
        //selectbtn.onClick
    }
    private void LoadScin(Scins scin)
    {
        Sprite sprite = sprites.Find(s => s.name == scin.nameScin);
        scinimage.sprite = sprite;
    }
    private void ClickBtnBuy()
    {
        int userid = PlayerPrefs.GetInt("CurrentUserId", 0);
        int coins = PlayerPrefs.GetInt("CurrentUserCoins", 0);
        Debug.Log("Текущие данные" + userid + " " + coins + " " + currentscin.idScin);
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        //if (currentscin.)
    }
}

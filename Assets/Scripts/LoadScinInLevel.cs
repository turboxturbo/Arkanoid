using NUnit.Framework;
using System.Collections.Generic;
using System.Xml.Schema;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class LoadScinInLevel : MonoBehaviour
{
    [SerializeField] private GameObject ball;
    [SerializeField] private GameObject prefabball;
    [SerializeField] private List<Sprite> sprites;
    [SerializeField] private Text coins;
    private string namescin;
    void Start()
    {
        int userid = PlayerPrefs.GetInt("CurrentUserId", 0);
        if (userid == 0)
        {
            return;
        }
        ApiRequests.GetMyCoins(OnLoadCoinsReceived, new CurrentUser { userId = userid });
        //coins.text = "Coins: " + PlayerPrefs.GetInt("CurrentUserCoins", 0).ToString();
        namescin = PlayerPrefs.GetString("CurrentScin", "scin3");
        LoadSprite();
        Debug.Log("Установлен скин: " + namescin);
    }
    void LoadSprite()
    {
        Sprite sprite = sprites.Find(s => s.name == namescin);
        var sr = ball.GetComponent<SpriteRenderer>();
        var srpref = prefabball.GetComponent<SpriteRenderer>();
        sr.sprite = sprite;
        srpref.sprite = sprite;
    }
    void OnLoadCoinsReceived(CoinsAnswer coinsanswer)
    {
        Debug.Log("Coins received: " + coinsanswer.user.coins);
        PlayerPrefs.SetInt("CurrentUserCoins", coinsanswer.user.coins);
        PlayerPrefs.Save();
        coins.text = "Coins: " + coinsanswer.user.coins.ToString();
    }
}

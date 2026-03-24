using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScrollViewMyScin : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField] private Image scinimage;
    [SerializeField] private Text price;
    [SerializeField] private Text namescin;
    [SerializeField] private List<Sprite> sprites;

    public void LoadData(UserScins scin)
    {
        price.text = scin.scins.price.ToString();
        namescin.text = scin.scins.nameScin;
        LoadScin(scin);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //PlayerPrefs.SetString("CurrentScin", eventData);
        PlayerPrefs.Save();
        Debug.Log("Текущий скин: " + PlayerPrefs.GetString("CurrentScin", "scin3"));
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        price.color = Color.red;
        namescin.color = Color.red;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        price.color = Color.white;
        namescin.color = Color.white;
    }

    void LoadScin(UserScins scin)
    {
        Sprite sprite = sprites.Find(s => s.name == scin.scins.nameScin);
        scinimage.sprite = sprite;
    }
}

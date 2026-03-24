using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class ScinManager : MonoBehaviour
{
    //[SerializeField] private GameObject item;
    [SerializeField] private Transform scrollcontent;
    [SerializeField] GameObject itemscroll;
    private List<UserScins> scins;
    void Start()
    {
        LoadMyScin();
    }
    void LoadMyScin()
    {
        int userid = PlayerPrefs.GetInt("CurrentUserId", 0);
        if (userid == 0)
        {
            return;
        }
        ApiRequests.GetMyScins(OnLoadMyScin, new CurrentUser { userId = userid });
    }

    void OnLoadMyScin(Answer answer)
    {
        scins = answer.data.userscins;
        if (answer.status)
        {
            foreach(Transform scin in scrollcontent)
            {
                Destroy(scin.gameObject);
            }
            foreach (var scin in scins)
            {
                var iteminscroll = Instantiate(itemscroll, scrollcontent);
                var item = iteminscroll.GetComponent<ScrollViewMyScin>();
                item.LoadData(scin);
            }
        }
    }
}

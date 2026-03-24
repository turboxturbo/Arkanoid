using Mono.Cecil.Cil;
using Unity.VisualScripting;
using UnityEngine;

public class VictoryManager : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject buttonrepeat;
    [SerializeField] private GameObject buttonexit;
    private int userid;
    private int coins;
    // Update is called once per frame
    void Update()
    {
        if (WinManager.win)
        {
            animator.SetBool("isopen", true);
            buttonexit.SetActive(false);
            buttonrepeat.SetActive(false);
            userid = PlayerPrefs.GetInt("CurrentUserId", 0);
            coins = PlayerPrefs.GetInt("CurrentUserCoins", 0);
            ApiRequests.IncreaseCoins(OnIncreaseCoinsResponseReceived, new CurrentUser { userId = userid });
            WinManager.win = false;
        }
    }

    private void OnIncreaseCoinsResponseReceived(PlusCoinsResponse response)
    {
        if (response.status)
        {
            PlayerPrefs.SetInt("CurrentUserCoins", response.coins);
            PlayerPrefs.Save();
            Debug.Log("Установлено новое коливество денег" + response.coins);
        }
    }
}

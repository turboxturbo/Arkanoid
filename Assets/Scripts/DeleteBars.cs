using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeleteBars : MonoBehaviour
{
    //[SerializeField] private GameObject spawnpoint;
    //[SerializeField] private GameObject ball;
    [SerializeField] private AudioClip barbreaksound;
    [SerializeField] private List<GameObject> effects;
    [SerializeField] private List<GameObject> bars;
    private int hitsdestroy;
    private int hitscount = 0;
    private int random;
    private int namerandom;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.name == "Circle" || collision.gameObject.name == "Circle(Clone)")
        {
            random = Random.Range(0, 6);
            if (gameObject.name == "BasicArkanoidPack_0(Clone)" || gameObject.name == "BasicArkanoidPack_1(Clone)")
            {
                hitsdestroy = 1;
                TouchBar();
            }
            else if (gameObject.name == "BasicArkanoidPack_2(Clone)" || gameObject.name == "BasicArkanoidPack_3(Clone)")
            {
                hitsdestroy = 2;
                TouchBar();
            }
            else if (gameObject.name == "BasicArkanoidPack_4(Clone)" || gameObject.name == "BasicArkanoidPack_5(Clone)")
            {
                hitsdestroy = 3;
                TouchBar();
            }
            else if (gameObject.name == "BasicArkanoidPack_6(Clone)")
            {
                hitsdestroy = 4;
                TouchBar();
            }
        }
    }
    void BreakBar()
    {
        Destroy(gameObject);
        WinManager.DestroyBar();
        if (random == 0)
        {
            GameObject effectInstance = Instantiate(effects[0], gameObject.transform.position, Quaternion.identity);
            effectInstance.name = "BonusDoubleBalls";
        }
        else if(random == 1)
        {
            GameObject effectInstance = Instantiate(effects[1], gameObject.transform.position, Quaternion.identity);
            effectInstance.name = "BonusTripleBalls";
        }
        else if (random == 2)
        {
            GameObject effectInstance = Instantiate(effects[2], gameObject.transform.position, Quaternion.identity);
            effectInstance.name = "IncreaseSpeed";
        }
        else if (random == 3)
        {
            GameObject effectInstance = Instantiate(effects[3], gameObject.transform.position, Quaternion.identity);
            effectInstance.name = "DecreaseSpeed";
        }
        else if (random == 4)
        {
            GameObject effectInstance = Instantiate(effects[4], gameObject.transform.position, Quaternion.identity);
            effectInstance.name = "IncreaseScale";
        }
        else if (random == 5)
        {
            GameObject effectInstance = Instantiate(effects[5], gameObject.transform.position, Quaternion.identity);
            effectInstance.name = "DecreaseScale";
        }
    }
    void TouchBar()
    {
        hitscount++;
        SoundManager.instance.PlayBarBreak(barbreaksound);
        int hitsLeft = hitsdestroy - hitscount;
        if (hitsLeft <= 0)
        {
            // последняя жизнь — уничтожаем и спавним бонус
            BreakBar();
            return;
        }
        GameObject newbar = null;
        namerandom = Random.Range(1, 3);
        if (hitsLeft == 3)
        {
            // была 4-хитовая, стала 3-хитовая

            if (namerandom == 1)
            {
                newbar = Instantiate(bars[4], transform.position, Quaternion.identity);
                newbar.name = "BasicArkanoidPack_4(Clone)";
            }
            else if (namerandom == 2)
            {
                newbar = Instantiate(bars[5], transform.position, Quaternion.identity);
                newbar.name = "BasicArkanoidPack_5(Clone)";
            }
        }
        else if (hitsLeft == 2)
        {
            // стала 2-хитовой
            if (namerandom == 1)
            {
                newbar = Instantiate(bars[2], transform.position, Quaternion.identity);
                newbar.name = "BasicArkanoidPack_2(Clone)";
            }
            else if (namerandom == 2)
            {
                newbar = Instantiate(bars[3], transform.position, Quaternion.identity);
                newbar.name = "BasicArkanoidPack_3(Clone)";
            }
        }
        else if (hitsLeft == 1)
        {
            // стала 1-хитовой
            if (namerandom == 1)
            {
                newbar = Instantiate(bars[0], transform.position, Quaternion.identity);
                newbar.name = "BasicArkanoidPack_0(Clone)";
            }
            else if (namerandom == 2)
            {
                newbar = Instantiate(bars[1], transform.position, Quaternion.identity);
                newbar.name = "BasicArkanoidPack_1(Clone)";
            }
        }
        Destroy(gameObject);
    }
}

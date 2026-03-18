using NUnit.Framework;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DelBallAndHearts : MonoBehaviour
{
    [SerializeField] private List<Image> hearts;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnballpoint;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject buttonrepeat;
    [SerializeField] private GameObject buttonexit;
    public bool gameover = false;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int ballcounter = GameObject.FindGameObjectsWithTag("Ball").Length;
        if ((collision.gameObject.name == "Circle" || collision.gameObject.name == "Circle(Clone)") && ballcounter == 1)
        {
            Destroy(collision.gameObject);
            GameObject newBall = Instantiate(prefab, spawnballpoint.position, Quaternion.identity);
            newBall.name = "Circle";
            if (hearts.Count > 0)
            {
                hearts[hearts.Count - 1].gameObject.SetActive(false);
                hearts.RemoveAt(hearts.Count - 1);
                if (hearts.Count == 0)
                {
             
                    animator.SetBool("isopen", true);
                    buttonrepeat.SetActive(false);
                    buttonexit.SetActive(false);
                    gameover = true;
                }
            }
            else if (hearts.Count == 0)
            {
                animator.SetBool("isopen", true);
                buttonrepeat.SetActive(false);
                buttonexit.SetActive(false);
                gameover = true;
            }
        }
        else if ((collision.gameObject.name == "Circle" || collision.gameObject.name == "Circle(Clone)") && ballcounter > 1){
            Destroy(collision.gameObject);
        }
        else if (collision.gameObject.CompareTag("Bonus"))
        {
            Destroy(collision.gameObject);
        }
    }
}

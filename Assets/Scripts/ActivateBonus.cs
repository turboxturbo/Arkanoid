using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ActivateBonus : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] private GameObject rocket;
    [SerializeField] private GameObject ball;
    //[SerializeField] private GameObject spawnpoint;
    private GameObject effecttext;
    private Text bonustext;
    private GameObject[] balls;
    private RectTransform rect;
    private float minScaleX = 1f;
    private float maxScaleX = 1.5f;
    void Start()
    {
        rocket = GameObject.FindGameObjectWithTag("Rocket");
        rect = rocket.GetComponent<RectTransform>();
        effecttext = GameObject.Find("EffectText");
        bonustext = effecttext.GetComponent<Text>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Rocket")
        {
            
            if (gameObject.name == "BonusDoubleBalls")
            {
                Duplicate(2);
                bonustext.text = "doubleballs";
            }
            else if (gameObject.name == "BonusTripleBalls")
            {
                Duplicate(3);
                bonustext.text = "tripleballs";
            }
            else if (gameObject.name == "IncreaseSpeed")
            {
                BallMove.speed += 3f;
                bonustext.text = "+speed";
            }
            else if (gameObject.name == "DecreaseSpeed")
            {
                BallMove.speed -= 3f;
                bonustext.text = "-speed";
            }
            else if (gameObject.name == "IncreaseScale")
            {
                IncreaseScale();
                bonustext.text = "+scale";
            }
            else if (gameObject.name == "DecreaseScale")
            {
                DecreaseScale();
                bonustext.text = "-scale";
            }
            Destroy(gameObject);
        }
    }
    void DecreaseScale()
    {
        Vector3 scale = rect.localScale;
        if (scale.x >= minScaleX)
        {
            scale.x -= 0.3f;
            rect.localScale = scale;
        }
    }
    void IncreaseScale()    {
        Vector3 scale = rect.localScale;
        if (scale.x < maxScaleX)
        {
            scale.x += 0.3f;
            rect.localScale = scale;
        }
    }
    void Duplicate(int quantity)
    {
        balls = GameObject.FindGameObjectsWithTag("Ball");
        foreach (GameObject ballinballs in balls)
        {
            for (int i = 0; i < quantity; i++)
            {
                Instantiate(ball, ballinballs.transform.position, Quaternion.identity);
            }
        }
    }
}

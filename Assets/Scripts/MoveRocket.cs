using UnityEngine;

public class MoveRocket : MonoBehaviour
{
    [SerializeField] private float speed = 10f;
    [SerializeField] private Transform[] movepoints;
    [SerializeField] private DelBallAndHearts delBallAndHearts;

    // Update is called once per frame
    void Start()
    {
        gameObject.transform.localScale = ResetRocketScale.startScale;
    }
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, movepoints[0].position, Time.deltaTime * speed);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            gameObject.transform.position = Vector2.MoveTowards(gameObject.transform.position, movepoints[1].position, Time.deltaTime * speed);
        }
        else if(Input.GetKeyDown(KeyCode.Escape))
        {
            if (delBallAndHearts.gameover == false && WinManager.win == false)
            {
                Time.timeScale = (Time.timeScale == 0) ? 1f : 0f;
            }
        }
    }
}

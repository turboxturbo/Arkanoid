using UnityEngine;

public class BallMove : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static float speed = 1f;
    private Rigidbody2D rb;
    private float timer = 0f;
    private Vector3 lastPos;

    void Start()
    {
        speed = 8f;
        rb = GetComponent<Rigidbody2D>();

        float angle = Random.Range(-30f, 30f);
        Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
        rb.linearVelocity = direction.normalized * speed;
        lastPos = transform.position;
    }

    void FixedUpdate() //только 50 раз
    {
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
        timer += Time.fixedDeltaTime;
        if (timer >= 2.5f)
        {
            timer = 0;
            if (Mathf.Abs(lastPos.x - transform.position.x) < 0.01f)
            {
                float angle = Random.Range(-30f, 30f);
                Vector2 direction = new Vector2(Mathf.Sin(angle * Mathf.Deg2Rad), -Mathf.Cos(angle * Mathf.Deg2Rad));
                rb.linearVelocity = direction.normalized * speed;
            }
            lastPos = transform.position;
        }
    }
}

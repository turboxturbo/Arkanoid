using UnityEngine;

public class MoveMobileBar : MonoBehaviour
{
    [SerializeField] private Transform[] movepoints;
    [SerializeField] private float speed = 1f;
    private int position = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.MoveTowards(transform.position, movepoints[position].position, Time.deltaTime * speed);
        if (Vector3.Distance(transform.position, movepoints[position].position) < 0.01f)
        {
            position = (position + 1) % movepoints.Length;
        }
    }
}

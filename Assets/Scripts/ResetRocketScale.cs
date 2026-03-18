using UnityEngine;

public class ResetRocketScale : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public static Vector3 startScale;
    RectTransform rect;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        startScale = rect.localScale;
        Debug.Log("Current scale: " + startScale);
    }
}

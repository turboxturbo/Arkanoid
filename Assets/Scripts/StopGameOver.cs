using UnityEngine;

public class StopGameOver : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void StopGame()
    {
        Time.timeScale = 0f;
    }
}

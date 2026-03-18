using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RepeatBtn : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void ClickBtn() 
    {
        Time.timeScale = 1f;
        WinManager.win = false;
        if (gameObject.name == "Repeat1lvl")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (gameObject.name == "Repeat2lvl")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (gameObject.name == "Repeat3lvl")
        {
            SceneManager.LoadScene("Level3");
        }
    }
}

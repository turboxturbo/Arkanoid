using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevelScene : MonoBehaviour
{
    private string levelname;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void LoadLevel()
    {
        if (gameObject.name == "1lvlbtn")
        {
            levelname = "Level1";
        }
        else if (gameObject.name == "2lvlbtn")
        {
            levelname = "Level2";
        }
        else if (gameObject.name == "3lvlbtn")
        {
            levelname = "Level3";
        }
        else if (gameObject.name == "Exit")
        {
            levelname = "LevelController";
        }
        Time.timeScale = 1f;
        WinManager.win = false;
        SceneManager.LoadScene(levelname);
    }
}


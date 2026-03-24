using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenLevelScene : MonoBehaviour
{
    private string scenename;
    public void LoadLevel()
    {
        if (gameObject.name == "1lvlbtn")
        {
            scenename = "Level1";
            ResetData();
        }
        else if (gameObject.name == "2lvlbtn")
        {
            scenename = "Level2";
            ResetData();
        }
        else if (gameObject.name == "3lvlbtn")
        {
            scenename = "Level3";
            ResetData();
        }
        else if (gameObject.name == "Exit")
        {
            scenename = "LevelController";
            ResetData();
        }
        else if (gameObject.name == "Shopbtn")
        {
            scenename = "Shop";
        }
        else if (gameObject.name == "ExitShopBtn")
        {
            scenename = "LevelController";
        }
        else if (gameObject.name == "SelectScinBtn")
        {
            scenename = "ScinController";
        }
        SceneManager.LoadScene(scenename);
    }
    private void ResetData()
    {
        Time.timeScale = 1f;
        WinManager.win = false;
    }
}


using UnityEngine;
using UnityEngine.SceneManagement;

public class OpenSignUpScene : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void OnBtnClick()
    {
        SceneManager.LoadScene("SignupController");
    }
}

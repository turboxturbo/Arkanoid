using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class LoginManager : MonoBehaviour
{
    [SerializeField] private InputField loginfield;
    [SerializeField] private InputField passwordfield;

    public void OnClickBtn()
    {
        if (!string.IsNullOrEmpty(loginfield.text) && !string.IsNullOrEmpty(passwordfield.text))
        {
            ApiRequests.Auth(OnAuthorization, new Logins() { Login = loginfield.text, Password = passwordfield.text });
        }
        else
        {
            Text loginfieldtext = loginfield.placeholder as Text;
            loginfieldtext.text = "Заполните все поля";
            loginfield.text = "";

            Text passwordfieldtext = passwordfield.placeholder as Text;
            passwordfieldtext.text = "Заполните все поля";
            passwordfield.text = "";
        }
    }
    void OnAuthorization(AuthResponse response)
    {
        Debug.Log(response.status);
        Debug.Log(response.iduser);

        if (response.status)
        {
            SceneManager.LoadScene("LevelController");
            PlayerPrefs.SetInt("CurrentUserId", response.iduser);
            PlayerPrefs.Save();
        }
        else
        {
            Text loginfieldtext = loginfield.placeholder as Text;
            loginfieldtext.text = "Неверные данные";
            loginfield.text = "";

            Text passwordfieldtext = passwordfield.placeholder as Text;
            passwordfieldtext.text = "Неверные данные";
            passwordfield.text = "";
        }
    }
}

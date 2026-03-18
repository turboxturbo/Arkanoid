using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SignupManager : MonoBehaviour
{
    [SerializeField] private InputField namefield;
    [SerializeField] private InputField descfield;
    [SerializeField] private InputField loginfield;
    [SerializeField] private InputField passfield;

    public void OnClickBtn()
    {
        if (!string.IsNullOrEmpty(namefield.text) && !string.IsNullOrEmpty(descfield.text) && !string.IsNullOrEmpty(loginfield.text) && !string.IsNullOrEmpty(passfield.text))
        {
            ApiRequests.CreateNewUser(OnUsersCreateReceived, new Users() { Name = namefield.text, Description = descfield.text, Login = loginfield.text, Password = passfield.text });
        }
        else
        {
            Text namefieldtext = namefield.placeholder as Text;
            namefieldtext.text = "Заполните все поля";
            Text descfieldtext = descfield.placeholder as Text;
            descfieldtext.text = "Заполните все поля";
            Text loginfieldtext = loginfield.placeholder as Text;
            loginfieldtext.text = "Заполните все поля";
            Text passfieldtext = passfield.placeholder as Text;
            passfieldtext.text = "Заполните все поля";
        }
    }

    void OnUsersCreateReceived(UserCreateResponse response)
    {
        Debug.Log(response.status);
        if (response.status)
        {
            SceneManager.LoadScene("LoginController");
        }
        else
        {
            Text namefieldtext = namefield.placeholder as Text;
            namefieldtext.text = "Неверные данные";
            Text descfieldtext = descfield.placeholder as Text;
            descfieldtext.text = "Неверные данные";
            Text loginfieldtext = loginfield.placeholder as Text;
            loginfieldtext.text = "Неверные данные";
            Text passfieldtext = passfield.placeholder as Text;
            passfieldtext.text = "Неверные данные";
        }
    }
}

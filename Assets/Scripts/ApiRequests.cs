using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using static UnityEngine.UIElements.UxmlAttributeDescription;

public static class ApiRequests
{
    private static string apiUrl = "https://localhost:7253/api/";
    public static void GetUsers(Action<string> callback)
    {
        GameManager.instance.StartCoroutine(GetUsersCoroutine(callback));
    }
    public static void CreateNewUser(Action<UserCreateResponse> callback, Users user)
    {
        GameManager.instance.StartCoroutine(CreateUsersCoroutine(callback, user));
    }
    public static void Auth(Action<AuthResponse> callback, Logins login)
    {
        GameManager.instance.StartCoroutine(AuthCoroutine(callback, login));
    }
    public static IEnumerator GetUsersCoroutine(Action<string> callback)
    {
        using(UnityWebRequest request = UnityWebRequest.Get(apiUrl + "UsersLogins/getAllUsers"))
        {
            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success)
            {
                callback.Invoke(request.downloadHandler.text);
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }
    public static IEnumerator AuthCoroutine(Action<AuthResponse> callback, Logins login) 
    {
        string jsonData = JsonUtility.ToJson(login);
        Debug.Log(jsonData);
        byte[] bodyRow = System.Text.Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl + "UsersLogins/authorization", "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRow);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if (request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                AuthResponse loginResponse = JsonUtility.FromJson<AuthResponse>(jsonResponse);
                Debug.Log(loginResponse);
                callback?.Invoke(loginResponse);
            }
            else
            {
                Debug.Log(request.error);
            }
        }
    }

    public static IEnumerator CreateUsersCoroutine(Action<UserCreateResponse> callback, Users user)
    {
        string jsonData = JsonUtility.ToJson(user);
        Debug.Log(jsonData);
        byte[] bodyRow = System.Text.Encoding.UTF8.GetBytes(jsonData);

        using (UnityWebRequest request = new UnityWebRequest(apiUrl + "UsersLogins/createNewUserAndLogin", "POST"))
        {
            request.uploadHandler = new UploadHandlerRaw(bodyRow);
            request.downloadHandler = new DownloadHandlerBuffer();
            request.SetRequestHeader("Content-Type", "application/json");

            yield return request.SendWebRequest();

            if(request.result == UnityWebRequest.Result.Success)
            {
                string jsonResponse = request.downloadHandler.text;
                UserCreateResponse userResponse = JsonUtility.FromJson<UserCreateResponse>(jsonResponse);
                callback?.Invoke(userResponse);
            }
            else
            {
                Debug.Log(request.error);
            }
        }

    }
}

using System;
using UnityEngine;

[Serializable]
public class Users
{
    public string Name;
    public string Description;
    public string Login;
    public string Password;
}

[Serializable]
public class UserCreateResponse 
{
    public bool status;
}

using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Answer
{
    public Data data;
    public bool status;
}

[Serializable]
public class Data 
{
    public List<UserScins> userscins;
}

[Serializable]
public class  UserScins
{
    public int idScinUser;
    public int idUser;
    public UsersScins users;
    public int idScin;
    public ScinsUsers scins;
}

[Serializable]
public class UsersScins
{
    public int id_User;
    public string name;
    public string descrioption;
}

[Serializable]
public class ScinsUsers
{
    public int idScin;
    public string nameScin;
    public int price;
}

[Serializable]
public class CurrentUser
{
    public int userId;
}




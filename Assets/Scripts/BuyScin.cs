using System;
using UnityEngine;

[Serializable]
public class BuyScin 
{
    public int scinId;
    public int userId;
}

[Serializable]
public class BuyScinResponse
{
    public bool status;
}

[Serializable]
public class UpdateCoinsResponse
{
    public bool status;
}

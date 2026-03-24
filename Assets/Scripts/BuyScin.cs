using System;
using UnityEngine;

[Serializable]
public class BuyScin 
{
    public int scinId { get; set; }
    public int userId { get; set; }
}

[Serializable]
public class BuyScinResponse
{
    public bool status { get; set; }
}

[Serializable]
public class UpdateCoinsResponse
{
    public bool status { get; set; }
}

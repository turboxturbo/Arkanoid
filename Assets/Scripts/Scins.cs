using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class CurrentUser
{
    public int iduser;
}

[Serializable]
public class ScinsDataShort
{
    public string name;
}
[Serializable]
public class ScinsContainer 
{
    public List<ScinsDataShort> scins;
}


[Serializable]
public class ScinsResponse 
{
    public bool status;
    public ScinsContainer scins;
}


using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class AllScins
{
    public DataAllScins data;
    public bool status;
}

[Serializable]
public class DataAllScins
{
    public List<Scins> scins;
}

[Serializable]
public class Scins
{
    public int idScin;
    public string nameScin;
    public int price;
}

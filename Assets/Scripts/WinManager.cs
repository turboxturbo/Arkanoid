using UnityEngine;

public class WinManager : MonoBehaviour
{
    public static int breakablebars;
    public static bool win = false;
    public static void DestroyBar()
    {
        breakablebars--;
        if (breakablebars <= 0)
        {
            win = true;
        }
    }
}

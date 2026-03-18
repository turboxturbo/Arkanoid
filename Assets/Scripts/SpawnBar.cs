using UnityEngine;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class SpawnBar : MonoBehaviour
{
    public Transform[] spawnpoints;
    [SerializeField] private List<GameObject> bars;
    // Update is called once per frame
    void Start()
    {
        SpawnPoint();
        WinManager.breakablebars = GameObject.FindGameObjectsWithTag("Breakable").Length;
        Debug.Log("Всего баров" + WinManager.breakablebars);
    }

    void SpawnPoint() // 18 bars
    {
        for (int i = 0; i < spawnpoints.Length;  i++)
        {
            int random = Random.Range(0, bars.Count);
            Instantiate(bars[random], spawnpoints[i].position, Quaternion.identity);
        }
    }
}

using UnityEngine;

public class AutoSpawnPoints : MonoBehaviour
{
    [SerializeField] private SpawnBar spawnbar;
    [SerializeField] private int rows = 2;
    [SerializeField] private int quantityBarsPerRow = 9;
    [SerializeField] private float rowDistance = 0.5f;

    void Start()
    {
        spawnbar.spawnpoints = CreateSpawnPoints();
    }

    Transform[] CreateSpawnPoints()
    {
        Transform[] points = new Transform[rows * quantityBarsPerRow];  
        float spacing = -0.65f;         

        for (int i = 0; i < rows; i++)                   
        {
            for (int j = 0; j < quantityBarsPerRow; j++)
            {
                int index = i * quantityBarsPerRow + j;   
                GameObject point = new GameObject("SpawnPoint_" + index);
                point.transform.position = new Vector3(
                    j * spacing - (quantityBarsPerRow - 1) * spacing / 2,    
                    i * rowDistance + 3,
                    0
                );
                point.transform.parent = transform;
                points[index] = point.transform;
            }
        }
        return points;
    }
}

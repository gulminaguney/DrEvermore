using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FloorTilerFix : MonoBehaviour
{
    public GameObject floorPrefab;
    public int gridX = 10;
    public int gridZ = 10;
    public float tileSpacing = 1f;

    public void Generate()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 pos = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                GameObject obj = Instantiate(floorPrefab, pos, Quaternion.identity);
                obj.transform.SetParent(transform);
            }
        }
    }
}

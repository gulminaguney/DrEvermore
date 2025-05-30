using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class FloorTiler : MonoBehaviour
{
    public GameObject floorPrefab; 
    public int gridX = 10;
    public int gridZ = 10;
    public float tileSpacing = 1f;

    void Start()
    {
        for (int x = 0; x < gridX; x++)
        {
            for (int z = 0; z < gridZ; z++)
            {
                Vector3 position = new Vector3(x * tileSpacing, 0, z * tileSpacing);
                Instantiate(floorPrefab, position, Quaternion.identity, transform);
            }
        }
    }
}

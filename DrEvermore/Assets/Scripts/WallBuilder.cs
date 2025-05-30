using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class WallBuilder : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject doorPrefab;
    public float spacing = 4f;

    // Her oda 4x4 birimliktir
    public void BuildWalls()
    {
        int roomSize = 4;
        int corridorLength = 6;

        // Oda pozisyonları (2x2 yerleşim)
        Vector3[] roomOrigins = new Vector3[]
        {
            new Vector3(0, 0, 0),                  // Sol alt
            new Vector3(0, 0, (roomSize + 1) * spacing), // Sol üst
            new Vector3((roomSize + 1) * spacing, 0, 0), // Sağ alt
            new Vector3((roomSize + 1) * spacing, 0, (roomSize + 1) * spacing) // Sağ üst
        };

        foreach (Vector3 origin in roomOrigins)
        {
            BuildRoom(origin, roomSize);
        }

        // Ortada yatay koridor çiz
        for (int i = -1; i <= corridorLength; i++)
        {
            Vector3 posLeft = new Vector3(i * spacing, 0, roomSize * spacing);
            Instantiate(wallPrefab, posLeft, Quaternion.identity, transform);
        }
    }

    void BuildRoom(Vector3 origin, int size)
    {
        for (int i = 0; i < size; i++)
        {
            // Sol duvar
            Vector3 left = origin + new Vector3(0, 0, i * spacing);
            Instantiate(wallPrefab, left, Quaternion.identity, transform);

            // Sağ duvar
            Vector3 right = origin + new Vector3((size - 1) * spacing, 0, i * spacing);
            Instantiate(wallPrefab, right, Quaternion.identity, transform);

            // Alt duvar
            Vector3 bottom = origin + new Vector3(i * spacing, 0, 0);
            Instantiate(wallPrefab, bottom, Quaternion.Euler(0, 90, 0), transform);

            // Üst duvar (kapı için ortada açıklık)
            Vector3 top = origin + new Vector3(i * spacing, 0, (size - 1) * spacing);
            if (i == size / 2)
            {
                Instantiate(doorPrefab, top, Quaternion.Euler(0, 90, 0), transform);
            }
            else
            {
                Instantiate(wallPrefab, top, Quaternion.Euler(0, 90, 0), transform);
            }
        }
    }
}

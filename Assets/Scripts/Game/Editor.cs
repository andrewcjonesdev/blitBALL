using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Editor : MonoBehaviour
{
    void Start()
    {
        Debug.Log("test");
        MatManager.LoadMaterials();
        TileManager.LoadTiles();
        MapManager.Build();
    }

    void Update()
    {

    }


}

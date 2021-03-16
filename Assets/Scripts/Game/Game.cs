using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Start()
    {
        MatManager.LoadMaterials();
        TileManager.LoadTiles();
        MapManager.Build();
    }

    void Update()
    {

    }
}

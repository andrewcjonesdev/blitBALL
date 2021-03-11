using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Started");
        MatManager.LoadMaterials();
        TileManager.LoadTiles();
        //MapManager.SaveDefaultMap();
        //MapManager.CreateDefault();
        MapManager.Build();
    }

    void Update()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour
{

    public static Manager instance = null;

    public Material[] materials;
    public PrefabTile[] prefab_tiles;
    //public tprefab_entity[] prefab_entities;
    //public Map map;
    //public Player player;

    void Awake()
    {
        if (instance == null)
        {

            Debug.Log("manager");

            materials = new Material[5];
            prefab_tiles = new PrefabTile[30];
            //prefab_entities = new tprefab_entity[10];
            //map = new Map();
            //player = new Player();

            instance = this;

        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

}

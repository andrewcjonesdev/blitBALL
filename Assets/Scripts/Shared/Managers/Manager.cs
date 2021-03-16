using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public static Manager instance = null;
    public Material[] materials;
    public PrefabTile[] prefab_tiles;
    public Map map;

    void Awake()
    {
        if (instance == null)
        {
            Scene currentScene = SceneManager.GetActiveScene();
            string sceneName = currentScene.name;
            if (sceneName == "Game")
            {
                Debug.Log("Game Manager");
                materials = new Material[5];
                prefab_tiles = new PrefabTile[30];
                map = new Map();
            }
            if (sceneName == "Editor")
            {
                Debug.Log("Editor Manager");
                materials = new Material[5];
                prefab_tiles = new PrefabTile[30];
                map = new Map();
            }
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

}

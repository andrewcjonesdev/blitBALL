using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class MapManager
{

    public static void Build()
    {

        Map map = new Map();
        GameObject tile;
        int d;

        map.Init();
        //map.Clear();
        //map.CreateDefault();
        //map.Save("test");
        
        map.Load("test");

        for (int ty = 0; ty < map.height; ty++)
        {
            for (int tx = 0; tx < map.width; tx++)
            {
                for (int tz = 0; tz < map.length; tz++)
                {
                    for (int tl = 0; tl <= 1; tl++)
                    {
                        d = map.data.grid[tx, ty, tz, tl];
                        if (d != 255)
                        {

                            tile = GameObject.Instantiate(Manager.instance.prefab_tiles[d].obj) as GameObject;
                            tile.AddComponent<MeshCollider>();
                            //tile.GetComponent<Renderer>().material = Manager.instance.materials[0];
                            tile.transform.position = new Vector3
                            (
                                tz - 6.5f,
                                ty - 0.5f,
                                tx - 6.5f
                            );
                            tile.transform.eulerAngles = new Vector3
                            (
                                Manager.instance.prefab_tiles[d].u_rx,
                                Manager.instance.prefab_tiles[d].u_ry,
                                Manager.instance.prefab_tiles[d].u_rz
                            );
                            tile.transform.localScale = new Vector3
                            (
                                Manager.instance.prefab_tiles[d].u_s,
                                Manager.instance.prefab_tiles[d].u_s,
                                Manager.instance.prefab_tiles[d].u_s
                            );
                        }
                    }
                }
            }
        }
    }

}

[Serializable]
public class MapData
{

    public byte[,,,] grid = new byte[14, 7, 14, 2];

}

public class Map
{

    public int width;
    public int length;
    public int height;
    public MapData data = new MapData();
    public void Init()
    {
        width = data.grid.GetLength(0);
        height = data.grid.GetLength(1);
        length = data.grid.GetLength(2);
    }
    public void Clear()
    {
        for (int ty = 0; ty < height; ty++)
        {
            for (int tx = 0; tx < width; tx++)
            {
                for (int tz = 0; tz < length; tz++)
                {
                    for (int tl = 0; tl <= 1; tl++)
                    {
                        data.grid[tx, ty, tz, tl] = 255;
                    }
                }
            }
        }
    }
    public void CreateDefault()
    {
        data.grid[4, 0, 5, 0] = 0;
        data.grid[5, 0, 5, 0] = 0;
    }

    public void Load(string file)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + file + ".dat", FileMode.Open);
        data = bf.Deserialize(stream) as MapData;
        stream.Close();
    }

    public void Save(string file)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + file + ".dat", FileMode.Create);
        bf.Serialize(stream, data);
        stream.Close();
    }

}
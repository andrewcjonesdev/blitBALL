using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public static class MapManager
{

    public static int width = 14;
    public static int length = 14;
    public static int height = 7;


    /*public static void SaveDefaultMap()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/Maps/Default.dat", FileMode.Create);

        TestData data = new TestData();
        data.CreateDefault();

        bf.Serialize(stream, data);
        stream.Close();
    }*/

    public static void Build()
    {

        MapData map_data = new MapData();
        map_data.CreateDefault();
        //map_data.Save("test");
        map_data.Load("test");

        GameObject tile;
        int d;

        for (int ty = 0; ty < map_data.height; ty++)
        {
            for (int tx = 0; tx < map_data.width; tx++)
            {
                for (int tz = 0; tz < map_data.length; tz++)
                {
                    for (int tl = 0; tl <= 1; tl++)
                    {
                        d = map_data.grid[tx, ty, tz, tl];
                        //Debug.Log(d);
                        if (d != 255)
                        {

                            tile = GameObject.Instantiate(Manager.instance.prefab_tiles[d].obj) as GameObject;
                            tile.AddComponent<MeshCollider>();
                            //tile.GetComponent<Renderer>().material = Manager.instance.materials[0];
                            tile.transform.position = new Vector3
                            (
                                tz-6.5f,
                                ty-0.5f,
                                tx-6.5f
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

//[Serializable]
public class MapData
{

    public int width;
    public int length;
    public int height;
    public byte[,,,] grid = new byte[14, 7, 14, 2];

    public void CreateDefault()
    {
        width = grid.GetLength(0);
        height = grid.GetLength(1);
        length = grid.GetLength(2);
        for (int ty = 0; ty < height; ty++)
        {
            for (int tx = 0; tx < width; tx++)
            {
                for (int tz = 0; tz < length; tz++)
                {
                    for (int tl = 0; tl <= 1; tl++)
                    {
                        grid[tx, ty, tz, tl] = 255;
                    }
                }
            }
            grid[4, 0, 5, 0] = 0;
            grid[5, 0, 5, 0] = 0;
        }
    }

    public void Load(string file)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + file + ".dat", FileMode.Open);
        //bf.Deserialise(stream, grid);
        grid = bf.Deserialise(stream);
        //Debug.Log(stream);
        stream.Close();
    }

    public void Save(string file)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.dataPath + "/Maps/" + file + ".dat", FileMode.Create);
        bf.Serialize(stream, grid);
        stream.Close();
    }

}
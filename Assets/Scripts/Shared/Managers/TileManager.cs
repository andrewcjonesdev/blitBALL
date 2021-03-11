using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TileManager
{
    public static void LoadTiles()
    {

        PrefabTile tile = new PrefabTile();
        TextAsset txt = Resources.Load("Meta/Tiles") as TextAsset;
        string[] lines = txt.text.Split("\n"[0]);
        string s;
        int n = 0;
        int t = 0;

        for (int l = 0; l < lines.Length; l++)
        {

            s = lines[l];

            /* Name */
            if (n == 0)
            {
                tile = new PrefabTile();
                tile.name = s;
            }

            /* Mesh */
            if (n == 1)
            {
                tile.obj = Resources.Load("Models/Tiles/" + s.Substring(0, s.Length - 5)) as GameObject;
            }

            /* Attribute */
            if (n == 2)
            {
                tile.att = int.Parse(s);
            }

            /* Material */
            if (n == 3)
            {
                tile.mat = int.Parse(s);
            }

            /* Delphi RX */
            if (n == 4)
            {
                tile.d_rx = float.Parse(s);
            }

            /* Delphi RY */
            if (n == 5)
            {
                tile.d_ry = float.Parse(s);
            }

            /* Delphi RZ */
            if (n == 6)
            {
                tile.d_rz = float.Parse(s);
            }

            /* Unity RX */
            if (n == 7)
            {
                tile.u_rx = float.Parse(s);
            }

            /* Unity RY */
            if (n == 8)
            {
                tile.u_ry = float.Parse(s);
            }

            /* Unity RZ */
            if (n == 9)
            {
                tile.u_rz = float.Parse(s);
            }

            /* Delphi Scale */
            if (n == 10)
            {
                tile.d_s = float.Parse(s);
            }

            /* Unity Scale */
            if (n == 11)
            {
                tile.u_s = float.Parse(s);
            }

            /* Increment */
            n++;
            if (n == 12)
            {
                n = 0;
                Manager.instance.prefab_tiles[t] = tile;
                //Debug.Log(Manager.instance.prefab_tiles[t]);
                t++;
            }

        }

    }

}

/*
	public static void load_tiles()
	{

		tprefab_tile tile = new tprefab_tile();
    	TextAsset txt = Resources.Load("data/tiles") as TextAsset;
		string[] lines = txt.text.Split("\n"[0]);
		string s;
		int n = 0;
		int t = 0;

		for (int l=0;l<lines.Length;l++)
		{

			s = lines[l];

			//Name//
			if (n == 0) {
				tile = new tprefab_tile();
				tile.name = s;
			}

			//Mesh//
			if (n == 1) {
				tile.obj = Resources.Load("tiles/" + s.Substring(0,s.Length-5)) as GameObject;
			}

			//Attribute//
			if (n == 2) {
				tile.att = int.Parse(s);
			}

			//Material//
			if (n == 3) {
				tile.mat = int.Parse(s);
			}

			//Delphi RX//
			if (n == 4) {
				tile.d_rx = float.Parse(s);
			}

			//Delphi RY//
			if (n == 5) {
				tile.d_ry = float.Parse(s);
			}

			//Delphi RZ//
			if (n == 6) {
				tile.d_rz = float.Parse(s);
			}

			//Unity RX//
			if (n == 7) {
				tile.u_rx = float.Parse(s);
			}

			//Unity RY//
			if (n == 8) {
				tile.u_ry = float.Parse(s);
			}

			//Unity RZ//
			if (n == 9) {
				tile.u_rz = float.Parse(s);
			}

			//Delphi Scale//
			if (n == 10) {
				tile.d_s = float.Parse(s);
			}

			//Unity Scale//
			if (n == 11) {
				tile.u_s = float.Parse(s);
			}

			//Increment//
			n++;
			if (n == 12) {
				n = 0;
				Manager.instance.prefab_tiles[t] = tile;
				t++;
			}


		}

	}
*/
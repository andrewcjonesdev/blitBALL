using System.Globalization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatManager
{
    public static void LoadMaterials()
    {

        TextAsset txt = (TextAsset)Resources.Load("Meta/Materials");
        string[] lines = txt.text.Split("\n"[0]);
        Shader shader = Resources.Load("Shaders/unlit", typeof(Shader)) as Shader;
        string s;
        string name = "";
        Material material;
        Texture texture;
        int n = 0;
        int m = 0;

        for (int l = 0; l < lines.Length; l++)
        {

            s = lines[l];

            /* Name */
            if (n == 1)
            {
                name = s.Substring(0, s.Length - 1);
            }

            /* Material */
            if (n == 2)
            {
                material = new Material(shader);
                texture = Resources.Load("Meta/Textures/" + name, typeof(Texture)) as Texture;
                material.mainTexture = texture;
                Manager.instance.materials[m] = material;
                m++;
            }

            /* Increment */
            n++;
            if (n == 3)
            {
                n = 0;
            }
        }
    }
}

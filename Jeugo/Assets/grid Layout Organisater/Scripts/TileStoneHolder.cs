using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class TileStyle
{
    public Texture Newtexture;
}


public class TileStoneHolder : MonoBehaviour
{

    public static TileStoneHolder Instance;

    public TileStyle[] TileStyles;

    void Awake()
    {
        Instance = this;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stone
{

    public int indRow;
    public int indCol;
    public int StoneNumber;
    public List<Tile> lstLiberty;

    public Stone()
    {
        lstLiberty = new List<Tile>();
    }


}
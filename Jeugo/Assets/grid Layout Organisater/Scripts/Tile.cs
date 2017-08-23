using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour {
    public int indRow;
    public int indCol;
    private int number;
    private Canvas TileCanvas;
    private RawImage Piecetexture;

    private void Awake()
    {
        Piecetexture = GetComponentInChildren<RawImage>();
        TileCanvas = GetComponentInChildren<Canvas>();
    }

    private void ApplyStyleFromHolder(int index)
    {
        Piecetexture.texture = TileStoneHolder.Instance.TileStyles[index].Newtexture;
    }

    private void SetVisible()
    {
        TileCanvas.enabled = false;
        Piecetexture.enabled = false;
    }

    private void SetEmpty()
    {
        TileCanvas.enabled = false;
        Piecetexture.enabled = false;
    }
    public int PieceTextureNumber
    {
       
        get
        {
            return number;
        }
        set
        {
            number = value;
            if(number==0)
            {
                SetEmpty();
            }
            else
            {
                ApplyStyleFromHolder(number);
                SetVisible();
            }
        }
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

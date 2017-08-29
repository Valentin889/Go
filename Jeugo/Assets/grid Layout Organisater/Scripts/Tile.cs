using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Tile : MonoBehaviour, IPointerDownHandler {

    public int indRow;
    public int indCol;
    private int number;
    private Canvas TileCanvas;
    private RawImage Piecetexture;
    public Stone StoneInTile;

    private void Awake()
    {
        Piecetexture = GetComponentInChildren<RawImage>();
        TileCanvas = GetComponentInChildren<Canvas>();
        StoneInTile = GetComponentInChildren<Stone>();
    }

    private void ApplyStyleFromHolder(int index)
    {
        Piecetexture.texture = TileStoneHolder.Instance.TileStyles[index].Newtexture;
    }

    public void SetVisible()
    {
        TileCanvas.enabled = true;
        Piecetexture.enabled = true;
    }

    public void SetEmpty()
    {
        TileCanvas.enabled = false;
        Piecetexture.enabled = false;
    }
    public void SetStoneCoordinates()
    {
        StoneInTile.indRow = indRow;
        StoneInTile.indCol = indCol;
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
        SetStoneCoordinates();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData evenData)
    {
        
        GameManager[] theCanvases = GameObject.FindObjectsOfType<GameManager>();
        GameManager TheCanvas = theCanvases[0];


        if (this.PieceTextureNumber == 0)
        {
            this.PieceTextureNumber=TheCanvas.CheckTile();

        }
        
        
    }



}

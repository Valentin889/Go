using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public GameStage State;
    private bool moveMade;

    private Tile[,] AllTile = new Tile[8, 8];
    private List<Tile[]> columns = new List<Tile[]>();
    private List<Tile[]> rows = new List<Tile[]>();
    private List<Tile> EmptySquares = new List<Tile>();

	// Use this for initialization
	void Start ()
    {
        Tile[] AllTileOneDim = GameObject.FindObjectOfType<Tile>();
        object[] test = GameObject.FindObjectOfType(typeof(Tile));
        GameObject[] obj= SceneManager.GetActiveScene().GetRootGameObjects();
        foreach(object t in obj)
        {

        }

        foreach (Tile t in AllTileOneDim)
        {
            t.PieceTextureNumber = 0;
            AllTile[t.indRow, t.indCol] = t;
            EmptySquares.Add(t);
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}

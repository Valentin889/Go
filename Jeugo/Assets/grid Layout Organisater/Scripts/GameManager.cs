using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public Tile[,] AllTile = new Tile[9, 9];


	// Use this for initialization
	void Start ()
    {
        Tile[] AllTileOneDim = GameObject.FindObjectsOfType<Tile>();

        foreach (Tile t in AllTileOneDim)
        {
            t.PieceTextureNumber = 0;
            AllTile[t.indRow, t.indCol] = t;
        }
	}
	
    public void GameBtnHandler()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }

	// Update is called once per frame
	void Update () {
		
	}
}

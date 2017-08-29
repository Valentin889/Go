using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public Tile[,] AllTile = new Tile[9, 9];
    private bool bPlayer1;

	// Use this for initialization
	void Start ()
    {
        Tile[] AllTileOneDim = GameObject.FindObjectsOfType<Tile>();
        bPlayer1 = true;

        foreach (Tile t in AllTileOneDim)
        {
            t.PieceTextureNumber = 0;
            AllTile[t.indRow, t.indCol] = t;
        }
	}
	
    public void GameBtnStart()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().buildIndex);
    }
    public void GameBtnPass()
    {
        bPlayer1 = !bPlayer1;
    }
        


    public int CheckTile()
    {
        int iReturn = 0;
        if (bPlayer1)
        {
            iReturn = 1;
        }
        else
        {
            iReturn = 2;
        }
        bPlayer1 = !bPlayer1;
        return iReturn;
    }

	// Update is called once per frame
	void Update () {
		
	}
}

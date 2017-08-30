using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    
    public Tile[][] AllTile = new Tile[9][];
    private bool bPlayer1;

    void Awake()
    {
        Tile[] AllTileOneDim = GameObject.FindObjectsOfType<Tile>();
        bPlayer1 = true;
       
        for (int i = 0; i < AllTile.Length; i++)
        {
            AllTile[i] = new Tile[9];
        }



        foreach (Tile t in AllTileOneDim)
        {
            AllTile[t.indRow][t.indCol] = t;
            Debug.Log(AllTile[t.indRow][t.indCol]);
            t.PieceTextureNumber = 0;

        }
      
        
    }

    // Use this for initialization
    void Start ()
    {
        
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

	public void SetStoneLiberty(Stone ActiveStone)
	{
        int iCol = ActiveStone.indCol;
        int iRow = ActiveStone.indRow;

        Debug.Log(iCol);
        Debug.Log(iRow);


        Tile TileTest = AllTile[iCol][iRow - 1];
        Debug.Log(TileTest.PieceTextureNumber);
        TestLiberty(TileTest, ActiveStone);
        
        TileTest = AllTile[iCol][iRow + 1];
        Debug.Log(TileTest.PieceTextureNumber);
        TestLiberty(TileTest, ActiveStone);

        TileTest = AllTile[iCol-1][iRow];
        Debug.Log(TileTest.PieceTextureNumber);
        TestLiberty(TileTest, ActiveStone);

        TileTest = AllTile[iCol+1][iRow];
        Debug.Log(TileTest.PieceTextureNumber);
        TestLiberty(TileTest, ActiveStone);
    }
    private void TestLiberty(Tile tile, Stone stone)
    {
        Debug.Log(stone.indRow);
        if (tile.PieceTextureNumber == 0)
        {
           stone.lstLiberty.Add((tile));
        }
    }


	// Update is called once per frame
	void Update () {
		
	}
}

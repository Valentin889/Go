using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Stone : MonoBehaviour, IPointerDownHandler
{

    public int indRow;
    public int indCol;
    public int StoneNumber;

    public void SelectStone()
    {
        GameManager[] theCanvases = GameManager.FindObjectsOfType<GameManager>();
        GameManager TheCanvas = theCanvases[0];

        
    }


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void OnPointerDown(PointerEventData evenData)
    {
        SelectStone();
    }
}

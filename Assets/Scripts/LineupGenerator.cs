using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineupGenerator : MonoBehaviour {

    public int TotalLineups = 2;//TODO for now

    //Rule Fields

    // Use this for initialization
    void Start () {
		
	}

    public void Activate()
    {
        for (int i = 0; i < TotalLineups; i++)
        {
            Vector2 newLocation = new Vector2(0, 0);
            createLineupAtLocation(newLocation);
        }
    }

    private void createLineupAtLocation(Vector2 location)
    {
        //TODO
    }
}

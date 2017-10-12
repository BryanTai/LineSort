using System.Collections.Generic;
using UnityEngine;

public class LineupGenerator : MonoBehaviour {

    public GameObject lineupPrefab;
    public GameController gameController;
    private const float Y_POS = 2.5f;

    //Rule Fields

    // Use this for initialization
    void Start () {
        
	}

    public void Activate(List<Rule> initialRules)
    {
        int totalLineups = initialRules.Count;
        //TODO just loading 2 lineups for now
        for (int i = 0; i < totalLineups; i++)
        {
            float xPos = -2f + i * 4; //TODO need to tweak this logic with more lineups
            createLineupAtLocation(xPos, Y_POS, initialRules[i]);
        }
    }

    private void createLineupAtLocation(float x, float y, Rule rule)
    {
        Vector3 newPosition = new Vector3(x, y);
        GameObject newLineupObject = Instantiate(lineupPrefab, newPosition, Quaternion.identity);
        Lineup newLineup = newLineupObject.GetComponent<Lineup>();
        newLineup.SetRule(rule);
        gameController.AddLineupToLineups(newLineup);
    }
}

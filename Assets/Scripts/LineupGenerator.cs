using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineupGenerator : MonoBehaviour {

    public GameObject lineupPrefab;
    public GameController gameController;
    private const float Y_POS = 2.5f;
    private RuleGenerator ruleGenerator;

    //Rule Fields

    // Use this for initialization
    void Start () {
        ruleGenerator = new RuleGenerator();
	}

    public void Activate(int totalLineups)
    {
        //TODO just loading 2 lineups for now
        for (int i = 0; i < totalLineups; i++)
        {
            float xPos = -2f + i * 4; //TODO need to tweak this logic with more lineups
            createLineupAtLocation(xPos, Y_POS);
        }
    }

    private void createLineupAtLocation(float x, float y)
    {
        Vector3 newPosition = new Vector3(x, y);
        GameObject newLineupObject = Instantiate(lineupPrefab, newPosition, Quaternion.identity);
        Lineup newLineup = newLineupObject.GetComponent<Lineup>();
        newLineup.SetRule(ruleGenerator.GenerateNewRule());
    }
}

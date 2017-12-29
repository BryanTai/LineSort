using System.Collections.Generic;
using UnityEngine;

public class LineupGenerator : MonoBehaviour {

    public GameObject lineupPrefab;
    public GameController gameController;
    private const float Y_POS = 2.5f;

    private Sprite[] sprites;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
    }

    public void Activate(List<Rule> initialRules)
    {
        int totalLineups = initialRules.Count;
        for (int i = 0; i < totalLineups; i++)
        {
            float xPos = -2f + i * 2; //TODO need to tweak this logic with more lineups
            createLineupAtLocation(xPos, Y_POS, initialRules[i]);
        }
    }

    private void createLineupAtLocation(float x, float y, Rule rule)
    {
        Vector3 newPosition = new Vector3(x, y);
        GameObject newLineupObject = Instantiate(lineupPrefab, newPosition, Quaternion.identity);
        Lineup newLineup = newLineupObject.GetComponent<Lineup>();
        newLineup.SetRule(rule);
        newLineup.SetSprites(sprites);
        gameController.AddLineupToLineups(newLineup);
    }
}

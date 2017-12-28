using System.Collections.Generic;
using UnityEngine;

public class LineupGenerator : MonoBehaviour {

    public GameObject lineupPrefab;
    public GameController gameController;
    private const float Y_POS = 2.5f;

    private Sprite[] sprites; //TODO Load Lineup sprites HERE to reduce Resource calls

    private const string CORRECT_PATH = "correctNotifications";
    private const int CORRECT_LENGTH = 10;
    private string[] correctNotifications;

    
    void Awake()
    {
        loadAllCorrectNotifications();
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
        newLineup.SetCorrectNotifications(correctNotifications, CORRECT_LENGTH);
        gameController.AddLineupToLineups(newLineup);
    }

    private void loadAllCorrectNotifications()
    {
        //correctNotifications = new string[CORRECT_LENGTH];
        TextAsset correctAsset = Resources.Load<TextAsset>(CORRECT_PATH);
        string[] linesFromFile = correctAsset.text.Split("\n"[0]);
        correctNotifications = linesFromFile;
    }

}

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public PersonGenerator PersonGenerator;
    public LineupGenerator LineupGenerator;
    private RuleGenerator ruleGenerator;
    public Scoreboard Scoreboard;

    Selectable currentlySelected;
    public List<Lineup> Lineups;
    public List<Person> WaitingPersons;

    private int maxPersonsForLevel; 
    private int totalWaitingPersons = 0;
    const int INITIAL_PERSONS = 5; //Set this really big to test spacing

    //Timer Fields
    private float createPersonRate;
    private float changeRuleRate = 10; //TODO tweak this
    private float changeRuleWarningTime = 3;

    private bool gameIsRunning = true;

    //Notification Fields
    private const string CORRECT_PATH = "correctNotifications";
    private const int CORRECT_LENGTH = 10;
    private string[] correctNotifications;

    System.Random rnd;

    private void Awake()
    {
        rnd = new System.Random();
        Lineups = new List<Lineup>();
        WaitingPersons = new List<Person>();

        readGlobalData();
        loadAllCorrectNotifications();

        GlobalData.PlayerScore = 0;
    }

    private void readGlobalData()
    {
        createPersonRate = GlobalData.CreatePersonRate;
        maxPersonsForLevel = GlobalData.MaxPersons;
    }
    private void loadAllCorrectNotifications()
    {
        TextAsset correctAsset = Resources.Load<TextAsset>(CORRECT_PATH);
        string[] linesFromFile = correctAsset.text.Split("\n"[0]);
        correctNotifications = linesFromFile;
    }

    // Use this for initialization
    void Start () {
        Debug.Log(gameObject.tag);
        
        PersonGenerator.Activate(maxPersonsForLevel);

        for (int i = 0; i < INITIAL_PERSONS; i++)
        {
            createNewPerson();
        }

        int totalLineups = 3;

        ruleGenerator = new RuleGenerator();
        List<Rule> initialRules = new List<Rule>(); //TODO could probablyjust use arrays
        for (int i = 0; i < totalLineups; i++)
        {
            initialRules.Add(ruleGenerator.GenerateNewRule());
        }
        
        LineupGenerator.Activate(initialRules);

        Scoreboard.UpdateScore(0);

        StartCoroutine(UpdateLineupRulesAtIntervals(changeRuleRate, changeRuleWarningTime));
        StartCoroutine(CreateNewPersonAtIntervals(createPersonRate));
    }

    //TODO might need a lock on this list?
    private void addPersonToWaitingList(Person newPerson)
    {
        WaitingPersons.Add(newPerson);
        totalWaitingPersons++;
    }

    IEnumerator CreateNewPersonAtIntervals(float createPersonDelay)
    {
        while (gameIsRunning)
        {
            yield return new WaitForSeconds(createPersonDelay);
            createNewPerson();
        }
    }

    private void createNewPerson()
    {
        if(totalWaitingPersons < maxPersonsForLevel)
        {
            Person newPerson = PersonGenerator.CreatePersonAtRandomLocation();
            addPersonToWaitingList(newPerson);
        }
        else
        {
            handleTooManyPeople();
        }
    }

    //TODO punishment?
    private void handleTooManyPeople()
    {
        Debug.Log("TOO MANY PEOPLE! CANNOT GENERATE A NEW PERSON!");
    }

    public void AddLineupToLineups(Lineup lineup)
    {
        Lineups.Add(lineup);
    }

    //Selecting logic
    /**
     * If newSelected is a Person and...
     * - currentlySelected is a Person...
     * -- new Person becomes Selected, old Person becomes Deselected
     * - currentlySelected is a Line...
     * -- new Person becomes Selected, Line becomes Deselected
     * Else if newSelected is a Line and...
     * - currentlySelected is a Person...
     * -- Assign Person to the Line
     * - currentlySelected is a Line...
     * -- new Line becomes Selected, old Line becomes Deselected
     * 
     * TODO i have a feeling this is going to scale really bad when I add more stuff
    **/
    public void UpdateCurrentlySelected(Selectable newSelected)
    {
        if (currentlySelected == null)
        {
            currentlySelected = newSelected;
            return;
        }
        if (currentlySelected == newSelected)
        {
            return;
        }

        if (newSelected.GetType() == typeof(Lineup) && currentlySelected.GetType() == typeof(Person))
        {
            Lineup selectedLineup = newSelected as Lineup;
            Person selectedPerson = currentlySelected as Person;

            removePersonFromWaitingList(selectedPerson);
            bool addedToLineup = selectedLineup.AssignPerson(selectedPerson);

            if (addedToLineup){
                if (Rule.NameMatchesRule(selectedPerson.name, selectedLineup.Rule))
                {
                    Debug.Log("Rule MATCHED!");
                    Scoreboard.IncreaseScore(1);
                    selectedLineup.FlashNotification(getRandomCorrectNotification(), Color.green);
                    //TODO different Persons will have different score values
                }
                else
                {
                    Debug.Log("Rule INCORRECT!");
                    selectedLineup.FlashNotification("WRONG!", Color.red);
                    //TODO implement some sort of penalty
                }
            }
        }

        currentlySelected.BecomeDeselected();
        currentlySelected = newSelected;
    }

    private void removePersonFromWaitingList(Person personToRemove)
    {
        PersonGenerator.FreeUpPosition(personToRemove.LocationIndex);
        totalWaitingPersons--;
        WaitingPersons.Remove(personToRemove);
    }

    IEnumerator UpdateLineupRulesAtIntervals(float changeRuleRate, float changeRuleWarningTime)
    {
        while (gameIsRunning)
        {
            yield return new WaitForSeconds(changeRuleRate - changeRuleWarningTime);
            yield return StartCoroutine(FlashRulesText(changeRuleWarningTime));

            updateLineupRules();
        }
    }

    IEnumerator FlashRulesText(float flashTimeSeconds)
    {
        for(int i = 0; i < flashTimeSeconds; i++)
        {
            foreach (Lineup lineup in Lineups)
            {
                lineup.SetRuleColor(Color.red);
            }
            yield return new WaitForSeconds(0.5f);
            foreach (Lineup lineup in Lineups)
            {
                lineup.SetRuleColor(Color.white);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    private void updateLineupRules()
    {
        foreach (Lineup lineup in Lineups)
        {
            lineup.SetRule(ruleGenerator.GenerateNewRule());
        }
    }

    private string getRandomCorrectNotification()
    {
        return correctNotifications[rnd.Next(CORRECT_LENGTH)];
    }

}

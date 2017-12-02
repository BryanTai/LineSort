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

    private int maxPersonsForLevel = 25; //TODO this seems to be a good MAX for hardest levels
    private int totalWaitingPersons = 0;
    const int INITIAL_PERSONS = 5; //Set this really big to test spacing

    //Timer Fields
    private float createPersonTime = 2;
    private float changeRuleTime = 20; //TODO tweak this

    private void Awake()
    {
        Lineups = new List<Lineup>();
        WaitingPersons = new List<Person>();

        GlobalData.PlayerScore = 0;
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
        InvokeRepeating("updateLineupRules", changeRuleTime, changeRuleTime);
        InvokeRepeating("createNewPerson", createPersonTime, createPersonTime);
    }

    //TODO might need a lock on this list?
    private void addPersonToWaitingList(Person newPerson)
    {
        WaitingPersons.Add(newPerson);
        totalWaitingPersons++;
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

    //TODO
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
            bool assignedCorrectly = selectedLineup.AssignPerson(selectedPerson);

            if (assignedCorrectly){
                if (Rule.NameMatchesRule(selectedPerson.name, selectedLineup.Rule))
                {
                    //Correct, add points
                    Debug.Log("Rule MATCHED!");
                    Scoreboard.IncreaseScore(1); 
                    //TODO different Persons will have different score values
                }
                else
                {
                    //Incorrect, no points
                    Debug.Log("Rule INCORRECT!");
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

    private void updateLineupRules()
    {
        foreach (Lineup lineup in Lineups)
        {
            lineup.SetRule(ruleGenerator.GenerateNewRule());
        }
    }
}

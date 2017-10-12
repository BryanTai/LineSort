using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public PersonGenerator PersonGenerator;
    public LineupGenerator LineupGenerator;
    private RuleGenerator ruleGenerator;
    public Scoreboard Scoreboard;

    Selectable currentlySelected;
    public List<Person> PersonWaitList;
    public List<Lineup> Lineups;

    private float changeRuleTime = 20; //TODO tweak this

    // Use this for initialization
    void Start () {
        Debug.Log(gameObject.tag);
        PersonWaitList = new List<Person>();
        Lineups = new List<Lineup>();
        PersonGenerator.Activate();

        int totalLineups = 2;

        ruleGenerator = new RuleGenerator();
        List<Rule> initialRules = new List<Rule>(); //TODO could probablyjust use arrays
        for (int i = 0; i < totalLineups; i++)
        {
            initialRules.Add(ruleGenerator.GenerateNewRule());
        }
        
        LineupGenerator.Activate(initialRules);

        Scoreboard.UpdateScore(0);
        InvokeRepeating("updateLineupRules", changeRuleTime, changeRuleTime);
	}

    public void AddPersonToWaitList(Person newPerson)
    {
        //TODO Might need a lock on this later
        PersonWaitList.Add(newPerson);
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
            bool personGotAssigned = selectedLineup.AssignPerson(selectedPerson);
            if (personGotAssigned){
                if (Rule.DoesNameMatchRule(selectedPerson.name, selectedLineup.Rule))
                {
                    //Correct, add points
                    Debug.Log("Rule MATCHED!");
                    Scoreboard.IncreaseScore(1); //TODO different Persons will have different score values
                }
                else
                {
                    //Incorrect, no points
                    Debug.Log("Rule INCORRECT!");
                }
            }
        }

        currentlySelected.BecomeDeselected();
        currentlySelected = newSelected;
    }

    private void updateLineupRules()
    {
        foreach (Lineup lineup in Lineups)
        {
            lineup.SetRule(ruleGenerator.GenerateNewRule());
        }
    }
}

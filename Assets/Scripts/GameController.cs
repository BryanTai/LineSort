using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    Selectable currentlySelected;
    

    public List<Person> PersonWaitList;
    public List<Lineup> Lineups;
    public PersonGenerator personGenerator;
    public LineupGenerator lineupGenerator;
    private RuleGenerator ruleGenerator;

    private float changeRuleTime = 20; //TODO tweak this

    // Use this for initialization
    void Start () {
        Debug.Log(gameObject.tag);
        PersonWaitList = new List<Person>();
        Lineups = new List<Lineup>();
        personGenerator.Activate();

        int totalLineups = 2;

        ruleGenerator = new RuleGenerator();
        List<Rule> initialRules = new List<Rule>(); //TODO could probablyjust use arrays
        for (int i = 0; i < totalLineups; i++)
        {
            initialRules.Add(ruleGenerator.GenerateNewRule());
        }
        
        lineupGenerator.Activate(initialRules);
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

        /*
        System.Type newSelType = newSelected.GetType();
        System.Type currSelType = currentlySelected.GetType();

        if (newSelType == typeof(Person))
        {
            currentlySelected.BecomeDeselected();
        }
        else if(newSelType == typeof(Lineup))
        {
            if (currSelType == typeof(Person))
            {
                currentlySelected.BecomeDeselected();
                assignPersonToLineup(currentlySelected as Person, newSelected as Lineup);
            }
            else if (currSelType == typeof(Lineup))
            {
                currentlySelected.BecomeDeselected();
            }
        }*/
        if (newSelected.GetType() == typeof(Lineup) && currentlySelected.GetType() == typeof(Person))
        {
            //assignPersonToLineup(currentlySelected as Person, newSelected as Lineup);

            Lineup selectedLineup = newSelected as Lineup;
            selectedLineup.AssignPerson(currentlySelected as Person);
        }

        currentlySelected.BecomeDeselected();
        currentlySelected = newSelected;
    }

    //TODO might not need this anymore
    private void assignPersonToLineup(Person person, Lineup lineup)
    {
        string name = person.Name;
        string rule = lineup.Rule.ToString();
        Debug.Log("Assigning " + name + " to " + rule);

        Vector2 lastSpotInLine = new Vector2(lineup.GetXPosition(), lineup.GetLastSpot());

        person.TeleportToPoint(lastSpotInLine);
    }

    private void updateLineupRules()
    {
        foreach (Lineup lineup in Lineups)
        {
            lineup.SetRule(ruleGenerator.GenerateNewRule());
        }
    }
}

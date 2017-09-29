using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    public string Rule { get; set; }
    public int MaxPersons { get; set; }
    private Queue<Person> queuedPersons;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
        queuedPersons = new Queue<Person>();

        //TODO for testing
        Rule = "PLACEHOLDER_RULE";
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Line: " + Rule);
        becomeSelected();
    }

    public float GetXPosition()
    {
        return transform.position.x;
    }

    //This depends on how many Persons are lined up already
    public float GetLastSpot()
    {
        return transform.position.y; //TODO for now
    }
}

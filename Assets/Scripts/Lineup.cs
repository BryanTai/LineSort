using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    public int MaxPersons { get; set; }
    private Queue<Person> queuedPersons;

    public const float PERSON_Y_OFFSET = 1.15f;

    private TextMesh textMesh;

    public Rule Rule { get; private set; }


    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
        queuedPersons = new Queue<Person>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();

        //TODO for testing
        textMesh.text = "PLACEHOLDER_RULE";
        MaxPersons = 3;
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Line: " + Rule.ToString());
        becomeSelected();
    }

    public void SetRule(Rule rule)
    {
        this.Rule = rule;
        textMesh.text = rule.ToString();
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

    public void AssignPerson(Person person)
    {
        if(queuedPersons.Count >= MaxPersons)
        {
            //Say that the LINE IS FULL!
            Debug.Log("LINE IS FULL!!!");
        }
        else
        {
            Vector2 lastSpotInLine = calculateLastSpot();
            person.TeleportToPoint(lastSpotInLine);
            queuedPersons.Enqueue(person);

            if (doesNameMatchRule(person.Name))
            {
                Debug.Log("Rule MATCHED!");
                //Correct, add points
            }
            else
            {
                //Incorrect, no points
                Debug.Log("Rule INCORRECT!");
            }
        }
    }

    private Vector2 calculateLastSpot()
    {
        //TODO this works for ODD values of MaxPersons
        Vector2 toReturn = new Vector2();
        toReturn.x = transform.position.x;
        int listOffset = ((int)(MaxPersons / 2)) - queuedPersons.Count;
        float yOffset = listOffset * PERSON_Y_OFFSET;
        toReturn.y = transform.position.y + yOffset;
        return toReturn;
    }

    private bool doesNameMatchRule(string name) {
        return Rule.DoesNameMatchRule(name, Rule);
    }

}

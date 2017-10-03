using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    public string RuleText { get; set; } //TODO just a placeholder
    public int MaxPersons { get; set; }
    private Queue<Person> queuedPersons;

    public const float PERSON_Y_OFFSET = 1.15f;

    private TextMesh textMesh;

    public Rule LineRule { get; set; }

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
        queuedPersons = new Queue<Person>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();

        //TODO for testing
        RuleText = "PLACEHOLDER_RULE";
        textMesh.text = RuleText;
        MaxPersons = 3;
    }

    void Update()
    {

    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Line: " + RuleText);
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

    public void AssignPerson(Person person)
    {
        if(queuedPersons.Count >= MaxPersons)
        {
            //Say that the LINE IS FULL!
        }else
        {
            Vector2 lastSpotInLine = calculateLastSpot();
            person.TeleportToPoint(lastSpotInLine);
            queuedPersons.Enqueue(person);

            if (DoesNameMatchRule(person.Name))
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
        Vector2 toReturn = new Vector2();
        toReturn.x = transform.position.x;
        toReturn.y = transform.position.y; //TODO placeholder

        return toReturn;
    }


    //Rule Checking Logic
    public bool DoesNameMatchRule(string name) {
        return Rule.DoesNameMatchRule(name, LineRule);
    }

}

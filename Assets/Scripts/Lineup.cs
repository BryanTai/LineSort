using System;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    public int MaxPersons { get; set; }
    private Queue<Person> queuedPersons;

    private const float PERSON_Y_OFFSET = 1f;
    private float timeToProcessPerson = 3; //TODO tweak this

    private TextMesh textMesh;

    public Rule Rule { get; private set; }

    private bool processingPerson = false;
    private float startTime = 0;


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
    //Lineup Logic
    /**If the queue is empty, nothing to process
     * Else, queue has persons and...
     * - if not already processing the person, start processing and start the timer.
     * - else...
     * -- if timeToProcess has been reached, dequeue the person and stop processing.
     * -- else, let the timer keep going
     * 
    **/ 

    void Update()
    {
        if(queuedPersons.Count > 0)
        {
            if (!processingPerson)
            {
                processingPerson = true;
                startTime = Time.time;
            }
            else
            {
                if (Time.time - startTime > timeToProcessPerson)
                {
                    Person processedPerson = queuedPersons.Dequeue();
                    Destroy(processedPerson.gameObject);
                    foreach (Person p in queuedPersons)
                    {
                        p.TeleportToPoint(new Vector2(p.transform.position.x, p.transform.position.y + PERSON_Y_OFFSET));
                    }
                    processingPerson = false;
                }
            }
        }
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Line: " + Rule.ToString());
        becomeSelected();
    }

    public void SetRule(Rule rule)
    {
        this.Rule = rule;
        fillTextField(rule.ToString());
    }

    private void fillTextField(string newText)
    {
        float rowLimit = 1.0f; //TODO TEST THIS
        string[] words = newText.Split(' ');
        string temp;
        textMesh.text = "";
        MeshRenderer textRenderer = textMesh.GetComponent<MeshRenderer>();
        for (int i = 0; i < words.Length; i++)
        {
            temp = textMesh.text;
            textMesh.text += words[i] + " ";
            if (textRenderer.bounds.extents.x > rowLimit)
            {
                temp += Environment.NewLine;
                temp += words[i] + " ";
                textMesh.text = temp;
            }
        }
    }

    public float GetXPosition()
    {
        return transform.position.x;
    }

    public bool AssignPerson(Person person)
    {
        if(queuedPersons.Count >= MaxPersons)
        {
            //Say that the LINE IS FULL!
            Debug.Log("LINE IS FULL!!!");
            return false;
        }
        else
        {
            Vector2 lastSpotInLine = calculateLastSpot();
            person.PlaceInLine(lastSpotInLine);
            queuedPersons.Enqueue(person);
            return true;
        }
    }

    private Vector2 calculateLastSpot()
    {
        //TODO this works for ODD values of MaxPersons... 
        // I'll need some way to dynamically calculate the PERSON_Y_OFFSET
        Vector2 toReturn = new Vector2();
        toReturn.x = transform.position.x;
        int listOffset = ((int)(MaxPersons / 2)) - queuedPersons.Count;
        float yOffset = listOffset * PERSON_Y_OFFSET;
        toReturn.y = transform.position.y + yOffset;
        return toReturn;
    }

}

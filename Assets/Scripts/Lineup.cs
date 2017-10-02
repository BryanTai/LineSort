using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lineup : Selectable {

    public string RuleText { get; set; } //TODO just a placeholder
    public int MaxPersons { get; set; }
    private Queue<Person> queuedPersons;

    private TextMesh textMesh;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("lineup_sheet");
        queuedPersons = new Queue<Person>();

        Transform childText = gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();

        //TODO for testing
        RuleText = "PLACEHOLDER_RULE";
        textMesh.text = RuleText;
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


    //Rule Checking Logic
    public bool DoesNameMatchRule(string name) {

        return false;
    }

}

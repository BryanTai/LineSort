using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    Selectable currentlySelected;
    

    public List<GameObject> AllSelectableObjects; //TODO split into list of persons and lineups?
    public PersonGenerator personGenerator;

	// Use this for initialization
	void Start () {
        Debug.Log(gameObject.tag);
        AllSelectableObjects = new List<GameObject>();
        personGenerator.Activate();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddPersonToList(GameObject newPerson)
    {
        //TODO Might need a lock on this later
        AllSelectableObjects.Add(newPerson);
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
    /*public void UpdateCurrentlySelected(Selectable newSelected)
    {
        if (currentlySelected == null)
        {
            currentlySelected = newSelected;
            return;
        }

        System.Type newSelType = newSelected.GetType();
        System.Type currSelType = currentlySelected.GetType();

        if (newSelType == typeof(Person))
        {
            if (currSelType == typeof(Person))
            {
                currentlySelected.BecomeDeselected();
            }else if (currSelType == typeof(Lineup))
            {

            }
        }
        else if(newSelType == typeof(Lineup))
        {
            if (currSelType == typeof(Person))
            {

            }
            else if (currSelType == typeof(Lineup))
            {

            }
        }

        


    }*/

    public void TestPublic()
    {
        Debug.Log("Call to GameController!");
    }
}

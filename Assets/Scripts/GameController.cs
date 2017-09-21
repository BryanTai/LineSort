using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    Selectable currentlySelected;
    Selectable previouslySelected;
    

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
    public void TestPublic()
    {
        Debug.Log("Another class can access GameController!");
    }

    public void AddPersonToList(GameObject newPerson)
    {
        //TODO Might need a lock on this later
        AllSelectableObjects.Add(newPerson);
    }
}

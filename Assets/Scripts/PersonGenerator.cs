using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    //TODO How to count time?
    public GameObject person;
    const int MAX_PERSONS = 2;
    public GameController gameController;
    
	// Use this for initialization
	void Start () {
        //TODO Load up all the names from a txt file or maybe a CSV file
    }

    public void Activate()
    {
        //TODO For now, just initializes two Persons
        for (int i = 0; i < MAX_PERSONS; i++)
        {
            Vector3 newPosition = new Vector3(i, -1, 0);
            GameObject newPerson = Instantiate(person, newPosition, Quaternion.identity);
            newPerson.name = "PLACEHOLDER_NAME"; //TODO
            gameController.AddPersonToList(newPerson);
        }
    }

}

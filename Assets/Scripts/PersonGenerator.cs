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

    }

    public void Activate()
    {
        //TODO For now, just initializes two Persons
        for (int i = 0; i < MAX_PERSONS; i++)
        {
            Vector3 newPosition = new Vector3(i, -1, 0);
            GameObject newPerson = Instantiate(person, newPosition, Quaternion.identity);
            gameController.AddPersonToList(newPerson);
        }
    }

}

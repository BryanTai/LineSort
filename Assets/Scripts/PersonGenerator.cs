using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    //TODO How to count time?
    public GameObject person;
    const int MAX_PERSONS = 2;
    public GameController gameController;

    //Name fields
    public TextAsset namesText;
    private string[] allNames;
    const int ALL_NAMES_AMOUNT = 3;
    System.Random rnd;

	// Use this for initialization
	void Start () {
        rnd = new System.Random();
    }

    public void Activate()
    {
        loadAllNamesFromTextFile();

        //TODO For now, just initializes two Persons
        for (int i = 0; i < MAX_PERSONS; i++)
        {
            Vector3 newPosition = new Vector3(i, -1, 0);
            GameObject newPersonGameObject = Instantiate(person, newPosition, Quaternion.identity);
            Person newPerson = newPersonGameObject.GetComponent<Person>();

            int randomIndex = rnd.Next(ALL_NAMES_AMOUNT);

            string newName = allNames[randomIndex];//"PLACEHOLDER_NAME_" + i;
            Debug.Log("New Person: " + newName);
            newPersonGameObject.name = newName;
            newPerson.Name = newName;

            gameController.AddPersonToWaitList(newPerson); 
        }
    }

    //TODO let's start with a small text file with only 3 names
    private void loadAllNamesFromTextFile()
    {
        allNames = new string[ALL_NAMES_AMOUNT];
        string path = "Assets/Resources/names.txt"; //TODO Will probably be passing in the path or some other parameter as game grows
        //TODO
        //use names from https://stackoverflow.com/questions/1803628/raw-list-of-person-names
        int i = 0;
        foreach (string line in File.ReadAllLines(path, Encoding.UTF8)) {
            allNames[i] = line;

            //TODO REMOVE THIS WHEN WE USE MORE NAMES OR CONSOLE IS GONNA FLOOD
            //Debug.Log(allNames[i]); 

            i++;
        }
    }
}

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    //TODO How to count time?
    public GameObject personPrefab;
    const int MAX_PERSONS = 2;
    public GameController gameController;

    //Name fields
    public TextAsset namesText;
    private string[] allNames;
    const int MERANDA_NAMES_AMOUNT = 5163;
    public string namesFilePath = "Assets/Resources/merandaNamesSorted.txt";
    System.Random rnd;

    //New Person positioning
    int minX = -5;
    int maxX = 5;
    int minY = -4;
    int maxY = 0;

	// Use this for initialization
	void Start () {
        rnd = new System.Random();
    }

    public void Activate()
    {
        loadAllNamesFromTextFile(namesFilePath);

        //TODO For now, just initializes two Persons
        for (int i = 0; i < MAX_PERSONS; i++)
        {
            int nextX = rnd.Next(minX, maxX + 1);
            int nextY = rnd.Next(minY, maxY + 1);
            createPersonAtLocation(nextX, nextY);
        }
    }

    private void createPersonAtLocation(int x, int y)
    {
        Vector3 newPosition = new Vector3(x, y, 0);
        GameObject newPersonGameObject = Instantiate(personPrefab, newPosition, Quaternion.identity);
        Person newPerson = newPersonGameObject.GetComponent<Person>();

        int randomIndex = rnd.Next(MERANDA_NAMES_AMOUNT);

        string newName = allNames[randomIndex];
        Debug.Log("New Person: " + newName);
        newPersonGameObject.name = newName;
        newPerson.SetName(newName);

        gameController.AddPersonToWaitList(newPerson);
    }

    //TODO let's start with a small text file with only 3 names
    private void loadAllNamesFromTextFile(string path)
    {
        allNames = new string[MERANDA_NAMES_AMOUNT];
        int i = 0;
        foreach (string line in File.ReadAllLines(path, Encoding.UTF8)) {
            allNames[i] = line;

            //TODO REMOVE THIS WHEN WE USE MORE NAMES OR CONSOLE IS GONNA FLOOD
            //Debug.Log(allNames[i]); 

            i++;
        }
    }
}

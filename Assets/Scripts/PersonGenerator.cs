using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    public GameObject personPrefab;
    const int INITIAL_PERSONS = 5; //Set this really big to test spacing
    public GameController gameController;

    //Name fields
    private string[] allNames;
    const int MERANDA_NAMES_AMOUNT = 5163;
    private string namesFilePath = "merandaNamesSorted";
    System.Random rnd;

    //New Person positioning
    int minX = -2;
    int maxX = 2;
    int minY = -4;
    int maxY = -1;

    private int maxPersonsForLevel;
    private bool[] isPositionOccupied;
    private List<int> freeIndexes;
    //Timer fields
    

    public void Activate(int maxPersonsForLevel)
    {
        rnd = new System.Random();
        loadAllNamesFromTextFile(namesFilePath);

        this.maxPersonsForLevel = maxPersonsForLevel;
        isPositionOccupied = new bool[maxPersonsForLevel];
        freeIndexes = new List<int>();
        for(int i = 0; i < maxPersonsForLevel; i++)
        {
            freeIndexes.Add(i);
        }

        for (int i = 0; i < INITIAL_PERSONS; i++)
        {
            CreatePersonAtRandomLocation();
        }

    }

    //TODO Cache the person locations so they don't end up stacked
    public void CreatePersonAtRandomLocation()
    {
        
        int nextIndex = freeIndexes[rnd.Next(freeIndexes.Count)];

        //TODO confirm this math...
        int columns = maxX - minX + 1;
        int rows = maxY - minY + 1;
        int nextX = (nextIndex % columns) + minX;
        int nextY = (nextIndex / rows) + minY ;
        
        createPersonAtLocation(nextX, nextY);
    }

    private void createPersonAtLocation(int x, int y)
    {
        float finalY = y;
        if (x % 2 == 0) //stagger the person layout to reduce name clipping
        {
            finalY -= 0.25f;
        }

        Vector3 newPosition = new Vector3(x, finalY, 0);
        GameObject newPersonGameObject = Instantiate(personPrefab, newPosition, Quaternion.identity);
        Person newPerson = newPersonGameObject.GetComponent<Person>();

        string newName = allNames[rnd.Next(MERANDA_NAMES_AMOUNT)];
        Debug.Log("New Person: " + newName);
        newPersonGameObject.name = newName;
        newPerson.SetName(newName);

        gameController.AddPersonToWaitList(newPerson);
    }

    //TODO make this less hardcoded
    private int convertXYToIndex(int x, int y)
    {
        int columns = maxX - minX;
        return (columns * (y + 1)) + x + 2;
    }

    private void loadAllNamesFromTextFile(string path)
    {
        allNames = new string[MERANDA_NAMES_AMOUNT];
        TextAsset allNamesAsset = Resources.Load<TextAsset>(path);
        string[] linesFromFile = allNamesAsset.text.Split("\n"[0]);

        int i = 0;
        foreach (string line in linesFromFile) {
            allNames[i] = line;
            i++;
        }
    }
}

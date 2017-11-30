using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    public GameObject personPrefab;

    //Name fields
    private string[] allNames;
    const int MERANDA_NAMES_AMOUNT = 5163;
    private string namesFilePath = "merandaNamesSorted";
    System.Random rnd;

    //New Person positioning
    private int minX = -2;
    private int maxX = 2;
    private int minY = -4;
    private int maxY = -1;
    private int columns;
    private float staggerOffset = 0.25f;

    private int maxPersonsForLevel;
    private List<int> freeIndexes;

    //Person Sprite fields
    const string PERSON_SPRITE_FILE = "person_sheet_";
    private Sprite[][] personSpriteSheets;
    private int totalSpriteSheets = 4;


    void Awake()
    {
        personSpriteSheets = new Sprite[totalSpriteSheets][];
        for(int i = 0; i < totalSpriteSheets; i++)
        {
            string spriteName = PERSON_SPRITE_FILE + i;
            personSpriteSheets[i] = Resources.LoadAll<Sprite>(spriteName);
        }
    }

    public void Activate(int maxPersonsForLevel)
    {
        rnd = new System.Random();
        loadAllNamesFromTextFile(namesFilePath);

        columns = maxX - minX + 1;
        //rows = maxY - minY + 1;

        this.maxPersonsForLevel = maxPersonsForLevel;
        freeIndexes = new List<int>();
        for(int i = 0; i < maxPersonsForLevel; i++)
        {
            freeIndexes.Add(i);
        }
    }

    public Person CreatePersonAtRandomLocation()
    {
        int randomIndex = rnd.Next(freeIndexes.Count);
        int nextLocationIndex = freeIndexes[randomIndex];
        freeIndexes.RemoveAt(randomIndex);
        return createPersonAtIndex(nextLocationIndex);
    }

    private Person createPersonAtIndex(int nextIndex)
    {
        int nextX = (nextIndex % columns) + minX;
        int nextY = (nextIndex / columns) + minY;
        float finalY = nextY;
        if (nextX % 2 == 0) //stagger the person layout to reduce name clipping
        {
            finalY -= staggerOffset;
        }

        Vector3 newPosition = new Vector3(nextX, finalY, 0);
        GameObject newPersonGameObject = Instantiate(personPrefab, newPosition, Quaternion.identity);
        Person newPerson = newPersonGameObject.GetComponent<Person>();

        string newName = allNames[rnd.Next(MERANDA_NAMES_AMOUNT)];
        
        newPersonGameObject.name = newName;
        newPerson.SetName(newName);
        newPerson.LocationIndex = nextIndex;

        int randomSpriteIndex = rnd.Next(0, totalSpriteSheets);
        newPerson.SetSprites(personSpriteSheets[randomSpriteIndex]);

        Debug.Log("New Person Generated!: " + newName);
        return newPerson;
    }

    public void FreeUpPosition(int index)
    {
        freeIndexes.Add(index);
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

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    public GameObject personPrefab;

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

    private NameGenerator nameGenerator;
    private System.Random rnd;

    void Awake()
    {
        rnd = new System.Random();
        nameGenerator = new NameGenerator(GlobalData.MaxNameLength, GlobalData.MinNameLength);
        columns = maxX - minX + 1;
        //rows = maxY - minY + 1;

        personSpriteSheets = new Sprite[totalSpriteSheets][];
        for(int i = 0; i < totalSpriteSheets; i++)
        {
            string spriteName = PERSON_SPRITE_FILE + i;
            personSpriteSheets[i] = Resources.LoadAll<Sprite>(spriteName);
        }
    }

    public void Activate(int maxPersonsForLevel)
    {
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

        //TODO bug with Instantiate in Unity 2017.3.0f3, have to manually set the position :I
        newPerson.gameObject.transform.position = newPosition;

        string newName = nameGenerator.GetNewName();
        newPersonGameObject.name = newName;
        newPerson.SetName(newName);
        newPerson.LocationIndex = nextIndex;

        int randomSpriteIndex = rnd.Next(0, totalSpriteSheets);
        newPerson.SetSprites(personSpriteSheets[randomSpriteIndex]);

        return newPerson;
    }

    public void FreeUpPosition(int index)
    {
        freeIndexes.Add(index);
    }
}

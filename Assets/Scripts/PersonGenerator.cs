using System.IO;
using System.Text;
using UnityEngine;

public class PersonGenerator : MonoBehaviour {

    public GameObject personPrefab;
    const int INITIAL_PERSONS = 16; //TODO LOWER THIS, JUST FOR TESTING
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

    //Timer fields
    private float createPersonTime = 2;

    public void Activate()
    {
        rnd = new System.Random();
        loadAllNamesFromTextFile(namesFilePath);

        for (int i = 0; i < INITIAL_PERSONS; i++)
        {
            createPersonAtRandomLocation();
        }
        InvokeRepeating("createPersonAtRandomLocation", createPersonTime, createPersonTime);
    }

    //TODO Cache the person locations so they don't end up stacked
    private void createPersonAtRandomLocation()
    {
        int nextX = rnd.Next(minX, maxX + 1);
        int nextY = rnd.Next(minY, maxY + 1);
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

        int randomIndex = rnd.Next(MERANDA_NAMES_AMOUNT);

        string newName = allNames[randomIndex];
        Debug.Log("New Person: " + newName);
        newPersonGameObject.name = newName;
        newPerson.SetName(newName);

        gameController.AddPersonToWaitList(newPerson);
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

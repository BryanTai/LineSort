using System;
using UnityEngine;

public class NameGenerator {
    //Name fields
    const int MIN_NAME_LENGTH = 3; //Might add the 2 letter names later
    const int MAX_NAME_LENGTH = 11; //Note that text file 10 holds all names with 10+ length
    private string[][] allNames;
    private int[] allNameCounts;
    const int MERANDA_NAMES_AMOUNT = 5163;
    private string namesFilePath = "merandaNamesSortedLength";
    private int currentMaxNameLength;
    private int currentMinNameLength;
    private System.Random rnd;
    
    public NameGenerator()
    {
        currentMaxNameLength = GlobalData.MaxNameLength;
        currentMinNameLength = GlobalData.MinNameLength;

        rnd = new System.Random();
        loadAllNamesFromTextFile(namesFilePath);
    }

    public string GetNewName()
    {
        int nameLength = rnd.Next(currentMinNameLength, currentMaxNameLength + 1);
        int nameIndex = rnd.Next(allNameCounts[nameLength]);
        return allNames[nameLength][nameIndex];
    }

    //TODO MOVE THIS TO GLOBALDATA TO PREVENT REPEATED LOADS
    //Note that allNames indexes smaller than MIN_NAME_LENGTH are empty
    private void loadAllNamesFromTextFile(string path)
    {

        allNames = new string[MAX_NAME_LENGTH][];
        allNameCounts = new int[MAX_NAME_LENGTH];

        for (int length = MIN_NAME_LENGTH; length < MAX_NAME_LENGTH; length++)
        {
            string fileName = path + length;
            TextAsset namesAsset = Resources.Load<TextAsset>(fileName);
            string[] linesFromFile = namesAsset.text.Split(new string[] { "\n", "\r\n" }, StringSplitOptions.RemoveEmptyEntries);
            allNames[length] = linesFromFile;
            allNameCounts[length] = allNames[length].GetLength(0);
        }
    }
}

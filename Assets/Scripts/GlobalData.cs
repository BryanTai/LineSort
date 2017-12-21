//Data that needs to be passed between Scenes
using System.Collections.Generic;
using UnityEngine;
public class GlobalData : MonoBehaviour{

    public static float CreatePersonRate { get; set; }
    public static int CurrentLevel { get; set; }
    public static int MaxLines { get; set; }
    public static int MaxNameLength { get; set; }
    public static int MaxPersons { get; set; }
    public static int PlayerScore { get; set; }
    public static int TimerSeconds { get; set; }


    //TODO Going to Main Menu will re-call this function, essentially forgetting the changes from last time.
    // Save data to file?
    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);

        CreatePersonRate = 2;
        CurrentLevel = 1;
        MaxNameLength = 5;
        MaxPersons = 25; //this seems to be a good MAX for hardest levels
        PlayerScore = 0;
        TimerSeconds = 60;
        Debug.Log("GlobalData good to go!");
    }
}

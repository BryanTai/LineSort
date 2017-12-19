//Data that needs to be passed between Scenes
using System.Collections.Generic;
using UnityEngine;
public class GlobalData : MonoBehaviour{

    public static int CurrentLevel { get; set; }
    public static int MaxLines { get; set; }
    public static int MaxPersons { get; set; }
    public static int MaxNameLength { get; set; }
    public static int PlayerScore { get; set; }
    public static int TimerSeconds { get; set; }


    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
        CurrentLevel = 1;
        MaxNameLength = 5;
        TimerSeconds = 60;
    }
}

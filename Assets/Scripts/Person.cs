using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Selectable {

    public string Name { get; set; }

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("person_sheet");
    }

    void OnMouseDown()
    {
        Debug.Log("Clicked Person!");
        becomeSelected();
    }
}

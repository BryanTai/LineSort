using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Selectable {

    void OnMouseDown()
    {
        Debug.Log("Clicked Person!");
        isSelected = true;
    }
}

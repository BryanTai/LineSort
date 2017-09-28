using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Person : Selectable {

    public string Name { get; private set; }
    private TextMesh textMesh;

    void Awake()
    {
        sprites = Resources.LoadAll<Sprite>("person_sheet");
        Transform childText = this.gameObject.transform.GetChild(0);
        textMesh = childText.GetComponent<TextMesh>();
        
    }

    void OnMouseDown()
    {
        becomeSelected();
    }

    public void SetName(string name)
    {
        this.Name = name;
        textMesh.text = this.Name;
    }
}

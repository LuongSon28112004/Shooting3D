using System;
using System.Collections.Generic;
using UnityEngine;

public class LoadListObject : ModelMonoBehaviour
{
    [SerializeField] private List<GameObject> objectsToLoad;

    public List<GameObject> ObjectsToLoad { get => objectsToLoad; set => objectsToLoad = value; }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        if(this.objectsToLoad.Count > 0) return;
        this.LoadObjects();
    }

    private void LoadObjects()
    {
        foreach (Transform child in transform)
        {
            GameObject obj = child.gameObject;
            objectsToLoad.Add(obj);
        }
    }
}

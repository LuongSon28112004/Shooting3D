using System;
using System.Collections.Generic;
using UnityEngine;

public class objectPool : ModelMonoBehaviour
{
    [SerializeField] protected Transform Holder;
    [SerializeField] protected List<Transform> prefabs;
    [SerializeField] protected List<Transform> poolObjs;


    protected override void LoadComponents(){
        this.LoadPrefabs();
        this.LoadHolder();
    }

    protected virtual void LoadHolder()
    {
        if(this.Holder != null) return;
        this.Holder = transform.Find("Holder");
        Debug.Log(transform.name + ": Load Holder" , gameObject);
    }

    protected virtual void LoadPrefabs(){
        if(this.prefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj){
            prefabs.Add(prefab);
            Debug.Log("Add");
        }
        this.HidePrefabs();

        Debug.Log(transform.name + "Load prefabs" , gameObject);
    }

    protected virtual void HidePrefabs(){
        foreach(Transform prefab in prefabs){
            prefab.gameObject.SetActive(false);
        }
    }

    public virtual Transform Spawn(string prefabName,Vector3 spawnPos , Quaternion rotation){
        Transform prefab = this.getPrefabByName(prefabName);
        if(prefab == null)
        {
            Debug.LogWarning("not found prefab "+ prefabName);
            return null;
        }
        Transform newPrefab = this.getObjectFromPool(prefab);
        newPrefab.position = spawnPos;
        //newPrefab.rotation = rotation;
        newPrefab.parent = this.Holder;
        return newPrefab;
    }

    protected virtual Transform getObjectFromPool(Transform Prefab){
        foreach (Transform poolObj in this.poolObjs)
        {
            if(poolObj.name == Prefab.name){
                this.poolObjs.Remove(poolObj);
                return poolObj;
            }
        }
        Transform newPrefab = Instantiate(Prefab);
        newPrefab.name = Prefab.name;
        return newPrefab;
    }

    public virtual void Despawn(Transform obj){
        this.poolObjs.Add(obj);
        obj.gameObject.SetActive(false);
    }

    public virtual Transform getPrefabByName(string prefabName)
    {
        foreach(Transform prefab in this.prefabs){
            if(prefab.name == prefabName){
                return prefab;
            }
        }
        return null;
    }
}

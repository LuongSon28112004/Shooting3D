using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnByCollider : Despawn
{
    [SerializeField] protected bool isDeSpawn = false;

    protected override void LoadComponents()
    {
        base.LoadComponents();
    }

    protected override bool CanDespawn()
    {
        return isDeSpawn;
    }

    private void OnEnable()
    {
        isDeSpawn = false;
    }
    
}
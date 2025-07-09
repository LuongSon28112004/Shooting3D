using System;
using System.Collections;
using UnityEngine;

public class RandomEnemy : ModelMonoBehaviour
{
    [SerializeField] private float timeSpawn = 2f;
    [SerializeField] private bool hasSpawned = true;

    private void FixedUpdate()
    {
        this.Spawn();
    }

    protected virtual void Spawn()
    {
        if (hasSpawned)
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    private IEnumerator SpawnEnemy()
    {
        hasSpawned = false;
        Transform Enemy = EnemySpawner.Instance.Spawn(EnemySpawner.enemyOne, transform.position, transform.rotation);
        Enemy.gameObject.SetActive(true);
        yield return new WaitForSeconds(timeSpawn);
        hasSpawned = true;
    }
}

using UnityEngine;

public class BulletPlayerDespawnByCollider : DespawnByCollider
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy") || other.gameObject.CompareTag("Wall"))
        {
            isDeSpawn = true;
        }
    }
    
    protected override void DeSpawnObject()
    {
        BulletPlayerSpawner.Instance.Despawn(transform.parent);
    }
}

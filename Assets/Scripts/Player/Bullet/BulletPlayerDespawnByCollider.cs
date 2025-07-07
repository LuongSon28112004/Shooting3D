using UnityEngine;

public class BulletPlayerDespawnByCollider : DespawnByCollider
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            isDeSpawn = true;
            Debug.Log("Bullet collided with an enemy and will despawn.");
        }
    }
    
    protected override void DeSpawnObject()
    {
        BulletPlayerSpawner.Instance.Despawn(transform);
    }
}

using UnityEngine;

public class EnemyImpact : EnemyAbstract
{
    void OnCollisionEnter(Collision other)
    {
        this.EnemyCtl.EnemyDamageSender.Send(other.transform);
    }
}

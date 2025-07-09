using UnityEngine;

public class EnemyDamageSender : DamageSender
{
    [Header("Enemy Damage Sender Settings")]
    [SerializeField] private float Damage = 1f;

    public override void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    protected override void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Dectect(Damage);
    }
}

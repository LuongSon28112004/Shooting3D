using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
[RequireComponent(typeof(Rigidbody))]
public class BulletPlayerDamageSender : DamageSender
{
    [Header("Bullet Player Damage Sender Settings")]
    [SerializeField] private float bulletDamage = 1f;

    public override void Send(Transform obj)
    {
        DamageReceiver damageReceiver = obj.GetComponentInChildren<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
    }

    protected override void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Dectect(bulletDamage);
    }
}

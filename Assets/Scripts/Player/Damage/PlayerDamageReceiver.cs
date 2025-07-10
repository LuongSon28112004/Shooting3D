using UnityEngine;

public class PlayerDamageReceiver : DamageReceiver
{
    [Header("Player Damage Receiver")]
   [SerializeField] private bool isDead = false;

    protected override void Update()
    {
        base.Update();
        if (this.IsDead())
        {
            this.Dead();
        }
    }

    private void OnEnable()
    {
        this.Reborn();
    }

    protected override bool IsDead()
    {
        this.isDead = this.hp <= 0;
        return this.isDead;
    }

    protected override void Dead()
    {
        Destroy(this.gameObject);
    }
}

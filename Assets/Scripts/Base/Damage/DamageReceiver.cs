using UnityEngine;

public class DamageReceiver : ModelMonoBehaviour
{
    [Header("Damage Receiver Settings")]

    [SerializeField] protected float hp = 1f;
    [SerializeField] protected float maxHp = 1f;

    protected override void Start()
    {
        base.Start();
        this.Reborn();
    }


    protected virtual void Reborn()
    {
        this.hp = this.maxHp;
    }

    public virtual void Add(float add)
    {
        this.hp += add;
        if (this.hp > this.maxHp)
        {
            this.hp = this.maxHp;
        }
    }

    public virtual void Dectect(float dect)
    {
        this.hp -= dect;
        if (this.hp <= 0)
        {
            this.hp = 0;
        }
    }

    protected virtual bool IsDead()
    {
        return this.hp <= 0;
    }

    protected virtual void Dead()
    {
        
    }

}

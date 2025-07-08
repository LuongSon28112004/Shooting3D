using UnityEngine;

public class BulletCtl : ModelMonoBehaviour
{
    [Header("Bullet Control Settings")]
    [SerializeField] private BulletPlayerDamageSender damageSender;

    public BulletPlayerDamageSender DamageSender { get => damageSender; }
    protected override void Start()
    {
        base.Start();
        this.damageSender = this.GetComponentInChildren<BulletPlayerDamageSender>();
        if (this.damageSender == null)
        {
            Debug.LogError("BulletPlayerDamageSender is not found on the bullet.");
        }
    }
    
    
}

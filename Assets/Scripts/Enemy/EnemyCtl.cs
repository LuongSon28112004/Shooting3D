using UnityEngine;

public class EnemyCtl : ModelMonoBehaviour
{
    [Header("EnemyCtl Setting")]
    [SerializeField] private EnemyDamageSender enemyDamageSender;

    public EnemyDamageSender EnemyDamageSender { get => enemyDamageSender;  }

    protected override void Start()
    {
        base.Start();
        enemyDamageSender = GetComponentInChildren<EnemyDamageSender>();
    }
}

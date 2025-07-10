using UnityEngine;

public class EnemyAbstract : ModelMonoBehaviour
{
    [Header("EnemyAbstract Settings")]
    [SerializeField] private EnemyCtl enemyCtl;

    public EnemyCtl EnemyCtl { get => enemyCtl; }

    protected override void Start()
    {
        base.Start();
        if (enemyCtl != null) return;
        enemyCtl = transform.parent.GetComponent<EnemyCtl>();
        if (enemyCtl == null)
        {
            Debug.LogError("EnemyCtl is not found on the enemy.");
        }
    }

}

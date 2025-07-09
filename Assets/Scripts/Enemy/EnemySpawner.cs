using UnityEngine;

public class EnemySpawner : objectPool
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance { get => instance; }
    [SerializeField] public static string enemyOne = "Spider";

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogError("Multiple instances of EnemySpawner detected. Destroying the new instance.");
            return;
        }
        instance = this;
    }


}

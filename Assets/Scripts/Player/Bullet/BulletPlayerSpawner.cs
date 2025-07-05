using UnityEngine;

public class BulletPlayerSpawner : objectPool
{
    private static BulletPlayerSpawner instance;

    public static BulletPlayerSpawner Instance { get => instance; }
    [SerializeField] public static string bulletOne = "BulletOne";
    [SerializeField] public static string bulletTwo = "BulletTwo";
    [SerializeField] public static string bulletThree = "BulletThree";

    protected override void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    
}

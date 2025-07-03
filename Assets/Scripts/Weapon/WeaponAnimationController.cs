using UnityEngine;

public class WeaponAnimationController : ModelMonoBehaviour
{
    private static WeaponAnimationController instance;

    public static WeaponAnimationController Instance { get => instance; }
    public ObjectWeapons ObjectWeapons { get => objectWeapons;  set => objectWeapons = value; }

    [SerializeField] private ObjectWeapons objectWeapons;

    protected override void Awake()
    {
        base.Awake();
        if (instance != null)
        {
            Debug.LogWarning("Multiple instances of WeaponAnimationController detected.");
            return;
        }
        instance = this;
    }
    
    protected override void LoadComponents()
    {
        base.LoadComponents();
        if (objectWeapons == null)
        {
            objectWeapons = GetComponent<ObjectWeapons>();
        }
    }
}

using UnityEngine;

public class WeaponAnimationController : ModelMonoBehaviour
{
    private static WeaponAnimationController instance;

    public static WeaponAnimationController Instance { get => instance; }

    [SerializeField] private ObjectWeapons objectWeapons;
    [SerializeField] private WeaponAnimation weaponAnimation;
    public ObjectWeapons ObjectWeapons { get => objectWeapons;  set => objectWeapons = value; }
    public WeaponAnimation WeaponAnimation { get => weaponAnimation; }

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
        if (weaponAnimation == null)
        {
            weaponAnimation = GetComponent<WeaponAnimation>();
        }
    }
}

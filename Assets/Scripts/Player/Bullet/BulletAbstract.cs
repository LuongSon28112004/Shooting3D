using UnityEngine;

public class BulletAbstract : ModelMonoBehaviour
{
    [Header("BulletAbstract Settings")]
    [SerializeField] private BulletCtl bulletCtl;

    protected BulletCtl BulletCtl { get => bulletCtl;  }

    protected override void Start()
    {
        base.Start();
        this.bulletCtl = transform.parent.GetComponent<BulletCtl>();
        if (this.bulletCtl == null)
        {
            Debug.LogError("BulletCtl is not found on the bullet.");
        }
    }

}

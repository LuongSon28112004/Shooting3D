using UnityEngine;

public class BulletImpact : BulletAbstract
{
    [Header("Bullet Impact Settings")]
    [SerializeField] private BoxCollider boxCollider;
    [SerializeField] private Rigidbody rigidbody;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadCollider()
    {
        if (boxCollider != null) return;
        boxCollider = GetComponent<BoxCollider>();
        Debug.Log("BoxCollider loaded: " + (boxCollider != null));
    }

    protected virtual void LoadRigidbody()
    {
        if (rigidbody != null) return;
        rigidbody = GetComponent<Rigidbody>();
        Debug.Log("Rigidbody loaded: " + (rigidbody != null));
    }

    private void OnCollisionEnter(Collision collision) {
        this.BulletCtl.DamageSender.Send(collision.transform);
    }

}

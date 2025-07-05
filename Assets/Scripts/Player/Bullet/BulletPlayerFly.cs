using UnityEngine;

public class BulletPlayerFly : ModelMonoBehaviour, IFly
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Vector3 direction = Vector3.forward;

    public Vector3 Direction { get => direction; set => direction = value; }

    protected virtual void FixedUpdate()
    {
        this.Fly();
    }

    public void Fly()
    {
        transform.parent.Translate(direction * speed * Time.deltaTime);
    }
}

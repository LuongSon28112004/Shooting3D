using UnityEngine;

public abstract class DamageSender : MonoBehaviour
{

    public abstract void Send(Transform obj);

    protected abstract void Send(DamageReceiver damageReceiver);
}
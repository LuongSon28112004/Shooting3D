using UnityEngine;
using UnityEngine.InputSystem;

public class Attack : ModelMonoBehaviour
{
    [SerializeField] private GameObject firePoint;
    protected override void Update()
    {
        if (InputManager.Instance.AttackInput)
        {
            Transform bullet = BulletPlayerSpawner.Instance.Spawn(BulletPlayerSpawner.bulletOne, firePoint.transform.position, firePoint.transform.rotation);
            Debug.Log(transform.parent.forward);
            bullet.GetComponentInChildren<BulletPlayerFly>().Direction = firePoint.transform.forward;
            bullet.gameObject.SetActive(true);
        }
    }
}

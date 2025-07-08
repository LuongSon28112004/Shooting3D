using System.Collections;
using UnityEngine;

public class Attack : ModelMonoBehaviour
{
    [SerializeField] private bool isAttack = true;
    [SerializeField] private float timeShooting = 0.5f;

    protected override void Update()
    {
        base.Update();
        Attacking();
    }

    protected void Attacking()
    {
        if (isAttack)
        {
            StartCoroutine(Shooting());
        }
    }

    protected virtual IEnumerator Shooting()
    {
        if (InputManager.Instance.AttackInput)
        {
            Transform bullet = getBullet();
            if (bullet == null)
            {
                Debug.LogError("Bullet prefab not found.");
                yield break;
            }
            // Debug.Log(transform.parent.forward);
            BulletPlayerFly bulletPlayerFly = bullet.GetComponentInChildren<BulletPlayerFly>();
            if (bulletPlayerFly == null)
            {
                Debug.LogError("BulletPlayerFly component not found on the bullet prefab.");
                yield break;
            }
            bulletPlayerFly.Direction = new Vector3(0, 0, 1);
            bullet.gameObject.SetActive(true);
            isAttack = false;
            yield return new WaitForSeconds(timeShooting);
            isAttack = true;
        }
    }

    protected virtual Transform getBullet()
    {
        Transform bullet;
        if (WeaponAnimationController.Instance.WeaponAnimation.WeasponPosition == 0 || WeaponAnimationController.Instance.WeaponAnimation.WeasponPosition == 1)
        {
            bullet = BulletPlayerSpawner.Instance.Spawn(BulletPlayerSpawner.bulletTwo, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        }
        else
        {
            bullet = BulletPlayerSpawner.Instance.Spawn(BulletPlayerSpawner.bulletOne, transform.position + new Vector3(0, 0.5f, 0), transform.rotation);
        }
        return bullet;
    }
}

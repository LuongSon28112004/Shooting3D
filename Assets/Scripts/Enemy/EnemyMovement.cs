using UnityEngine;

public class EnemyMovement : ModelMonoBehaviour
{
    [SerializeField] private float speed = 2f;
    [SerializeField] private Transform targetPlayer;

    protected override void Awake()
    {
        base.Awake();
        if (targetPlayer == null)
        {
            targetPlayer = GameObject.FindGameObjectWithTag("Player")?.transform;
            if (targetPlayer == null)
            {
                Debug.LogError("Target player not found. Please assign a player transform.");
            }
        }
    }

    protected override void Update()
    {
        if (targetPlayer == null) return;

        Vector3 direction = (targetPlayer.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
        transform.LookAt(targetPlayer);
        transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0);
    }
}

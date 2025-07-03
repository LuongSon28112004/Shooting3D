using UnityEngine;

public class Crosshair3D : ModelMonoBehaviour
{
    [SerializeField]
    private Camera playerCamera;
    [SerializeField] 
    private GameObject weaponObject;
    private float rayDistance = 100f;
    private Vector3 enlargedScale = new Vector3(1.5f, 1.5f, 1.5f);
    private Vector3 defaultScale = new Vector3(1f, 1f, 1f);

    protected override void Update()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hit;

        // Mặc định màu xanh nếu chưa chạm
        Color rayColor = Color.green;

        if (Physics.Raycast(ray, out hit, rayDistance))
        {
            // Nếu chạm đúng đối tượng có tag "Target"
            if (hit.collider.CompareTag("Target"))
            {
                transform.localScale = enlargedScale;
                rayColor = Color.red; // Chuyển sang đỏ nếu trúng mục tiêu
            }
            else
            {
                transform.localScale = defaultScale;
            }
        }
        else
        {
            transform.localScale = defaultScale;
        }

        // Vẽ tia raycast
        Debug.DrawRay(ray.origin, ray.direction * rayDistance, rayColor);

        // Đặt lại vị trí và hướng của weaponObject
        transform.position = playerCamera.transform.position + playerCamera.transform.forward * 2f;
        transform.rotation = playerCamera.transform.rotation;

        weaponObject.transform.rotation = playerCamera.transform.rotation;
    }
}

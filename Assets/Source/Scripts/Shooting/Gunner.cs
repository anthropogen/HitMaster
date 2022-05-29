using UnityEngine;

public class Gunner : MonoBehaviour
{
    [SerializeField] private Gun gun;
    [SerializeField] private GameFactory factory;
    [SerializeField, Range(0, 100)] float pointDistance;
    private Camera cam;
    private void Start()
    {
        cam = Camera.main;
    }

    private void Update()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin, ray.direction * 25, Color.red);
        RaycastHit hit;
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 direction;
            if (Physics.Raycast(ray, out hit))
            {
                direction = hit.point - gun.ShootPos;
            }
            else
            {
                direction = ray.GetPoint(pointDistance) - gun.ShootPos;
            }
            Quaternion rotation = Quaternion.LookRotation(direction);
            factory.BulletPool.GetAt(gun.ShootPos, rotation);

        }
    }
}

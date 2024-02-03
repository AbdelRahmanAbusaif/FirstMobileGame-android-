using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float Speed;
    [SerializeField] Vector2 maxPus;
    [SerializeField] Vector2 minPus;
    private void Update()
    {
        if (transform.position == target.position)
            return;

        Vector3 targetpos = new (target.position.x, target.position.y, -10);
        targetpos.x = Mathf.Clamp(targetpos.x, minPus.x, maxPus.x);
        targetpos.y = Mathf.Clamp(targetpos.y, minPus.y, maxPus.y);
        transform.position = Vector3.Lerp(transform.position, targetpos, Speed);
    }
}

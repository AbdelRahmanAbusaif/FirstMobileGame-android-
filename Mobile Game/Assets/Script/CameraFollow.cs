using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float Speed;
    [SerializeField] private Vector2 maxPus;
    [SerializeField] private Vector2 minPus;
    private void Update()
    {
        if (transform.position == target.position)
            return;

        Vector3 targetpos = new Vector3(target.position.x, target.position.y, -10);
        targetpos.x = Mathf.Clamp(targetpos.x, minPus.x, maxPus.x);
        targetpos.y = Mathf.Clamp(targetpos.y, minPus.y, maxPus.y);
        transform.position = Vector3.Lerp(transform.position, targetpos, Speed);
    }
}

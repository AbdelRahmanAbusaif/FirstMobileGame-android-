using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{
    public GameObject arrowPrefab;
    public Transform arrowSpawnPoint;
    public float arrowForce = 10f;
    public float shootInterval = 2f; // Adjust this to control the shooting frequency

    private void Start()
    {
        // Start shooting arrows immediately and then continue at regular intervals
        InvokeRepeating("ShootArrow", 1f, shootInterval);
    }

    void ShootArrow()
    {
        GameObject arrow = Instantiate(arrowPrefab, arrowSpawnPoint.position, Quaternion.Euler(arrowSpawnPoint.eulerAngles.x,arrowSpawnPoint.eulerAngles.y,arrowSpawnPoint.eulerAngles.z-90));
        Rigidbody2D rb = arrow.GetComponent<Rigidbody2D>();
        rb.AddForce(arrowSpawnPoint.right * arrowForce, ForceMode2D.Impulse);
        if (arrow.CompareTag("wall"))
            Destroy(arrow);
    }
}

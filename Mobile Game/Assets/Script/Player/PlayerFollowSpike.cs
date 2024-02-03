using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFollowSpike : MonoBehaviour
{
    [SerializeField] private Transform target;
    private Transform firstPosotion;
    private Transform lastPosotion;
    private ParticaleSystem Effect;
    private void Start()
    {
        Effect = FindAnyObjectByType<ParticaleSystem>().GetComponent<ParticaleSystem>();

        firstPosotion = new GameObject().transform;
        lastPosotion = new GameObject().transform;
        firstPosotion.position = gameObject.transform.position;
    }
    public void FollowPlayer()
    {
        firstPosotion.position = gameObject.transform.position;
        
        gameObject.transform.localPosition = new Vector3(target.position.x - 3f, target.position.y - 0.9f, 0);

        lastPosotion.position = gameObject.transform.position;

        Physics2D.IgnoreLayerCollision(7, 8);
        Physics2D.IgnoreLayerCollision(7, 6);

        Effect.RunParticale(firstPosotion,lastPosotion);
    }
}

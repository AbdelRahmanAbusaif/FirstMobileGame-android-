using UnityEngine;

public class Arrow : MonoBehaviour
{
    //Movement movement;
    //private void Start()
    //{
    //    movement = FindAnyObjectByType<Movement>().GetComponent<Movement>();
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "wall":
            case "Enemy":
                Destroy(gameObject);
                break;
            case "Player":
                //do fking something
                //movement.GameOver();
                //break;
            default:
                break;
        }
    }
}

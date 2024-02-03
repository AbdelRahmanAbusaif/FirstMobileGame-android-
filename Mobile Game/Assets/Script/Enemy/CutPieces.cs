using System.Collections;
using UnityEngine;

public class CutPieces : MonoBehaviour
{
    public GameObject bloodEffect;

    GameObject Enemy;
    bool isDead;
    AudioManager am;
    private void Start()
    {
        Physics2D.IgnoreLayerCollision(6, 8, false);
        isDead = false;
        am = FindAnyObjectByType<AudioManager>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isDead)
        {
            Collider2D collider = collision.collider;
            am.PlayClip(am.KillEffect);
            Cut(gameObject,collider);
        }
    }

    public void Cut(GameObject pieces,Collider2D Player)
    {
        if (!isDead)
        {
            GameObject Blood = Instantiate(bloodEffect, transform.position, Quaternion.identity);
            StartCoroutine(DestroyEffect(Blood));
        }

        if (pieces != null && pieces.transform.parent != null)
        {
            // Access the parent GameObject if 'pieces' is a child
            Enemy = pieces.transform.parent.gameObject;
        }
        else
        {
            Enemy = pieces;
        }
        ForUIEnemy uiEnemy = Enemy.GetComponent<ForUIEnemy>();
        if (!uiEnemy.isCount)
        {
            FindObjectOfType<UIEnemy>().DisActive(Enemy);
        }
        uiEnemy.isCount = true;
        for (int i = 0; i < Enemy.transform.childCount; i++)
        {
            HingeJoint2D hinge = Enemy.transform.GetChild(i).GetComponent<HingeJoint2D>();
            Rigidbody2D rb = Enemy.transform.GetChild(i).GetComponent<Rigidbody2D>();
            Collider2D cl = Enemy.transform.GetChild(i).GetComponent<Collider2D>();

            if (hinge != null && rb != null && !isDead && cl != null )
            {
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 1.0f;
                rb.AddForce(new Vector2(transform.position.x * 30, transform.position.y * 30));

                hinge.enabled = false;

                //sp.color = new Color(144, 144, 144);

                Physics2D.IgnoreCollision(cl, Player);
            }
        }
        isDead = true;
        StartCoroutine(DestroyEffect(Enemy));
    }
    IEnumerator DestroyEffect(GameObject Blood)
    {
        yield return new WaitForSeconds(2);
        Destroy(Blood);
    }
}


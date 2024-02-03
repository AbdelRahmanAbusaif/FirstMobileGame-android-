using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    Movement movement;
    PlayerFollowSpike player;
    GameOverMeny GameOverMenu;
    AudioManager am;
    //public float Attemp = 0;

    /*[Header("iframes")]
    public SpriteRenderer spr;
    public float NumberOfFlashing = 3;
    public float IframeDuration = 2;
    */
    private void Start()
    {
        movement = GetComponent<Movement>();
        player = FindObjectOfType<PlayerFollowSpike>();
        GameOverMenu = FindObjectOfType<GameOverMeny>();
        am = FindAnyObjectByType<AudioManager>();
        //Attemp = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap"))
        {
            try
            {
                //Take Damage For (Attacking) player
                DamagePlayer();
            }
            catch
            {
                // Handle exceptions if necessary
            }
        }
    }
    public void DamagePlayer()
    {
        //Die here
        GameOver();
        print("Player Die");

    }

    public void GameOver()
    {
        if (movement != null)
        {
            print("Die ");

            // Disable Movement script
            movement.StopMovement();
            
            // Reset velocity to zero
            movement.rb.velocity = new Vector3(0, 0, 0);
            
            //show UI Game  over menu 
            GameOverMenu.GameOverActive();
            
            //play sound die
            am.PlayClip(am.DieEffects);
        }
    }
}

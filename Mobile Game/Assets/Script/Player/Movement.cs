using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public delegate void MyEventHandler(GameObject sender);
    public event MyEventHandler MyEvent;
    public class MySubscriber
    {
        public void HandleEvent(GameObject sender)
        {
            Destroy(sender);
        }
    }
    GameObject PlayerInstiate;

    private float power = 1.3f;
    private float countAttack = 60000;

    public Rigidbody2D rb;
    public GameObject Player;
    private AudioManager am;

    public Vector2 minPower;
    public Vector2 maxPower;

    TragectoryLine tl;
    //PlayerFollowSpike PlayerFollow;

    Camera cam;
    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    bool isStill = true;
    bool allowInput = true;
    bool isDragging = false;

    public float PowerPr 
    { 
        get 
        {
            return power;
        } 
        set 
        {
            if(value > 0 )
            {
                power=value;
            }
            else
            {
                power = 2f;
            }
        }
    }
    public float CountAttackPr
    {
        get
        {
            return countAttack;
        }
        set
        {
            if (value > 0)
            {
                countAttack = value;
            }
            else
            {
                value = 100000f ;
            }
        }
    }

    private void Start()
    {
        cam = Camera.main;
        tl = GetComponent<TragectoryLine>();
        //PlayerFollow =FindAnyObjectByType<PlayerFollowSpike>().GetComponent<PlayerFollowSpike
        retSlowMotion();
        countAttack=CountAttackPr; 
        power=PowerPr;
        am = FindAnyObjectByType<AudioManager>();
        Debug.Log($"Audio Manager {am.IsUnityNull()}");
    }
    private void Update()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch (you can modify this based on your requirements)

            // Check if the touch is on the object
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(touch.position);

            switch (touch.phase)
            {
                case TouchPhase.Began:
                    if (Physics.Raycast(ray, out hit) && hit.transform == transform)
                    {
                        OnTouchDown();
                    }
                    break;

                case TouchPhase.Moved:
                    if (isDragging)
                    {
                        OnTouchDrag();
                    }
                    break;

                case TouchPhase.Ended:
                    if (isDragging)
                    {
                        OnTouchUp();
                        isDragging = false;
                    }
                    break;
            }
        }
        
    }
    private void OnMouseDown()
    {
        if (!allowInput || countAttack<=0)
            return;
        rb.velocity = new Vector3(rb.velocity.x * 0.2f, rb.velocity.y * 0.2f);
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        startPoint.z = 15;
        SlowMotion();
        //Player.gameObject.SetActive(true);
        //PlayerFollow.FollowPlayer();

        //this is game object i want to destroy
        // Instantiate the GameObject only if it hasn't been instantiated before
        if (PlayerInstiate == null)
        {
            PlayerInstiate = Instantiate(Player, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.6f, 0), Quaternion.identity);
            PlayerInstiate.name = "UniqueName";


            ParticaleSystem pr = PlayerInstiate.GetComponent<ParticaleSystem>();
            pr.RunParticale(transform, transform);

            //Destroy Partical System
            StartCoroutine(DestroyPartical(pr));

            Transform[] Body = new Transform[PlayerInstiate.transform.childCount];
            for (global::System.Int32 i = 0; i < PlayerInstiate.transform.childCount; i++)
            {
                Body[i] = PlayerInstiate.transform.GetChild(i);
                Rigidbody2D rb = Body[i].GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f) * transform.position.x, Random.Range(-0.5f, 0.5f) * transform.position.y);
            }

            MySubscriber subscriber = new MySubscriber();
            MyEvent += subscriber.HandleEvent;

        }
        else
        {
            
            // Invoke the event passing the cloned GameObject
            MyEvent?.Invoke(PlayerInstiate);
            PlayerInstiate = Instantiate(Player, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.6f, 0), Quaternion.identity);
            PlayerInstiate.name = "UniqueName";

            ParticaleSystem pr = PlayerInstiate.GetComponent<ParticaleSystem>();
            pr.RunParticale(transform, transform);

            //Destroy Partical System
            StartCoroutine(DestroyPartical(pr));

            Transform[]Body = new Transform[PlayerInstiate.transform.childCount];
            for (global::System.Int32 i = 0; i < PlayerInstiate.transform.childCount; i++)
            {
                Body[i] = PlayerInstiate.transform.GetChild(i);
                Rigidbody2D rb = Body[i].GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f) * transform.position.x, Random.Range(-0.5f, 0.5f) * transform.position.y);
            }

            MySubscriber subscriber = new MySubscriber();
            MyEvent += subscriber.HandleEvent;
        }

    }
    void OnTouchDown()
    {
        if (!allowInput || countAttack <= 0)
            return;
        rb.velocity = new Vector3(rb.velocity.x * 0.2f, rb.velocity.y * 0.2f);
        startPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        startPoint.z = 15;
        SlowMotion();
        //Player.gameObject.SetActive(true);
        //PlayerFollow.FollowPlayer();
        isDragging = true;
        // game = Instantiate(Player, gameObject.transform.position, Quaternion.identity);
        if (PlayerInstiate == null)
        {
            PlayerInstiate = Instantiate(Player, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.6f, 0), Quaternion.identity);
            PlayerInstiate.name = "UniqueName";


            ParticaleSystem pr = PlayerInstiate.GetComponent<ParticaleSystem>();
            pr.RunParticale(transform, transform);

            //Destroy Partical System
            StartCoroutine(DestroyPartical(pr));

            Transform[] Body = new Transform[PlayerInstiate.transform.childCount];
            for (global::System.Int32 i = 0; i < PlayerInstiate.transform.childCount; i++)
            {
                Body[i] = PlayerInstiate.transform.GetChild(i);
                Rigidbody2D rb = Body[i].GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f) * transform.position.x, Random.Range(-0.5f, 0.5f) * transform.position.y);
            }

            MySubscriber subscriber = new MySubscriber();
            MyEvent += subscriber.HandleEvent;
        }
        else
        {

            // Invoke the event passing the cloned GameObject
            MyEvent?.Invoke(PlayerInstiate);
            PlayerInstiate = Instantiate(Player, new Vector3(transform.position.x - 0.5f, transform.position.y + 0.6f, 0), Quaternion.identity);
            PlayerInstiate.name = "UniqueName";

            ParticaleSystem pr = PlayerInstiate.GetComponent<ParticaleSystem>();
            pr.RunParticale(transform, transform);

            //Destroy Partical System
            StartCoroutine(DestroyPartical(pr));

            Transform[] Body = new Transform[PlayerInstiate.transform.childCount];
            for (global::System.Int32 i = 0; i < PlayerInstiate.transform.childCount; i++)
            {
                Body[i] = PlayerInstiate.transform.GetChild(i);
                Rigidbody2D rb = Body[i].GetComponent<Rigidbody2D>();
                rb.velocity = new Vector2(Random.Range(-0.5f, 0.5f) * transform.position.x, Random.Range(-0.5f, 0.5f) * transform.position.y);
            }

            MySubscriber subscriber = new MySubscriber();
            MyEvent += subscriber.HandleEvent;
        }
    }
    private void OnMouseDrag()
    {
        if (!allowInput || countAttack <= 0)
            return;
        Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        currentPoint.z = 15;
        tl.RenderLine();
        SlowMotion();
    }
    void OnTouchDrag()
    {
        if (!allowInput || countAttack <= 0)
            return;
        Vector3 currentPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        currentPoint.z = 15;
        tl.RenderLine();
        SlowMotion();
    }
    private void OnMouseUp()
    {
        if (!allowInput || countAttack <=0)
            return;
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 15;
        force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        rb.AddForce(force * power, ForceMode2D.Impulse);
        tl.EndLine();
        retSlowMotion();
        //Player.gameObject.gameObject.SetActive(false);
        countAttack--;
        //play clip 
        am.PlayClip(am.MovementEffect);

    }
    void OnTouchUp()
    {
        if (!allowInput || countAttack <= 0)
            return;
        endPoint = cam.ScreenToWorldPoint(Input.mousePosition);
        endPoint.z = 15;
        force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
        rb.AddForce(force * power, ForceMode2D.Impulse);
        tl.EndLine();
        retSlowMotion();
        //Player.gameObject.gameObject.SetActive(false);
        countAttack--;
        //play clip 
        am.PlayClip(am.MovementEffect);
    }
    void SlowMotion()
    {
        Time.timeScale = 0.2f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
        force = new Vector2(0, 0);
    }
    void retSlowMotion()
    {
        Time.timeScale = 1f;
        Time.fixedDeltaTime = Time.timeScale * 0.02f;
    }
    public void StopMovement()
    {
        allowInput = false;
        retSlowMotion();
        tl.EndLine();
    }
    private IEnumerator DestroyPartical(ParticaleSystem trash)
    {
        yield return new WaitForSeconds(2);
        Destroy(trash);
    }
}
using UnityEngine;
using System.Collections;

/// <summary>
/// This class controls player movement
/// </summary>

public class SimplePlatformController : MonoBehaviour
{

    [HideInInspector]
    public static bool facingRight = true;
    [HideInInspector]
    public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;
    public GameObject Camera;

    private bool grounded = false;
    private Animator anim;
    private Rigidbody2D rb2d;
    private SpawnManager gameController;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();


       
    }

    void Start()
    {
        GameObject gameControllerObject = GameObject.FindWithTag("GameController");
        if (gameControllerObject != null)
        {
            gameController = gameControllerObject.GetComponent<SpawnManager>();
        }
        if (gameController == null)
        {
            Debug.Log("Cannot find 'GameController' Script");
        }
    }

        // Update is called once per frame
        void Update()
    {
        CameraFollow();
        //Check if player is on the ground	
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));



        //If player already jumped then they cannot jump again
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }

        //Shoot
        if (Input.GetButtonDown("Fire1"))
        {
            anim.SetTrigger("Shoot");
        }



        transform.position = new Vector2(

Mathf.Clamp(transform.position.x, -7, 0),
transform.position.y


);
        /*
        rb2d.position = new Vector2(

    Mathf.Clamp(rb2d.position.x, -5, 0),
    rb2d.position.y


    );
        */



    }

    void FixedUpdate()
    {
        /*
        //Get direction of movement
        float v = Input.GetAxis("Vertical");

        //If player already jumped then they cannot jump again
        if (v > 0 && grounded)
        {
            jump = true;
        }
        */

        float h = Input.GetAxis("Horizontal");

        //Set animation speed to absolute(positive) direction of movement
        anim.SetFloat("Speed",Mathf.Abs(h));


        //If direction of movement times speed is less than the maximum speed of the player then continue to add force to the player
        if (h * rb2d.velocity.x < maxSpeed)
        {
            rb2d.AddForce(Vector2.right * h * moveForce);
        }

        //If direction of movement times speed is more than the maximum speed of the player then limit the velocity at maximum speed		
        if (Mathf.Abs(rb2d.velocity.x) > maxSpeed)
        {
            rb2d.velocity = new Vector2(Mathf.Sign(rb2d.velocity.x) * maxSpeed, rb2d.velocity.y);
        }

        if (h != 0)//Moving
        {
            anim.SetInteger("animState",1);//Play Run Anim



            //If moving right but not facing right then flip player to face right
            if (h > 0 && !facingRight)
            {

                Flip();
            }

            //If moving left but not facing left then flip player to face left
            else if (h < 0 && facingRight)
            {

                Flip();
            }
        }
        else if (h == 0)//Not Moving
        {
            anim.SetInteger("animState",0);//idle anim
        }

        //	If player pressed jump then play jump animation and addforce to the y axis (up) then set jump to false
        if (jump)   
        {
            anim.SetTrigger("Jump");
            rb2d.AddForce(new Vector2(0f, jumpForce));
            jump = false;
        }



    }

    //Change the direction the player is facing
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
    }

    void CameraFollow() {
        Camera.GetComponent<Transform>().position= transform.position;

    }

    void OnCollisionExit2D(Collision2D other)
    {
        
        if (other.gameObject.CompareTag("Enemy"))
        {
            //Debug.Log("Collision");
            gameController.lives--;
            Debug.Log(gameController.lives);
            gameController.UpdateLives();
 
            if (gameController.lives > 0)
            {

                GameObject player = gameObject;

                player.GetComponent<Transform>().position = new Vector2(-5, 0);

            }
            else if (gameController.lives <= 0)
            {
                gameController.lives = 0;
                gameController.UpdateLives();
                gameController.GameOver();

                anim.SetTrigger("Death");
            }
            // sound.Play();
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            gameController.lives--;
            gameController.UpdateLives();
           
            
            if (gameController.lives > 0)
            {

                GameObject player =gameObject;

                player.GetComponent<Transform>().position = new Vector2(-5, 0);

            }
            else if (gameController.lives <= 0)
            {
                gameController.lives = 0;
                gameController.UpdateLives();
                gameController.GameOver();
                anim.SetTrigger("Death");

            }
            // sound.Play();
        }
    }
}

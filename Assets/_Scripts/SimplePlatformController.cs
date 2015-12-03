using UnityEngine;
using System.Collections;

/// <summary>
/// This class controls player movement
/// </summary>

public class SimplePlatformController : MonoBehaviour
{

    [HideInInspector]
    public bool facingRight = true;
    [HideInInspector]
    public bool jump = true;

    public float moveForce = 365f;
    public float maxSpeed = 5f;
    public float jumpForce = 1000f;
    public Transform groundCheck;

    private bool grounded = false;
    //private Animator anim;
    private Rigidbody2D rb2d;


    // Use this for initialization
    void Awake()
    {
        //anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Check if player is on the ground	
        grounded = Physics2D.Linecast(transform.position, groundCheck.position, 1 << LayerMask.NameToLayer("Ground"));



        //If player already jumped then they cannot jump again
        if (Input.GetButtonDown("Jump") && grounded)
        {
            jump = true;
        }
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
        //anim.SetFloat("Speed",Mathf.Abs(h));


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
            //anim.SetInteger("animState",1);//Play Walk Anim
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
            //anim.SetInteger("animState",0);//idle anim
        }

        //	If player pressed jump then play jump animation and addforce to the y axis (up) then set jump to false
        if (jump)
        {
            //anim.SetTrigger("Jump");
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
}

using UnityEngine;
using System.Collections;

public class Boss : MonoBehaviour {



    // public Transform target;
    public float speed;

    private Transform _transform;
    private float _distanceFromTarget;
    bool targ_acquired = false;
    public GameObject target_pos;
    public GameObject reset_pos;
    private SpawnManager gameController;
    public AudioSource sound;
    public GameObject expl;
    private Animator anim;
    public int scoreValue;
    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        this._transform = gameObject.GetComponent<Transform>();
        // target_pos = new Vector2(200, 200);
        // reset_pos = new Vector2(-200, 200);

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
        //  this._distanceFromTarget = Vector2.Distance(this._transform.position, target_pos.GetComponent<Transform>().position);
        // this._transform.position = Vector2.MoveTowards(this._transform.position, target_pos.GetComponent<Transform>().position, this.speed);




        if (!targ_acquired)
        {
            this._distanceFromTarget = Vector2.Distance(this._transform.position, target_pos.GetComponent<Transform>().position);
            this._transform.position = Vector2.MoveTowards(this._transform.position, target_pos.GetComponent<Transform>().position, this.speed);
            if (this._distanceFromTarget < 1)
            {
                targ_acquired = true;
            }
            //targ_acquired = false;
            //target_pos = reset_pos;
            // reset_pos=target_pos ;
            // targ_acquired = false;
        }
        else if (targ_acquired)
        {
            this._distanceFromTarget = Vector2.Distance(this._transform.position, reset_pos.GetComponent<Transform>().position);
            this._transform.position = Vector2.MoveTowards(this._transform.position, reset_pos.GetComponent<Transform>().position, this.speed);
            if (this._distanceFromTarget < 1)
            {
                targ_acquired = false;
            }
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Robot"))
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
    }
}

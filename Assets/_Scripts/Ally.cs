using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Ally : MonoBehaviour {



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
    public Image starOne;
    public Image starTwo;

    public int scoreValue;
    // Use this for initialization
    void Start()
    {
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
       else if  (targ_acquired)
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
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
            Instantiate(expl, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            gameController.AddScore(scoreValue);
            starOne.enabled = false;
            starTwo.enabled = false;
            // sound.Play();
        }
        /*
        if (other.gameObject.CompareTag("Boss"))
        {
            BossLife--;
            Debug.Log(BossLife);
            Destroy(gameObject);


            gameController.AddScore(scoreValue);
            if (BossLife < 1)
            {

                Destroy(other.gameObject);
                Instantiate(expl, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
                gameController.setLevelComplete();
            }

        // sound.Play();
    }*/
}

}

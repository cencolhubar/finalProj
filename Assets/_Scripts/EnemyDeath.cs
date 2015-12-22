using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {
    public int scoreValue;
	public static int BossLife=10;
    private SpawnManager gameController;
    public AudioSource sound;
	public GameObject expl;
    public GameObject collect;
    // Use this for initialization
    void Start () {
        scoreValue = 1;
        //Gets a reference to GameController so the score can be updated and gameover can be called
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
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
           // sound.Play();
            Destroy(other.gameObject);
            Destroy(gameObject);
			Instantiate(expl, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            Instantiate(collect, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
            gameController.AddScore(scoreValue);

            // sound.Play();
        }
		
		        if (other.gameObject.CompareTag("Boss"))
        {BossLife--;
           Debug.Log(BossLife);
            Destroy(gameObject);
			

             gameController.AddScore(scoreValue);
if (BossLife <1)
{
	
	 
	 			Instantiate(expl, other.gameObject.GetComponent<Transform>().position, Quaternion.identity);
                sound.Play();
                gameController.setLevelComplete();
                Destroy(other.gameObject);
            }	

            // sound.Play();
        }
    }
}

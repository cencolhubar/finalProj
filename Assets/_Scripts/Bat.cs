using UnityEngine;
using System.Collections;

/// <summary>
/// This class defines the Bsts GameObject's behaviour
/// </summary>
public class Bat : MonoBehaviour {
    private SpawnManager gameController;
    public AudioSource sound;
    // Use this for initialization
    void Start () {
        //Gets a reference to game controller so the score can be updated 
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
        if (other.gameObject.CompareTag("Player"))
        {
            
            gameController.lives--;
            gameController.UpdateLives();
            if (gameController.lives > 0)
            {

                GameObject player = other.gameObject;

                player.GetComponent<Transform>().position = new Vector3(0, 10, 0);

            }
           else if (gameController.lives <= 0)
            {
               
                gameController.lives = 0;
                gameController.GameOver();


            }
            sound.Play();
        }
    }
}

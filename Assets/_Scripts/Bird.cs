using UnityEngine;
using System.Collections;
/// <summary>
/// This class defines the Bird GameObject's behaviour
/// </summary>
public class Bird : MonoBehaviour
{

    public int scoreValue;
    private SpawnManager gameController;
    public AudioSource sound;
    // Use this for initialization
    void Start()
    {
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
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if (other.gameObject.CompareTag("Player"))
        { Destroy(gameObject);
            
            
            gameController.AddScore(scoreValue);
          
sound.Play();
        }
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Collectible : MonoBehaviour {
    public int scoreValue;
    private SpawnManager gameController;
    public AudioSource sound;
    private static int StarCount=0;
    public Text starText;
    public GameObject ally;
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
        if (other.gameObject.CompareTag("Robot"))
        {

            StarCount++;
            starText.text = StarCount.ToString();
            if (StarCount%2 ==0)
            {
                Instantiate(ally, new Vector2(0, 0), Quaternion.identity);
            }
            Destroy(gameObject);


            gameController.AddScore(scoreValue);
            
           

gameController.lives++;
gameController.UpdateLives();
            sound.Play();



        }
    }
}

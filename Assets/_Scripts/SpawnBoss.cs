using UnityEngine;
using System.Collections;

public class SpawnBoss : MonoBehaviour {
	// Use this for initialization
	public GameObject Boss;
	public GameObject BossPos;
    private SpawnManager gameController;
    void Start () {

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
Instantiate(Boss, BossPos.GetComponent<Transform>().position, Quaternion.identity);
            gameController.setBossActive();
            Destroy(gameObject);
	}
}
}
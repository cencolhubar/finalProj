using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);

            // gameController.AddScore(scoreValue);

            // sound.Play();
        }
    }
}

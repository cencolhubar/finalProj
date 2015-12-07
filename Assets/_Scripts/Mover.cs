using UnityEngine;
using System.Collections;
/// <summary>
/// This class controls very simple ai movement for the birds and bats
/// </summary>
public class Mover : MonoBehaviour
{
    private Vector2 startPos;
    public float scrSpeed;
    private SpawnManager gameController;
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
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        float newPos = Time.deltaTime * scrSpeed;
        transform.Translate(Vector3.right * newPos);
        */
        float h = Input.GetAxis("Horizontal");

        if (h > 0 && !gameController.getBossActive())
        {
            
            float newPos = Time.deltaTime * scrSpeed;
            transform.Translate(Vector2.right * newPos);

        }
        if (gameObject.CompareTag("Enemy"))
            {
            float newPos = Time.deltaTime * scrSpeed;
            transform.Translate(Vector2.right * newPos);
        }

    }
    void FixedUpdate()
    {
        
  
        
    }
}

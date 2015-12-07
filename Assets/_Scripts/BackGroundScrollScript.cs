using UnityEngine;
using System.Collections;

/// <summary>
/// This class loops the background around the quad
/// </summary>

public class BackGroundScrollScript : MonoBehaviour {

    public float speed;
    public float x;
    private SpawnManager gameController;
    // Use this for initialization
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
        
        float h = Input.GetAxis("Horizontal");

        if (h > 0 && transform.position.x == 0&&!gameController.getBossActive())
        {
            x = Mathf.Repeat(Time.time * speed, 1);
            GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0));

        }
        
        /*
        x = Mathf.Repeat(Time.time * speed, 1);
        GetComponent<Renderer>().sharedMaterial.SetTextureOffset("_MainTex", new Vector2(x, 0));
*/
    }
}

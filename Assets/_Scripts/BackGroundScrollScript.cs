using UnityEngine;
using System.Collections;

/// <summary>
/// This class loops the background around the quad
/// </summary>

public class BackGroundScrollScript : MonoBehaviour {

    public float speed;
    public float x;

    // Use this for initialization
    void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        
        float h = Input.GetAxis("Horizontal");

        if (h > 0 && transform.position.x == 0)
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

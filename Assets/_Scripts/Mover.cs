using UnityEngine;
using System.Collections;
/// <summary>
/// This class controls very simple ai movement for the birds and bats
/// </summary>
public class Mover : MonoBehaviour
{
    private Vector2 startPos;
    public float scrSpeed;
    void Start()
    {
        startPos = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Time.deltaTime * scrSpeed;
        transform.Translate(Vector3.right * newPos);



    }
}

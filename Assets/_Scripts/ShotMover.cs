using UnityEngine;
using System.Collections;
/// <summary>
/// This class controls very simple ai movement for the shots
/// </summary>
public class ShotMover : MonoBehaviour
{
    private Vector2 startPos;
    public float scrSpeed;
    private GameObject robot;
    private Transform rtransform;
    private Vector3 dir;
    void Start()
    {
        startPos = transform.position;
        robot = GameObject.FindWithTag("Robot");
        rtransform = robot.GetComponent<Transform>();
        //Vector3 absvect = new Vector3(Math.Abs(transform.localScale.x), Math.Abs(transform.localScale.y), 0);
        Debug.Log(rtransform.localScale);

        if (rtransform.localScale.x > 0)
        {
            dir = Vector3.right;
        }
        else
        if (rtransform.localScale.x < 0)
        {
            dir = Vector3.left;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float newPos = Time.deltaTime * scrSpeed;
        transform.Translate(dir * newPos);



    }
}









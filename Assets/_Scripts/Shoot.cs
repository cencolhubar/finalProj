using UnityEngine;
using System.Collections;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, zMin, zMax;
}

public class Shoot : MonoBehaviour
{

    private Rigidbody rb;
    public float speed;
    public Boundary boundary;
    public AudioSource Acc;
    public AudioSource Fire;

    public GameObject shot;
    public Transform shotSpawn;

    public float fireRate;
    private float nextFire;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Acc = GetComponent<AudioSource>();
    }

    void Update()
    {
        //Accept input from space bar to fire shots
        if (Input.GetKeyDown(KeyCode.LeftControl)
            && Time.time > nextFire
            )
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            Fire.Play();


        }

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Acc.Play();
        }
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            Acc.Stop();
        }
    }






}


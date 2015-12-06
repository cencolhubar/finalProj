using UnityEngine;
using System.Collections;

public class Follow : MonoBehaviour {

    public Transform target;
    public float speed;

    private Transform _transform;
    private float _distanceFromTarget;
    // Use this for initialization
    void Start () {
        this._transform = gameObject.GetComponent<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
        this._distanceFromTarget = Vector2.Distance(this._transform.position, this.target.position);
        this._transform.position = Vector2.MoveTowards(this._transform.position, this.target.position, this.speed);
        /*
        if (this._distanceFromTarget < 10)
        {
            this._transform.position = Vector2.MoveTowards(this._transform.position, this.target.position,this.speed);
        }
        */
    }
}

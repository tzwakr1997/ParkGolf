using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallManagement : MonoBehaviour {
    public Rigidbody ballRB;
    private Vector3 speed;


	// Use this for initialization
	void Start () {
        ballRB = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
        speed = ballRB.velocity;
        //Debug.Log(speed.z);

        if (ballRB.IsSleeping()) {
            Debug.Log("stop");
        } else {
            Debug.Log("move");
        }

        //if (Mathf.Abs(speed.x) <= 0.1 && Mathf.Abs(speed.y) <= 0.1 && Mathf.Abs(speed.z) <= 0.1) {
        //    ballRB.velocity = Vector3.zero;
        //    Debug.Log("stop");
        //}
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PadController : MonoBehaviour {

    public Transform ball;
    public Transform cube;
    public GameObject impact;
    impact script;
    public float speed = 90.0f;

    private void Start() {
        script = impact.GetComponent<impact>();
    }


    // Update is called once per frame
    void Update() {
        int flagShift = script.flagShift;

        if (flagShift == 0) {
            if (Input.GetKey("right")) {
                Vector3 axis = transform.TransformDirection(Vector3.up);
                this.transform.RotateAround(ball.transform.position, axis, speed * Time.deltaTime);
            } else if (Input.GetKey("left")) {
                Vector3 axis = transform.TransformDirection(Vector3.down);
                this.transform.RotateAround(ball.transform.position, axis, speed * Time.deltaTime);
            }
        }
    }
}

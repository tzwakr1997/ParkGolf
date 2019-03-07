using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hit : MonoBehaviour {

    private int flg = 0;

    void shoot() {
        float speed = 1.0f;


        var dir = Vector3.zero;
        dir.x = Input.acceleration.x;

        if (dir.sqrMagnitude > 1) {
            dir.Normalize();
        }

        if (dir.x < 0) {
            dir.x *= -1;
        }


        transform.position += new Vector3(0, 0, speed);

    }

    void OnTriggerEnter(Collider col) {
        if (col.gameObject.tag == "GameController") {
            shoot();
        }
    }

    // Use this for initialization
    void Start()
    {
        Input.gyro.enabled = true;

        if (!SystemInfo.supportsGyroscope)
        {
            Destroy(this);
            return;
        }
    }
	
	// Update is called once per frame
	void Update () {
        Quaternion q = Input.gyro.attitude;

        q.x *= -1;

        if (q.x < -0.7 && -0.8 < q.x && flg == 0) {
            Debug.Log("aiueo");
            shoot();
            flg = 1;
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    public static bool goal;

	// Use this for initialization
	void Start () {
        goal = false;
	}
	
	// Update is called once per frame
	void OnTriggerEnter (Collider col) {
        if(col.gameObject.tag=="Player"){
            goal = true;
        }
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackCamera : MonoBehaviour {

    public Transform target;
    public float smoothing =  5f;
    private Vector3 offfset;

     void Start ()
    {
        offfset = transform.position - target.position;
    }
    
    void Update ()
    {
        Vector3 targetCamPos = target.position + offfset;
        transform.position = Vector3.Lerp(
            transform.position,
            targetCamPos,
            Time.deltaTime * smoothing);
    }
}

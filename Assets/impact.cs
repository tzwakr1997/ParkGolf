using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class impact : MonoBehaviour{

    public SphereCollider sc;
    public Rigidbody rb;
    public GameObject pad;
    public MeshRenderer arr;
    public GameObject Shift;
    public int flagMove = 0;
    public int flagShift = 0;
    private float directionY;
    public int hitCount = 0;
    public float vol;

    //オブジェクトが衝突したとき
    void OnCollisionEnter(Collision collision){

        if (collision.gameObject.tag == "force"){
            //Input.gyro.enabled = false;
            rb = this.GetComponent<Rigidbody>();
            arr = GameObject.Find("arrow").GetComponent<MeshRenderer>();
            //Vector3 force = new Vector3(pad.transform.forward.x * 10.0f, 0.0f, pad.transform.forward.z * 10.0f);  // 力を設定
            if(UseAudioVol.GetAveragedVolume()<=1){
                vol = 1;
            }else if(UseAudioVol.GetAveragedVolume()>1& UseAudioVol.GetAveragedVolume()<=2){
                vol = UseAudioVol.GetAveragedVolume();
            }else if(UseAudioVol.GetAveragedVolume()>2){
                vol = 2;
            }
            Vector3 force = pad.transform.forward * 10.0f *vol;
            rb.AddForce(force, ForceMode.Impulse);
            flagMove = 1;
            flagShift = 0;
            hitCount++;
        }
    }


    private void Start()
    {
        Input.gyro.enabled = true;
        if (!Input.gyro.enabled) {
            Destroy(this);
        }

        pad.transform.rotation = Quaternion.Euler(0, 90, 0);
        Vector3 tmp = this.transform.position;
        pad.transform.position = new Vector3(tmp.x - 0.18f, tmp.y + 0.8f, tmp.z);
    }

    private void Update()
    {
        if (Input.GetMouseButton(0)) {
            sc.enabled = true;
            rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
            arr.enabled = false;
        }

        if (Input.GetKey("left shift")) {
            if (flagShift == 0) {
                flagShift += 1;
                directionY = pad.transform.localEulerAngles.y;
            }
        }

        if (rb.IsSleeping()) {

            if (flagMove == 1) {
                //Debug.Log("fuck");
                flagMove = 0;
                flagShift = 0;
                rb.velocity = Vector3.zero;

                Vector3 tmp = this.transform.position;
                pad.transform.position = new Vector3(tmp.x + 0.18f, tmp.y + 0.8f, tmp.z);
                pad.transform.rotation = Quaternion.Euler(0, -90, 0);

                sc.enabled = false;
                rb = GetComponent<Rigidbody>();
                rb.useGravity = false;
                arr.enabled = true;
                //Input.gyro.enabled = true;
            }
          
        }

        if (Input.GetKey("s")) {
            pad.transform.rotation = Quaternion.Euler(0, 90, 0);
            Vector3 tmp = this.transform.position;
            pad.transform.position = new Vector3(tmp.x - 0.18f, tmp.y + 0.8f, tmp.z);
        }

        if (flagShift == 1) {
            Quaternion q = Input.gyro.attitude;

            q.x *= -1;
            q.y *= 0;
            q.z *= 0;

            pad.transform.rotation = q;
            //Debug.Log(directionY);
            pad.transform.Rotate(-90, 0, 0);
            Quaternion rot = Quaternion.AngleAxis(directionY, Vector3.up);
            pad.transform.localRotation = rot * pad.transform.localRotation;
        }
    }
}

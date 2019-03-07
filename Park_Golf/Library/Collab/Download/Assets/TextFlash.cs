using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextFlash : MonoBehaviour
{
    public GameObject impact;
    impact script;

    //public
    public float speed = 1.0f;
    public static bool key;
    public Rigidbody rbBall;
   

    //private
    private Text text;
    private Image image;
    private float time;
    private float flash = 0.5f;
    private int flag = 0;
    private enum ObjType
    {
        TEXT,
        IMAGE
    };
    private ObjType thisObjType = ObjType.TEXT;

    void Start()
    {
      
            //アタッチしてるオブジェクトを判別
            if (this.gameObject.GetComponent<Image>())
            {
                thisObjType = ObjType.IMAGE;
                image = this.gameObject.GetComponent<Image>();
            }
            else if (this.gameObject.GetComponent<Text>())
            {
                thisObjType = ObjType.TEXT;
                text = this.gameObject.GetComponent<Text>();
            }

        script = impact.GetComponent<impact>();
        
    }

    void Update()
    {
        //if(Input.GetKey("left shift"))
        //{
        //    flash = 0;
        //}

        //if (rbBall.IsSleeping())
        //{
        //    if (flag == 1) {
        //        flash = 0.5f;
        //        flag = 0;
        //    }
        //} else {
        //if (flag == 0) {
        //    flag++;
        //}
        //}

        //flash = 0.5f;

        int flagShift = script.flagShift;

        if (flagShift == 0 && rbBall.IsSleeping()) {
            flash = 0.5f;
        } else if (flagShift == 1) {
            flash = 0.0f;
        }
 

        //オブジェクトのAlpha値を更新
        if (thisObjType == ObjType.IMAGE)
            {
                image.color = GetAlphaColor(image.color, flash);
            }
            else if (thisObjType == ObjType.TEXT)
            {
                text.color = GetAlphaColor(text.color, flash);
            }
    }

    //Alpha値を更新してColorを返す
    Color GetAlphaColor(Color color, float a)
    {
            time += Time.deltaTime * 2.0f * speed;
            color.a = Mathf.Sin(time) * a + a;

            return color;
     
    }
}
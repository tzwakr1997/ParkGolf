using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseAudioVol : MonoBehaviour {

    static AudioSource audioSource;

    // Use this for initialization
    void Start () {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.clip = Microphone.Start(null, true, 999, 44100);  // マイクからのAudio-InをAudioSourceに流す
        audioSource.loop = true;                                      // ループ再生にしておく
        //audioSource.mute = true;                                      // マイクからの入力音なので音を流す必要がない
        while (!(Microphone.GetPosition("") > 0)) { }             // マイクが取れるまで待つ。空文字でデフォルトのマイクを探してくれる
        audioSource.Play();                                           // 再生する
    }
	
	// Update is called once per frame
	void Update () {
        //float vol = GetAveragedVolume() * 100;
        //int volume = (int) vol;
        //Debug.Log(volume);
        float vol = GetAveragedVolume();
        Debug.Log(vol);
    }

    public static float GetAveragedVolume()
    {
        float[] data = new float[256];
        float a = 0;
        audioSource.GetOutputData(data, 0);
        foreach (float s in data)
        {
            a += Mathf.Abs(s);
        }
        a = a / 256.0f * 1000;
        return a;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GoTitle : MonoBehaviour {

	// Update is called once per frame
    public void LoadingNewScene(){
        SceneManager.LoadScene("Title");
    }
}

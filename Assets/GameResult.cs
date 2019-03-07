using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResult : MonoBehaviour {

	// Update is called once per frame
	void Update () {
        if(Goal.goal == true){
            SceneManager.LoadScene("Result");
        }	
	}
}

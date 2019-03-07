using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {

    public Text GameResult;
    public int score;
    public GameObject ResultUi;

	// Update is called once per frame
	void Update () {
        if(Goal.goal == true){
            int result = Mathf.FloorToInt(Timer.time);
            score = result - (impact.hitCount) * (impact.hitCount);
            GameResult.text = "Your Score" + score;
        }
		
	}
}

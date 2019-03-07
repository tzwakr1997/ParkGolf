using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour{
    public static bool goal;

    private void Start(){
        goal = false;
    }

    void OnTriggerEnter(Collider col){
        if(col.gameObject.name=="ball"){
            goal = true;
            Debug.Log("goal");

        }
    }

    public void LoadingNewScene()
    {
        if (goal == true)
        {
            SceneManager.LoadScene("Result");
        }
    }
}


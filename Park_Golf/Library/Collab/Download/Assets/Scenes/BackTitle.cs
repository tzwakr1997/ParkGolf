﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackTitle : MonoBehaviour
{

    public void LoadingNewScene()
    {
        SceneManager.LoadScene("Title");

    }
}

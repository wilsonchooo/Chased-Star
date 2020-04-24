﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextScene : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadMainScreen());
    }

    IEnumerator LoadMainScreen()
    {
        yield return new WaitForSeconds(7f); 

        SceneManager.LoadScene("MainMenu");
    }
}

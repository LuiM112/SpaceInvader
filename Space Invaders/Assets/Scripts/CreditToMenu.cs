using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreditToMenu : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(WaitForSceneLoad());
    }
    

    private IEnumerator WaitForSceneLoad()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(0);
    }
    
}

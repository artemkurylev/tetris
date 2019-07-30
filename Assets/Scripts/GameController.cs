using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        while (!isGameOver)
        {
            StartCoroutine(SpawnFigures());
            isGameOver = true;
        }
    }

    IEnumerator SpawnFigures()
    {
        for(var f = 1.0; f>=0; f -= 0.1)
        {
            Debug.Log("Created Figure!\n");
            yield return new WaitForSeconds(5);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

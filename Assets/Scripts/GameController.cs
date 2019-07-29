using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour{

    private bool isGameOver = false;
    // Start is called before the first frame update
    void Start()
    {
        while (!isGameOver)
        {
            SpawnFigures();
        }
    }

    void SpawnFigures()
    {

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

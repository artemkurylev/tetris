using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    private bool isGameOver = false;
    private int count = 0;
    public Text mainScoreDisplay;
    public static GameController gc;
    // Start is called before the first frame update
    void Start()
    {
        if (gc == null)
            gc = this.gameObject.GetComponent<GameController>();
    }
    public void CalculateCount(int delta)
    {
        int result = 0;
        switch (delta)
        {
            case 1:
                result = 100;
                break;
            case 2:
                result = 400;
                break;
            case 3:
                result = 700;
                break;
            case 4:
                result = 1500;
                break;
        }
        UpdateCount(result);
    }
    void UpdateCount(int delta)
    {
        count += delta;
        mainScoreDisplay.text = count.ToString();
    }
    
    // Update is called once per frame
    void Update()
    {
        
    }
}

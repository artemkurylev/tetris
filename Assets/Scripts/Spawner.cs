﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] figures;


    public void Spawn()
    {
        int index = Random.Range(0, figures.Length - 1);
        Debug.Log(transform.position);
        Instantiate(figures[index], transform.position, Quaternion.identity);

    }
    // Start is called before the first frame update
    void Start()
    {
        Spawn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}

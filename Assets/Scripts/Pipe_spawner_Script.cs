using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pipe_spawner_Script : MonoBehaviour
{
    //SerializeField
    [SerializeField] private GameObject nebula;
    public float spawnRate = 2f;
    public float timer = 0.0f;



    //function
    private void spawnPipe()
    {
        Instantiate(nebula, transform.position, transform.rotation);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spawnPipe();
    }

    // Update is called once per frame
    void Update()
    {   
        //spawn rate for the time
        if (timer < spawnRate)
        {
            timer = timer + Time.deltaTime;
        }
        else
        {
            spawnPipe();
            timer = 0.0f;
        }
        
    }
}

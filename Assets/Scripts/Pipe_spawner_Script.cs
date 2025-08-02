using System;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Pipe_spawner_Script : MonoBehaviour
{
    //SerializeField
    [SerializeField] private GameObject nebula;

    //variables

    //spawnrate
    private float spawnRate1 = 1f;
    private float spawnRate2 = 3f;
    private float timer = 0.0f;

    //spawn at reandom distance at X
    private float spawnRangeX1 = 2f;
    private float spawnRangeX2 = 11f;
    private float spawnRangeY = -0.03f;
    private float spawnRangeZ = 0f;




    //functions

    //spawnPipe at random X
    private void spawnPipe()
    {
        float randomX = UnityEngine.Random.Range(spawnRangeX1, spawnRangeX2); //Always use unityengine before using random 
        Vector3 SpawnPosition = new Vector3(randomX, spawnRangeY, spawnRangeZ);
        Instantiate(nebula, SpawnPosition, transform.rotation);
    }
    //randomize spawn rate
    private float SpawnRate()
    {
        return UnityEngine.Random.Range(spawnRate1, spawnRate2);
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
        if (timer < SpawnRate())
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

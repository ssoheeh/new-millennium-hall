using System;
using UnityEngine;

public class WaveSpawner : MonoBehaviour
{

    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        System.Random randomObj = new System.Random();

        int randomValue = randomObj.Next(900);
        Vector3 v = new Vector3(transform.position.x + randomValue, 0f, transform.position.z + randomValue);
        Instantiate(prefab, v, transform.rotation);
    }
    void EndSpawner()
    {
        WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public GameObject prefab;
    public float startTime;
    public float endTime;
    public float spawnRate;

    // Start is called before the first frame update
    void Start()
    {
        //WavesManager.instance.AddWave(this);
        InvokeRepeating("Spawn", startTime, spawnRate);
        Invoke("EndSpawner", endTime);
    }

    void Spawn()
    {
        System.Random randomObj = new System.Random();

        int randomValue = randomObj.Next(-1500,1500);
        

        Vector3 v = new Vector3(transform.position.x + randomValue, transform.position.y, transform.position.z + randomValue);
        Instantiate(prefab, v, transform.rotation);
    }
    void EndSpawner()
    {
        //WavesManager.instance.RemoveWave(this);
        CancelInvoke();
    }
    // Update is called once per frame
    void Update()
    {

    }
}

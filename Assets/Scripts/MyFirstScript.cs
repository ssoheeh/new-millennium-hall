using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyFirstScript : MonoBehaviour

{

    public float speed = 0f;
    public int life = 3;
    public int colleague = 0;


    // Start is called before the first frame update
    void Start()
    {
        print("test Start");
    }

    // Update is called once per frame
    void Update()
    {
        print(speed);
        print(life);
        print(colleague);
    }
}

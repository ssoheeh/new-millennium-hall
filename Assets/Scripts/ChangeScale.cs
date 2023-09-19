using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScale : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            Transform parent = transform.parent;

            transform.parent = null;
            transform.localScale = new Vector3(30f, 30f, 30f);
            transform.parent = parent;
        }
        
    }
}

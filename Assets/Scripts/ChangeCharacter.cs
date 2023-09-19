using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCharacter : MonoBehaviour
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
            transform.localScale = new Vector3(400f, 400f, 400f);
            transform.parent = parent;
        }
        else
        {

            Transform parent = transform.parent;

            transform.parent = null;
            transform.localScale = new Vector3(220f, 220f, 220f);
            transform.parent = parent;
        }
    }
}

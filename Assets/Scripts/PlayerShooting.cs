using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShooting : MonoBehaviour
{
    public GameObject prefab;
    public GameObject shootPoint;
    public GameObject flame;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnFire(InputValue value)
    {
        if (value.isPressed)
        {
            GameObject clone = Instantiate(prefab);

            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;

        }
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 spot = GameObject.Find("Player").transform.position;
      
        flame.transform.position = new Vector3(spot.x, spot.y + 120, spot.z);

        /*if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            //Instantiate(prefab,transform.position, transform.rotation);
            GameObject clone = Instantiate(prefab);
            clone.transform.position = shootPoint.transform.position;
            clone.transform.rotation = shootPoint.transform.rotation;
        }*/

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleContack : MonoBehaviour
{
    public float damage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        Life life = collision.collider.GetComponent<Life>();

        if (life != null)
        {
            life.amount -= damage;
        }
        
    }
}

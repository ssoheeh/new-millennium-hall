using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContactDamager : MonoBehaviour
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

    void OnTriggerEnter(Collider other)
    {
        

        Life life = other.GetComponent<Life>();

        if (life != null)
        {
            life.amount -= damage;
        }
       
    }
}

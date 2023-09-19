using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyMovement : MonoBehaviour
{

	public float speed;

	

	void Start()
	{
		
	}

	// Update is called once per frame
	void Update()
	{
		transform.Translate(-speed * Time.deltaTime, 0, 0);

	


	}


}

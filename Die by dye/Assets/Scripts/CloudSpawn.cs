using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawn : MonoBehaviour {

	public GameObject cloudSpawn;

	private float timeBtwSpawn;
	public float startTimeBtwSpawn;
	float timer = 0f;
	float startSpawning = 140f;

	// Update is called once per frame
	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= startSpawning) 
		{
			if (timeBtwSpawn <= 0) 
			{
				Instantiate (cloudSpawn, transform.position, Quaternion.identity);
				timeBtwSpawn = startTimeBtwSpawn; 
			} 
			else 
			{
				timeBtwSpawn -= Time.deltaTime;
			}
		}

	}
}

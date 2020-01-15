using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawn : MonoBehaviour {

	public GameObject bossSpawn;

	private float timeBtwSpawn;
	public float startTimeBtwSpawn;
	float timer = 0f;
	float startSpawning = 90f;

	private void Update()
	{
		timer += Time.deltaTime;

		if (timer >= startSpawning) 
		{
			if (timeBtwSpawn <= 0) 
			{
				Instantiate (bossSpawn, transform.position, Quaternion.identity);
				timeBtwSpawn = startTimeBtwSpawn; //Wait x amount of seconds before another boss spawn in game
			} 
			else 
			{
				timeBtwSpawn -= Time.deltaTime;
			}
		}
	}
}

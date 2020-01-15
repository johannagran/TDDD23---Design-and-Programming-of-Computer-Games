using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] enemyPattern;
    private float timeBtwSpawn;
    public float startTimeBtwSpawn;
    public float decreaseTime;
    public float minTime = 3f;
	float timer = 0f;
	float startSpawning = 12f;

    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    private void Update()
    {
		timer += Time.deltaTime;

		if (timer >= startSpawning && player.curHealth > 0) 
		{
			if (timeBtwSpawn <= 0) 
			{
				int rand = Random.Range (0, enemyPattern.Length);
				Instantiate (enemyPattern [rand], transform.position, Quaternion.identity);
				timeBtwSpawn = startTimeBtwSpawn; //Wait x amount of seconds before another enemy spawn in game
			
				if (startTimeBtwSpawn > minTime) 
				{
					startTimeBtwSpawn -= decreaseTime; //Time between spawns will be a little bit smaller next time an enemy spawns
				}
			} 
			else 
			{
				timeBtwSpawn -= Time.deltaTime;
			}
		}
    }
}

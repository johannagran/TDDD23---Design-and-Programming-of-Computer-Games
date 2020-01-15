using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrail : MonoBehaviour {

    public GameObject[] Trail;
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
	private Player player;

    private void Update()
    {

		if (timeBtwSpawns <= 0)
        {
            int rand = Random.Range(0, Trail.Length);
            GameObject instance = (GameObject)Instantiate(Trail[rand], transform.position, Quaternion.identity);

			Destroy(instance, 18f);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }
    }
}

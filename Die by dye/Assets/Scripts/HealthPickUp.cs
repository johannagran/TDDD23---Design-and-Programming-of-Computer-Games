using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour {

    private Player player;

	public float timer;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();

    }

    // Update is called once per fwWrame
    void Update () {
		timer += Time.deltaTime;

		if (timer >= 10f) {;
			Destroy (gameObject);
		}
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            FindObjectOfType<AudioManager>().Play("HealthPickUp");
            player.playerTakeHealth(1);
            Destroy(gameObject);
        }
    }
}

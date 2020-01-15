using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerDownSlow : MonoBehaviour
{
    private Player player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

		if (collision.CompareTag ("Player")) {
			player.movementSpeed = 1f;
		} 
    }

	void OnTriggerExit2D(Collider2D other)
	{

		if (other.CompareTag ("Player")) {
			player.movementSpeed = 5f;

		} 
	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossController : MonoBehaviour {

	public int curHealth;
	public int damage2Player; 
	private float timeBtwDamage = 1.5f;
	private Player player;
	private int scorePoint = 100;

	public Transform endPoint;
	public float speed;
	private int current;
	public GameObject deathEffectG;
	public GameObject deathEffectB;
	public GameObject deathEffectO;
	public GameObject deathEffectP;
	public Slider healthBar;

	void Start()
	{
		player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
	}

	void Update () 
	{
		if(transform.position != endPoint.position)
		{
			Vector2 pos = Vector2.MoveTowards(transform.position, endPoint.position, speed* Time.deltaTime);
			GetComponent<Rigidbody2D>().MovePosition(pos);
		}

		if (transform.position == endPoint.position) 
		{
			Destroy(gameObject);
		}

		//Give the player some time to recover before taking anymore damage
		if (timeBtwDamage > 0) 
		{
			timeBtwDamage -= Time.deltaTime;
		}
		healthBar.value = curHealth;

        if (curHealth <= 0)
        {
            Instantiate(deathEffectG, transform.position, Quaternion.identity);
            Instantiate(deathEffectB, transform.position, Quaternion.identity);
            Instantiate(deathEffectO, transform.position, Quaternion.identity);
            Instantiate(deathEffectP, transform.position, Quaternion.identity);

			Destroy(gameObject);
            
            FindObjectOfType<WeaponSwitching>().rainbowWeapon();
            ScoreManager.scoreValue += scorePoint;
        }
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.CompareTag("Player"))
		{
			if (timeBtwDamage <= 0) 
			{
				player.playerTakeDamage(1);
			}
		}
	} 

	public void bossTakeDamage(int damage)
	{
		curHealth -= damage;
        FindObjectOfType<AudioManager>().Play("EnemyDeathSound");
    }
}

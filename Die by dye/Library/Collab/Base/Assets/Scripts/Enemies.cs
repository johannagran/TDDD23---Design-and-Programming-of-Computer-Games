using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{
    public float movementSpeed; //To control how fast the enemy chases the player
    public int health; //Enemy total health
    private Transform target; //Holds the gameObject the enemies are chasing
    private Player player;
    public float stopDistance;

    //Drop
    public bool HealthDrop;
    public GameObject HealthDropObject;
    private float dropRate = 0.2f;

    public GameObject deathEffect; //Ifall vi vill ha det
    private int scorePoint = 10;

    //Enemy following player
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {

        if (player != null)
        {
                //Enemy moving towards player
                if (Vector2.Distance(transform.position, target.position) > stopDistance)
            {
                transform.position = Vector2.MoveTowards(transform.position, target.position, movementSpeed * Time.deltaTime); //Move the enemies position towards the player position at a certain speed (from, to, speed). Time.deltaTime makes sure that the enemies won't run faster on a fast computer comparing to a slow
            }

        }
          
        //If the enemy takes damage, destroy object
        if (health <= 0)
        {
            //Death effect when enemy die
            Instantiate(deathEffect, transform.position, Quaternion.identity);

            if (Random.Range(0f, 2f) <= dropRate)
            {
                Instantiate(HealthDropObject, transform.position, Quaternion.identity);
            }
			//score points on death
            ScoreManager.scoreValue += scorePoint;
            Destroy(gameObject);
        }
    }

    //Health decrease system
    public void enemyTakeDamage(int damage)
    {
        health -= damage;
    }

    //Collider enters the trigger
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            player.playerTakeDamage(1);
        }
    }
}

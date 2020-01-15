using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

	public float speed; //Projectile speed
	public float lifeTime; //Of the projectile
	public float distance; //Distance for radian
	public int damage;
	public LayerMask whatIsSolid; //Linear mask to ignore sertain colliders

    public GameObject destroyEffect;

	// Use this for initialization
	private void Start () {
		Invoke ("DestroyProjectile", lifeTime);

	}

	// Update is called once per frame
	private void Update () {

		//Rays
		RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.right, distance, whatIsSolid);

		//Checks if the ray collides with anything and what it has collided with
		if(hitInfo.collider != null){
			//If the grey enemy get hits by a red projectile
			if (hitInfo.collider.CompareTag ("EnemyGreen")) {
				hitInfo.collider.GetComponent<Enemies>().enemyTakeDamage(damage); //If the projectile collides with an enemy, call the TakeDamage function
			}
			//If the yellow enemy get hits by a green projectile
			if (hitInfo.collider.CompareTag ("EnemyOrange")) {
				hitInfo.collider.GetComponent<Enemies>().enemyTakeDamage(damage); //If the projectile collides with an enemy, call the TakeDamage function
			}
			if (hitInfo.collider.CompareTag ("EnemyBlue")) {
				hitInfo.collider.GetComponent<Enemies>().enemyTakeDamage(damage); //If the projectile collides with an enemy, call the TakeDamage function
			}
			if (hitInfo.collider.CompareTag ("EnemyPurple")) {
				hitInfo.collider.GetComponent<Enemies>().enemyTakeDamage(damage); //If the projectile collides with an enemy, call the TakeDamage function
			}
			if(hitInfo.collider.CompareTag("Boss"))
			{
				hitInfo.collider.GetComponent<BossController>().bossTakeDamage(damage);
			}

			DestroyProjectile();
		}


		transform.Translate(Vector2.right * speed * Time.deltaTime); //Shoot in the right direction
		
	}

	void DestroyProjectile() {
		//Instantiate (destroyEffect, transform.position, Quaternion.identity); //Ifall vi vill ha en destry effekt
		Destroy (gameObject);
		
	}
}

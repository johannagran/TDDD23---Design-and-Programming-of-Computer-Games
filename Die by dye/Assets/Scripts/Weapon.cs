using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    

    public GameObject projectile;
    public Transform shotPoint;
    private Player player;

    //public Sprite weaponSprite;
    //public GameObject explosionEffect;

    private float timeBtwShots;
    public float startTimeBtwShots; //Change to set how often the player will be allowed to shoot projectiles
    public float offset; //Added to compensate if the weapon graphics doesnt point to mouse crusor

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if (player.curHealth > 0)
        {
            //Handles rotation of weapon
            Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position; //Direction = destination - origin
            float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg; //Rotate to face the crusor
            transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset); //Only rotation in z axis
        }

        if (timeBtwShots <= 0 && player.curHealth > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
				//Instantiate(explosionEffect, shotPoint.position, Quaternion.identity);
                Instantiate(projectile, shotPoint.position, transform.rotation);
                timeBtwShots = startTimeBtwShots;
            }
        }
        else
        {
            timeBtwShots -= Time.deltaTime;
        }
    }
		
}

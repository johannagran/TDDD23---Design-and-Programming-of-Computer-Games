using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GreenSpawn : MonoBehaviour {
	 
	public GameObject greenEnemy1;

	void Start () {

		Instantiate(greenEnemy1, transform.position, Quaternion.identity);

	}
}

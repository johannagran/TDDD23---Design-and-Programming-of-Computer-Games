using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cloudMove : MonoBehaviour {
	public Transform endPoint;
	public float speed;

	// Update is called once per frame
	void Update () {

		if(transform.position != endPoint.position)
		{
			Vector2 pos = Vector2.MoveTowards(transform.position, endPoint.position, speed* Time.deltaTime);
			GetComponent<Rigidbody2D>().MovePosition(pos);
		}

		if (transform.position == endPoint.position) 
		{
			Destroy(gameObject);
		}

	}
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public float speed = 10f;
	public float speedTurn = 0.0f;

	private Transform target;
	private int wavepointIndex = 0;

	void Start()
	{
		target = Waypoints.points [0];
		StartCoroutine(Movement());
	}

	void Update()
	{
		if(Vector3.Distance(transform.position, target.position)<=0.4f)
		{
			GetNextWaypoint();
		}
	}

	void GetNextWaypoint()
	{
		if (wavepointIndex >= Waypoints.points.Length - 1) 
		{
			Destroy(gameObject);
			return;
		}

		wavepointIndex++;
		target = Waypoints.points [wavepointIndex];
	}

	IEnumerator Movement()
	{
		while(true)
		{
			Vector3 dir = target.position - transform.position;
			Vector3 newDir = Vector3.RotateTowards(transform.forward, dir, speed*Time.deltaTime,speedTurn);
			transform.rotation = Quaternion.LookRotation(newDir);
			transform.Translate (dir.normalized * speed * Time.deltaTime, Space.World);
			yield return null;
		}

	}
		
}
